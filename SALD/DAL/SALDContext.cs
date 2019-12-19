using SALD.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SALD.DAL
{
    public class SALDContext : DbContext
    {

        public SALDContext() : base("SALDContext")
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Adulto> Adultos { get; set; }
        public DbSet<Planificacion> Planificaciones { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}