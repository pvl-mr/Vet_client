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
    /// Логика взаимодействия для WindowAddVisitAnimals.xaml
    /// </summary>
    public partial class WindowAddVisitAnimals : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly VisitLogic visitLogic;
        private readonly List<AnimalViewModel> listAnimals;

        public int Id { set { id = value; } }
        private int? id;

        private Dictionary<int, (string, string)> visitAnimals;

        public WindowAddVisitAnimals(VisitLogic visitLogic, AnimalLogic animalLogic)
        {
            InitializeComponent();
            this.visitLogic = visitLogic;
            listAnimals = animalLogic.GetFilteredList(new AnimalBindingModel
            {
                ClientId = App.Client.Id
            });
        }

        private void WindowBondTravelExcursions_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                var view = visitLogic.GetFilteredList(new VisitBindingModel { Id = id })?[0];

                if (view != null)
                {
                    visitAnimals = view.Animals;
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void LoadData()
        {
            try
            {
                //Если к путешествию уже привязаны какие-то экскурсии, в ListBox с доступными экскурсиями 
                //оставляем только непривязанные экскурсии
                if (visitAnimals != null)
                {
                    foreach (var animal in visitAnimals)
                    {
                        ListBoxSelectedExcursions.Items.Add(animal);
                    }

                    ListBoxAvaliableExcursions.Items.Clear();

                    foreach (var animalAll in listAnimals)
                    {
                        if (!visitAnimals.ContainsKey(animalAll.Id))
                        {
                            ListBoxAvaliableExcursions.Items.Add(animalAll);
                        }
                    }
                }
                else
                {
                    foreach (var excursionFromAll in listAnimals)
                    {
                        ListBoxAvaliableExcursions.Items.Add(excursionFromAll);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAddExcursion_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAvaliableExcursions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Животное не выбрано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            visitAnimals.Add((int)ListBoxAvaliableExcursions.SelectedValue, (((AnimalViewModel)ListBoxAvaliableExcursions.SelectedItem).Name, ((AnimalViewModel)ListBoxAvaliableExcursions.SelectedItem).Description));
            Listboxes_Reload();
        }


        private void ButtonRemoveExcursion_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxSelectedExcursions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Животное не выбрано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Убрать животного ?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    visitAnimals.Remove((int)ListBoxSelectedExcursions.SelectedValue);
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
            ListBoxAvaliableExcursions.Items.Clear();
            ListBoxSelectedExcursions.Items.Clear();

            foreach (var selectedExcursion in visitAnimals)
            {
                ListBoxSelectedExcursions.Items.Add(selectedExcursion);
            }

            foreach (var tourFromAll in listAnimals)
            {
                if (!visitAnimals.ContainsKey(tourFromAll.Id))
                {
                    ListBoxAvaliableExcursions.Items.Add(tourFromAll);
                }
            }
        }

        private void ButtonBond_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var visit = visitLogic.GetFilteredList(new VisitBindingModel { Id = id })?[0];

               

                visitLogic.CreateOrUpdate(new VisitBindingModel
                {
                    Id = id,
                    Date = visit.Date,
                    Comment = visit.Comment,
                    ClientId = App.Client.Id,
                    ServiceIds = visit.Services.Keys.ToList(),
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
