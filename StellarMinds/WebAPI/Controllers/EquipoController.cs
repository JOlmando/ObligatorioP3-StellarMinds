using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.AccesoDatos.Excepciones;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;

namespace StellarMinds.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EquipoController(ICUAdd<EquiposDto> _add,
                                  ICUDelete<EquipoDeleteDto> _delete,
                                  ICUGetById<EquiposDto> _getEquipoById,
                                  ICUGetAll<EquiposDto> _getAll,
                                  ICUUpdate<EquiposDto> _update,
                                  ICUGetAllTelescopios<EquiposDto> _getAllTelescopios,
                                  ICUGetById<IEnumerable<EquiposDto>> _getEquiposByPid
        ) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Create([FromBody] EquiposDto equiposDto)
        {
            try
            {
                //return Ok(new { Message = "Se dio de alta correctamente", Id = _add.Execute(equiposDto) });

                int idAdd = _add.Execute(equiposDto);
                return CreatedAtAction("GetById", new { id = idAdd }, _getEquipoById.Execute(idAdd));
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
                return Ok(_getEquipoById.Execute(id));
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

        [HttpGet("prestamo/{id}")]
        public IActionResult GetEquiposByPid(int id)
        {
            try
            {
                IEnumerable<EquiposDto> equipos = _getEquiposByPid.Execute(id);

                return Ok(equipos);
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

        [HttpGet("telescopios")]
        public IActionResult GetAllTelescopios()
        {
            try
            {
                return Ok(_getAllTelescopios.Execute());
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
        public IActionResult Update([FromBody] EquiposDto equiposDto, int id)
        {
            try
            {
                //_update.Execute(id, _getEquipoById.Execute(id));
                _update.Execute(id, equiposDto);
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

        [HttpGet("{id}/disponibilidad")]
        public IActionResult GetDisponibilidad(int id)
        {
            try
            {
                var equipo = _getEquipoById.Execute(id);
                return Ok(new { stockSinUso = equipo.stockSinUso });
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
