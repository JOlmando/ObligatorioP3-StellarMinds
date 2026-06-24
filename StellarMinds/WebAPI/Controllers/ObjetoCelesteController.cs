using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.AccesoDatos.Excepciones;
using StellarMinds.LogicaAplicacion.Dtos.ObjetoCeleste;
using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;

namespace StellarMinds.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ObjetoCelesteController(ICUGetAll<ObjetoDto> _getAll
        ) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_getAll.Execute());
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
