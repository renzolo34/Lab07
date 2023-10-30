using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BInvoice
    {
        public List<Invoice> GetByDate(DateTime date)
        {
            DInvoice data = new DInvoice();
            var invoices = data.Get();
            var result = invoices.Where(x=> x.Date == date).ToList();
            return result;
        }
        public List<Invoice> Get()
        {


            DInvoice data = new DInvoice();
            var invoices = data.Get();

            return invoices;
        }
        public bool Insert(Invoice newInvoice)
        {
            DInvoice data = new DInvoice();

            bool success = data.InsertInvocie(newInvoice);

            return success;
        }

        public bool DeactivateInvoice(int invoiceId)
        {
            DInvoice data = new DInvoice();
            return data.DeactivateInvoice(invoiceId);
        }
    }
}
