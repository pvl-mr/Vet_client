using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.BusinessLogic;
using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace ClientViews
{
    /// <summary>
    /// Логика взаимодействия для WindowVaccination.xaml
    /// </summary>
    public partial class WindowVaccination : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly VaccinationLogic logic;
        private readonly AnimalLogic logicA;

        public int Id { set { id = value; } }
        private int? id;

        public WindowVaccination(VaccinationLogic logic, AnimalLogic logicA)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicA = logicA;
        }

        private void WindowVaccination_Load(object sender, RoutedEventArgs e)
        {
            List<AnimalViewModel> listAnimals = logicA.GetFilteredList(new AnimalBindingModel
            {
                ClientId = App.Client.Id
            });

            if (listAnimals != null)
            {
                ComboBoxVaccinations.ItemsSource = listAnimals;
                ComboBoxVaccinations.DisplayMemberPath = "Name";
                ComboBoxVaccinations.SelectedItem = null;
            }

            if (id.HasValue)
            {
                try
                {
                    var view = logic.GetFilteredList(new VaccinationBindingModel { Id = id })?[0];

                    if (view != null)
                    {
                        DatePicker.SelectedDate = view.Date;
                        TextBoxName.Text = view.Name;
                        TextBoxDescription.Text = view.Description;
                        ComboBoxVaccinations.SelectedValue = view.AnimalId;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxName.Text))
            {
                MessageBox.Show("Введите название прививки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxDescription.Text))
            {
                MessageBox.Show("Введите описание", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(DatePicker.Text))
            {
                MessageBox.Show("Введите дату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ComboBoxVaccinations.SelectedItem == null)
            {
                MessageBox.Show("Выберите питомца", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                logic.CreateOrUpdate(new VaccinationBindingModel
                {
                    Id = id,
                    Date = (DateTime)DatePicker.SelectedDate,
                    Description = TextBoxDescription.Text,
                    Name = TextBoxName.Text,
                    AnimalId = Convert.ToInt32(ComboBoxVaccinations.SelectedValue),
                    ClientId = App.Client.Id
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
