using Assignment2_userLogin.DataAccess.Repository.IRepository;
using Assignment2_userLogin.Models;
using Assignment2_userLogin.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.DataAccess.Repository
{
    public class SubCategoryRepository:Repository<SubCategory>,ISubCategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public SubCategoryRepository(ApplicationDBContext context):base(context)
        {
            _context = context;
        }

        public ICollection<SubCategory> GetSubCategoryByCategory(int categoryId)
        {
            var data= _context.SubCategories.Include(c => c.Category).Where(ci => ci.CategoryId == categoryId).ToList();
            return data;
        }
    }
}
