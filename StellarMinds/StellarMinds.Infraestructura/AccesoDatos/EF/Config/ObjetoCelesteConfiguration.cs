using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.Infraestructura.AccesoDatos.EF.Config
{
    internal class ObjetoCelesteConfiguration : IEntityTypeConfiguration<ObjetoCeleste>
    {
        public void Configure(EntityTypeBuilder<ObjetoCeleste> builder)
        {
            builder.OwnsOne(oc => oc.Nombre, VoName =>
            {
                VoName.Property(v => v.Value)
                      .HasColumnName("Nombre")
                      .IsRequired();
            });
        }
    }
}