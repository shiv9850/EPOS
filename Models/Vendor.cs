using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_POS.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vendortype { get; set; }
        public Contact Contact { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
