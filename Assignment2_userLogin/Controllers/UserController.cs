
using Assignment2_RegisterAndLogin.Models;
using Assignment2_RegisterAndLogin.Models.DTO;
using Assignment2_userLogin.Utility;
using Assignment2_userLogin.Utility.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;


namespace Assignment2_UserLogin.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmailSender _emailSender;
        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment, IEmailSender emailSender)
        {
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
            _emailSender = emailSender;
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUser());
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] AuthenticateVM authenticateVM)
        {
            if (authenticateVM == null)
                return BadRequest("Please fill the required fields");
            var userByEmail = _userService.UniqueByEmail(authenticateVM.Email);
            if (userByEmail == null)
                return NotFound();
            else
            {
                //var Count = userByEmail.count;
                //HttpContext.Session.SetInt32("CountValue", Count);
                if (userByEmail.LockOutDateTime <= DateTime.Now)
                {
                    if (userByEmail.Count < 3)
                    {
                        //HttpContext.Session.SetString("loginFaliurDateTime", DateTime.Now.ToString());
                        //var loginFaliurDateTime = HttpContext.Session.GetString("loginFaliurDateTime");
                        //if (Convert.ToDateTime(loginFaliurDateTime) >= DateTime.Now)
                        var userfromDb = _userService.Login(authenticateVM.Email, authenticateVM.Password);
                        if (userfromDb == null)
                        {
                            userByEmail.Count = userByEmail.Count + 1;
                            _userService.UpdateUser(userByEmail);
                            //HttpContext.Session.SetInt32("loginAttempt", userByEmail.count++);
                            return BadRequest("Please Check UserName And Password!!!!");
                        }
                        else
                        {
                            userByEmail.Count = 0;
                            _userService.UpdateUser(userByEmail);
                            return Ok(userfromDb);
                        }
                    }
                    else
                    {
                        userByEmail.Count = 0;
                        userByEmail.LockOutDateTime = DateTime.Now.AddHours(24);
                        var userToUpdate = _userService.UpdateUser(userByEmail);
                        //HttpContext.Session.SetString("loginFaliurDateTime", DateTime.Now.AddHours(24).ToString());
                        return BadRequest("You Are Reached Maximum Login Attempt,Please Try After 24 Hours!!!");
                    }
                }
                else
                    return BadRequest("User Have Blocked For 24 Hours,Please Try After " + (userByEmail.LockOutDateTime - DateTime.Now).TotalHours + " Hours!!!");
            }
        }
        [HttpGet("IsUniqueUserName")]
        public IActionResult IsUniqueUserName(string userName)
        {
            if (userName == null)
                return BadRequest();
            var isUniqueUserName = _userService.UniqueUserName(userName);
            if (isUniqueUserName != null)
                return BadRequest("UserName Already Taken!");
            return Ok();
        }
        [HttpGet("IsUniqueUser")]
        public IActionResult IsUniqueUser(string email)
        {
            var isUnique = _userService.UniqueEmail(email);
            if (isUnique != null)
                return BadRequest("Email Already Exsist!!!!");
            return Ok();
        }
        [HttpGet("ConfirmUrl")]
        public IActionResult ConfirmUrl(int userId)
        {
            if (userId == 0)
                return BadRequest();
            var userFromDb = _userService.GetUser(userId);
            if (userFromDb == null)
                return NotFound();
            var registerDateTime = userFromDb.RegisterDateTime.AddMinutes(15);
            if (registerDateTime >= DateTime.Now)
                return BadRequest("Verification time expired");
            if (userFromDb.EmailConfirm == true)
                return BadRequest("User Account Already Confirmed");
            userFromDb.EmailConfirm = true;
            _userService.UpdateUser(userFromDb);
            return Ok("User Verified Successfully");
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please enter valid Data");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var userData = _userService.Register(userDTO);
            var callbackUrl = ("https://localhost:44370/api/User/ConfirmUrl?userId=" + userData.Id);
            //var date = DateTime.Now.AddMinutes(15);
            //HttpContext.Session.SetString("value", date.ToString());
            _emailSender.SendEmailAsync(userDTO.Email, "User Varification",
                  $"Please confirm your account by <a href='{(callbackUrl)}'>clicking here</a>.");
            return Ok(userData);
        }
    }
}
