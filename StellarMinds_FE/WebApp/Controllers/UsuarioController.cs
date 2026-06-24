using Microsoft.AspNetCore.Mvc;
using StellarMinds.AppWeb.Models.Dtos.Equipos;
using StellarMinds.AppWeb.Models.Dtos.Usuarios;
using WebApp.Services.Http;

namespace StellarMinds.AppWeb.Controllers
{
    public class UsuarioController(AuxiliarClienteHttp _auxHttp) : Controller
    {
        public IActionResult Index()
        {

            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsuarioAltaDto usuarioAltaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(usuarioAltaDto);

                string? token = HttpContext.Session.GetString("Token");

                _auxHttp.EnviarSolicitud("api/usuario", "POST", usuarioAltaDto, token: token);
                return RedirectToAction(nameof(Create));
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
                var usuario =
                    _auxHttp.EnviarYDeserializar<GetUsuarioDto>
                    (
                        $"api/usuario/{id}",
                        "GET"
                    );

                if (usuario == null)
                    return NotFound();

                return View(usuario);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Edit(int id)
        {
            try
            {
                var usuario =
                    _auxHttp.EnviarYDeserializar<UsuarioModificarDto>
                    (
                        $"api/usuario/{id}",
                        "GET"
                    );

                if (usuario == null)
                    return NotFound();

                return View(usuario);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Edit(
    int id,
    UsuarioModificarDto usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(usuario);

                _auxHttp.EnviarSolicitud(
                    $"api/usuario/{id}",
                    "PUT",
                    usuario);

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
                var usuario =
                    _auxHttp.EnviarYDeserializar<GetUsuarioDto>
                    (
                        $"api/usuario/{id}",
                        "GET"
                    );

                if (usuario == null)
                    return NotFound();

                return View(usuario);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _auxHttp.EnviarSolicitud($"api/usuario/{id}", "DELETE");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public IActionResult ConTelescopio()
        {
            try
            {
                string? token = HttpContext.Session.GetString("Token");
                var equipos = _auxHttp.EnviarYDeserializar<List<EquipoDtoAlta>>("api/Equipo", "GET", token: token);
                ViewBag.Telescopios = equipos.Where(e => e.tipoEquipo == TipoEquipo.Telescopio).ToList();

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public IActionResult ConTelescopio(int idTelescopio)
        {
            try
            {
                string? token = HttpContext.Session.GetString("Token");
                var equipos = _auxHttp.EnviarYDeserializar<List<EquipoDtoAlta>>("api/Equipo", "GET", token: token);
                ViewBag.Telescopios = equipos.Where(e => e.tipoEquipo == TipoEquipo.Telescopio).ToList();

                var socios = _auxHttp.EnviarYDeserializar<List<UsuarioModificarDto>>($"api/Usuario/socios/telescopio/{idTelescopio}", "GET", token: token);

                return View(socios);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
