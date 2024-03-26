using ContactDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ContactDataAccess.Context
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public ContactsDbContext()
        {
            
        }

        public DbSet<ContactsModel> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=WILSON\\SQLEXPRESS;Database=Contacts;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactsModel>(
                entity =>
                {
                    entity.ToTable("Contacts_table");
                    entity.HasKey(e => e.ID);
                    entity.Property(e => e.ID);
                    entity.Property(e => e.FirstName);
                    entity.Property(e => e.LastName);
                    entity.Property(e => e.Email);
                    entity.Property(e => e.PhoneNumber);
                });
        }
    }
}
