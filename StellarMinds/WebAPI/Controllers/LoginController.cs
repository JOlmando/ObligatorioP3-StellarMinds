using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.AccesoDatos.Excepciones;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;

namespace StellarMinds.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(
        IJwtGenerator<UsuarioRol> _jwtGenerator,
        ICULoginUsuario<UsuarioRol> _loginUsuario
        ) : ControllerBase
    {
        /// <summary>
        /// Autentica un usuario y devuelve un JWT.
        /// </summary>
        /// <param name="userALogear">Datos de login.</param>
        /// <returns>Token JWT.</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UsuarioRol userALogear)
        {
            try
            {
                //Rol de usuario
                //string rolUser = _loginUsuario.Execute(userALogear.username, userALogear.password);

                //Dto solo con rol y username para generar el token
                //UsuarioRol usuarioRol = new UsuarioRol(userALogear.username, rolUser);

                UsuarioRol usuarioRol = _loginUsuario.Execute(userALogear.username, userALogear.password);

                //Generar token con el rol del usuario y username
                var token = _jwtGenerator.GenerateToken(usuarioRol);

                //Retornar el token al cliente
                return Ok(new { Token = token });
            }
            catch (BadRequestException ex)
            {
                return StatusCode(400, new { Error = new { StatusCode = 400, Message = ex.Message } });
            }
            catch (LogicaNegocioException ex)
            {
                return StatusCode(400, new { Error = new { StatusCode = 400, Message = ex.Message } });
            }
            catch (UnauthorizedAccessException ex)
            {
                return StatusCode(401, new { Error = new { StatusCode = 401, Message = ex.Message } });
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, new { Error = new { StatusCode = 404, Message = ex.Message } });
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { Error = new { StatusCode = 400, Message = ex.Message } });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = new { StatusCode = 500, Message = "No estoy disponible en este momento." } });
            }
        }
    }
}
