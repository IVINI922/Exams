using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public class UserService
    {
        public static string? Login(string login, string password)
        {
            List<User> users = new();
            using(Winter14112026Context context = new())
            {
                users = context.Users.ToList();
            }
            User? user = users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
            {
                return user.Surname + " " + user.Name + " " + user.Patronymic;
            }
            else
            {
                return null;
            }
        }
    }
}