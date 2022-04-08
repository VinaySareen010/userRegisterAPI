using Assignment2_userLogin.Models.Models;
using Assignment2_userLogin.Models.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Utility.Services.IServices
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        Product GetProduct(int id);
        IEnumerable<ProductDTO> GetProductsBySubCategory(int subCategoryId);
        IEnumerable<ReviewsCommentDTO> GetAllReviewCommentsBYProductId(int reviewId);
        bool AddProduct(ProductUpsertDTO productUpsertDTO);
        bool UpdateProduct(Product productUpsertDTO);
        bool DeleteProduct(int id);
        //decimal GetProductRatingByProductId(int productId, float rating);
        //IEnumerable<ProductUserReviewProductRatingDTO> GetAllProductWithRewies(int productid);
        //IEnumerable<ProductUserReviewProductRating> GetProductRatingByProductId();
        //IEnumerable<ProductUserReviewProductRatingDTO> GetAllProductwithDetails();
        //IEnumerable<ProductUserReviewProductRatingDTO> ProductFullDetails();
    }
}
