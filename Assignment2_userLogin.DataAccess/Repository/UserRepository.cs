using Assignment2_RegisterAndLogin.Models;
using Assignment2_RegisterAndLogin.Repository.IRepository;
using Assignment2_userLogin.DataAccess.Repository;
using Assignment2_userLogin.Models;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment2_RegisterAndLogin.Repository
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        private readonly ApplicationDBContext _context;

        private readonly AppSetting _appSetting;
        public UserRepository(ApplicationDBContext context, IOptions<AppSetting> appSetting):base(context)
        {
            _context = context;
            _appSetting = appSetting.Value;
        }

        public User Login(string userEmail, string password)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == userEmail && u.Password == password);
            if (userInDb == null)
                return null;
            userInDb.Token = GenrateJwtToken(userInDb.UserName, userInDb.Email);
            userInDb.Password = "";
            return userInDb;
        }

        public User Register(User user)
        {
            User objuser = new User()
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                RegisterDateTime = DateTime.Now,
                Image = user.Image,
                Salt = user.Salt

            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public string GenrateJwtToken(string name, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,name),
                    new Claim(ClaimTypes.Email,email)
                }),
                Expires = DateTime.UtcNow.AddHours(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescritor);
            return tokenHandler.WriteToken(token);

        }
        public User UserNameExist(string userName)
        {
            var userfromDb = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (userfromDb == null)
                return null;
            return userfromDb;
        }

        public User Exists(string email)
        {
            var userfromDb = _context.Users.FirstOrDefault(u => u.Email == email);
            if (userfromDb == null)
                return null;
            return userfromDb;

        }
        
    }
}