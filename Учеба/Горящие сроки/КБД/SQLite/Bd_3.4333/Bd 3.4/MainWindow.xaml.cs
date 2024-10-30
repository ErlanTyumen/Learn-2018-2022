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
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;

namespace Bd_3._4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly hotelsContext _context = new hotelsContext();
        private CollectionViewSource clientsViewSource;
        private CollectionViewSource clientsOrdersViewSource;
        public Client client;
        public Order order;
        public MainWindow()
        {
            InitializeComponent();
            clientsViewSource = (CollectionViewSource)FindResource(nameof(clientsViewSource));
            clientsOrdersViewSource = (CollectionViewSource)FindResource(nameof(clientsOrdersViewSource));
        }
        private void Window_Loaded(object sender,RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Clients.Load();
            _context.Orders.Load();
            clientsViewSource.Source = _context.Clients.Local.ToObservableCollection();
            clientsOrdersViewSource.Source = _context.Orders.Local.ToObservableCollection();
            
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client = new Client();
                
                AddClient form = new AddClient(this);
                form.ShowDialog();
                
                if(client!=null)
                {
                    _context.Clients.Add(client);
                    _context.SaveChanges();
                    clientsViewSource.View.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Something goes wrong");
                clientsViewSource.View.Refresh();
            }
        }

        private void deleteClient_Click(object sender, RoutedEventArgs e)
        {
            Client dClient = clientDataGrid.SelectedItem as Client;
            DeleteAllOrders(dClient);
            _context.Clients.Local.Remove(dClient);
            MessageBox.Show("Deleted!");
            clientsViewSource.View.Refresh();
            _context.SaveChanges();
        }

        private void updateClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clientDataGrid.SelectedItem != null)
                {
                    _context.SaveChanges();
                    clientDataGrid.CommitEdit();                  
                    clientsViewSource.View.Refresh();                 
                    MessageBox.Show("Update!");

                }
            }
            catch
            {
                MessageBox.Show("Something goes wrong with update!");
            }
        }

        private void clientDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client selected;
            try
            {
                selected = ((Client)(clientDataGrid.SelectedItem));

            }
            catch
            {

                orderDataGrid.Visibility = System.Windows.Visibility.Hidden;
                addOrder.Visibility = System.Windows.Visibility.Hidden;
                updateOrder.Visibility = System.Windows.Visibility.Hidden;
                deleteOrder.Visibility = System.Windows.Visibility.Hidden;
                return;
            }
            if (selected != null)
            {
                orderDataGrid.Visibility = System.Windows.Visibility.Visible;
                addOrder.Visibility = System.Windows.Visibility.Visible;
                updateOrder.Visibility = System.Windows.Visibility.Visible;
                deleteOrder.Visibility = System.Windows.Visibility.Visible;
                clientsOrdersViewSource.Source = (selected.Orders);
                clientsOrdersViewSource.View.Refresh();
            }

        }

        private void DeleteAllOrders(Client client)
        {
            var ordfordelete = client.Orders;
            foreach (Order item in ordfordelete.ToArray())
                _context.Orders.Local.Remove(item);
            _context.SaveChanges();
        }

        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                order = new Order();
                AddOrder form = new AddOrder(this);
                form.ShowDialog();
                client = (Client)clientDataGrid.SelectedItem;
                order.ClientId = client.ClientId;
                
                _context.Orders.Local.Add(order);
                MessageBox.Show("Order added!");
                _context.SaveChanges();
                orderDataGrid.CommitEdit();
                orderDataGrid.CommitEdit();
                clientsOrdersViewSource.View.Refresh();
                clientsOrdersViewSource.View.MoveCurrentTo(client);
               
              
            }
            catch
            {
                MessageBox.Show("Something goes wrong");
                clientsViewSource.View.Refresh();
            }
        }

        private void updateOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckOrder(orderDataGrid.SelectedItem as Order))
                {
                    _context.SaveChanges();
                    orderDataGrid.CommitEdit();
                    orderDataGrid.CommitEdit();
                    clientsOrdersViewSource.View.Refresh();
                    clientsOrdersViewSource.View.MoveCurrentTo(order);
                    MessageBox.Show("Update!");
                }
                else
                {
                    MessageBox.Show("Incorrect Data!");
                }
            }
            catch
            {
                MessageBox.Show("Something goes wrong with update!");
            }
            
        }

        private void deleteOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order dOrder = orderDataGrid.SelectedItem as Order;
                _context.Orders.Local.Remove(dOrder);
                MessageBox.Show("Deleted!");
                _context.SaveChanges();
                clientsOrdersViewSource.View.Refresh();


            }
            catch
            {
                MessageBox.Show("Something goes wrong with delete");
            }
        }

        public bool CheckOrder(Order order)
        {
            bool check = false;
            if (order == null)
                return check;
            if (order.Arrival > order.Departure)
                return check;
            if (!order.IsActive && (order.Arrival < order.DateOfBooking))
                return check;
            if (order.Sum <= 0)
                return check;
            foreach (Room item in _context.Rooms)
            {
                if (order.RoomId == item.RoomId)
                    check = true;
            }
            return check;
        }
    }
}
