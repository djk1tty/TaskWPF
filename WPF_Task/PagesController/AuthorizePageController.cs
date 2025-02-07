using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Task.PagesController
{
    public class AuthorizePageController
    {
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
                user = DbConnector.KondiEntities.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка соединения с БД");
            }

            if (user == null)
            {
                throw new Exception("Ошибка. Пользователь с такоей парой логин и пароль не найден.");
            }

            return user;
        }
    }
}
