using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Models.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory SubCategory { get; set; }
        public int ProductImageId { get; set; }
        [ForeignKey("ProductImageId")]
        public ProductImage ProductImage { get; set; }
        public int ReviewsId { get; set; }
        [ForeignKey("ReviewsId")]
        public Reviews Reviews { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int ProductRatingId { get; set; }
        [ForeignKey("ProductRatingId")]
        public ProductRating ProductRating { get; set; }
    }
}
