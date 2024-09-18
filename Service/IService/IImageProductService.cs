using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Response.ImageProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IImageProductService
    {
        Task<BaseResponse<IEnumerable<GetAllImageProductsResponse>>> GetAllImageProductsFromBase();

    }
}
