using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_POS.Models
{
    public class Item
    {
        public int Id { get; set; }

        public int CatalogId { get; set; }

        public string Name { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SalingPrice { get; set; }

        public string Category { get; set; }

        public string Size { get; set; }
        public Units Unit { get; set; } = Units.Piece;
        public int VendorId { get; set; }
    }
}
