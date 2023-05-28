using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using WorldCoffee.Model;

namespace WorldCoffee.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
            coffeeHousesCmb.ItemsSource = App.context.CoffeeHouses.ToList();
            employeeControlGrid.Visibility = Visibility.Collapsed;
            postCmb.ItemsSource = App.context.Posts.ToList();
            enteredAdminTbl.Text = App.enteredUser.name;
        }

        private void coffeeHousesCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            searchEmployeeTb.Text = string.Empty;
            App.selectedHouse = coffeeHousesCmb.SelectedItem as CoffeeHouses;
            EmployeesLb.ItemsSource = App.context.Employees.Where(em => em.coffeehouse_id == App.selectedHouse.id).ToList();
            searchEmployeeTb.IsEnabled = true;
        }

        private void EmployeesLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedEmployee = EmployeesLb.SelectedItem as Employees;
            this.DataContext = App.selectedEmployee;
            if (App.selectedEmployee != null)
            {
                postCmb.SelectedIndex = App.selectedEmployee.post_id - 1;
                employeeControlGrid.Visibility = Visibility.Visible;
                if (App.selectedEmployee.is_works == true)
                {
                    isWorksTbl.Text = "Да";
                }
                else
                {
                    isWorksTbl.Text = "Нет";
                }
            }
            else
            {
                employeeControlGrid.Visibility = Visibility.Collapsed;
                isWorksTbl.Text = string.Empty;
            }
        }

        private void isWorksTbl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void setVacationBtn_Click(object sender, RoutedEventArgs e)
        {
            CalendarWindow calendarWindow = new CalendarWindow();
            calendarWindow.ShowDialog();
            if (calendarWindow.DialogResult == true)
            {
                this.DataContext = null;
                this.DataContext = App.selectedEmployee;
            }
        }

        private void clearVacationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectedEmployee.vacation_start != null)
            {
                App.selectedEmployee.vacation_start = null;
                App.selectedEmployee.vacation_end = null;
                App.context.Entry(App.selectedEmployee).State = System.Data.EntityState.Modified;
                App.context.SaveChanges();
                this.DataContext = null;
                this.DataContext = App.selectedEmployee;
            }
        }

        private void delayMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectedEmployee.delay_count != 0)
            {
                App.selectedEmployee.delay_count -= 1;
                App.context.Entry(App.selectedEmployee).State = System.Data.EntityState.Modified;
                App.context.SaveChanges();
                this.DataContext = null;
                this.DataContext = App.selectedEmployee;
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void delayPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            App.selectedEmployee.delay_count += 1;
            App.context.Entry(App.selectedEmployee).State = System.Data.EntityState.Modified;
            App.context.SaveChanges();
            this.DataContext = null;
            this.DataContext = App.selectedEmployee;
        }

        private void truancyMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectedEmployee.truancy_count != 0)
            {
                App.selectedEmployee.truancy_count -= 1;
                App.context.Entry(App.selectedEmployee).State = System.Data.EntityState.Modified;
                App.context.SaveChanges();
                this.DataContext = null;
                this.DataContext = App.selectedEmployee;
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void truancyPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            App.selectedEmployee.truancy_count += 1;
            App.context.Entry(App.selectedEmployee).State = System.Data.EntityState.Modified;
            App.context.SaveChanges();
            this.DataContext = null;
            this.DataContext = App.selectedEmployee;
        }

        private void hospitalMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectedEmployee.hospital_count != 0)
            {
                App.selectedEmployee.hospital_count -= 1;
                App.context.Entry(App.selectedEmployee).State = System.Data.EntityState.Modified;
                App.context.SaveChanges();
                this.DataContext = null;
                this.DataContext = App.selectedEmployee;
            }
            else
            {
                SystemSounds.Beep.Play();
            }

        }

        private void hospitalPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            App.selectedEmployee.hospital_count += 1;
            App.context.Entry(App.selectedEmployee).State = System.Data.EntityState.Modified;
            App.context.SaveChanges();
            this.DataContext = null;
            this.DataContext = App.selectedEmployee;
        }

        private void searchEmployeeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (coffeeHousesCmb.SelectedIndex != -1)
            {
                App.selectedHouse = coffeeHousesCmb.SelectedItem as CoffeeHouses;
                EmployeesLb.ItemsSource = App.context.Employees.Where(em => em.coffeehouse_id == App.selectedHouse.id && em.name.Contains(searchEmployeeTb.Text)).ToList();
            }
        }

        private void searchEmployeeTb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (coffeeHousesCmb.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите кофейню!");
                searchEmployeeTb.IsEnabled = false;
            }
        }

        private void postCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedEmployee.post_id = postCmb.SelectedIndex + 1;
            App.context.Entry(App.selectedEmployee).State = System.Data.EntityState.Modified;
            App.context.SaveChanges();
            this.DataContext = null;
            this.DataContext = App.selectedEmployee;
        }

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            App.enteredUser = null;
            this.Close();
        }

        private void aboutCoffeeHouses_Click(object sender, RoutedEventArgs e)
        {
            AboutCoffeeHousesWindow aboutCoffeeHousesWindow = new AboutCoffeeHousesWindow();
            aboutCoffeeHousesWindow.ShowDialog();
        }
    }
}
