using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_TopSecrets.Security;

namespace WCF_TopSecrets.BLL
{
    class Secret
    {
        EFContext ctx = new EFContext();
        SecurityProxy sp = new SecurityProxy();

        // Отримати дані по користувачу
        public SecretData[] GetAllSecretData(int userId, string key)
        {
            SecretData[] secretDatas = ctx.Secrets.Where(s => s.UserId == userId).Select(s => new SecretData()
            {
                Id = s.Id,
                Description = s.Description,
                Login = s.Login,
                Password = s.Password,
                Url = s.Url
            }).ToArray();

            foreach(SecretData sd in secretDatas)
            {
                try
                {
                    sd.Description = sp.Decrypt(key, sd.Description);
                    sd.Login = sp.Decrypt(key, sd.Login);
                    sd.Password = sp.Decrypt(key, sd.Password);
                    sd.Url = sp.Decrypt(key, sd.Url);
                } catch (Exception ex)
                {

                }
            }

            return secretDatas;
        }

        // Добавити секретні дані 
        public void AddSecretData(int userId, SecretData data, string key)
        {
            ctx.Secrets.Add(new Entities.Secret()
            {
                Login = sp.Encrypt(key, data.Login),
                Password = sp.Encrypt(key, data.Password),
                Description = sp.Encrypt(key, data.Description),
                Url = sp.Encrypt(key, data.Url),
                UserId = Convert.ToInt32(userId),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });

            ctx.SaveChanges();
        }

        // Редагувати секретні дані
        public bool EditSecretData(int userId, int secretId, SecretData data, string key)
        {
            Entities.Secret secret = GetSecretById(userId, secretId);

            if (secret == null) return false;

            secret.Login = sp.Encrypt(key, data.Login);
            secret.Password = sp.Encrypt(key, data.Password);
            secret.Description = sp.Encrypt(key, data.Description);
            secret.Url = sp.Encrypt(key, data.Url);
            secret.UpdatedAt = DateTime.Now;

            ctx.SaveChanges();

            return true;
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
