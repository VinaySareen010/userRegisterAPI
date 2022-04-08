using Assignment2_userLogin.DataAccess.Repository.IRepository;
using Assignment2_userLogin.Models;
using Assignment2_userLogin.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.DataAccess.Repository
{
     public class ProductUserReviewProductRatingRepository:Repository<ProductUserReviewProductRating>, IProductUserReviewProductRatingRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductUserReviewProductRatingRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<ProductUserReviewProductRating> ProductFullDetails()
        {
           var productDetails= _context.ProductUserReviewProductRatings.Include(p => p.Product).Include(d => d.ProductRating).ToList();
            return productDetails;
        }
        //public decimal GetProductRatingByProductId(int productId,float rating)
        //{
        //    var ratingData = _context.ProductUserReviewProductRatings.Include(r => r.ProductRating)
        //        .Where(p => p.ProductId == productId).ToList();
        //    var ratingSum = ratingData.Sum(d => d.ProductRating.Ratings);
        //    var TotalProductCount = ratingData.Count();
        //    var finalRating = ratingSum / TotalProductCount;
        //    return finalRating;
        //}
    }
}
