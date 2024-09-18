using Service.RequestAndResponse.BaseResponse;
using Service.RequestAndResponse.Request.Rating;
using Service.RequestAndResponse.Response.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IRatingService
    {

        public Task<BaseResponse<RatingResponse>> AddRating(CreateRatingRequest createRating);
        public Task<BaseResponse<RatingResponse>> UpdateRatingAsync(UpdateRatingRequest updateRating);
        public Task<bool> DeleteRatingAsync(int ratingId);

        public Task<BaseResponse<IEnumerable<RatingResponse>>> GetRatingByProductId(int productId);
        public Task<BaseResponse<IEnumerable<RatingResponse>>> GetRatingByAccountId(string accountId);
        //public Task<Rating> GetRatingByUserIdAndProduct(string accountId, int productId)
    }
}
