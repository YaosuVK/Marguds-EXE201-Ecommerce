﻿using BussinessObject.IdentityModel;
using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO : BaseDAO<Product>
    {
        private readonly MargudsContext _context;

        public ProductDAO(MargudsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllOrdersAsync()
        {
            return await _context.Products
           .Include(p => p.Category)
           .Include(p => p.ImageProducts)
           .Include(p => p.Ratings)
           .ToListAsync();

        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Set<Product>()
                .Where(p => p.Status == true)
                .Include(p => p.Category)
                .Include(p => p.ImageProducts)
                .Include(p => p.Ratings)
                .SingleOrDefaultAsync(p => p.ProductID == id);
        }

        public async Task<bool> DeleteTest(Product product)
        {
            product.Status = false;
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task<IEnumerable<Product>> ViewProductForHomePage()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ImageProducts)
                .Include(p => p.Ratings)
                .Where(p => p.Status == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string search = null, double? lowPrice = null, double? highPrice = null, int? category = null, string sortBy = null, int pageIndex = 1, int pageSize = 10)
        {
            IQueryable<Product> products = _context.Products
                .Include(p => p.ImageProducts)
                .Include(p => p.Category)
                .Include(p => p.Ratings);

            // Apply search
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.ToLower().Contains(search.ToLower()));
            }

            // Apply filters
            if (lowPrice.HasValue)
            {
                products = products.Where(p => p.PurchasePrice >= lowPrice.Value);
            }

            if (highPrice.HasValue)
            {
                products = products.Where(p => p.PurchasePrice <= highPrice.Value);
            }

            if (category.HasValue && category > 0)
            {
                products = products.Where(p => p.CategoryID == category);
            }

            // Apply default sorting
            products = products.OrderBy(p => p.Name);

            // Apply sorting based on sortBy parameter, if provided
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "price_asc":
                        products = products.OrderBy(p => p.PurchasePrice);
                        break;
                    case "price_desc":
                        products = products.OrderByDescending(p => p.PurchasePrice);
                        break;
                }
            }

            // Apply pagination
            var paginatedProducts = PaginatedList<Product>.Create(products, pageIndex, pageSize);

            // Execute the query and return the results as a list
            return paginatedProducts;
        }

        public async Task<IEnumerable<Product>> SearchProductAsync(string? search, int pageIndex, int pageSize)
        {
            IQueryable<Product> searchProducts = _context.Products
                .Include(p => p.ImageProducts)
                .Include(p => p.Category)
                .Include(p => p.Ratings);


            // Apply search
            if (!string.IsNullOrEmpty(search))
            {
                searchProducts = searchProducts.Where(p => p.Name.ToLower().Contains(search.ToLower()));
            }

            var result = PaginatedList<Product>.Create(searchProducts, pageIndex, pageSize).ToList();
            return result;
        }

        public int GetTotalPagesAsync(string search, List<Product> products, int pageSize)
        {
            var total = GetCountList(search);
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            if (pageSize <= 0)
            {
                throw new ArgumentException("Page size must be greater than 0", nameof(pageSize));
            }

            int totalPages = (int)Math.Ceiling(total / (double)pageSize);
            return totalPages;
        }
        public int GetCountList(string? search)
        {
            IQueryable<Product> searchProducts = _context.Products;
            // Apply search
            if (!string.IsNullOrEmpty(search))
            {
                searchProducts = searchProducts.Where(p => p.Name.ToLower().Contains(search.ToLower()));
            }

            var result = searchProducts.Count();
            return result;
        }
    }
}
