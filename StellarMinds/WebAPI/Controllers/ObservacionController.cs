using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Infraestructura.AccesoDatos.Excepciones;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.ObjetoCeleste;
using StellarMinds.LogicaAplicacion.Dtos.Observacion;
using StellarMinds.LogicaAplicacion.Dtos.Prestamo;
using StellarMinds.LogicaNegocio.Excepciones;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.WebAPI.DTOs.EvaluacionDtos;
using StellarMinds.WebAPI.Services;

namespace StellarMinds.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ObservacionController(ICUListadoRankingObjetosCelestes<IEnumerable<RankingObjetoCelesteDto>> _rankingObjetos,
                                       ICUAdd<ObservacionAltaDto> _addObservacion,
                                       ICUGetById<ObservacionAltaDto> _getObservacionById,
                                       ICUGetById<PrestamoDto> _getPrestamoById,
                                       ICUGetById<ObjetoDto> _getObjetoCelesteById,
                                       //ICUGetById<EquiposDto> _getEquipoById,
                                       GroqEvaluacionService _groqService,
                                       ICUGetById<IEnumerable<EquiposDto>> _getEquiposByPid

        ) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Socio")]
        public async Task<IActionResult> Create(ObservacionAltaDto observacionDto)
        {
            try
            {
                int idAdd = _addObservacion.Execute(observacionDto);
                return CreatedAtAction("GetById", new { id = idAdd }, _getObservacionById.Execute(idAdd));
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

        [HttpPost("evaluar")]
        public async Task<IActionResult> Evaluar(ObservacionAltaDto observacionDto)
        {
            try
            {
                PrestamoDto prestamo = _getPrestamoById.Execute(observacionDto.PrestamoId);
                ObjetoDto objetoCeleste = _getObjetoCelesteById.Execute(observacionDto.ObjetoCelesteId);
                IEnumerable<EquiposDto> equipos = _getEquiposByPid.Execute(prestamo.id);

                TelescopioEvalDto? telescopio = null;
                CamaraEvalDto? camara = null;
                OcularEvalDto? ocular = null;

                foreach (var equipo in equipos)
                {
                    if (equipo != null && (int)equipo.tipoEquipo == 0)
                    {
                        telescopio = new TelescopioEvalDto(AperturaMm: equipo.apertura,
                                                           FocalMm: equipo.distanciaFocal,
                                                           RelacionFocal: equipo.relacionFocal);
                    }
                    else if (equipo != null && (int)equipo.tipoEquipo == 2)
                    {
                        camara = new CamaraEvalDto(Sensor: equipo.tipoSensor,
                                                   ResolucionPx: equipo.resolucion,
                                                   TamanioPixel: equipo.tamanioPixel);

                    }
                    else if (equipo != null && (int)equipo.tipoEquipo == 3)
                    {
                        ocular = new OcularEvalDto(Diametro: equipo.diametro,
                                                   AnguloVision: equipo.anguloVision);
                    }
                }
                ObjetoCelesteEvalDto objetoCelesteDto = new ObjetoCelesteEvalDto(Nombre: objetoCeleste.nombre,
                                                                                 Tipo: objetoCeleste.tipo);

                EvaluacionRequestDto evaluacionRequest = new EvaluacionRequestDto(telescopio,
                                                                                  camara,
                                                                                  ocular,
                                                                                  objetoCelesteDto);

                if (evaluacionRequest.Telescopio == null || evaluacionRequest.ObjetoCeleste == null || (evaluacionRequest.Camara == null && evaluacionRequest.Ocular == null))
                {
                    return BadRequest(new { Code = 400, Error = "Observacion invalida" });
                }

                var evaluacion = await _groqService.EvaluarEquipoAsync(evaluacionRequest);

                if (evaluacion.Indicador == null)
                {
                    return BadRequest(new { Code = 400, Error = evaluacion.Detalle });
                }

                ObservacionAltaDto observacionCorrecta = new ObservacionAltaDto(observacionDto.PrestamoId,
                                                                                DateTime.Now,
                                                                                evaluacion.Indicador,
                                                                                evaluacion.Detalle,
                                                                                observacionDto.ObjetoCelesteId);

                //int idAdd = _addObservacion.Execute(observacionCorrecta);
                return Ok(observacionCorrecta);
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
                var observacion = _getObservacionById.Execute(id);
                if (observacion == null)
                {
                    return NotFound();
                }
                return Ok(observacion);
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


        [HttpGet("ranking")]
        public IActionResult Ranking()
        {
            try
            {
                return Ok(_rankingObjetos.Execute());
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
