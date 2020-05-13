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
        ObservableCollection<Objects.SecretData> SecretsDataCollection = new ObservableCollection<Objects.SecretData>();
        public ServiceClient serviceTopSecrets = new ServiceClient();

        public bool isAuth { get; set; }
        public string token { get; set; }
        public string login { get; set; }
        public string key { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            SetAuthInterface(false);

            SecretsData.ItemsSource = SecretsDataCollection;
        }

        // Реєстрація аккаунту
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.service = serviceTopSecrets;

            registerWindow.ShowDialog();
        }

        // Вхід
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.service = serviceTopSecrets;

            bool? res = loginWindow.ShowDialog();

            if(res == true)
            {
                token = loginWindow.token;
                login = loginWindow.login;
                SetAuthInterface(true);
            }
        }

        // Редагування профіля
        private void ChangeProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            EditProfile editProfileWindow = new EditProfile();
            editProfileWindow.service = serviceTopSecrets;
            editProfileWindow.token = token;
            editProfileWindow.ShowDialog();
        }

        // Зміна пароля
        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePasswordWindow = new ChangePassword();
            changePasswordWindow.service = serviceTopSecrets;
            changePasswordWindow.token = token;
            changePasswordWindow.ShowDialog();
        }

        // Додати секретні дані
        private void AddSecretDataBtn_Click(object sender, RoutedEventArgs e)
        {
            AddSecretData manageSecretData = new AddSecretData();
            manageSecretData.service = serviceTopSecrets;
            manageSecretData.token = token;
            manageSecretData.key = key;
            manageSecretData.ShowDialog();
        }

        // Редагувати секретні дані
        private void EditSecretDataBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Objects.SecretData secret in SecretsDataCollection)
            {
                if (secret.IsSelected)
                {
                    ServiceTopSecrets.SecretData secretData = new ServiceTopSecrets.SecretData();
                    secretData.Login = secret.Login;
                    secretData.Password = secret.Password;
                    secretData.Url = secret.Url;
                    secretData.Description = secret.Description;

                    EditSecretData manageSecretData = new EditSecretData(secretData);
                    manageSecretData.service = serviceTopSecrets;
                    manageSecretData.token = token;
                    manageSecretData.key = key;
                    manageSecretData.id = secret.Id;
                   
                    manageSecretData.ShowDialog();
                }
            }
        }

        // Видалити секретні дані
        private void DeleteSecretDataBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Objects.SecretData secret in SecretsDataCollection)
            {
                if(secret.IsSelected)
                {
                    serviceTopSecrets.DeleteSecretData(token, secret.Id);
                    SecretsDataCollection.Remove(secret);
                }
            }
        }

        // Встановити статус інтерфуйсу згідно авторизації
        private async void SetAuthInterface(bool auth = true)
        {
            isAuth = auth;

            if(auth)
            {
                AddSecretDataBtn.IsEnabled = true;
                ChangePasswordBtn.IsEnabled = true;
                DeleteSecretDataBtn.IsEnabled = true;
                EditSecretDataBtn.IsEnabled = true;
                LoginBtn.IsEnabled = true;
                RegisterBtn.IsEnabled = false;
                ChangeProfileBtn.IsEnabled = true;

                HappyBlock.Text = "Привіт, " + login;

                try
                {
                    ServiceTopSecrets.SecretData[] secretDatas = await serviceTopSecrets.GetAllSecretDataAsync(token, key);

                    foreach (ServiceTopSecrets.SecretData sd in secretDatas)
                    {
                        SecretsDataCollection.Add(new Objects.SecretData()
                        {
                            IsSelected = false,
                            Description = sd.Description,
                            Url = sd.Url,
                            Login = sd.Login,
                            Password = sd.Password
                        });
                    }

                } catch (Exception ex)
                {
                    MessageBox.Show("Сталася помилка при отриманні даних");
                }
               
            }
            else
            {
                AddSecretDataBtn.IsEnabled = false;
                ChangePasswordBtn.IsEnabled = false;
                DeleteSecretDataBtn.IsEnabled = false;
                EditSecretDataBtn.IsEnabled = false;
                LoginBtn.IsEnabled = true;
                RegisterBtn.IsEnabled = true;
                ChangeProfileBtn.IsEnabled = false;

                HappyBlock.Text = "ЗБЕРІГАЙТЕ ДАНІ БЕЗПЕЧНО НА =TOP=SECRETS=";

                SecretsDataCollection.Clear();
            }
        }
    }
}
