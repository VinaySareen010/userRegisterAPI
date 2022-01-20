
using Assignment2_RegisterAndLogin.Repository.IRepository;
using Assignment2_userLogin.DataAccess.Repository;
using Assignment2_userLogin.DataAccess.Repository.IRepository;
using Assignment2_userLogin.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_RegisterAndLogin.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private readonly AppSetting _appSetting;
        public UnitOfWork(ApplicationDBContext context,IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
            _context = context;
            UserRepository = new UserRepository(_context,appSetting);
            categoryRepository = new CategoryRepository(_context);
            subCategoryRepository = new SubCategoryRepository(_context);
            productImageRepository = new ProductImageRepository(_context);
            productRepository = new ProductRepository(_context);
            productRatingRepository = new ProductRatingRepository(_context);
            reviewsRepository = new ReviewsRepository(_context);
            reviewsCommentRepository = new ReviewsCommentRepository(_context);
        }
        public IUserRepository UserRepository { get; private set; }
        public ICategoryRepository categoryRepository { get;private set; }
        public ISubCategoryRepository subCategoryRepository { get;private set; }
        public IProductImageRepository productImageRepository { get; private set; }
        public IProductRepository productRepository { get; private set; }
        public IProductRatingRepository productRatingRepository { get; private set; }
        public IReviewsRepository reviewsRepository { get;private set; }
        public IReviewsCommentRepository reviewsCommentRepository { get; set; }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
