using System;
using System.Collections.Generic;
using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.BusinessLogic;
using ClientBusinessLogic.ViewModels;
using System.Windows;

using Unity;
using Microsoft.Win32;

namespace ClientViews
{
    /// <summary>
    /// Логика взаимодействия для WindowVisitMedicines.xaml
    /// </summary>
    public partial class WindowVisitMedicines : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly VisitLogic visitLogic;
        private readonly ClientReportLogic reportLogic;

        public WindowVisitMedicines(VisitLogic visitLogic, ClientReportLogic reportLogic)
        {
            InitializeComponent();
            this.visitLogic = visitLogic;
            this.reportLogic = reportLogic;
        }

        private void WindowGetVisitMedicines_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = visitLogic.GetFilteredList(new VisitBindingModel
                {
                    ClientId = App.Client.Id
                });

                if (list != null)
                {
                    ListBoxVisits.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void ButtonSaveToExcel_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxVisits.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите визиты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var list = new List<VisitViewModel>();

                    foreach (var visit in ListBoxVisits.SelectedItems)
                    {
                        list.Add((VisitViewModel)visit);
                    }

                    reportLogic.SaveVisitMedicinesToExcel(new ReportVisitBindingModel
                    {
                        FileName = dialog.FileName,
                        Visits = list
                    });

                    MessageBox.Show("Список успешно сохранён в Excel-файл!", "Успех", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ButtonSaveToWord_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxVisits.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите визиты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            try
            {
                if (dialog.ShowDialog() == true)
                {
                    var list = new List<VisitViewModel>();

                    foreach (var visit in ListBoxVisits.SelectedItems)
                    {
                        list.Add((VisitViewModel)visit);
                    }

                    reportLogic.SaveVisitMedicinesToWord(new ReportVisitBindingModel
                    {
                        FileName = dialog.FileName,
                        Visits = list
                    });

                    MessageBox.Show("Список успешно сохранён!", "Успех", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
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
