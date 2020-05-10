using System.Linq;
using System.Text;
using System.Security.Cryptography;

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
        public Entities.User GetUserByLogin(string login)
        {
            return ctx.Users.Where(u => u.Login == login).FirstOrDefault();
        }

        // Отримати користувача по токену
        public Entities.User GetUserByToken(string token)
        {
            return ctx.Users.Where(u => u.Token == token).FirstOrDefault();
        }

        // Видалити токен
        public void RemoveToken(string token)
        {
            GetUserByToken(token).Token = "";

            ctx.SaveChanges();
        }

        // Зберегти
        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
