using Microsoft.AspNetCore.Mvc;
using StellarMinds.AppWeb.Models.Dtos.Equipos;
using StellarMinds.AppWeb.Models.Dtos.Prestamos;
using WebApp.Services.Http;

namespace StellarMinds.AppWeb.Controllers
{
    public class EquipoController(AuxiliarClienteHttp _auxHttp) : Controller
    {
        public IActionResult Index()
        {
            try
            {
                //var equipos = _auxHttp.EnviarYDeserializar<List<EquipoDtoListado>>("api/equipo", "GET")?? new List<EquipoDtoListado>();
                string? token = HttpContext.Session.GetString("Token");
                var equipos = _auxHttp.EnviarYDeserializar<IEnumerable<EquipoDtoListado>>("api/Equipo", "GET", token: token);
                if (equipos == null)
                {
                    return NotFound();
                }
                return View(equipos);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                string? token = HttpContext.Session.GetString("Token");
                var equipo =
                    _auxHttp.EnviarYDeserializar<EquipoDtoAlta>
                    ($"api/equipo/{id}", "GET", token: token);

                if (equipo == null)
                    return NotFound();

                return View(equipo);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] EquipoDtoAlta equipodto)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    ModelState.AddModelError("", "Datos para dar de alta un equipo invalidos");
                //    return View(equipodto);
                //}

                string? token = HttpContext.Session.GetString("Token");

                _auxHttp.EnviarSolicitud($"api/Equipo", "POST", equipodto, token: token);

                ModelState.AddModelError("", "Equipo registrado");
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(equipodto);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.Id = id;
                string? token = HttpContext.Session.GetString("Token");
                var equipo =
                    _auxHttp.EnviarYDeserializar<EquipoDtoAlta>($"api/equipo/{id}", "GET", token: token);

                if (equipo == null)
                    return NotFound();

                return View(equipo);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromForm] EquipoDtoAlta equipo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(equipo);

                string? token = HttpContext.Session.GetString("Token");
                _auxHttp.EnviarSolicitud($"api/equipo/{id}", "PUT", body: equipo, token: token);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                ViewBag.Id = id;

                string? token = HttpContext.Session.GetString("Token");

                var equipo = _auxHttp.EnviarYDeserializar<EquipoDtoListado>($"api/equipo/{id}", "GET", token: token);

                var prestamos = _auxHttp.EnviarYDeserializar<IEnumerable<PrestamoDto>>("api/Prestamo", "GET", token: token);

                if (equipo == null)
                    return NotFound();

                ViewBag.equipoPrestado = EquipoEnPrestamo(prestamos, equipo);
                return View(equipo);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {


                string? token = HttpContext.Session.GetString("Token");
                _auxHttp.EnviarSolicitud($"api/equipo/{id}", "DELETE", token: token);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        public bool EquipoEnPrestamo(IEnumerable<PrestamoDto> prestamos, EquipoDtoListado equipo)
        {
            foreach (var prestamo in prestamos)
            {
                if (prestamo.Estado == 1)
                {
                    foreach (var equipoDetalle in prestamo.DetallesEquipos)
                    {
                        if (equipoDetalle.MarcaEquipo == equipo.Marca && equipoDetalle.ModeloEquipo == equipo.Modelo)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}

