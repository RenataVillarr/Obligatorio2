using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obligatorio2.Models;

namespace Obligatorio2.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {

        }

        public DbSet<TipoMaquina> tipomaquinas {  get; set; }
        public DbSet<Socio> socios { get; set; }
        public DbSet<Local> locales { get; set; }
        public DbSet<Maquina> maquinas { get; set; }
        public DbSet<Ejercicio> ejercicios { get; set; }
        public DbSet<Rutina> rutinas { get; set; }
        public DbSet<SocioRutina> sociorutinas { get; set; }
        public DbSet<RutinaEjercicio> rutinaejercicios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ignorar las clases SelectListGroup y SelectListItem
            modelBuilder.Ignore<SelectListGroup>();
            modelBuilder.Ignore<SelectListItem>();
            modelBuilder.Entity<SocioRutina>().HasKey(sr => new { sr.IdSocio, sr.IdRutina });
            modelBuilder.Entity<RutinaEjercicio>().HasKey(re => new { re.IdRutina, re.IdEjercicio });


        }

    }
}
