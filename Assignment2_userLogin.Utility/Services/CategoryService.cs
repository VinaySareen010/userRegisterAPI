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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool AddCategory(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                return false;
            var saveCategory = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            if (!_unitOfWork.categoryRepository.Save(saveCategory))
                return false;
            else
                return true;
        }
        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            var categoryDTO = _unitOfWork.categoryRepository.GetAll().Select(_mapper.Map<Category, CategoryDTO>);
            return categoryDTO;
        }







        public CategoryDTO GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
        public bool DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
