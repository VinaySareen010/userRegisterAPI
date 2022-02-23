using Assignment2_RegisterAndLogin.Models;
using Assignment2_userLogin.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_RegisterAndLogin.Repository.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        User Login(string userEmail, string password);
        User Register(User user);
        User Exists(string email);
        User UserNameExist(string userName);
    }
}
