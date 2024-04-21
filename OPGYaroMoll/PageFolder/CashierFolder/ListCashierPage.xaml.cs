using OPGYaroMoll.ClassFolder;
using OPGYaroMoll.DataFolder;
using OPGYaroMoll.WindowFolder.CashierFolder;
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

namespace OPGYaroMoll.PageFolder.CashierFolder
{
    /// <summary>
    /// Логика взаимодействия для ListCashierPage.xaml
    /// </summary>
    public partial class ListCashierPage : Page
    {
        public ListCashierPage()
        {
            Visitors visitors = new Visitors(); 
            InitializeComponent();
            VariableClass.ListCashierPage1 = this;
            UpdateList();
        }

        public void UpdateList()
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
          .Visitors.Where(u => u.ComleteNameVisitors
          .StartsWith(LoginTb.Text))
          .ToList().OrderBy(u => u.ComleteNameVisitors);
          //if (VariableClass.AddTickersBtn_Click2 != null) VariableClass.AddTickersBtn_Click2.UpdateList();
        }

        private void LoginTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        private void DeletUser_Click(object sender, RoutedEventArgs e)
        {
            Visitors visitors = membersDataGrid.SelectedItem as Visitors;
            if (membersDataGrid.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите посетителя" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"посетителя " +
                    $"{visitors.ComleteNameVisitors}?"))
                {
                    DBEntities.GetContext().Visitors
                        .Remove(membersDataGrid.SelectedItem as Visitors);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Посетитель удален");
                    membersDataGrid.ItemsSource = DBEntities.GetContext()
                        .Visitors.ToList().OrderBy(u => u.ComleteNameVisitors);
                }

            }
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            new EditTickersWindow(membersDataGrid.SelectedItem as Visitors).Show();
            UpdateList();
        }

        private void membersDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
