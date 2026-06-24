using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.Infraestructura.AccesoDatos.EF.Config
{
    public class CamaraConfiguration : IEntityTypeConfiguration<Camara>
    {
        public void Configure(EntityTypeBuilder<Camara> builder)
        {
            builder.OwnsOne(c => c.TipoSensor, VOTipoSensor =>
            {
                VOTipoSensor.Property(v => v.Value).HasColumnName("TipoSensor").IsRequired();
            });
        }
    }
}