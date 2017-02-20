namespace WebApplication17.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Quest : DbContext
    {
        public Quest()
            : base("name=Quest")
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(e => e.OrderType)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasOptional(e => e.Service)
                .WithRequired(e => e.Order);
        }
    }
}
