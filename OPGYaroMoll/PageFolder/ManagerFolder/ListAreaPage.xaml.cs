using OPGYaroMoll.ClassFolder;
using OPGYaroMoll.DataFolder;
using OPGYaroMoll.WindowFolder.ManagerFolder.AreaFolder;
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

namespace OPGYaroMoll.PageFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для ListAreaPage.xaml
    /// </summary>
    public partial class ListAreaPage : Page
    {
        public ListAreaPage()
        {
            Area area = new Area();
            InitializeComponent();
            VariableClass.ListAreaPage1 = this;
            UpdateList();
        }

        private void AddAreaBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        public void UpdateList() 
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
          .Area.Where(u => u.NameArea
          .StartsWith(SearchTb.Text))
          .ToList().OrderBy(u => u.NameArea);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        private void EditAreaBtn_Click(object sender, RoutedEventArgs e)
        {
            new EditAreaWindow().Show();
        }

        private void DeleteArea_Click(object sender, RoutedEventArgs e)
        {
            Area area = membersDataGrid.SelectedItem as Area;

            if (membersDataGrid.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите артиста" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"площадку " +
                    $"{area.NameArea}?"))
                {
                    DBEntities.GetContext().Area
                        .Remove(membersDataGrid.SelectedItem as Area);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Представление удаленно");
                    membersDataGrid.ItemsSource = DBEntities.GetContext()
                        .Area.ToList().OrderBy(u => u.NameArea);
                }

            }
        }
    }
}
