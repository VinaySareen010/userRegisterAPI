using Assignment2_userLogin.Models.Models.DTO;
using Assignment2_userLogin.Utility.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetAllCategory()
        {
            var category = _categoryService.GetAllCategories();
            if (category == null)
                return BadRequest();
            return Ok(category);
        }
        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null && !ModelState.IsValid)
                return BadRequest();
            var data = _categoryService.AddCategory(categoryDTO);
            return Ok(data);
        }
    }
}
