using Assignment2_userLogin.Models.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Utility.Services.IServices
{
    public interface ISubCategoryService
    {
        IEnumerable<SubCategoryDTO> GetAllSubCategories();
        IEnumerable<SubCategoryDTO> GetSubCategoriesByCategory(int categoryId);
        bool AddSubCategory(SubCategoryUpsertDTO subCategoryUpsertDTO);
        bool UpdateSubCategory(SubCategoryUpsertDTO subCategoryUpsertDTO);
        bool DeleteSubCategory(int id);
        SubCategoryDTO GetSubCategory(int id);
    }
}
