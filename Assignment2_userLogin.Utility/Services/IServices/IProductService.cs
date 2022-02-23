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
        //IEnumerable<ProductUserReviewProductRatingDTO> GetAllProductWithRewies(int productid);
        IEnumerable<ProductUserReviewProductRatingDTO> GetAllProductwithDetails();
        ProductDTO GetProduct(int id);
        IEnumerable<ProductDTO> GetProductsBySubCategory(int subCategoryId);
       // decimal GetProductRatingByProductId(int productId);
        IEnumerable<ReviewsCommentDTO> GetAllReviewCommentsBYProductId(int reviewId);
        
        bool AddProduct(ProductUpsertDTO productUpsertDTO);
        bool UpdateProduct(ProductUpsertDTO productUpsertDTO);
        bool DeleteProduct(int id);
    }
}
