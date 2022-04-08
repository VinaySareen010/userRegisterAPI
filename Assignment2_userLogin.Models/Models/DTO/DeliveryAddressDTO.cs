using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Models.Models.DTO
{
    public class DeliveryAddressDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public string NearBy { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public int PinCode { get; set; }
        public enum Option { Home, Work }
        public Option AddressType { get; set; }
    }
}
