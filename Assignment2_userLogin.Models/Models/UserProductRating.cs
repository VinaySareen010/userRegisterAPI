using Assignment2_RegisterAndLogin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Models.Models
{
    public class UserProductRating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int ProductRatingId { get; set; }
        [ForeignKey("ProductRatingId")]
        public ProductRating ProductRating { get; set; }
        public int ReviewsId { get; set; }
        [ForeignKey("ReviewsId")]
        public Reviews Reviews { get; set; }

    }
}
