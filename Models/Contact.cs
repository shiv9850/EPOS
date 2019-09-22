using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_POS.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        //[Phone]
        public int Mobile { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        //[Phone]
        public int ALternateMobile { get; set; }
        public int Phone { get; set; }
    }
}
