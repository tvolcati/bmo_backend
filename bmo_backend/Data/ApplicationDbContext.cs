namespace bmo_backend.Data
{
    using bmo_backend.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Machines> Machines { get; set; }
        public DbSet<Runnings> Runnings { get; set; }
        public DbSet<Vibration> Vibration { get; set; }
        public DbSet<Temperature> Temperature { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Temperature>()
                .HasKey(t => new { t.Id_running, t.Timestamp }); // Define a chave composta para Temperature

            modelBuilder.Entity<Vibration>()
                .HasKey(v => new { v.Id_running, v.Timestamp }); // Define a chave composta para Vibration

            base.OnModelCreating(modelBuilder);
        }
    }
}


