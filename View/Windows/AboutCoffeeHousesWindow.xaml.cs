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
    /// Логика взаимодействия для AboutCoffeeHousesWindow.xaml
    /// </summary>
    public partial class AboutCoffeeHousesWindow : Window
    {
        public AboutCoffeeHousesWindow()
        {
            InitializeComponent();
            coffeeHousesLb.ItemsSource = App.context.CoffeeHouses.ToList();
        }

        private void employeesCount_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock employeesCount = (TextBlock)sender;
            int index = int.Parse(employeesCount.Tag.ToString());
            employeesCount.Text = App.context.Employees.Where(em => em.coffeehouse_id == index).Count().ToString();
        }
    }
}
