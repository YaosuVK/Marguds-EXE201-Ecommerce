using BussinessObject.Model;
using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Product;
using Service.RequestAndResponse.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IProductService
    {

        Task<BaseResponse<GetProductDetailsResponse>> GetProductDetailByIdFromBase(int id);
        Task<BaseResponse<IEnumerable<GetAllProductsForManagerResponse>>> GetAllProductsFromBase();
        Task<BaseResponse<GetProductDetailForHP>> GetProductByIdFromBase(int id);
        Task<BaseResponse<AddProductRequest>> AddProductByIdFromBase(AddProductRequest request);
        Task<Boolean> DeleteTest(int id);
        Task<BaseResponse<UpdateProductRequest>> UpdateProductFromBase(int id, UpdateProductRequest product);
        Task<BaseResponse<IEnumerable<GetFilterProductResponse>>> GetProductsAsync(string? search, double? lowPrice, double? highPrice, int? category, string sortBy, int pageIndex, int pageSize);
        /*Task<BaseResponse<List<GetTopProductSoldInAMonth>>> GetTopProductsSoldInMonthAsync(int top);*/
        Task<BaseResponse<SearchProductResponse>> SearchProductAsync(string? search, int pageIndex, int pageSize);
        int GetTotalPagesAsync(string search, List<Product> products, int pageSize);
    }
}
