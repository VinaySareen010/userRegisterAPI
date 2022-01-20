using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_RegisterAndLogin.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public string Token { get; set; }
        public string Salt { get; set; }
       
    }
}
