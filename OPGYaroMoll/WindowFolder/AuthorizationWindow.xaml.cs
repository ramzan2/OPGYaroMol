using OPGYaroMoll.ClassFolder;
using OPGYaroMoll.DataFolder;
using OPGYaroMoll.WindowFolder.CashierFolder;
using OPGYaroMoll.WindowFolder.ManagerFolder;
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

namespace OPGYaroMoll.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }


        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void AuthorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text;
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                txtPassword.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext()
                        .User.FirstOrDefault(u => u.LoginUser == LoginTb.Text);

                    if (user == null)
                    {
                        MBClass.ErrorMB("Введен не верный логин");
                        LoginTb.Focus();
                        return;
                    }
                    if (user.PasswordUser != txtPassword.Password)
                    {
                        MBClass.ErrorMB("Введен не верный пароль");
                        txtPassword.Focus();
                        return;
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            case 1:
                                new MenuCashierWindow(user).Show();
                                Close();
                                break;
                            case 2:
                                new MenuManagerWindow(user).Show();
                                Close();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }

            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
