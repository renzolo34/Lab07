using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Invoice
    {
        public int Invoice_Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public bool Active { get; set; }
         
        // Relación con la tabla 'customers'
        public Customer Customer { get; set; }
    }
}
