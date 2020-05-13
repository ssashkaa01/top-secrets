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
   
    public partial class ChangePassword : Window
    {
        public ServiceClient service;
        public string token { get; set; }

        public ChangePassword()
        {
            InitializeComponent();
        }

        private async void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!UserValidator.CheckPassword(lastPassBox.Password))
            {
                MessageBox.Show(UserValidator.CheckPasswordMessage());
                return;
            }

            if (!UserValidator.CheckPassword(pass1Box.Password))
            {
                MessageBox.Show(UserValidator.CheckPasswordMessage());
                return;
            }

            if (pass1Box.Password != pass2Box.Password)
            {
                MessageBox.Show(UserValidator.CheckPasswordNotEquelsMessage());
                return;
            }

            bool res = await service.ChangePasswordAsync(token, lastPassBox.Password, pass1Box.Password);

            if (res)
            {
                MessageBox.Show("Пароль змінено!");

                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Щось не так... Попробуйте перевірити старий пароль.");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
