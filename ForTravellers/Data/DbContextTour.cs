using ForTravellers.Models;
using Microsoft.EntityFrameworkCore;

namespace ForTravellers.Data
{
    public class DbContextTour : DbContext
    {

        public DbContextTour(DbContextOptions<DbContextTour> options) : base(options)
        {
        }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Pkg> Packages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ForTravellers.Models.LoginVm> LoginVm { get; set; } = default!;
        public DbSet<ForTravellers.Models.RegistrationVm> RegistrationVm { get; set; } = default!;
    }
}
