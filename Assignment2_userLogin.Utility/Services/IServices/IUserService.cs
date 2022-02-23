
using Assignment2_RegisterAndLogin.Models;
using Assignment2_RegisterAndLogin.Models.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.Utility.Services.IServices
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUser();
        UserDTO Login(string userEmail, string password);
        UserDTO Register(UserDTO userDTO);
        UserDTO UniqueUserName(string userName);
        UserDTO UniqueEmail(string email);
        User UniqueByEmail(string email);
        bool UpdateUser(User userDTO);
        User GetUser(int id);
        bool UpdateUser(UserDTO userDTO);
    }
}
