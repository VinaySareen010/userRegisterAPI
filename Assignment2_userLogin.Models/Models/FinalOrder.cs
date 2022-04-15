using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Models.Models
{
    public class FinalOrder
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        [ForeignKey("OrderDetailsId")]
        public OrderDetail OrderDetail { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Count { get; set; }
        public int TotalPrice { get; set; }
    }
}
