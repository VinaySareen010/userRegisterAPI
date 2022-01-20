﻿using Assignment2_userLogin.DataAccess.Repository.IRepository;
using Assignment2_userLogin.Models;
using Assignment2_userLogin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.DataAccess.Repository
{
    public class ProductImageRepository:Repository<ProductImage>,IProductImageRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductImageRepository(ApplicationDBContext context):base(context)
        {
            _context = context;
        }
    }
}