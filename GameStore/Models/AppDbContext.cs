using Microsoft.EntityFrameworkCore;

namespace GameStore.Models
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Juego-Plataforma
            modelBuilder.Entity<Juego_Plataforma>().HasKey(jp => new
            {
                jp.JuegoId,
                jp.PlataformaId
            });
            modelBuilder.Entity<Juego_Plataforma>().HasOne(j => j.Juego).WithMany(jp => jp.Juegos_Plataformas).HasForeignKey(p => p.JuegoId);
            modelBuilder.Entity<Juego_Plataforma>().HasOne(p => p.Plataforma).WithMany(jp => jp.Juegos_Plataformas).HasForeignKey(p => p.PlataformaId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Juego_Plataforma> Juegos_Plataformas { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Carrito> Carritos { get; set; } 
    }
}
