using opencv_raspberry_test.server.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SpeedService speedService;

        public MainWindow(SpeedService speedService)
        {
            DataContext = speedService;
            InitializeComponent();
            this.speedService = speedService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            speedService.Start();
        }
    }
}
