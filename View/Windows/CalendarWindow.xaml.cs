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
    /// Логика взаимодействия для CalendarWindow.xaml
    /// </summary>
    public partial class CalendarWindow : Window
    {
        public CalendarWindow()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void acceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (start != null && end != null)
            {
                if (start < DateTime.Now)
                {
                    MessageBox.Show("Дата начала отпуска не может начинаться раньше чем сегодняшняя дата!");
                }
                else
                {
                    App.selectedEmployee.vacation_start = start;
                    App.selectedEmployee.vacation_end = end;
                    App.context.Entry(App.selectedEmployee).State = System.Data.EntityState.Modified;
                    App.context.SaveChanges();
                    this.DialogResult = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Выделите 2 даты!");
            }
        }
        DateTime start;
        DateTime end;
        private void vacationCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            start = vacationCalendar.SelectedDates.First();
            end = vacationCalendar.SelectedDates.Last();
            var dateStart = start.Day + "." + start.Month + "." + start.Year;
            var dateEnd = end.Day + "." + end.Month + "." + end.Year;
            vacationStartTbl.Text = dateStart;
            vacationEndTbl.Text = dateEnd;
        }
    }
}
