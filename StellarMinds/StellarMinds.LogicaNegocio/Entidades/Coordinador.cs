using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Coordinador : Usuario
    {
        public Coordinador(VOUserName UserName,
                           VOName nombre,
                           VOEmail email,
                           VOAddress adress,
                           VOPassword password) : base(UserName, nombre, email, adress, password)
        {
        }

        protected Coordinador()
        {
        }

        public override string GetRol()
        {
            return "Coordinador";
        }
    }
}