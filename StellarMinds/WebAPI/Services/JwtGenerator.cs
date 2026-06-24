using Microsoft.IdentityModel.Tokens;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StellarMinds.WebAPI.Services
{
    public class JwtGenerator : IJwtGenerator<UsuarioRol>
    {

        private readonly JwtSettings _settings;

        public JwtGenerator(JwtSettings settings)
        {
            _settings = settings;
        }

        public string GenerateToken(UsuarioRol usuario)
        {
            var key = Encoding.UTF8.GetBytes(_settings.Key);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.username),
                new Claim(ClaimTypes.Role, usuario.rol),
                new Claim(ClaimTypes.NameIdentifier, usuario.id.ToString())
                // Podés agregar más claims como rol, nombre, etc.
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
