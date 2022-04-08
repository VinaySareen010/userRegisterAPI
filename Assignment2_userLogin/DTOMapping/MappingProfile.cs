using Assignment2_RegisterAndLogin.Models;
using Assignment2_RegisterAndLogin.Models.DTO;
using Assignment2_RegisterAndLogin.Repository;
using Assignment2_RegisterAndLogin.Repository.IRepository;
using Assignment2_userLogin.Models;
using Assignment2_userLogin.Models.Models;
using Assignment2_userLogin.Models.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_RegisterAndLogin.DTOMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDTO>().ReverseMap();
            CreateMap<SubCategory, SubCategoryUpsertDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductUpsertDTO>().ReverseMap();
            CreateMap<ProductRating, ProductRatingDTO>().ReverseMap();
            CreateMap<Reviews, ReviewsDTO>().ReverseMap();
            CreateMap<ReviewsComment, ReviewsCommentDTO>().ReverseMap();
            CreateMap< ProductUserReviewProductRating, ProductUserReviewProductRatingDTO>().ReverseMap();
            CreateMap<ReviewRating, ReviewRating>().ReverseMap();
            CreateMap<ShoppingCartDTO, ShoppingCart>().ReverseMap();
            CreateMap<DeliveryAddressDTO, DeliveryAddress>().ReverseMap();      
        }
    }
}
