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
    /// Логика взаимодействия для AddTickersWindow.xaml
    /// </summary>
    public partial class AddTickersWindow : Window
    {
        public AddTickersWindow()
        {
            Visitors visitors = new Visitors();
            InitializeComponent();
            SeatNumderCb.ItemsSource = DBEntities.GetContext()
                .Ticket.ToList();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (VariableClass.AddTickersBtn_Click2 != null) VariableClass.AddTickersBtn_Click2.UpdateList();
            Close();
        }

        private void AddVisitorsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CompleteNameVisitorsTb.Text))
            {
                MBClass.ErrorMB("Введите ФИО посетителя");
                CompleteNameVisitorsTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(EmailVisitorTb.Text))
            {
                MBClass.ErrorMB("Введите почту посетителя");
                EmailVisitorTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(NumberPhoneVisitorsTb.Text))
            {
                MBClass.ErrorMB("Введите номер телефона");
                NumberPhoneVisitorsTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(SeatNumderCb.Text))
            {
                MBClass.ErrorMB("Выберите билет");
                SeatNumderCb.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Visitors.Add(new Visitors()
                    {
                        ComleteNameVisitors = CompleteNameVisitorsTb.Text,
                        EmailVisitors = EmailVisitorTb.Text,
                        NumberPhoneVisitors = NumberPhoneVisitorsTb.Text,
                        IdTicket = Int32.Parse(SeatNumderCb.SelectedValue.ToString())
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Посетитель успешно добавлен");
                    if (VariableClass.ListCashierPage1 != null) VariableClass.ListCashierPage1.UpdateList();
                    if (VariableClass.AddTickersBtn_Click2 != null) VariableClass.AddTickersBtn_Click2.UpdateList();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                    throw;

                }
                Close();
            }
        }
    }
}

