using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.Infraestructura.AccesoDatos.EF.Config
{
    public class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.HasOne(p => p.Usuario)
                   .WithMany()
                   .HasForeignKey(p => p.UsuarioId);

            builder.Property(p => p.FechaInicio)
                   .IsRequired();

            builder.Property(p => p.FechaFin)
                   .IsRequired();

            builder.OwnsOne(p => p.Estado, VOEstado =>
            {
                VOEstado.Property(v => v.Value)
                .HasColumnName("Estado")
                .IsRequired();
            });

            builder.HasMany(p => p.PrestamoDetalles)
                   .WithOne(pd => pd.Prestamo)
                   .HasForeignKey(pd => pd.PrestamoId);

        }
    }
}