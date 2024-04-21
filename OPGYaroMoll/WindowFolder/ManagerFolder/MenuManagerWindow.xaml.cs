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

namespace OPGYaroMoll.WindowFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuManagerWindow.xaml
    /// </summary>
    public partial class MenuManagerWindow : Window
    {
        public MenuManagerWindow(DataFolder.User user)
        {
            InitializeComponent();
            DataContext = user;
            MainFrame.Navigate(new PageFolder.ManagerFolder.ListPerformancePage());
        }


        private void ListPerformance_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.ManagerFolder.ListPerformancePage());
            ListPerformance.Visibility = Visibility.Hidden;
            ListPerformanceBtnWhite.Visibility = Visibility.Visible;
            ListArtistsBtn.Visibility = Visibility.Visible;
            ListArtistsBtnWhite.Visibility = Visibility.Hidden;
            ListAreaBtn.Visibility = Visibility.Visible;
            ListAreaBtnWhite.Visibility = Visibility.Hidden;
        }

        private void ListArtistsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.ManagerFolder.ListArtistsPage());
            ListArtistsBtn.Visibility = Visibility.Hidden;
            ListArtistsBtnWhite.Visibility = Visibility.Visible;
            ListPerformance.Visibility = Visibility.Visible;
            ListPerformanceBtnWhite.Visibility = Visibility.Hidden;
            ListAreaBtn.Visibility = Visibility.Visible;
            ListAreaBtnWhite.Visibility = Visibility.Hidden;
        }

        private void ListAreaBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.ManagerFolder.ListAreaPage());
            ListAreaBtn.Visibility = Visibility.Hidden;
            ListAreaBtnWhite.Visibility = Visibility.Visible;
            ListPerformance.Visibility = Visibility.Visible;
            ListPerformanceBtnWhite.Visibility = Visibility.Hidden;
            ListArtistsBtn.Visibility = Visibility.Visible;
            ListArtistsBtnWhite.Visibility = Visibility.Hidden;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
