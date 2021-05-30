using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.BusinessLogic;
using System;
using System.Windows;
using Unity;

namespace ClientViews
{
    /// <summary>
    /// Логика взаимодействия для WindowPet.xaml
    /// </summary>
    public partial class WindowPet : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly AnimalLogic animalLogic;
        private readonly VaccinationLogic vaccinationLogic;

        public int Id { set { id = value; }}
        private int? id;

        public WindowPet(AnimalLogic animalLogic, VaccinationLogic vaccinationLogic)
        {
            InitializeComponent();
            this.animalLogic = animalLogic;
            this.vaccinationLogic = vaccinationLogic;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxName.Text))
            {
                MessageBox.Show("Введите кличку животного", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxType.Text))
            {
                MessageBox.Show("Введите вид животного", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxBreed.Text))
            {
                MessageBox.Show("Введите породу животного", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxDescription.Text))
            {
                MessageBox.Show("Введите породу животного", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("id - " + id);
            try
            {
                animalLogic.CreateOrUpdate(new AnimalBindingModel
                {
                    Id = id,
                    Name = TextBoxName.Text,
                    Type = TextBoxType.Text,
                    Breed = TextBoxBreed.Text,
                    Description = TextBoxDescription.Text,
                    ClientId = App.Client.Id,
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

        private void WindowAnimal_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = animalLogic.GetFilteredList(new AnimalBindingModel {Id = id })?[0];

                    if (view != null)
                    {
                        TextBoxName.Text = view.Name;
                        TextBoxType.Text = view.Type;
                        TextBoxBreed.Text = view.Breed;
                        TextBoxDescription.Text = view.Description;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
