using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.Infraestructura.AccesoDatos.EF.Config
{
    public class ObservacionConfiguration : IEntityTypeConfiguration<Observacion>
    {
        public void Configure(EntityTypeBuilder<Observacion> builder)
        {
            builder.HasOne(o => o.Prestamo)
                   .WithMany()
                   .HasForeignKey(o => o.PrestamoId);

            //builder.OwnsOne(o => o.Indicador, VOIndicador =>
            //{
            //    VOIndicador.Property(v => v.Value).HasColumnName("Indicador").IsRequired();
            //});

            builder.HasOne(o => o.ObjetoCeleste)
                   .WithMany()
                   .HasForeignKey(o => o.ObjetoCelesteId);
        }
    }
}