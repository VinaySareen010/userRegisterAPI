using Assignment2_RegisterAndLogin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Models.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public double OrderTotal { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionId { get; set; }
        public int DeliveryAddressId { get; set; }
        [ForeignKey("DeliveryAddressId")]
        public DeliveryAddress DeliveryAddress { get; set; }
    }
}

    