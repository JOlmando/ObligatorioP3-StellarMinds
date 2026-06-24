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
    [Authorize]
    public class UsuarioController(ICUAdd<UsuarioAltaDto> _add,
                                   //ICUGetAll<GetUsuarioDto> _getAll,
                                   ICUGetAll<GetUsuarioDto> _getAllSocios,
                                   ICUGetById<GetUsuarioDto> _getById,
                                   ICUDelete<UsuarioDeleteDto> _delete,
                                   ICUUpdate<UsuarioAltaDto> _update,
                                   ICUGetById<IEnumerable<GetUsuarioDto>> _getSociosByTelescopio) : ControllerBase
    {

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Create([FromBody] UsuarioAltaDto usuarioAltaDto)
        {
            try
            {
                int id = _add.Execute(usuarioAltaDto);

                return CreatedAtAction(nameof(GetById), new { id }, _getById.Execute(id));
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

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    try
        //    {
        //        return Ok(_getAll.Execute());
        //    }
        //    catch (NotFoundException e)
        //    {
        //        return NotFound(e.Error());
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, new Error(500, e.Message));
        //    }
        //}

        [HttpGet("socios")]
        public IActionResult GetAllSocios()
        {
            try
            {
                return Ok(_getAllSocios.Execute());
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_getById.Execute(id));
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

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            try
            {
                _delete.Execute(id);
                return Ok();
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

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Update(
            int id,
            [FromBody] UsuarioAltaDto usuarioDto)
        {
            try
            {
                _update.Execute(id, usuarioDto);
                return Ok();
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

        [HttpGet("socios/telescopio/{id}")]
        [Authorize(Roles = "Coordinador,Administrador")]
        public IActionResult GetSociosByTelescopio(int id)
        {
            try
            {
                return Ok(_getSociosByTelescopio.Execute(id));
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