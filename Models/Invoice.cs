using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_POS.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public string Type { get; set; }
        public string TransactionId { get; set; }
        [Required]
        public string PaymentMode { get; set; }
        public string Remark { get; set; }
        [Required]
        public string PaidAmount { get; set; }
        public string BalanceAmount { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public virtual List<InvoiceDetails> InvoiceDetails { get; set; } 

    }
}
