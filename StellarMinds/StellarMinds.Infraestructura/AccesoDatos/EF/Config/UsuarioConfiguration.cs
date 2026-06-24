using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.Infraestructura.AccesoDatos.EF.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.OwnsOne(u => u.UserName, VoUserName =>
            {
                VoUserName.Property(v => v.Value).HasColumnName("UserName").IsRequired();
            });

            builder.OwnsOne(u => u.Name, VoName =>
            {
                VoName.Property(v => v.Value).HasColumnName("Name").IsRequired();
            });

            builder.OwnsOne(u => u.Email, VoEmail =>
            {
                VoEmail.Property(v => v.Value).HasColumnName("Email").IsRequired();
            });

            builder.OwnsOne(u => u.Password, VoPassword =>
            {
                VoPassword.Property(v => v.Value).HasColumnName("Password").IsRequired();
            });

            builder.OwnsOne(u => u.Adress, VoAdress =>
            {
                VoAdress.Property(v => v.Calle).HasColumnName("Calle").IsRequired();
                VoAdress.Property(v => v.NumeroPuerta).HasColumnName("NumeroPuerta").IsRequired();
                VoAdress.Property(v => v.Apartamento).HasColumnName("Apartamento").IsRequired();
            });

        }
    }
}
