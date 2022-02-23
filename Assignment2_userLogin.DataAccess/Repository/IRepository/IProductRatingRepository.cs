using Assignment2_userLogin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.DataAccess.Repository.IRepository
{
    public interface IProductRatingRepository:IRepository<ProductRating>
    {
        //decimal GetProductRatingByProductId(int productId);
    }
}
