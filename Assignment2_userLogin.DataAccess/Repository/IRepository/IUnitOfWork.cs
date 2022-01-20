using Assignment2_userLogin.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_RegisterAndLogin.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ICategoryRepository categoryRepository { get; }
        ISubCategoryRepository subCategoryRepository { get; }
        IProductImageRepository productImageRepository { get; }
        IProductRatingRepository productRatingRepository { get; }
        IProductRepository productRepository { get; }
        IReviewsRepository reviewsRepository { get; }
        IReviewsCommentRepository reviewsCommentRepository { get; }
    }
}
