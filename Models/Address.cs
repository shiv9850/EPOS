using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_POS.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public string ThirdLine { get; set; }
        public string Taluka { get; set; }
        public string Distict { get; set; }
        public string State { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public int PinCode { get; set; }

    }
}
