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

namespace OPGYaroMoll.WindowFolder.ManagerFolder.PerformanceFolder
{
    /// <summary>
    /// Логика взаимодействия для AddPerformanceWindow.xaml
    /// </summary>
    public partial class AddPerformanceWindow : Window
    {
        public AddPerformanceWindow()
        {
            Performance performance = new Performance();
            InitializeComponent();
            ArtistsCb.ItemsSource = DBEntities.GetContext()
                .Artists.ToList();
            AreaCb.ItemsSource = DBEntities.GetContext()
              .Area.ToList();
        }

        private void AddPerformanceBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().Performance.Add(new Performance()
            {
                TitlePerformance = TitlePerformanceTb.Text,
                DatePerformance = Convert.ToDateTime(DatePerformance.SelectedDate),
                TicketPrice = Convert.ToDecimal(PriceTicketTb.Text),
                IdArtists = Convert.ToInt32(ArtistsCb.SelectedValue),
                IdArea = Convert.ToInt32(AreaCb.SelectedValue)
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Представление успешно добавленно");
            if (VariableClass.ListPerformancePage1 != null) VariableClass.ListPerformancePage1.UpdateList();
            Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
