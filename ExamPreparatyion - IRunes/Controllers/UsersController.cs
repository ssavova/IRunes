using ExamPreparatyion___IRunes.Services;
using ExamPreparatyion___IRunes.ViewModels.Home;
using ExamPreparatyion___IRunes.ViewModels.User;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace ExamPreparatyion___IRunes.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = this.usersService.GetUserId(username, password);
            if(userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);


            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
           
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Password must be the same!");
            }

            if (input.Username?.Length < 4 || input.Username?.Length > 10)
            {
                return this.Error("Username must be in range 4 - 10 characters");
            }

            if(input.Password?.Length < 6 || input.Password?.Length > 20)
            {
                return this.Error("Password must be in range 6-20 characters");
            }

            if (this.usersService.IsUsernameUsed(input.Username))
            {
                return this.Error("This username is already used!");
            }

            if (this.usersService.IsEmailUsed(input.Email))
            {
                return this.Error("This email is already used!");
            }

            if (!IsValid(input.Email))
            {
                return this.Error("Please enter valid email adress");
            }

            this.usersService.CreateUser(input.Username, input.Password, input.Email);

           
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            this.SignOut();

            return this.Redirect("/");
        }

        private bool IsValid(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
