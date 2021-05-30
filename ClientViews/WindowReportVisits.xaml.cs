using ClientBusinessLogic.BusinessLogic;
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
using ClientBusinessLogic.Interfaces;
using ClientBusinessLogic.ViewModels;
using ClientBusinessLogic.BindingModels;
using Microsoft.Win32;
using ClientBusinessLogic.HelperModels;

namespace ClientViews
{
    /// <summary>
    /// Логика взаимодействия для WindowReportVisits.xaml
    /// </summary>
    public partial class WindowReportVisits : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ClientReportLogic logic;
        private readonly IEntityStorage<ClientViewModel, ClientBindingModel> clientStorage;
        public WindowReportVisits(ClientReportLogic logic, IEntityStorage<ClientViewModel, ClientBindingModel> clientStorage)
        {
            InitializeComponent();
            this.logic = logic;
            this.clientStorage = clientStorage;
        }


        private void ButtonFormReport_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerFrom.SelectedDate >= DatePickerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var dataSource = logic.GetVisitAnimalsMedicines(new ReportVisitBindingModel
                {
                    DateFrom = DatePickerFrom.SelectedDate,
                    DateTo = DatePickerTo.SelectedDate,
                    ClientId = App.Client.Id
                }, App.Client.Id);
                DataGridReport.ItemsSource = dataSource;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonToPdf_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerFrom.SelectedDate >= DatePickerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            {
                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        logic.SaveVisitAnimalsMedicinesToPdf(new ReportVisitBindingModel
                        {
                            FileName = dialog.FileName,
                            DateFrom = DatePickerFrom.SelectedDate,
                            DateTo = DatePickerTo.SelectedDate,
                            ClientId = App.Client.Id
                        }, App.Client.Id);
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void ButtonSendToMail_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerFrom.SelectedDate >= DatePickerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var fileName = "Отчет.pdf";

                logic.SaveVisitAnimalsMedicinesToPdf(new ReportVisitBindingModel
                {
                    FileName = fileName,
                    DateFrom = DatePickerFrom.SelectedDate,
                    DateTo = DatePickerTo.SelectedDate,
                    ClientId = App.Client.Id
                }, App.Client.Id);

                MailLogic.MailSend(new MailSendInfo
                {
                    MailAddress = App.Client.Email,
                    Subject = "Отчет по визитам",
                    Text = "Отчет по визитам от " + DatePickerFrom.SelectedDate.Value.ToShortDateString() + " по " + DatePickerTo.SelectedDate.Value.ToShortDateString(),
                    FileName = fileName
                });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
        }

    }
}
