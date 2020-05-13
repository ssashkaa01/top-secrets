using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPF_TopSecrets.Helpers
{
    class UserValidator
    {
        // Перевірити email
        public static bool CheckEmail(string email)
        {
            Regex rgx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            return rgx.IsMatch(email);
        }

        // Отримати повідомлення про помилку логіна
        public static string CheckEmailMessage()
        {
            return "Ви ввели некоректний email.";
        }

        // Перевірити логін
        public static bool CheckLogin(string login)
        {
            Regex rgx = new Regex(@"^[a-z0-9]{2,30}$");

            return rgx.IsMatch(login);
        }

        // Отримати повідомлення про помилку логіна
        public static string CheckLoginMessage()
        {
            return "Ви ввели некоректний логін. Від 2 до 30 символів, a-z 0-9";
        }

        // Перевірити пароль
        public static bool CheckPassword(string pass)
        {
            Regex rgx = new Regex(@"^[A-Za-z0-9]{8,40}$");

            return rgx.IsMatch(pass);
        }

        // Отримати повідомлення про помилку паролю
        public static string CheckPasswordMessage()
        {
            return "Ви ввели некоректний пароль. Від 8 до 40 символів, A-Z a-z 0-9";
        }

        // Отримати повідомлення про помилку імені
        public static string CheckPasswordNotEquelsMessage()
        {
            return "Паролі не сходяться";
        }

        // Перевірити ім'я
        public static bool CheckName(string name)
        {
            Regex rgx = new Regex(@"^[\p{IsCyrillic}\s]{2,40}$");

            return rgx.IsMatch(name);
        }

        // Отримати повідомлення про помилку імені
        public static string CheckNameMessage()
        {
            return "Ви ввели некоректне ім'я. Від 2 до 40 символів, кирилиця";
        }

        // Перевірити прізвище
        public static bool CheckSurname(string surname)
        {
            Regex rgx = new Regex(@"^[\p{IsCyrillic}\s]{2,40}$");

            return rgx.IsMatch(surname);
        }

        // Отримати повідомлення про помилку імені
        public static string CheckSurnameMessage()
        {
            return "Ви ввели некоректне прізвище. Від 2 до 40 символів, кирилиця";
        }

        // Перевірити ключ
        public static bool CheckKey(string key)
        {
            Regex rgx = new Regex(@"^[A-Za-z0-9]{4,40}$");

            return rgx.IsMatch(key);
        }

        // Отримати повідомлення про помилку паролю
        public static string CheckKeyMessage()
        {
            return "Ви ввели некоректний ключ шифрування. Від 4 до 40 символів, A-Z a-z 0-9";
        }
    }
}
