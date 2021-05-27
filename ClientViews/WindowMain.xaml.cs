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
    /// Логика взаимодействия для WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public WindowMain()
        {
            InitializeComponent();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowVisits>();
            form.ShowDialog();
        }

        private void bGetAnimals_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowPets>();
            form.ShowDialog();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowVaccinations>();
            form.ShowDialog();
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowVisitMedicines>();
            form.ShowDialog();
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowReportVisits>();
            form.ShowDialog();
        }
    }
}
