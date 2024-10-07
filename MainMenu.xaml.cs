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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private readonly MainWindow mainWindow;

        public MainMenu(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void ChangePageStart(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new InpData(mainWindow));
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void GoToRules(object sender, EventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Info(mainWindow));
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
    }
}
