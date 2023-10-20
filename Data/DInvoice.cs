using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DInvoice
    {
        private readonly string connectionString = "Data Source=LAB1504-31\\SQLEXPRESS;Initial Catalog=db;User ID=renzo;Password=123456";
        public List<Invoice> Get()
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ListInvoices", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Invoice invoice = new Invoice
                            {
                                Invoice_Id = (int)reader["invoice_id"],
                                CustomerId = (int)reader["customer_id"],
                                Date = (DateTime)reader["date"],
                                Total = (decimal)reader["total"],
                                Active = (bool)reader["active"]
                            };
                            invoices.Add(invoice);
                        }
                    }
                }
            }

            return invoices;
        }
    }
}
