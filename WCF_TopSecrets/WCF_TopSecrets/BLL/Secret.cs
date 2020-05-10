using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_TopSecrets.BLL
{
    class Secret
    {
        EFContext ctx = new EFContext();

        // Отримати дані по користувачу
        public SecretData[] GetAllSecretData(int userId)
        {
            return ctx.Secrets.Where(s => s.UserId == userId).Select(s => new SecretData()
            {
                Description = s.Description,
                Login = s.Login,
                Password = s.Password,
                Url = s.Url
            }).ToArray();
        }

        // Добавити секретні дані 
        public void AddSecretData(int userId, SecretData data)
        {
            ctx.Secrets.Add(new Entities.Secret()
            {
                Login = data.Login,
                Password = data.Password,
                Description = data.Description,
                Url = data.Url,
                UserId = Convert.ToInt32(userId),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });

            ctx.SaveChanges();
        }

        // Отримати секретні дані
        public Entities.Secret GetSecretById(int userId, int secretId)
        {
            return ctx.Secrets.Where(s => s.UserId == userId && s.Id == secretId).FirstOrDefault();
        }

        // Видалити секретні дані 
        public bool RemoveById(int userId, int secretId)
        {
            Entities.Secret secret = GetSecretById(userId, secretId);

            if (secret == null) return false;

            ctx.Secrets.Remove(secret);

            ctx.SaveChanges();

            return true;
        }
    }
}
