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

            DateTime searchDate = DatePickerSearch.SelectedDate ?? DateTime.MinValue;

            List<Invoice> filteredInvoices = bInvoice.GetByDate(searchDate.Date);

            ListViewInvoices.ItemsSource = filteredInvoices;
        }

    }
}
