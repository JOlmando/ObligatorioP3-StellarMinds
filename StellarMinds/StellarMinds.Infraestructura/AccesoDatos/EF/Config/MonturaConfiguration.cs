using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.Infraestructura.AccesoDatos.EF.Config
{
    public class MonturaConfiguration : IEntityTypeConfiguration<Montura>
    {
        public void Configure(EntityTypeBuilder<Montura> builder)
        {
            builder.OwnsOne(m => m.TipoMontura, VOTipoMontura =>
            {
                VOTipoMontura.Property(v => v.Value)
                       .HasColumnName("TipoMontura")
                       .IsRequired();
            });
        }
    }
}