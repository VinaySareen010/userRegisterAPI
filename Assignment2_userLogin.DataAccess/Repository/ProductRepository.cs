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
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsBySubCategory(int subCategoryId)
        {
            if (subCategoryId == 0)
                return null;
            var productList = _context.Products.Include(sc => sc.SubCategory).Where(sci => sci.SubCategoryId == subCategoryId).ToList();
            return productList;
        }
        //public float UpdateProductRatingByProductId(int productId, float rating)
        //{

        //}


        //public decimal GetProductRatingByProductId(int productId, float rating)
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
