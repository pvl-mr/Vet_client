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

        private void WindowAddAnimalsToVisit_Load(object sender, RoutedEventArgs e)
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
                if (visitAnimals != null)
                {
                    foreach (var animal in visitAnimals)
                    {
                        ListBoxSelectedAnimals.Items.Add(animal);
                    }

                    ListBoxAvaliableAnimals.Items.Clear();

                    foreach (var animalAll in listAnimals)
                    {
                        if (!visitAnimals.ContainsKey(animalAll.Id))
                        {
                            ListBoxAvaliableAnimals.Items.Add(animalAll);
                        }
                    }
                }
                else
                {
                    foreach (var allAnimals in listAnimals)
                    {
                        ListBoxAvaliableAnimals.Items.Add(allAnimals);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAvaliableAnimals.SelectedItems.Count == 0)
            {
                MessageBox.Show("Животное не выбрано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            visitAnimals.Add((int)ListBoxAvaliableAnimals.SelectedValue, (((AnimalViewModel)ListBoxAvaliableAnimals.SelectedItem).Name, ((AnimalViewModel)ListBoxAvaliableAnimals.SelectedItem).Description));
            Listboxes_Reload();
        }


        private void ButtonRemoveAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxSelectedAnimals.SelectedItems.Count == 0)
            {
                MessageBox.Show("Животное не выбрано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Убрать животного ?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    visitAnimals.Remove((int)ListBoxSelectedAnimals.SelectedValue);
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
            ListBoxAvaliableAnimals.Items.Clear();
            ListBoxSelectedAnimals.Items.Clear();

            foreach (var selectedAnimal in visitAnimals)
            {
                ListBoxSelectedAnimals.Items.Add(selectedAnimal);
            }

            foreach (var availableAnimal in listAnimals)
            {
                if (!visitAnimals.ContainsKey(availableAnimal.Id))
                {
                    ListBoxAvaliableAnimals.Items.Add(availableAnimal);
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
