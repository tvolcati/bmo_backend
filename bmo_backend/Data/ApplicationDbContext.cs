using bmo_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace bmo_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Machines> Machines { get; set; }
        public DbSet<Runnings> Runnings { get; set; }
        public DbSet<Temperature> Temperature { get; set; }
        public DbSet<Distance> Distance { get; set; }
        public DbSet<Vibration> Vibration { get; set; }
        public DbSet<Compressor> Compressors { get; set; }
        public DbSet<CompressorRunning> CompressorRunnings { get; set; }
        public DbSet<Prensa> Prensas { get; set; }
        public DbSet<PrensaRunning> PrensaRunnings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da tabela Machines
            modelBuilder.Entity<Machines>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Machines>()
                .Property(m => m.Id)
                .ValueGeneratedNever(); // Desativa o autoincremento

            // Configuração da tabela Runnings
            modelBuilder.Entity<Runnings>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Runnings>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd(); // Ativa o autoincremento

            modelBuilder.Entity<Runnings>()
                .HasOne<Machines>()
                .WithMany()
                .HasForeignKey(r => r.Id_Machine);

            // Configuração das tabelas de série temporal com chave primária "id"
            modelBuilder.Entity<Temperature>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Temperature>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd(); // Ativa o autoincremento

            modelBuilder.Entity<Distance>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Distance>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd(); // Ativa o autoincremento

            modelBuilder.Entity<Vibration>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Vibration>()
                .Property(v => v.Id)
                .ValueGeneratedOnAdd(); // Ativa o autoincremento

            // Configuração de chaves estrangeiras
            modelBuilder.Entity<Temperature>()
                .HasOne<Runnings>()
                .WithMany()
                .HasForeignKey(t => t.Id_Running);

            modelBuilder.Entity<Distance>()
                .HasOne<Runnings>()
                .WithMany()
                .HasForeignKey(d => d.Id_Running);

            modelBuilder.Entity<Vibration>()
                .HasOne<Runnings>()
                .WithMany()
                .HasForeignKey(v => v.Id_Running);

            // Configurações para Compressor e CompressorRunning
            modelBuilder.Entity<Compressor>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<CompressorRunning>()
                .HasKey(cr => cr.RunningId);

            // Remove to create Compressor
            //modelBuilder.Entity<CompressorRunning>()
            //    .HasOne(cr => cr.Compressor)
            //    .WithMany(c => c.CompressorRunnings)
            //    .HasForeignKey(cr => cr.CompressorId);

            // Configurações para Prensa e PrensaRunning
            modelBuilder.Entity<Prensa>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<PrensaRunning>()
                .HasKey(pr => pr.RunningId);

            ////modelBuilder.Entity<PrensaRunning>()
            ////    .HasOne(pr => pr.Prensa)
            ////    .WithMany(p => p.PrensaRunnings)
            ////    .HasForeignKey(pr => pr.PrensaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
