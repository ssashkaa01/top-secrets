using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPF_TopSecrets.Helpers
{
    class SecretValidator
    {
       
        // Перевірити опис
        public static bool CheckDescription(string descr)
        {
            Regex rgx = new Regex(@"^[\p{IsCyrillic}\s\p{L}0-9]{2,100}$");

            return rgx.IsMatch(descr);
        }

        // Отримати повідомлення про помилку опису
        public static string CheckDescriptionMessage()
        {
            return "Ви ввели некоректний опис. Від 2 до 100 символів, кирилиця, латинь та числа.";
        }

        // Перевірити посилання
        public static bool CheckUrl(string url)
        {
            Regex rgx = new Regex(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$");

            return rgx.IsMatch(url);
        }

        // Отримати повідомлення про помилку посилання
        public static string CheckUrlMessage()
        {
            return "Ви ввели некоректне посилання.";
        }

        // Перевірити пароль
        public static bool CheckPassword(string pass)
        {
            return pass.Length >= 6 && pass.Length <= 100;
        }

        // Отримати повідомлення про помилку паролю
        public static string CheckPasswordMessage()
        {
            return "Ви ввели некоректний пароль. Кількість символів повинна бути від 6 до 100";
        }

        // Перевірити email
        public static bool CheckEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        // Отримати повідомлення про помилку email
        public static string CheckEmailMessage()
        {
            return "Ви ввели некоректний email.";
        }

        // Перевірити логін
        public static bool CheckLogin(string login)
        {
            Regex rgx = new Regex(@"^[A-Za-z0-9_-]{8,40}$");

            return rgx.IsMatch(login);
        }

        // Отримати повідомлення про помилку email
        public static string CheckLoginMessage()
        {
            return "Ви ввели некоректний логін";
        }
    }
}
