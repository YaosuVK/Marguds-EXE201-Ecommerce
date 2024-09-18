using BussinessObject.Model;
using DataAccessLayer;
using Repository.BaseRepository;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ImageProductRepository : BaseRepository<ImageProduct>, IImageProductRepository
    {
        private readonly ImageProductDAO _imageProductDao;
        public ImageProductRepository(ImageProductDAO imageProductDao) : base(imageProductDao)
        {
            _imageProductDao = imageProductDao;
        }

        public async Task<IEnumerable<ImageProduct>> GetAllAsync()
        {
            return await _imageProductDao.GetAllAsync();
        }

        public async Task<ImageProduct> GetByIdAsync(int id)
        {
            return await _imageProductDao.GetByIdAsync(id);
        }

        public async Task<ImageProduct> AddAsync(ImageProduct entity)
        {
            return await _imageProductDao.AddAsync(entity);
        }

        public async Task<ImageProduct> UpdateAsync(ImageProduct entity)
        {
            return await _imageProductDao.UpdateAsync(entity);
        }

        public async Task<ImageProduct> DeleteAsync(ImageProduct entity)
        {
            return await _imageProductDao.DeleteAsync(entity);
        }


    }
}
