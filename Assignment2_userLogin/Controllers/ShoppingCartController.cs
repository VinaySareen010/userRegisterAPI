using Assignment2_userLogin.Models;
using Assignment2_userLogin.Models.Models;
using Assignment2_userLogin.Models.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        [HttpPost("SaveOrderDetails")]
        public IActionResult SaveOrderDetails([FromBody]OrderDetailsDto orderDetailsDto)
        {
            orderDetailsDto.OrderDate = DateTime.Now;
            orderDetailsDto.ShippingDate = DateTime.Now.AddDays(7);
            var orderDetail=_mapper.Map<OrderDetailsDto, OrderDetail>(orderDetailsDto);
            var saveOrder = _context.OrderDetails.Add(orderDetail); 
            _context.SaveChanges();
            
            return Ok(saveOrder.Entity);
        }
        [HttpPost("SaveFinalOrder")]
        public IActionResult SaveFinalOrder(int userId, [FromBody] List<FinalOrderDTO> finalOrderDTOs)
        {
            var finalOrders = _mapper.Map<List<FinalOrderDTO>, List<FinalOrder>>(finalOrderDTOs);
            _context.FinalOrders.AddRange(finalOrders);
            _context.SaveChanges();
            RemoveShopppingCart(userId);
            return Ok();
        }   
        [HttpDelete("RemoveShoppingCartData")]
        public IActionResult RemoveShoppingCartData(int shoppingCartId)
        {
            var result = _context.ShoppingCarts.Find(shoppingCartId);
            _context.ShoppingCarts.Remove(result);
            _context.SaveChanges();
            return Ok();
        }
        [NonAction]
        public IActionResult RemoveShopppingCart(int userId)
        {
            var results= _context.ShoppingCarts.Where(x => x.UserId == userId).ToList();
            _context.ShoppingCarts.RemoveRange(results);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("FinalOrderDeatils")]
        public IActionResult FinalOrderDeatils(int userId)
        {
            var finalOrderDeatils = _context.FinalOrders.Include(p => p.Product)
                .Include(xp => xp.OrderDetail.DeliveryAddress.User).Where(p => p.OrderDetail.DeliveryAddress.UserId == userId).ToList();
             
            return Ok(finalOrderDeatils);    
        }
        [HttpGet("OrderDeatils")]
        public IActionResult OrderDeatils(int userId)
        {
            var orderDetails = _context.OrderDetails.Include(x => x.DeliveryAddress)
                .Include(xp => xp.DeliveryAddress.User).FirstOrDefault(p => p.DeliveryAddress.UserId == userId);
            return Ok(orderDetails);
        }
        [HttpPost("SaveShoppingCartRange")]
        public IActionResult SaveShoppingCartRange(int userId,[FromBody] List<ShoppingCartDTO> shoppingCartDTO)
        {
            var finalOrders = _mapper.Map<List<ShoppingCartDTO>, List<ShoppingCart>>(shoppingCartDTO);
            _context.ShoppingCarts.AddRange(finalOrders);   
            _context.SaveChanges();
            return Ok();
        }
    }
}
