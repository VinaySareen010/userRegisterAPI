using Assignment2_RegisterAndLogin.Models;
using Assignment2_userLogin.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<ReviewsComment> ReviewsComments { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<ProductUserReviewProductRating> ProductUserReviewProductRatings { get; set; }
        public DbSet<ReviewRating> ReviewRatings { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<FinalOrder> FinalOrders { get; set; }
    }
}
