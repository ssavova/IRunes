using ExamPreparatyion___IRunes.ViewModels.Home;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamPreparatyion___IRunes.Controllers
{
    public class HomeController: Controller
    {
        private readonly IRunesDbContext db;
        public HomeController(IRunesDbContext db)
        {
            this.db = db;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var userName = this.db.Users.FirstOrDefault(u => u.Id == this.User).Username;
                var viewModel = new HomeViewModel()
                {
                    Username = userName
                };

                return this.View(viewModel,"Home");
            }

            return this.View();
        }
    }
}
