using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_POS.Models
{
    public class InvoiceDetails
    {
        public int Id { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public int ItemId { get; set; }
        public int ItemQunatity { get; set; }
        public Item Item { get; set; }
        public decimal Discount { get; set; }
    }
}
