using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_POS.Models
{
    public class ItemCatalog
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public Units Unit { get; set; } = Units.Piece;
        public bool Hidden { get; set; } = false;
    }
}
