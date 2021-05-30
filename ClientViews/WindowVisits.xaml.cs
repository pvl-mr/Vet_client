using ClientBusinessLogic.BindingModels;
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

namespace ClientViews
{
    /// <summary>
    /// Логика взаимодействия для WindowVisits.xaml
    /// </summary>
    public partial class WindowVisits : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly VisitLogic logic;

        public WindowVisits(VisitLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void WindowTravels_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.GetFilteredList(new VisitBindingModel
                {
                    ClientId = App.Client.Id
                });

                if (list != null)
                {
                    DataGridTravels.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowVisit>();

            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridTravels.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите визит", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            var form = Container.Resolve<WindowVisit>();
            form.Id = ((VisitViewModel)DataGridTravels.SelectedItems[0]).Id;

            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridTravels.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите визит", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            MessageBoxResult result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int id = ((VisitViewModel)DataGridTravels.SelectedItems[0]).Id;

                try
                {
                    logic.Delete(new VisitBindingModel { Id = id });
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

        private void ButtonBondExcursions_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridTravels.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите визит", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var form = Container.Resolve<WindowAddVisitAnimals>();
            form.Id = ((VisitViewModel)DataGridTravels.SelectedItems[0]).Id;

            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowStatisticCountVisits>();

            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowStatisticServicesVisit>();

            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }
    }
}
