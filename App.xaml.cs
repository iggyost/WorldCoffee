using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WorldCoffee.Model;

namespace WorldCoffee
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static WorldCoffeeDbEntities context = new WorldCoffeeDbEntities();
        public static CoffeeHouses selectedHouse = new CoffeeHouses();
        public static Employees selectedEmployee = new Employees();
        public static Users enteredUser = new Users();
    }
}
