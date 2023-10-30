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
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db;User ID=renzolo;Password=123456";
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

        public bool InsertInvocie(Invoice newInvoice)
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Definir los parámetros del procedimiento almacenado
                    command.Parameters.Add(new SqlParameter("@customer_id", newInvoice.CustomerId));
                    command.Parameters.Add(new SqlParameter("@date", newInvoice.Date));
                    command.Parameters.Add(new SqlParameter("@total", newInvoice.Total));
                    command.Parameters.Add(new SqlParameter("@active", newInvoice.Active));

                    // Parámetro @active es opcional ya que tiene un valor por defecto en el procedimiento almacenado

                    try
                    {
                        int rowAffected = command.ExecuteNonQuery();

                        return rowAffected > 0;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }

            }

        }

        public bool DeactivateInvoice(int invoiceId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DeactivateInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar el parámetro @invoiceId
                    command.Parameters.Add(new SqlParameter("@invoiceId", invoiceId));

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; 
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
