using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Administrador : Usuario
    {
        public Administrador(VOUserName UserName,
                             VOName nombre,
                             VOEmail email,
                             VOAddress adress,
                             VOPassword password) : base(UserName, nombre, email, adress, password)
        {
        }

        private Administrador()
        {
        }

        public override string GetRol()
        {
            return "Administrador";
        }
    }
}
