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
    public partial class Register : Window
    {
        public ServiceClient service;

        public Register()
        {
            InitializeComponent();
        }

        private async void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!UserValidator.CheckLogin(loginBox.Text))
            {
                MessageBox.Show(UserValidator.CheckLoginMessage());
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

            if (!UserValidator.CheckKey(keyBox.Password))
            {
                MessageBox.Show(UserValidator.CheckKeyMessage());
                return;
            }

            bool res = await service.RegisterAsync(loginBox.Text, pass1Box.Password, keyBox.Password);

            if(res)
            {
                MessageBox.Show("Дякуємо за реєстрацію. Тепер ви можете увійти");
                this.DialogResult = true;
                this.Close();
            }else
            {
                MessageBox.Show("Не вдалося зареєструватись, можливо логін зайнятий");
            }
           
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
