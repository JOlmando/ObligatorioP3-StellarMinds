using Microsoft.AspNetCore.Mvc;
using StellarMinds.AppWeb.Models.Dtos.Equipos;
using StellarMinds.AppWeb.Models.Dtos.Logs;
using StellarMinds.AppWeb.Models.Dtos.Prestamos;
using StellarMinds.AppWeb.Models.Dtos.Usuarios;
using WebApp.Services.Http;


namespace StellarMinds.AppWeb.Controllers
{
    public class PrestamoController(IConfiguration _configuration, AuxiliarClienteHttp _auxHttp) : Controller
    {

        public IActionResult Index()
        {
            try
            {
                string? token = HttpContext.Session.GetString("Token");

                var prestamos = _auxHttp.EnviarYDeserializar<List<LogPrestamoDto>>("api/Prestamo/auditoria", "GET", token: token) ?? new List<LogPrestamoDto>();

                return View(prestamos);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        private void CargarViewBag()
        {
            string? token = HttpContext.Session.GetString("Token");

            var equipos = _auxHttp.EnviarYDeserializar<List<EquipoDtoAlta>>("api/Equipo", "GET", token: token);

            ViewBag.Telescopios = equipos.Where(e => e.tipoEquipo == TipoEquipo.Telescopio).ToList();
            ViewBag.Monturas = equipos.Where(e => e.tipoEquipo == TipoEquipo.Montura).ToList();
            ViewBag.Camaras = equipos.Where(e => e.tipoEquipo == TipoEquipo.Camara).ToList();
            ViewBag.Oculares = equipos.Where(e => e.tipoEquipo == TipoEquipo.Ocular).ToList();
            ViewBag.Socios = _auxHttp.EnviarYDeserializar<List<GetUsuarioDto>>("api/Usuario/socios", "GET", token: token);
            ViewBag.ApiUrl = _configuration["ApiSettings:BaseUrl"];
            ViewBag.Token = token;
        }

        public IActionResult Create()
        {
            try
            {
                CargarViewBag();
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public IActionResult Create(PrestamoAltaDto prestamo)
        {
            if (!ModelState.IsValid)
            {
                CargarViewBag();
                ModelState.AddModelError("", "Datos para dar de alta el prestamo invalidos");
                return View(prestamo);
            }
            try
            {
                string? token = HttpContext.Session.GetString("Token");

                int idCoordinador = int.Parse(HttpContext.Session.GetString("IdUsuarioSession"));

                prestamo = prestamo with { idCoordinador = idCoordinador };

                _auxHttp.EnviarSolicitud("api/Prestamo", "POST", prestamo, token: token);

                ModelState.AddModelError("", "Prestamo registrado");
                return View();
            }
            catch (Exception ex)
            {
                CargarViewBag();
                ModelState.AddModelError("", ex.Message);
                return View(prestamo);
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                string? token = HttpContext.Session.GetString("Token");

                PrestamoDto prestamo = _auxHttp.EnviarYDeserializar<PrestamoDto>($"api/prestamo/detalle/{id}", "GET", token: token);

                if (prestamo == null)
                    return NotFound();

                return View(prestamo);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult ListadoSocio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ListadoSocio(int mes, int anio)
        {
            try
            {
                int idsocio = int.Parse(HttpContext.Session.GetString("IdUsuarioSession"));

                string? token = HttpContext.Session.GetString("Token");
                var prestamos = _auxHttp.EnviarYDeserializar<List<PrestamoDtoListado>>
                    (
                        $"api/prestamo/listado?usuarioId={idsocio}&mes={mes}&anio={anio}", "GET", token: token
                    );
                if (prestamos is not null && prestamos.Count() == 0)
                    ViewBag.Message = "No hay prestamos para la fecha dada.";

                return View(prestamos);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }



        public IActionResult Auditoria(int? usuarioId)
        {
            try
            {
                string url = "api/prestamo/auditoria";

                if (usuarioId.HasValue)
                {
                    url += $"?usuarioId={usuarioId}";
                }

                var logs =
                    _auxHttp.EnviarYDeserializar<List<LogPrestamoDto>>
                    (
                        url,
                        "GET"
                    ) ?? new List<LogPrestamoDto>();

                return View(logs);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult Devolucion()
        {
            try
            {
                string? token = HttpContext.Session.GetString("Token");
                ViewBag.Socios = _auxHttp.EnviarYDeserializar<List<GetUsuarioDto>>("api/Usuario/socios", "GET", token: token);
                ViewBag.Token = token;
                ViewBag.ApiUrl = _configuration["ApiSettings:BaseUrl"];
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public IActionResult Devolucion(int idPrestamo)
        {
            try
            {
                int coordId = int.Parse(HttpContext.Session.GetString("IdUsuarioSession"));
                string? token = HttpContext.Session.GetString("Token");
                _auxHttp.EnviarSolicitud($"api/Prestamo/devolver/{idPrestamo}?coordId={coordId}", "GET", token: token);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                string? token = HttpContext.Session.GetString("Token");
                ModelState.AddModelError("", ex.Message);
                ViewBag.Socios = _auxHttp.EnviarYDeserializar<List<GetUsuarioDto>>("api/Usuario/socios", "GET", token: token);
                ViewBag.ApiUrl = _configuration["ApiSettings:BaseUrl"];
                return View();
            }
        }


        [HttpGet]
        public IActionResult AuditoriaPretamos()
        {
            try
            {
                string? token = HttpContext.Session.GetString("Token");

                List<PrestamoDto> prestamos = _auxHttp.EnviarYDeserializar<List<PrestamoDto>>("/api/Prestamo", "GET", token: token);



                return View(prestamos);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

    }
}