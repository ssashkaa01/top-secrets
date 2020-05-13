using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_TopSecrets.Helpers;
using WPF_TopSecrets.ServiceTopSecrets;

namespace WPF_TopSecrets
{
    public partial class Login : Window
    {
        public ServiceClient service;
        public string token { get; set; }
        public string login { get; set; }
        public string key { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private async void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!UserValidator.CheckLogin(loginBox.Text))
            {
                MessageBox.Show(UserValidator.CheckLoginMessage());
                return;
            }

            if (!UserValidator.CheckPassword(passBox.Password))
            {
                MessageBox.Show(UserValidator.CheckPasswordMessage());
                return;
            }

            if (!UserValidator.CheckKey(keyBox.Password))
            {
                MessageBox.Show(UserValidator.CheckKeyMessage());
                return;
            }

            string res = await service.LoginAsync(loginBox.Text, passBox.Password, keyBox.Password);

            if (res != "")
            {
                token = res;
                login = loginBox.Text;
                key = keyBox.Password;
                MessageBox.Show("Ви увійшли!");

                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильний логін або пароль");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
