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
   
    public partial class EditProfile : Window
    {
        public ServiceClient service;
        public string token { get; set; }

        public EditProfile()
        {
            InitializeComponent();
        }

        private async void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {

            if (!UserValidator.CheckEmail(emailBox.Text))
            {
                MessageBox.Show(UserValidator.CheckEmailMessage());
                return;
            }

            if (!UserValidator.CheckName(nameBox.Text))
            {
                MessageBox.Show(UserValidator.CheckNameMessage());
                return;
            }

            if (!UserValidator.CheckSurname(surnameBox.Text))
            {
                MessageBox.Show(UserValidator.CheckSurnameMessage());
                return;
            }

            bool res = await service.EditProfileAsync(token, nameBox.Text, surnameBox.Text, emailBox.Text);

            if (res)
            {
                MessageBox.Show("Профіль змінено!");

                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Щось не так :(");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
