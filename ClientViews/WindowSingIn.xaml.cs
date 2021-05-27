using ClientBusinessLogic.BusinessLogic;
using ClientBusinessLogic.ViewModels;
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
using Unity;
using VetclinicStorage.EntityStorages;

namespace ClientViews
{
    /// <summary>
    /// Логика взаимодействия для WindowSingIn.xaml
    /// </summary>
    public partial class WindowSingIn : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ClientLogic logic;
        public WindowSingIn(ClientLogic logic)
        {
            this.logic = logic;
            InitializeComponent();
        }

        private void bSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxLogin.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var clients = logic.GetFullList();

            ClientViewModel clinetView = null;

            foreach (var client in clients)
            {
                if (client.Email == TextBoxLogin.Text && client.Pass == TextBoxPassword.Text)
                {
                    clinetView = client;
                }
            }

            if (clinetView != null)
            {
                App.Client = clinetView;
                var formMain = Container.Resolve<WindowMain>();
                formMain.Show();
                Close();
                Console.WriteLine(App.Client.Id + " ------------ ");
            }
            else
            {
                MessageBox.Show("Неверно введён логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void bSignUp_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowSignUp>();
            form.ShowDialog();
        }
    }
}
