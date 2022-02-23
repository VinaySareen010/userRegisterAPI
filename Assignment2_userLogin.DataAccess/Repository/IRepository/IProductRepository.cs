using Assignment2_userLogin.Models.Models;
using Assignment2_userLogin.Models.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.DataAccess.Repository.IRepository
{
    public interface IProductRepository:IRepository<Product>
    {
        IEnumerable<Product> GetProductsBySubCategory(int subCategoryId);
    }
}
