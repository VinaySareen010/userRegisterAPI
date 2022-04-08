using Assignment2_userLogin.DataAccess.Repository.IRepository;
using Assignment2_userLogin.Models;
using Assignment2_userLogin.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2_userLogin.DataAccess.Repository
{
    public class ProductRatingRepository:Repository<ProductRating>,IProductRatingRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRatingRepository(ApplicationDBContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<ProductUserReviewProductRating> GetProductRatingByProductId()
        {
            var ratingdata = _context.ProductUserReviewProductRatings.Include(r => r.ProductRating);/*.Where(r=>r.ProductRatingId== ProductRating.Id)*/

        //var ratingsum = ratingdata.sum(d => d.productrating.ratings);
        //var totalcount = ratingdata.count();
        //var finalrating = ratingsum / totalcount;
            return ratingdata;

        }
    }
}
