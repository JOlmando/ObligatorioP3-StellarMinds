using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StellarMinds.AppWeb.Models
{
    public record VMUsuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [DisplayName("Nombre de usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[A-Z][a-z]+(?: [A-Z][a-z]+)?$",
        ErrorMessage = "El nombre debe comenzar con mayúscula y tener formato válido.")]
        [DisplayName("Nombre completo")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        [DisplayName("Correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La calle es obligatoria.")]
        [DisplayName("Calle")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El número de puerta es obligatorio.")]
        [DisplayName("Número")]
        public int NumeroPuerta { get; set; }

        [DisplayName("Apartamento")]
        public int Apartamento { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
        ErrorMessage = "Debe tener mayúsculas, minúsculas, números y un caracter especial.")]
        [DisplayName("Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        [DisplayName("Rol")]
        public string Rol { get; set; }
    }
}