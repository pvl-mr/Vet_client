using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.BusinessLogic;
using ClientBusinessLogic.ViewModels;
using System;
using System.Windows;
using Unity;

namespace ClientViews
{
    /// <summary>
    /// Логика взаимодействия для WindowVaccinations.xaml
    /// </summary>
    public partial class WindowVaccinations : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly VaccinationLogic logic;

        public WindowVaccinations(VaccinationLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void WindowVaccinations_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.GetFilteredList(new VaccinationBindingModel
                {
                    ClientId = App.Client.Id
                });

                if (list != null)
                {
                    DataGridVaccinations.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowVaccination>();

            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridVaccinations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите прививку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var form = Container.Resolve<WindowVaccination>();
            form.Id = ((VaccinationViewModel)DataGridVaccinations.SelectedItems[0]).Id;

            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridVaccinations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите место", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int id = ((VaccinationViewModel)DataGridVaccinations.SelectedItems[0]).Id;

                try
                {
                    logic.Delete(new VaccinationBindingModel { Id = id });
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
    }
}
