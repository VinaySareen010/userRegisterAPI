
using Assignment2_RegisterAndLogin.Models;
using Assignment2_RegisterAndLogin.Models.DTO;
using Assignment2_RegisterAndLogin.Repository.IRepository;
using Assignment2_userLogin.DataAccess;
using Assignment2_userLogin.Utility.Services.IServices;
using AutoMapper;
using FluentEmail.Core;
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

        public IEnumerable<UserDTO> GetAllUser()
        {
            var userList = _unitOfWork.UserRepository.GetAll().Select(_mapper.Map<User,UserDTO>);
            return userList;
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
                var user = _unitOfWork.UserRepository.Login(userEmail, hpass);
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
            userInDb.RegisterDateTime = DateTime.Now;
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
        public UserDTO UniqueUserName(string userName)
        {
            var user = _unitOfWork.UserRepository.UserNameExist(userName);
            var userDto = _mapper.Map<User, UserDTO>(user);
            if (userDto == null)
                return null;
            return userDto;
        }
        public UserDTO UniqueEmail(string email)
        {
            var user = _unitOfWork.UserRepository.Exists(email);
            var userDto = _mapper.Map<User, UserDTO>(user);
            if (userDto == null)
                return null;
            return userDto;
        }
        public User GetUser(int id)
        {
            if (id == 0)
                return null;
            var userFromDb = _unitOfWork.UserRepository.GetById(id);
            if (userFromDb == null)
                return null;
            //var userDto = _mapper.Map<User, UserDTO>(userFromDb);
            //return userDto;
            return userFromDb;
        }
        public bool UpdateUser(UserDTO userDTO)
        {
            if (userDTO == null)
                return false;
            var userToUpdate = _mapper.Map<UserDTO, User>(userDTO);
            var userInDb = _unitOfWork.UserRepository.Update(userToUpdate);
            //var userInDb = _unitOfWork.UserRepository.Update(userDTO);
            return userInDb;
        }
        public bool UpdateUser(User userDTO)
        {
            if (userDTO == null)
                return false;
            //var userToUpdate = _mapper.Map<UserDTO, User>(userDTO);
            //var userInDb = _unitOfWork.UserRepository.Update(userToUpdate);
            var userInDb = _unitOfWork.UserRepository.Update(userDTO);
            return userInDb;
        }

        public User UniqueByEmail(string email)
        {
            var user = _unitOfWork.UserRepository.Exists(email);
            //var userDto = _mapper.Map<User, UserDTO>(user);
            if (user == null)
                return null;
            return user;
        }
    }
     
}
