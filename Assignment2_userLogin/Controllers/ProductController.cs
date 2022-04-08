using Assignment2_userLogin.Models.Models;
using Assignment2_userLogin.Models.Models.DTO;
using Assignment2_userLogin.Utility.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Controllers
{
    [Authorize]
    [Route("api/Product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }
        //[AllowAnonymous]
        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var productList = _productService.GetAllProducts();
            return Ok(productList);
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] ProductUpsertDTO productUpsertDTO)
        {
            if (productUpsertDTO == null)
                return BadRequest();
            //var webRootPath = _webHostEnvironment.ContentRootPath;  //Server Path Takes
            //var files = HttpContext.Request.Form.Files; //Design se image get
            //if (files.Count > 0)
            //{
            //    string fileName = Guid.NewGuid().ToString(); //Random Name Generate
            //    var uploads = Path.Combine(webRootPath, @"images/products"); //server store
            //    var extension = Path.GetExtension(files[0].FileName); //Store Extensions
            //    var final = Path.Combine(uploads, fileName + extension);
            //    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            //    {
            //        files[0].CopyTo(fileStream);
            //    }
            //    byte[] imageArray = System.IO.File.ReadAllBytes(final);
            //    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            //    productUpsertDTO.Image = $"data:{files[0].ContentType};base64,{base64ImageRepresentation}";
            //}
            var product = _productService.AddProduct(productUpsertDTO);
            return Ok(product);
        }
        [HttpPut("UpdateRating")]
        public IActionResult UpdateRating([FromBody]RatingVM ratingVM)
        {
            var productDetails = _productService.GetProduct(ratingVM.productID);
            var claculateproductRating = (productDetails.RatingAvg) + (ratingVM.RatingAvg);
            var productRatingToUpdate = claculateproductRating / 2;
            productDetails.RatingAvg = productRatingToUpdate;
            _productService.UpdateProduct(productDetails);
            return Ok();
        }
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody]Product productUpsertDTO) 
        {
            if (productUpsertDTO == null)
                return BadRequest();
            var productToUpdate = _productService.UpdateProduct(productUpsertDTO);
            return Ok(productToUpdate);
        }
        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();
            var productToDelete = _productService.DeleteProduct(id);
            return Ok(productToDelete);
        }
        [HttpGet("subCategoryId")]
        public IActionResult GetProductsBySubCategory(int subCategoryId)
        {
            if (subCategoryId == 0) 
                return BadRequest();
            var productList = _productService.GetProductsBySubCategory(subCategoryId);
            if (productList == null)
                return NotFound();
            return Ok(productList);
        }
        //[HttpGet("GetAllProductwithDetails")]
        //public IActionResult GetAllProductwithDetailsController()
        //{
        //    var productList = _productService.GetAllProductwithDetails();
        //    return Ok(productList);

        //}
        //[HttpGet("ProductFullDetails")]
        //public IActionResult ProductFullDetails()
        //{
        //    var productList = _productService.ProductFullDetails();
        //    return Ok(productList);
        //}
        //[HttpGet("GetProductRatingByProductId")]
        //public IActionResult GetProductRatingByProductId()
        //{
        //    var productList = _productService.GetProductRatingByProductId();
        //    return Ok(productList);
        //}
        
        
    }
}
