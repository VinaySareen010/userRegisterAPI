using Assignment2_userLogin.Models;
using Assignment2_userLogin.Models.Models;
using Assignment2_userLogin.Models.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assignment2_userLogin.Controllers
{
    [Route("api/ShoppingCart")]
    [ApiController]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public ShoppingCartController(ApplicationDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet("GetShoppingCartDetailsByProductId")]
        public IActionResult GetShoppingCartDetailsByUserId(int userId)
        {
            var cartList = _context.ShoppingCarts.Include(p=>p.Product).Where(x=>x.UserId==userId);
            return Ok(cartList);
        }
        [HttpPost("SaveItemInShoppingCart")]
        public IActionResult SaveItemInShoppingCart([FromBody]ShoppingCartDTO shoppingCartDTO)
        {
            var saveProduct = _mapper.Map<ShoppingCartDTO, ShoppingCart>(shoppingCartDTO);
            var productFromDB = _context.ShoppingCarts.AsNoTracking().Where(p=>p.UserId==saveProduct.UserId && p.ProductId==saveProduct.ProductId).ToList();
            if(productFromDB.Any())
            {
                saveProduct.Count = saveProduct.Count + productFromDB.Count;
                saveProduct.Id=productFromDB[0].Id;
                _context.Update(saveProduct);
            }
            else
            {
                _context.Add(saveProduct);
            }
             _context.SaveChanges();
            return Ok();
        }
        [HttpGet("GetAddressByUserId")]
        public IActionResult GetAddressByUserId(int userId)
        {
            var addressList = _context.DeliveryAddresses.Include(x=>x.User).Where(x => x.UserId == userId).ToList();
            return Ok(addressList);
        }
        [HttpPost("saveAddressByUserId")]
        public IActionResult saveAddress([FromBody] DeliveryAddressDTO DeliveryAddressDTO)
        {
            var saveProduct = _mapper.Map<DeliveryAddressDTO, DeliveryAddress>(DeliveryAddressDTO);
            var Data = _context.DeliveryAddresses.Add(saveProduct);
             _context.SaveChanges();
            return Ok(Data.Entity);
        }   
    }
}
