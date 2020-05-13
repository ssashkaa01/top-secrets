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

        public bool AddSecretData(string token, string key, SecretData data)
        {
            // Отримаємо користувача по токену
            Entities.User user = userCtx.GetUserByToken(token);

            // Якщо користувач не існує, то завершуємо
            if (user != null) return false;

            // Добавляємо дані
            secretCtx.AddSecretData(user.Id, data, key);

            return true;
        }

       
        public bool ChangePassword(string token, string lastPass, string newPass)
        {
            // Отримаємо користувача по токену
            Entities.User user = userCtx.GetUserByToken(token);

            // Якщо користувач не існує, то завершуємо
            if (user != null) return false;

            // Перевіряємо старий пароль
            bool checkOld = userCtx.CheckOldPassword(user.Id, lastPass);

            if (!checkOld) return false;

            // Оновляємо пароль
            userCtx.CheckOldPassword(user.Id, newPass);

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

        public bool EditProfile(string token, string name, string surname, string email)
        {
            // Отримаємо користувача по токену
            Entities.User user = userCtx.GetUserByToken(token);

            // Якщо користувач не існує, то завершуємо
            if (user != null) return false;

            userCtx.Edit(user.Id, name, surname, email);
           
            return true;
        }

        public bool EditSecretData(string token, string key, int id, SecretData data)
        {
            // Отримаємо користувача по токену
            Entities.User user = userCtx.GetUserByToken(token);

            // Якщо користувач не існує, то завершуємо
            if (user != null) return false;

            Entities.Secret secret = user.Secrets.Where(s => s.Id == id).FirstOrDefault();

            // Якщо даних не існує, то завершуємо
            if (secret != null) return false;

            // Пробуємо змінити дані
            return secretCtx.EditSecretData(user.Id, secret.Id, data, key);
        }

        public SecretData[] GetAllSecretData(string token, string key)
        {
            // Отримаємо користувача по токену
            Entities.User user = userCtx.GetUserByToken(token);

            // Якщо користувач не існує, то завершуємо
            if (user != null) return null;

            // Отримати дані
            return secretCtx.GetAllSecretData(user.Id, key);
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
