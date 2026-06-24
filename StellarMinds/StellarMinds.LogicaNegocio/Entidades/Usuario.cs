using StellarMinds.LogicaNegocio.VO;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public VOUserName UserName { get; set; }
        public VOName Name { get; set; }
        public VOEmail Email { get; set; }
        public VOAddress Adress { get; set; }
        public VOPassword Password { get; set; }

        protected Usuario()
        {
        }

        public Usuario(VOUserName userName, VOName nombre, VOEmail email, VOAddress adress, VOPassword password)
        {
            UserName = userName;
            Name = nombre;
            Email = email;
            Adress = adress;
            Password = password;
            Validar();
        }

        public void Validar()
        {
            if (UserName == null || Name == null || Email == null || Adress == null || Password == null)
            {
                throw new ArgumentException("Todos los campos son obligatorios");
            }
        }

        public abstract string GetRol();

        public virtual void Update(Usuario obj)
        {
            UserName = obj.UserName;
            Name = obj.Name;
            Email = obj.Email;
            Adress = obj.Adress;
            Password = obj.Password;
            Validar();
        }
    }
}
