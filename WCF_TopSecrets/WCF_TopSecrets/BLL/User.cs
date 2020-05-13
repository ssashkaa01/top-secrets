using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System;

namespace WCF_TopSecrets.BLL
{
    class User
    {
        EFContext ctx = new EFContext();

        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        // Згенерувати хеш
        public string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        // Отримати користувача по логіну
        public UserData GetUserDataById(int userId)
        {
            Entities.User user = GetUserById(userId);

            return new UserData()
            {
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };
        }

        // Отримати користувача по логіну
        public Entities.User GetUserByLogin(string login)
        {
            return ctx.Users.Where(u => u.Login == login).FirstOrDefault();
        }

        // Отримати користувача по токену
        public Entities.User GetUserByToken(string token)
        {
            return ctx.Users.Where(u => u.Token == token).FirstOrDefault();
        }

        // Отримати користувача по Id
        public Entities.User GetUserById(int userId)
        {
            return ctx.Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        // Видалити токен
        public void RemoveToken(string token)
        {
            GetUserByToken(token).Token = "";

            ctx.SaveChanges();
        }

        // Встановити токен
        public string SetToken(int userId, string tokenData)
        {
            string token = GetHashString(tokenData);

            GetUserById(userId).Token = token;

            ctx.SaveChanges();

            return token;
        }

        // Перевірити чи правильно введено старий пароль
        public bool CheckOldPassword(int userId, string password)
        {
            Entities.User user = GetUserById(userId);

            return user.Password == GetHashString(password);
        }

        // Встановити новий пароль
        public void ChangePassword(int userId, string password)
        {
            Entities.User user = GetUserById(userId);

            user.Password = GetHashString(password);

            ctx.SaveChanges();
        }

        // Створити користувача
        public void Create(string login, string password, string key)
        {
            ctx.Users.Add(new Entities.User()
            {
                Login = login,
                Password = GetHashString(password),
                KeyHash = GetHashString(key),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
           
            ctx.SaveChanges();
        }

        // Редагувати дані користувача
        public void Edit(int userId, string name, string surname, string email)
        {
            Entities.User user = GetUserById(userId);

            user.Name = name;
            user.Surname = surname;
            user.Email = email;

            ctx.SaveChanges();
        }

        // Зберегти
        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
