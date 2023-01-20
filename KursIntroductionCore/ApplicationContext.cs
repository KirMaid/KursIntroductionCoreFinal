
using KursIntroduction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace KursIntroductionCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            //Database.EnsureDeleted();   // удаляем бд со старой схемой
            //Database.EnsureCreated();   // создаем бд с новой схемой
        }

        protected readonly IConfiguration Configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=trainzilla;Username=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.Id)
                                 .UseIdentityAlwaysColumn()
                                 .HasIdentityOptions(startValue: 10);
            modelBuilder.Entity<Fare>().Property(u => u.Id)
                                 .UseIdentityAlwaysColumn()
                                 .HasIdentityOptions(startValue: 10);
            modelBuilder.Entity<Flight>().Property(u => u.Id)
                                 .UseIdentityAlwaysColumn()
                                 .HasIdentityOptions(startValue: 10);
            modelBuilder.Entity<Train>().Property(u => u.Id)
                     .UseIdentityAlwaysColumn()
                     .HasIdentityOptions(startValue: 10);
            modelBuilder.Entity<Transaction>().Property(u => u.Id)
         .UseIdentityAlwaysColumn()
         .HasIdentityOptions(startValue: 10);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Fare> Fares { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Train> Trains { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }

}
