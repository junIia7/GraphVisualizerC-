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
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Page
    {
        private readonly MainWindow mainWindow;
        public Info(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        private void OnMouse(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Background = Brushes.LightSalmon;
        }
        private void OffMouse(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Background = Brushes.LightBlue;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {

            mainWindow.mainFrame.GoBack();
        }
    }
}
