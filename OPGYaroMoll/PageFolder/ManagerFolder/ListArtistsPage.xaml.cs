using OPGYaroMoll.ClassFolder;
using OPGYaroMoll.DataFolder;
using OPGYaroMoll.WindowFolder.ManagerFolder.ArtistsFolder;
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
    /// Логика взаимодействия для ListArtistsPage.xaml
    /// </summary>
    public partial class ListArtistsPage : Page
    {
        public ListArtistsPage()
        {
            Artists artists = new Artists();
            InitializeComponent();
            VariableClass.ListArtistsPage1 = this;
            UpdateList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        public void UpdateList()
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
          .Artists.Where(u => u.NameArtists
          .StartsWith(SearchTb.Text))
          .ToList().OrderBy(u => u.NameArtists);
        }

        private void EditArtistsBtn_Click(object sender, RoutedEventArgs e)
        {
            new EditArtistsWindow().Show();
        }

        private void DeleteArtists_Click(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сотрудника для удаления");
            }
            else
            {
                try
                {
                    Artists artists = membersDataGrid.SelectedItem as Artists;
                    if (MBClass.QuestionMB($"Удалить выбраного сотрудника?"))
                    {
                        object[] performance = DBEntities.GetContext().Performance.ToArray();

                        for (int i = 0; i < performance.Length; i++)
                        {
                            Performance performance1 = performance[i] as Performance;
                            if (performance1.IdArtists == artists.IdArtists)
                            {
                                performance1.IdArtists = null;

                                DBEntities.GetContext().SaveChanges();

                            }
                        }

                        object[] user = DBEntities.GetContext().User.ToArray();

                        for (int i = 0; i < user.Length; i++)
                        {
                            User user1 = user[i] as User;
                            if (user1.IdArtists == artists.IdArtists)
                            {
                                user1.IdArtists = null;

                                DBEntities.GetContext().SaveChanges();

                            }
                        }
                        DBEntities.GetContext().SaveChanges();
                        DBEntities.GetContext().Artists.Remove(artists);

                        DBEntities.GetContext().SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                membersDataGrid.ItemsSource = DBEntities.GetContext().Artists.ToList();
            }
        }

        private void AddArtistsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
