using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Program.DAL
{
    public partial class BuyerContext : DbContext
    {
        public BuyerContext()
            : base("name=BuyerContext")
        {
        }

        public virtual DbSet<Bureau> Bureau { get; set; }
        public virtual DbSet<BureauBuyer> BureauBuyer { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<InfoBuyer> InfoBuyer { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketType> TicketType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bureau>()
                .Property(e => e.AddressBureau)
                .IsUnicode(false);

            modelBuilder.Entity<Bureau>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Bureau>()
                .HasMany(e => e.BureauBuyer)
                .WithRequired(e => e.Bureau)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Buyer>()
                .Property(e => e.BuyerName)
                .IsUnicode(false);

            modelBuilder.Entity<Buyer>()
                .HasMany(e => e.BureauBuyer)
                .WithRequired(e => e.Buyer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Buyer>()
                .HasOptional(e => e.InfoBuyer)
                .WithRequired(e => e.Buyer);

            modelBuilder.Entity<InfoBuyer>()
                .Property(e => e.PlaceOfCreation)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Buyer)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TicketType>()
                .Property(e => e.DiscountSize)
                .HasPrecision(3, 2);

            modelBuilder.Entity<TicketType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TicketType>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.TicketType)
                .WillCascadeOnDelete(false);
        }
    }
}
