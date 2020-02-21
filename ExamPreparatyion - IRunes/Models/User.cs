using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparatyion___IRunes.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
