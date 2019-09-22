using E_POS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_POS.DBContext
{
    public class PosContext : DbContext
    {
        public PosContext(DbContextOptions<PosContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"Server=CSNB0340\SQLEXPRESS;Database=EPOSDB;Trusted_Connection=True;");
        //}
        public DbSet<E_POS.Models.Invoice> Invoice { get; set; }
        public DbSet<E_POS.Models.InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<E_POS.Models.Item> Item { get; set; }
        public DbSet<E_POS.Models.ItemCatalog> ItemCatalog { get; set; }
        public DbSet<E_POS.Models.Vendor> Vendor { get; set; }
    }
}
