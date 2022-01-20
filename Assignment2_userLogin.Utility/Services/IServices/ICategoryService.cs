using Assignment2_userLogin.Models.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Utility.Services.IServices
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAllCategories();
        bool AddCategory(CategoryDTO categoryDTO);
        bool UpdateCategory(CategoryDTO categoryDTO);
        bool DeleteCategory(int id);
        CategoryDTO GetCategory(int id);
    }
}
