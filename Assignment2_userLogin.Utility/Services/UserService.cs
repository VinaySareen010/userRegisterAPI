
using Assignment2_RegisterAndLogin.Models;
using Assignment2_RegisterAndLogin.Models.DTO;
using Assignment2_RegisterAndLogin.Repository.IRepository;
using Assignment2_userLogin.DataAccess;
using Assignment2_userLogin.Utility.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Utility.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public UserDTO Login(string userEmail, string password)
        {
            if (userEmail == null && password == null)
                return null;
            var userinDB = _unitOfWork.UserRepository.Exists(userEmail);
            if (userinDB != null)
            {
                var salt = userinDB.Salt;
                var hpass = userinDB.Password;
                var success = HashingPassword.VerifyHash(password, salt, hpass);
                if (!success)
                    return null;
                var user = _unitOfWork.UserRepository.Login(userEmail, password);

                var userDto = _mapper.Map<User, UserDTO>(user);
                return userDto;
            }
            else
                return null;
        }

        public UserDTO Register([FromBody]UserDTO userDTO)
        {
            if (userDTO == null)
                return null;
            var salt = HashingPassword.CreateSalt();
            
            var hash= HashingPassword.CreateHash(userDTO.Password, salt);
            userDTO.Password = hash;
            var userInDb = _mapper.Map<UserDTO, User>(userDTO);
            userInDb.Salt = salt;
            var user= _unitOfWork.UserRepository.Register(userInDb);
            
            UserDTO user1 = new UserDTO()
            {
                Id=user.Id,
                UserName = user.UserName,
                Email=user.Email,
                Password=user.Password,
                RegisterDateTime=user.RegisterDateTime,
                Image=user.Image,
                Salt=user.Salt
            };
            user1.Password = "";
            return user1;
        }
    }
     
}
