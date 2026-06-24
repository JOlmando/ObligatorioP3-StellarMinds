using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.Infraestructura.AccesoDatos.EF.Config
{
    public class AuditoriaPrestamoConfiguration
        : IEntityTypeConfiguration<Log>
    {
        public void Configure(
            EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.DateTime)
                .IsRequired();

            builder.Property(a => a.Operation)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.TableName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(a => a.Prestamo)
                .WithMany()
                .HasForeignKey(a => a.PrestamoId);
        }
    }
}