using OPGYaroMoll.ClassFolder;
using OPGYaroMoll.DataFolder;
using OPGYaroMoll.WindowFolder.CashierFolder;
using OPGYaroMoll.WindowFolder.ManagerFolder.PerformanceFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

namespace OPGYaroMoll.PageFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для ListPerformancePage.xaml
    /// </summary>
    public partial class ListPerformancePage : Page
    {
        public ListPerformancePage()
        {
            Performance performance = new Performance();
            InitializeComponent();
            VariableClass.ListPerformancePage1 = this;
            UpdateList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        public void UpdateList()
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
          .Performance.Where(u => u.TitlePerformance
          .StartsWith(SearchTb.Text))
          .ToList().OrderBy(u => u.TitlePerformance);
            //if (VariableClass.AddTickersBtn_Click2 != null) VariableClass.AddTickersBtn_Click2.UpdateList();
        }

        private void EditPerformanceBtn_Click(object sender, RoutedEventArgs e)
        {
            new EditPerformanceWindow(membersDataGrid.SelectedItem as Performance).Show();
            UpdateList();
        }

        private void DeletePerformance_Click(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сотрудника для удаления");
            }
            else
            {
                try
                {
                    Performance performance = membersDataGrid.SelectedItem as Performance;
                    if (MBClass.QuestionMB($"Удалить выбраного сотрудника?"))
                    {
                        object[] ticket = DBEntities.GetContext().Ticket.ToArray();

                        for (int i = 0; i < ticket.Length; i++)
                        {
                            Ticket ticket1 = ticket[i] as Ticket;
                            if (ticket1.IdPerformance == performance.IdPerformance)
                            {
                                ticket1.IdPerformance = null;

                                DBEntities.GetContext().SaveChanges();

                            }
                        }
                        DBEntities.GetContext().SaveChanges();
                        DBEntities.GetContext().Performance.Remove(performance);

                        DBEntities.GetContext().SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                membersDataGrid.ItemsSource = DBEntities.GetContext().Performance.ToList();
            }
        }

        private void AddPerformanceBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddPerformanceWindow().Show();
        }
    }
}
