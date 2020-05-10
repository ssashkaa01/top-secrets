using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_TopSecrets
{
    [ServiceContract]
    public interface IService
    {
        // Повертає токен при успішній авторизації або пустий рядок, якщо авторизація не вдалася
        [OperationContract]
        string Login(string login, string password);

        // Реєстрація
        [OperationContract]
        bool Register(string login, string password);

        // Вийти із системи
        [OperationContract]
        bool Logout(string token);

        // Добавити секретні дані
        [OperationContract]
        bool AddSecretData(string token, SecretData data);

        // Видалити секретні дані
        [OperationContract]
        bool DeleteSecretData(string token, int id);

        // Отримати всі секретні дані
        [OperationContract]
        SecretData[] GetAllSecretData(string token);
    }

    [DataContract]
    public class SecretData
    {
        string url = "";
        string login = "";
        string password = "";
        string description = "";

        bool IsEmpty(string value)
        {
            return value == "" || value == null;
        }

        [DataMember]
        public string Url
        {
            get { return url; }
            set {
                if(IsEmpty(value))
                {
                    throw new Exception("Url can't be empty!");
                }

                url = value;
            }
        }

        [DataMember]
        public string Login
        {
            get { return login; }
            set {

                if (IsEmpty(value))
                {
                    throw new Exception("Login can't be empty!");
                }

                login = value;
            }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set {
                if (IsEmpty(value))
                {
                    throw new Exception("Description can't be empty!");
                }

                description = value;
            }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set
            {
                if (IsEmpty(value))
                {
                    throw new Exception("Password can't be empty!");
                }

                password = value;
            }
        }
    }
}
