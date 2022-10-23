using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }
        //public DbSet<Root> Root { get; set; }
        //public DbSet<Header> Header { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<Customer>().HasMany(x => x.Phones);
            modelBuilder.Entity<Customer>().HasMany(x => x.Emails);
            modelBuilder.Entity<Root>().HasNoKey();
        }
    }
}
