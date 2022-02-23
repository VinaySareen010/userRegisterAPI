using Assignment2_userLogin.DataAccess.Repository.IRepository;
using Assignment2_userLogin.Models;
using Assignment2_userLogin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.DataAccess.Repository
{
    public class ReviewsRepository:Repository<Reviews>,IReviewsRepository
    {
        private readonly ApplicationDBContext _context;
        public ReviewsRepository(ApplicationDBContext context):base(context)
        {
            _context = context;
        }

        //public IEnumerable<Reviews> GetAllReviewsBYProductId(int productId)
        //{
        //    var reviewList = _context.Reviews.Where(rp => rp.ProductId == productId).ToList();
        //    return reviewList;
        //}
    }
}
