using Microsoft.VisualBasic.ApplicationServices;
using OPGYaroMoll.ClassFolder;
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

namespace OPGYaroMoll.WindowFolder.CashierFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuCashierWindow.xaml
    /// </summary>
    public partial class MenuCashierWindow : Window
    {
        public MenuCashierWindow(DataFolder.User user)
        {
            InitializeComponent();
            VariableClass.AddTickersBtn_Click2 = this;
            UpdateList();
            DataContext = user;
            MainFrame.Navigate(new PageFolder.CashierFolder.ListCashierPage());
        }

        private void ListTickersBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MainFrame.Navigate(new PageFolder.CashierFolder.ListCashierPage());
            ListTickersBtn.Visibility = Visibility.Hidden;
            ListTickersBtnWhite.Visibility = Visibility.Visible;
            AddTickersBtn.Visibility = Visibility.Visible;
            AddTickersBtnWhite.Visibility = Visibility.Hidden;
        }

        private void AddTickersBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddTickersWindow().Show();
            AddTickersBtn.Visibility = Visibility.Hidden;
            AddTickersBtnWhite.Visibility = Visibility.Visible;
            ListTickersBtn.Visibility = Visibility.Visible;
            ListTickersBtnWhite.Visibility = Visibility.Hidden;
        }

        public void UpdateList()
        {
            MainFrame.Navigate(new PageFolder.CashierFolder.ListCashierPage());
            ListTickersBtn.Visibility = Visibility.Hidden;
            ListTickersBtnWhite.Visibility = Visibility.Visible;
            AddTickersBtn.Visibility = Visibility.Visible;
            AddTickersBtnWhite.Visibility = Visibility.Hidden;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }

    }
}
