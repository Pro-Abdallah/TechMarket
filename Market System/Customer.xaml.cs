using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace Market_System
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        TechMartEntities db = new TechMartEntities();

        public Customer()
        {
            InitializeComponent();

        }

        public void Insert_Click(object sender, RoutedEventArgs e)
        {
            Customers customer = new Customers();

            customer.FullName = NameBox.Text;
            customer.Phone = int.Parse(PhoneBox.Text);
            customer.Email = EmailBox.Text;
            customer.Adress = AdressBox.Text;

            db.Customers.Add(customer);
            db.SaveChanges();
        }



        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();
            int ID = int.Parse(IDBox.Text);
            customers = db.Customers.Remove(db.Customers.First(x => x.CustomerID == ID));
            db.SaveChanges();



        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ListDG.ItemsSource = db.Customers;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();
            int ID = int.Parse(IDBox.Text);
            customers = db.Customers.First(x => x.CustomerID == ID);

            customers.FullName = NameBox.Text;
            customers.Phone = int.Parse(PhoneBox.Text);
            customers.Email = EmailBox.Text;
            customers.Adress = AdressBox.Text;
            
            db.Customers.Add(customers);
            db.SaveChanges();
        }
    }
}

