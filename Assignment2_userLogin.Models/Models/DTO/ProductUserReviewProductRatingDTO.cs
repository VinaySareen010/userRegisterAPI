using Assignment2_RegisterAndLogin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Models.Models.DTO
{
    public class ProductUserReviewProductRatingDTO
    {
       // public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int UserId { get; set; }
        public int ProductRatingId { get; set; }
        [ForeignKey("ProductRatingId")]
        public ProductRating ProductRating { get; set; }
        public int ReviewsId { get; set; }
        [ForeignKey("ReviewsId")]
        public Reviews Reviews { get; set; }
        public int ReviewsCommentId { get; set; }
        [ForeignKey("ReviewsCommentId")]
        public ReviewsComment ReviewsComment { get; set; }
        public int ReviewRatingId { get; set; }
        [ForeignKey("ReviewRatingId")]
        public ReviewRating ReviewRating { get; set; }
    }
}
