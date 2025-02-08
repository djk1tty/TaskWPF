using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Task.Models;

namespace WPF_Task.PagesController
{
    public class AuthorizePageController
    {
        private InternetShopEntities dbConnection;
        public AuthorizePageController()
        {
            dbConnection = new InternetShopEntities();
        }
        public User FindUserByLoginAndPassword(string login, string password)
        {
            if (login == "")
            {
                throw new Exception("Ошибка. Логин не заполнен.");
            }

            if (password == "")
            {
                throw new Exception("Ошибка. Пароль не заполнен.");
            }

            User user;
            try
            {
                user = dbConnection.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка соединения с БД");
            }

            if (user == null)
            {
                throw new Exception("Ошибка. Пользователь с такой парой логин и пароль не найден.");
            }

            return user;
        }
    }
}
