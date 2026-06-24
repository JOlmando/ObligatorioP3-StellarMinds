using Microsoft.AspNetCore.Mvc;
using StellarMinds.AppWeb.Models.Dtos.Usuarios;
using System.IdentityModel.Tokens.Jwt;
using WebApp.Services.Http;

namespace StellarMinds.AppWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuxiliarClienteHttp _auxHttp;
        public LoginController(AuxiliarClienteHttp aux)
        {
            _auxHttp = aux;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioLoginDto aLogear)
        {

            try
            {
                UsuarioRol mapperLogear = new UsuarioRol(0, aLogear.username, aLogear.password, "null");

                if (!ModelState.IsValid)
                    return View(mapperLogear);

                var resp = _auxHttp.EnviarYDeserializar<LoginRespuestaDto>("api/login", "POST", mapperLogear);

                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(resp.Token);

                HttpContext.Session.SetString("Token", resp.Token);
                HttpContext.Session.SetString("Nombre", jwt.Claims.First(c => c.Type == "unique_name").Value);
                HttpContext.Session.SetString("Rol", jwt.Claims.First(c => c.Type == "role").Value);
                HttpContext.Session.SetString("IdUsuarioSession", jwt.Claims.First(c => c.Type == "nameid").Value);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }


        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }

        public class LoginRespuestaDto
        {
            public string? Token { get; set; }
        }
    }
}