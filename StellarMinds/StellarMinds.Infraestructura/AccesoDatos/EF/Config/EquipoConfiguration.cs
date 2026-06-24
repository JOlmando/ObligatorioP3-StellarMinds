using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.Infraestructura.AccesoDatos.EF.Config
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.OwnsOne(e => e.Marca, VoMarca =>
            {
                VoMarca.Property(v => v.Value)
                       .HasColumnName("Marca")
                       .IsRequired();
            });
            builder.OwnsOne(e => e.Modelo, VoModelo =>
            {
                VoModelo.Property(v => v.Value)
                        .HasColumnName("Modelo")
                        .IsRequired();
            });
            builder.OwnsOne(e => e.CantidadDisponible, VOCantidadDisponible =>
            {
                VOCantidadDisponible.Property(v => v.Value)
                                    .HasColumnName("CantidadDisponible")
                                    .IsRequired();
            });

            builder.HasMany(e => e.PrestamoDetalles)
                   .WithOne(pd => pd.Equipo)
                   .HasForeignKey(pd => pd.EquipoId);
        }
    }
}