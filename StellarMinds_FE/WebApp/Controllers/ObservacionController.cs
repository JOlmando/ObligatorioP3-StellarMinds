using Microsoft.AspNetCore.Mvc;
using StellarMinds.AppWeb.Models.Dtos.ObjetoCeleste;
using StellarMinds.AppWeb.Models.Dtos.Observaciones;
using StellarMinds.AppWeb.Models.Dtos.Prestamos;
using StellarMinds.LogicaAplicacion.Dtos.ObjetoCeleste;
using WebApp.Services.Http;

namespace StellarMinds.AppWeb.Controllers
{
    public class ObservacionController(IConfiguration _configuration, AuxiliarClienteHttp _auxHttp) : Controller
    {

        public IActionResult Index()
        {
            try
            {
                string? token = HttpContext.Session.GetString("Token");

                var observaciones =
                    _auxHttp.EnviarYDeserializar<List<ObservacionDto>>
                    (
                        "api/observacion",
                        "GET",
                        token: token
                    )
                    ?? new();

                return View(observaciones);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id)
        {
            try
            {
                string? token = HttpContext.Session.GetString("Token");

                var observacion =
                    _auxHttp.EnviarYDeserializar<ObservacionDto>
                    (
                        $"api/observacion/{id}",
                        "GET",
                        token: token
                    );

                if (observacion == null)
                    return NotFound();

                return View(observacion);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        public void CargarCreate()
        {
            string? token = HttpContext.Session.GetString("Token");
            int idSocio = int.Parse(HttpContext.Session.GetString("IdUsuarioSession"));
            var prestamos = _auxHttp.EnviarYDeserializar<IEnumerable<PrestamoDto>>($"api/Prestamo/usuario/{idSocio}", "GET", token: token);
            ViewBag.Prestamos = prestamos ?? new List<PrestamoDto>();
            var objetosCelestes = _auxHttp.EnviarYDeserializar<IEnumerable<ObjetoDto>>("/api/ObjetoCeleste", "GET", token: token);
            ViewBag.ObjetosCelestes = objetosCelestes ?? new List<ObjetoDto>();
            ViewBag.ApiUrl = _configuration["ApiSettings:BaseUrl"];
            ViewBag.Token = token;
        }

        public IActionResult Create()
        {
            try
            {
                CargarCreate();
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Create(ObservacionAltaDto dto)
        {
            try
            {
                CargarCreate();
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Datos para dar de alta la observacion invalidos");
                    return View(dto);
                }
                string? token = HttpContext.Session.GetString("Token");

                ObservacionAltaDto obs = new ObservacionAltaDto(dto.FechaObs, dto.PrestamoId, dto.Indicador, dto.Detalle, dto.ObjetoCelesteId);

                obs = obs with { Detalle = string.IsNullOrEmpty(obs.Detalle) ? "" : obs.Detalle };

                _auxHttp.EnviarSolicitud("api/observacion", "POST", body: obs, token: token);


                ModelState.AddModelError("", "Observacion registrada");
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(dto);
            }
        }

        public IActionResult Ranking()
        {
            try
            {
                string? token = HttpContext.Session.GetString("Token");

                var ranking =
                    _auxHttp.EnviarYDeserializar<List<RankingObjetoCelesteDto>>
                    (
                        "api/observacion/ranking",
                        "GET",
                        token: token
                    )
                    ?? new();

                return View(ranking);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}