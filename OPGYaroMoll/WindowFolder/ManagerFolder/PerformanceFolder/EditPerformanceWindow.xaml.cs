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
    /// Логика взаимодействия для EditPerformanceWindow.xaml
    /// </summary>
    public partial class EditPerformanceWindow : Window
    {
        Performance performance = new Performance();
        public EditPerformanceWindow(Performance performance)
        {
            InitializeComponent();
            DataContext = performance;
            this.performance.IdPerformance = performance.IdPerformance;
            ArtistsCb.ItemsSource = DBEntities.GetContext()
                .Artists.ToList();
            AreaCb.ItemsSource = DBEntities.GetContext()
            .Area.ToList();
        }

        private void SavePerformanceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                performance = DBEntities.GetContext().Performance
                   .FirstOrDefault(u => u.IdPerformance == performance.IdPerformance);
                performance.TitlePerformance = TitlePerformanceTb.Text;
                performance.DatePerformance = Convert.ToDateTime(DatePerformance.SelectedDate);
                performance.TicketPrice = Convert.ToDecimal(PriceTicketDb.Text);
                performance.IdArtists = Convert.ToInt32(ArtistsCb.SelectedValue);
                performance.IdArea = Convert.ToInt32(AreaCb.SelectedValue);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                if (VariableClass.ListPerformancePage1 != null) VariableClass.ListPerformancePage1.UpdateList();
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
