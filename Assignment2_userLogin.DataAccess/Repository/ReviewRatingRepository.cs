using Assignment2_userLogin.DataAccess.Repository.IRepository;
using Assignment2_userLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.DataAccess.Repository
{
     public class ReviewRatingRepository:Repository<ReviewRatingRepository>,IReviewRatingRepository
    {
        private readonly ApplicationDBContext _context;
        public ReviewRatingRepository(ApplicationDBContext context):base(context)
        {
            _context = context;
        }

    }
}
