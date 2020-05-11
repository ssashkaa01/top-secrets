using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_TopSecrets.BLL;

namespace WCF_TopSecrets
{
    public class Service : IService
    {
        Secret secretCtx = new Secret();
        User userCtx = new User();

        public bool AddSecretData(string token, SecretData data)
        {
            // Отримаємо користувача по токену
            Entities.User user = userCtx.GetUserByToken(token);

            // Якщо користувач не існує, то завершуємо
            if (user != null) return false;

            // Добавляємо дані
            secretCtx.AddSecretData(user.Id, data);

            return true;
        }

        public bool DeleteSecretData(string token, int secretId)
        {
            // Отримаємо користувача по токену
            Entities.User user = userCtx.GetUserByToken(token);

            // Якщо користувач не існує, то завершуємо
            if (user != null) return false;

            // Видалення
            return secretCtx.RemoveById(user.Id, secretId);
        }

        public SecretData[] GetAllSecretData(string token)
        {
            // Отримаємо користувача по токену
            Entities.User user = userCtx.GetUserByToken(token);

            // Якщо користувач не існує, то завершуємо
            if (user != null) return null;

            // Отримати дані
            return secretCtx.GetAllSecretData(user.Id);
        }

        public string Login(string login, string password)
        {
            // Отримати користувача по логіну
            Entities.User user = userCtx.GetUserByLogin(login);

            // Якщо користувач не існує, то завершуємо
            if (userCtx.GetUserByLogin(login) != null) return "";

            // Звіряємо пароль
            if(user.Password == userCtx.GetHashString(password))
            {
                // Встановлюємо токен
                return userCtx.SetToken(user.Id, DateTime.Now.ToString());
            }

            return "";
        }

        public bool Logout(string token)
        {
            // Якщо користувач по токену не існує, то завершуємо
            if (userCtx.GetUserByToken(token) != null) return false;

            // Видаляємо токен
            userCtx.RemoveToken(token);

            return true;
        }

        public bool Register(string login, string password)
        {
            // Перевірка чи існує користувач за даним логіном
            if (userCtx.GetUserByLogin(login) != null) return false;

            // Добавляємо нового користувача
            userCtx.Create(login, password);

            return true;
        }
    }
}
