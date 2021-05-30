using ClientBusinessLogic.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
    /// Логика взаимодействия для WindowStatistics.xaml
    /// </summary>
    public partial class WindowStatistics : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ClientStatisticLogic logic;

        public WindowStatistics(ClientStatisticLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void LoadData()
        {
            ((ColumnSeries)mcChartTravels.Series[0]).ItemsSource = logic.GetCountByMonths(0);
            ((ColumnSeries)mcChartTravels.Series[0]).ItemsSource = logic.GetCountByMonths(App.Client.Id);
            ((ColumnSeries)mcChartExcursions.Series[0]).ItemsSource = logic.GetAnimalsInfo(App.Client.Id);
            ((PieSeries)mcChartCountries.Series[0]).ItemsSource = logic.GetCountriesInfo(App.Client.Id);
        }

        private void WindowStatistics_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
