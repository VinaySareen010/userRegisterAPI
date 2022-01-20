
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
        UserDTO Login(string userEmail, string password);
        UserDTO Register(UserDTO userDTO);
    }
}
