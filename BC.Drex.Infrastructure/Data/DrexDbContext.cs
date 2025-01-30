using BC.Drex.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BC.Drex.Infrastructure.Data
{
    public class DrexDbContext : DbContext
    {
        public DrexDbContext(DbContextOptions<DrexDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransferLog> WalletTransferLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region -> User
            var userId = Guid.NewGuid();
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            //Seed data
            modelBuilder.Entity<User>().HasData(
                new User { Id = userId, Name = "admin", Email = "admin@bc.com", Password = BCrypt.Net.BCrypt.HashPassword("admin@123") }
            );
            #endregion

            #region -> Wallet
            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            //Seed data
            modelBuilder.Entity<Wallet>().HasData(
                new Wallet { Id = Guid.NewGuid(), Active = true, Amount = 5000, UserId = userId }
            );
            #endregion

            #region -> Wallet Transfer Log
            modelBuilder.Entity<WalletTransferLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            #endregion
        }
    }
}
