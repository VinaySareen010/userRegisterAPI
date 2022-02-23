using Assignment2_userLogin.Models.Models.DTO;
using Assignment2_userLogin.Utility.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Controllers
{
    [Route("api/SubCategory")]
    [ApiController]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }
        [HttpGet]
        public IActionResult GetAllSubCategories()
        {
            var subCategories = _subCategoryService.GetAllSubCategories();
            return Ok(subCategories);
        }
        [HttpGet("categoryId")]
        public IActionResult SubCategoiesByCategory(int categoryId)
        {
            if (categoryId == 0)
                return BadRequest();
            var subCategory = _subCategoryService.GetSubCategoriesByCategory(categoryId);
            if (subCategory == null)
                return NotFound();
            return Ok(subCategory);
        }
        [HttpPost]
        public IActionResult AddSubCategory([FromBody]SubCategoryUpsertDTO SCDto)
        {
            if (SCDto == null)
                return BadRequest();
            var subCategorysave = _subCategoryService.AddSubCategory(SCDto);
            return Ok(subCategorysave);
        }
    }
}
