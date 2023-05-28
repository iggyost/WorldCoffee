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

namespace WorldCoffee.View.Windows
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

        private void enterBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = App.context.Users.Where(u => u.login == loginTb.Text && u.password == passwordPb.Password).FirstOrDefault();
            if (user != null)
            {
                App.enteredUser = user;
                EmployeeWindow employeeWindow = new EmployeeWindow();
                employeeWindow.Show();
                this.Close();
            }
            else
            {
                errorAuthorizationTbl.Text = "Администратор не найден!";
            }
        }

        private void loginTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorAuthorizationTbl.Text = string.Empty;
        }

        private void passwordPb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            errorAuthorizationTbl.Text = string.Empty;
        }
    }
}
