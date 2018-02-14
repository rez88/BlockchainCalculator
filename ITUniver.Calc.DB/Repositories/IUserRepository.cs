﻿using ITUniver.Calc.DB.Models;
using System;

namespace ITUniver.Calc.DB.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Проверить наличие пользователя с таким паролем
        /// </summary>
        /// <param name="login">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        bool Check(string login, string password);
        bool Register(string Name, string Login, string Password, DateTime BirthDay, bool Sex);

        /// <summary>
        /// Загрузить пользователя по имени
        /// </summary>
        /// <param name="login">Имя пользователя</param>
        /// <returns></returns>
        User GetByName(string login);
    }
}