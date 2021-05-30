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
    /// Логика взаимодействия для WindowVisit.xaml
    /// </summary>
    public partial class WindowVisit : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly VisitLogic visitLogic;
        private readonly List<ServiceViewModel> listServices;
        private readonly List<AnimalViewModel> listAnimals;

        public int Id { set { id = value; } }
        private int? id;

        private Dictionary<int, (string, string)> visitServices;
        private Dictionary<int, (string, string)> visitAnimals;


        public WindowVisit(VisitLogic visitLogic, ServiceLogic serviceLogic)
        {
            InitializeComponent();
            this.visitLogic = visitLogic;
            listServices = serviceLogic.GetFullList();
        }

        private void WindowVisit_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = visitLogic.GetFilteredList(new VisitBindingModel { Id = id })?[0];

                    if (view != null)
                    {
                        DatePicker.SelectedDate = view.Date;
                        TextBoxComment.Text = view.Comment;
                        visitServices = view.Services;
                        visitAnimals = view.Animals;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                visitServices = new Dictionary<int, (string, string)>();
                visitAnimals = new Dictionary<int, (string, string)>();

                foreach (var service in listServices)
                {
                    ListBoxAvailable.Items.Add(service);
                }
               
            }
        }

        private void LoadData()
        {
            try
            {
                //Если к путешествию уже привязаны какие-то туры, в ListBox с доступными турами 
                //оставляем только непривязанные туры
                if (visitServices != null)
                {
                    foreach (var service in visitServices)
                    {
                        ListBoxSelected.Items.Add(service);
                    }

                    ListBoxAvailable.Items.Clear();

                    foreach (var serviceAll in listServices)
                    {
                        if (!visitServices.ContainsKey(serviceAll.Id))
                        {
                            ListBoxAvailable.Items.Add(serviceAll);
                        }
                    }
                }
                
                if (visitAnimals != null)
                {
                    ListBoxAnimals.ItemsSource = visitAnimals;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAddService_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAvailable.SelectedItems.Count == 0)
            {
                MessageBox.Show("Услуга не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            visitServices.Add((int)ListBoxAvailable.SelectedValue, (((ServiceViewModel)ListBoxAvailable.SelectedItem).Name, ((ServiceViewModel)ListBoxAvailable.SelectedItem).Description));
            Listboxes_Reload();
        }


        private void ButtonRemoveService_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxSelected.SelectedItems.Count == 0)
            {
                MessageBox.Show("Услуга не выбрана", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    visitServices.Remove((int)ListBoxSelected.SelectedValue);
                    Listboxes_Reload();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Listboxes_Reload()
        {
            ListBoxAvailable.Items.Clear();
            ListBoxSelected.Items.Clear();

            foreach (var selectedService in visitServices)
            {
                ListBoxSelected.Items.Add(selectedService);
            }

            foreach (var tourFromAll in listServices)
            {
                if (!visitServices.ContainsKey(tourFromAll.Id))
                {
                    ListBoxAvailable.Items.Add(tourFromAll);
                }
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate == null)
            {
                MessageBox.Show("Введите дату визита", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxComment.Text))
            {
                MessageBox.Show("Введите комментарий", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ListBoxSelected.Items.Count == 0)
            {
                MessageBox.Show("Выберите туры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            foreach (var k in visitAnimals.Keys.ToList())
            {
                Console.WriteLine(k + " nnn" );
            }
           

            try
            {
                visitLogic.CreateOrUpdate(new VisitBindingModel
                {
                    Id = id,
                    Date = (DateTime)DatePicker.SelectedDate,
                    Comment = TextBoxComment.Text,
                    ClientId = App.Client.Id,
                    ServiceIds = visitServices.Keys.ToList(),
                    AnimalIds = visitAnimals.Keys.ToList()
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
