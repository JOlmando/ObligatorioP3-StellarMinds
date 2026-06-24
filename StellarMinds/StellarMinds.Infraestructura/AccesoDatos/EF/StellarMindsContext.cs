using Microsoft.EntityFrameworkCore;
using StellarMinds.Infraestructura.AccesoDatos.EF.Config;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.Infraestructura.AccesoDatos.EF
{
    public class StellarMindsContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Coordinador> Cordinadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Telescopio> Telescopios { get; set; }
        public DbSet<Camara> Camaras { get; set; }
        public DbSet<Montura> Monturas { get; set; }
        public DbSet<Ocular> Oculares { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<PrestamoDetalle> PrestamoDetalles { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<ObjetoCeleste> ObjetosCeleste { get; set; }
        public DbSet<Log> Logs { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            base.OnConfiguring(optionBuilder);
            //optionBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog= StellarMinds; Integrated Security=True;");

            optionBuilder.UseSqlServer(@"Server=dbStellarMinds207448.mssql.somee.com; Database=dbStellarMinds207448;User ID=PisaniCamilo3_SQLLogin_1;Password=vrlw9ijzrp;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Usuarios
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            //Equipos
            modelBuilder.ApplyConfiguration(new EquipoConfiguration());
            modelBuilder.ApplyConfiguration(new CamaraConfiguration());
            modelBuilder.ApplyConfiguration(new MonturaConfiguration());

            //Prestamos
            modelBuilder.ApplyConfiguration(new PrestamoConfiguration());
            modelBuilder.ApplyConfiguration(new PrestamoDetalleConfiguration());

            //Observaciones
            modelBuilder.ApplyConfiguration(new ObservacionConfiguration());

            //Objetos Celestes
            modelBuilder.ApplyConfiguration(new ObjetoCelesteConfiguration());

        }
    }
}
