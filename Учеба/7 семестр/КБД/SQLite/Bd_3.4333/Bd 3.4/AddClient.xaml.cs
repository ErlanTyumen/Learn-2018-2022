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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        MainWindow main;
        
        public AddClient(MainWindow main)
        {
            this.main = main;   
            InitializeComponent();
        }

        private void Save_B_Click(object sender, RoutedEventArgs e)
        {
            DateTime formatted;
            main.client.Name = nameTextBox.Text;
            main.client.SecondName = secondNameTextBox.Text;          
            DateTime? selectedDate = DatePickerBirthday.SelectedDate;
            if (selectedDate.HasValue)
            {
                formatted = selectedDate.Value;
                main.client.Dob = formatted;
            }
            
            this.Close();
        }

        private void Cancel_B_Click(object sender, RoutedEventArgs e)
        {
            main.client = null;
            this.Close();
        }

        private void Cancel_B_Click(object sender, System.ComponentModel.CancelEventArgs e)
        {
            main.client = null;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            nameTextBox.Text = "";
            secondNameTextBox.Text = "";
            DatePickerBirthday = null;           
        }
    }
}
