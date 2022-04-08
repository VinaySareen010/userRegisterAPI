using Assignment2_RegisterAndLogin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Models.Models
{
    public class ProductRating
    {
        public int Id { get; set; }
        public float Ratings { get; set; }
       
    }
}
