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

namespace Bd_3._4
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        MainWindow main;
        public AddOrder(MainWindow main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void Save_B_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                main.order.RoomId = int.Parse(RoomIdTextBox.Text);
                main.order.Arrival = ArrivalDate.SelectedDate;
                main.order.Departure = DepartureDate.SelectedDate;
                main.order.IsActive = (bool)(is_Active.IsChecked);
                main.order.Sum = decimal.Parse(SumTextBox.Text);
                main.order.DateOfBooking = BookingDate.SelectedDate;
                if (main.CheckOrder(main.order))
                    this.Close();
                else
                    MessageBox.Show("Incorrect Data!");
            }
            catch
            {
                MessageBox.Show("Something goes wrong!");
            }
        }

        private void Cancel_B_Click(object sender, RoutedEventArgs e)
        {
            main.order = null;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RoomIdTextBox.Text = "";
            DepartureDate = null;
            ArrivalDate = null;
            is_Active.IsChecked = false;
            BookingDate = null;
            SumTextBox.Text = "";
        }
    }
}
