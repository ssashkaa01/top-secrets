﻿using System;
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
 
    public partial class AddSecretData : Window
    {
        public ServiceClient service;
        public string token { get; set; }
        public string key { get; set; }

        public AddSecretData()
        {
            InitializeComponent();
        }

        private async void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!SecretValidator.CheckDescription(descriptionBox.Text))
            {
                MessageBox.Show(SecretValidator.CheckDescriptionMessage());
                return;
            }

            if (!SecretValidator.CheckUrl(urlBox.Text))
            {
                MessageBox.Show(SecretValidator.CheckUrlMessage());
                return;
            }

            if (!SecretValidator.CheckLogin(loginBox.Text) && !SecretValidator.CheckEmail(loginBox.Text))
            {
                MessageBox.Show(SecretValidator.CheckLoginMessage());
                return;
            }

            if (!SecretValidator.CheckPassword(passBox.Text))
            {
                MessageBox.Show(SecretValidator.CheckPasswordMessage());
                return;
            }

            SecretData secretData = new SecretData();

            secretData.Url = urlBox.Text;
            secretData.Description = descriptionBox.Text;
            secretData.Login = loginBox.Text;
            secretData.Password = passBox.Text;

            bool res = await service.AddSecretDataAsync(token, key, secretData);

            if (res)
            {
                MessageBox.Show("Дані добавлено!");

                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Щось не так...");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
