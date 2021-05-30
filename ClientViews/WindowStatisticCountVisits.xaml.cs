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
    /// Логика взаимодействия для WindowStatisticCountVisits.xaml
    /// </summary>
    public partial class WindowStatisticCountVisits : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ClientStatisticLogic logic;

        public WindowStatisticCountVisits(ClientStatisticLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void LoadData()
        {
            ((ColumnSeries)mcChartTravels.Series[0]).ItemsSource = logic.GetCountByMonths(0);
            ((ColumnSeries)mcChartTravels.Series[0]).ItemsSource = logic.GetCountByMonths(App.Client.Id);
        }

        private void WindowStatistics_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
