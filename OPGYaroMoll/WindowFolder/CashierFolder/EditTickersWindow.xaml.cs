using OPGYaroMoll.ClassFolder;
using OPGYaroMoll.DataFolder;
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
    /// Логика взаимодействия для EditTickersWindow.xaml
    /// </summary>
    public partial class EditTickersWindow : Window
    {
        Visitors visitors = new Visitors();
        public EditTickersWindow(Visitors visitors)
        {
            InitializeComponent();
            DataContext = visitors;
            this.visitors.IdVisitors = visitors.IdVisitors;
            SeatNumderCb.ItemsSource = DBEntities.GetContext()
                .Ticket.ToList();
        }

        private void SaveVisitorsBtn_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                visitors = DBEntities.GetContext().Visitors
                    .FirstOrDefault(u => u.IdVisitors == visitors.IdVisitors);
                visitors.ComleteNameVisitors = CompleteNameVisitorsTb.Text;
                visitors.EmailVisitors = EmailVisitorTb.Text;
                visitors.NumberPhoneVisitors = NumberPhoneVisitorsTb.Text;
                visitors.IdTicket = Int32.Parse(SeatNumderCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                if (VariableClass.ListCashierPage1 != null) VariableClass.ListCashierPage1.UpdateList();
                //if (VariableClass.AddTickersBtn_Click2 != null) VariableClass.AddTickersBtn_Click2.UpdateList();
                Close();
            }
            catch(Exception ex)  
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
