using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_POS.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        [Required]
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        //public Contact Contact { get; set; }
        //public  List<Address> Addresses { get; set; }
    }
}
