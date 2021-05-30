using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.BusinessLogic;
using ClientBusinessLogic.ViewModels;
using System;
using System.Windows;
using Unity;

namespace ClientViews
{
    /// <summary>
    /// Логика взаимодействия для WindowPets.xaml
    /// </summary>
    public partial class WindowPets : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly AnimalLogic logic;

        public WindowPets(AnimalLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void WindowPets_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.GetFilteredList(new AnimalBindingModel
                {
                    ClientId = App.Client.Id
                });

                if (list != null)
                {
                    DataGridAnimals.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowPet>();

            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAnimals.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите экскурсию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var form = Container.Resolve<WindowPet>();
            form.Id = ((AnimalViewModel)DataGridAnimals.SelectedItems[0]).Id;

            Console.WriteLine(((AnimalViewModel)DataGridAnimals.SelectedItems[0]).Id + " iddd ");
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAnimals.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите животное", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int id = ((AnimalViewModel)DataGridAnimals.SelectedItems[0]).Id;

                try
                {
                    logic.Delete(new AnimalBindingModel { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                LoadData();
            }
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void ButtonRefresh_Click_1(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowStatisticAnimal>();

            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }
    }
}

