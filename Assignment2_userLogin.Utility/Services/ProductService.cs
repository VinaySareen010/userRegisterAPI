using Assignment2_RegisterAndLogin.Repository.IRepository;
using Assignment2_userLogin.Models.Models;
using Assignment2_userLogin.Models.Models.DTO;
using Assignment2_userLogin.Utility.Services.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Utility.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool AddProduct(ProductUpsertDTO productUpsertDTO)
        {
            if (productUpsertDTO == null)
                return false;
            var saveProduct = _mapper.Map<ProductUpsertDTO, Product>(productUpsertDTO);
            if (!_unitOfWork.productRepository.Save(saveProduct))
                return false;
            return true;
        }
        public bool UpdateProduct(ProductUpsertDTO productUpsertDTO)
        {
            if (productUpsertDTO == null)
                return false;
            var productToUpdate = _mapper.Map<ProductUpsertDTO, Product>(productUpsertDTO);
            if (!_unitOfWork.productRepository.Update(productToUpdate))
                return false;
            return true;
        }
        public bool DeleteProduct(int id)
        {
            if (id == 0)
                return false;
            var productInDb = _unitOfWork.productRepository.GetById(id);
            if (!_unitOfWork.productRepository.Delete(productInDb))
                return false;
            return true;
        }
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var productsInDB = _unitOfWork.productRepository.GetAll().Select(_mapper.Map<Product, ProductDTO>);
            return productsInDB;
        }
        public IEnumerable<ProductDTO> GetProductsBySubCategory(int subCategoryId)
        {
            if (subCategoryId == 0)
                return null;
            var productsInDb = _unitOfWork.productRepository
                .GetProductsBySubCategory(subCategoryId).Select(_mapper.Map<Product, ProductDTO>);
            if (productsInDb == null)
                return null;
            return productsInDb;
        }
        public IEnumerable<ProductUserReviewProductRatingDTO> GetAllProductwithDetails()
        {
            var ProductDetails = _unitOfWork.productUserReviewProductRatingRepository.GetAll(includeProperties: "Product,Reviews,ReviewsComment").Select(_mapper.Map<ProductUserReviewProductRating, ProductUserReviewProductRatingDTO>);
            return ProductDetails;
        }
        public IEnumerable<ProductUserReviewProductRatingDTO> GetAllProductWithRewies(int productid)
        {
            var ProductDetails = _unitOfWork.productUserReviewProductRatingRepository.GetAll(p => p.ProductId == productid, includeProperties: "Product,Reviews,ProductRating").Select(_mapper.Map<ProductUserReviewProductRating, ProductUserReviewProductRatingDTO>);
            return ProductDetails;
        }
        public IEnumerable<ReviewsCommentDTO> GetAllReviewCommentsBYProductId(int reviewId)
        {
            throw new NotImplementedException();
        }
       
        public ProductDTO GetProduct(int id)
        {
            throw new NotImplementedException();
        }
        
        //public decimal GetProductRatingByProductId(int productId)
        //{
        //   var productRating=_unitOfWork.productUserReviewProductRatingRepository.GetAll(prid=>prid.ProductId==productId,includeProperties:"ProductRating").ToList();
        //    var rating = productRating.Sum(d => d.ProductRating.Ratings);
        //    var finalRating=  
        //}

    }
}
