using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_TopSecrets;
using WPF_TopSecrets.Objects;
using WPF_TopSecrets.ServiceTopSecrets;

namespace WPF_TopSecrets
{
    public partial class MainWindow : Window
    {
        public bool IsAuth { get; set; }
        public string UserKey { get; set; }

        public MainWindow()
        {
            InitializeComponent();

           // ServiceClient serviceTopSecrets = new ServiceClient();

           // serviceTopSecrets.Register("sdfsadg", "sdfasdgs");

            ObservableCollection<Objects.SecretData> SecretsDataCollection = new ObservableCollection<Objects.SecretData>();

            SecretsDataCollection.Add(new Objects.SecretData() {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });

            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });
            SecretsDataCollection.Add(new Objects.SecretData()
            {
                IsSelected = false,
                Description = "Інстаграм маркетингової компанії",
                Url = "https://www.instagram.com/",
                Login = "super_user",
                Password = "super_password"
            });

            SecretsData.ItemsSource = SecretsDataCollection;
        }

        // Реєстрація аккаунту
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.ShowDialog();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeProfileBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSecretDataBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditSecretDataBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteSecretDataBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
