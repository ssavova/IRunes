using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparatyion___IRunes.Services
{
    public interface IUsersService
    {
        bool IsUsernameUsed(string username);
        bool IsEmailUsed(string email);

        void CreateUser(string username, string password, string email);

        string GetUserId(string username, string password);
    }
}
