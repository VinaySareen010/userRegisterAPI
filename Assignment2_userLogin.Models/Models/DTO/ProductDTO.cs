using Assignment2_RegisterAndLogin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Models.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float RatingAvg { get; set; }
        public int Price { get; set; }
        [ForeignKey("SubCategoryId")]
        public int SubCategoryId { get; set; }
    }
}
