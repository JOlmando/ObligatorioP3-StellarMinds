using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.Infraestructura.AccesoDatos.EF.Config
{
    public class PrestamoDetalleConfiguration : IEntityTypeConfiguration<PrestamoDetalle>
    {
        public void Configure(EntityTypeBuilder<PrestamoDetalle> builder)
        {
            builder.HasKey(pd => new { pd.PrestamoId, pd.EquipoId });

            builder.HasOne(pd => pd.Prestamo)
                   .WithMany(p => p.PrestamoDetalles)
                   .HasForeignKey(pd => pd.PrestamoId);

            builder.HasOne(pd => pd.Equipo)
                   .WithMany(e => e.PrestamoDetalles)
                   .HasForeignKey(pd => pd.EquipoId);
        }
    }
}