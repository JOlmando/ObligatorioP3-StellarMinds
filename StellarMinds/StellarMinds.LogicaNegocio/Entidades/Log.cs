namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Log
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public string Operation { get; private set; }
        public string TableName { get; private set; }
        public int? PrestamoId { get; private set; }
        public Prestamo Prestamo { get; private set; }

        public DateTime DateTime { get; private set; }
        public int UsuarioId { get; private set; }
       

        private Log() { }

        public Log(string operation, int usuarioid, string tablaname, int? prestamoid = null, string email = "null", string message = "null")
        {
            Operation = operation;
            UsuarioId = usuarioid;
            TableName = tablaname;
            PrestamoId = prestamoid;
            Email = email;
            Message = message;
            DateTime = DateTime.Now;
         
        }

    }
}
