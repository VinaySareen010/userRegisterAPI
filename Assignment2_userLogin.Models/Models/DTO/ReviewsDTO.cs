using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Models.Models.DTO
{
    public class ReviewsDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ReviewsommentId { get; set; }
        [ForeignKey("ReviewsommentId")]
        public ReviewsCommentDTO ReviewsComment { get; set; }
    }
}
