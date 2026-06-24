using Microsoft.AspNetCore.Mvc;
using StellarMinds.WebAPI.DTOs.EvaluacionDtos;
using StellarMinds.WebAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class EvaluacionEquipoController(GroqEvaluacionService _service) : ControllerBase
{
    //private readonly GroqEvaluacionService _service;

    //public EvaluacionEquipoController(GroqEvaluacionService service)
    //{
    //    _service = service;
    //}

    [HttpPost("evaluar")]
    public async Task<ActionResult<EvaluacionResponseDto>> Evaluar([FromBody] EvaluacionRequestDto request)
    {
        try
        {
            var resultado = await _service.EvaluarEquipoAsync(request);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = ex.Message });
        }
    }
}