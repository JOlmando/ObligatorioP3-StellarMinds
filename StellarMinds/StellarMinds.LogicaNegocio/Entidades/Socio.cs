using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Socio : Usuario
    {
        public Socio(VOUserName userName,
                     VOName nombre,
                     VOEmail email,
                     VOAddress adress,
                     VOPassword password) : base(userName, nombre, email, adress, password)
        {
        }

        private Socio()
        {
        }

        public override string GetRol()
        {
            return "Socio";
        }
    }
}