using Assignment2_RegisterAndLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_RegisterAndLogin.Repository.IRepository
{
    public interface IUserRepository
    {
        User Login(string userEmail, string password);
        User Register(User user);
        User Exists(string email);
    }
}
