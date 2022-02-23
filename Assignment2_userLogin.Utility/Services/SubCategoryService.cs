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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool AddSubCategory(SubCategoryUpsertDTO subCategoryUpsertDTO)
        {
            if (subCategoryUpsertDTO == null)
                return false;
            var subCategory = _mapper.Map<SubCategoryUpsertDTO, SubCategory>(subCategoryUpsertDTO);
            if (!_unitOfWork.subCategoryRepository.Save(subCategory))
                return false;
            return true;
        }

        public bool DeleteSubCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubCategoryDTO> GetAllSubCategories()
        {
            var subCategoryDTO = _unitOfWork.subCategoryRepository
                .GetAll().Select(_mapper.Map<SubCategory, SubCategoryDTO>);
            return subCategoryDTO;
        }

        public IEnumerable<SubCategoryDTO> GetSubCategoriesByCategory(int categoryId)
        {
            if (categoryId == 0)
                return null;
            var subCategoryInDb = _unitOfWork.subCategoryRepository
                .GetSubCategoryByCategory(categoryId).Select(_mapper.Map<SubCategory, SubCategoryDTO>);
            if (subCategoryInDb == null)
                return null;
            return subCategoryInDb;
        }

        public SubCategoryDTO GetSubCategory(int id)
        {
            throw new NotImplementedException();
        }

        //public SubCategoryDTO GetSubCategory(int id)
        //{
        //    var subCategory = _unitOfWork.subCategoryRepository.FirstOrDefault(includes: "Category");
        //   // _unitOfWork.categoryRepository.FirstOrDefault(t => t.Id == id);
        //    throw new NotImplementedException();
        //}
        public bool UpdateSubCategory(SubCategoryUpsertDTO subCategoryUpsertDTO)
        {
            throw new NotImplementedException();
        }
    }
}
