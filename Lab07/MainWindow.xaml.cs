using Business;
using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

namespace Lab07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DInvoice dInvoice = new DInvoice();
        private BInvoice bInvoice = new BInvoice();

        public MainWindow()
        {
            InitializeComponent();
            LoadInvoices();
            
        }
        private void LoadInvoices()
        {
            List<Invoice> invoices = dInvoice.Get();

            // Asigna la lista de facturas al ListView
            ListViewInvoices.ItemsSource = invoices;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDateTime = DateTimePickerSearch.Value ?? DateTime.MinValue;

            List<Invoice> filteredInvoices = bInvoice.GetByDate(selectedDateTime);

            ListViewInvoices.ItemsSource = filteredInvoices;
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            int customerId = int.Parse(CustomerIdTextBox.Text);
            DateTime date = InsertDate.Value ?? DateTime.Now;
            decimal total = decimal.Parse(TotalTextBox.Text);
            bool active = ActiveCheckBox.IsChecked ?? true; 

            Invoice newInvoice = new Invoice
            {
                CustomerId = customerId,
                Date = date,
                Total = total,
                Active = active
            };

            BInvoice bInvoice = new BInvoice();

            bool insertionResult = bInvoice.Insert(newInvoice);

            if (insertionResult)
            {
                CustomerIdTextBox.Clear();
                InsertDate.Value = DateTime.Now;
                TotalTextBox.Clear();
                ActiveCheckBox.IsChecked = true;
            }
            else
            {
              
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(InvoiceIdToDeleteTextBox.Text, out int invoiceId))
            {
                BInvoice bInvoice = new BInvoice();
                bool deactivationResult = bInvoice.DeactivateInvoice(invoiceId);

                if (deactivationResult)
                {

                }
                else
                {

                }

                InvoiceIdToDeleteTextBox.Clear();
            }
            else
            {

            }
        }
    }
}
