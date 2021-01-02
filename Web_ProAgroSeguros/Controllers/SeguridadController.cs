using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AspCoreConsumingWebApi.Utility;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mvc;
using Newtonsoft.Json;
using Web_ProAgroSeguros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Web_ProAgroSeguros.Controllers
{    
    public class SeguridadController : Controller
    {
        
        private IConfiguration _IConfiguration;

        public SeguridadController(IConfiguration configuration)
        {
            _IConfiguration = configuration;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(Credencial user, string ReturnUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                
                string apiBaseUrl = _IConfiguration.GetSection("WebAPIBaseUrl").GetSection("URL").Value;
                string endpoint = apiBaseUrl + "CatUsuarios/Login";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        //TempData["Nombre"] = JsonConvert.SerializeObject(apiResponse);
                        
                        //Array
                        //var LstCatUsuario = JsonConvert.DeserializeObject<List<CatUsuario>>(apiResponse);
                        //var MiCatUsuario = LstCatUsuario.First();
                        //TempData["Nombre"] = MiCatUsuario.nombre;

                        //One
                        var MiCatUsuario = JsonConvert.DeserializeObject<CatUsuario>(apiResponse);                        
                        HttpContext.Session.SetString("Nombre", MiCatUsuario.nombre);
                        HttpContext.Session.SetInt32("idEstado", MiCatUsuario.idEstado);

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,MiCatUsuario.nombre)
                        };
                        var ClaimsIdentidad = new ClaimsIdentity(claims, "Login");


                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentidad));
                        return Redirect(ReturnUrl == null ? "/Home/Index" : ReturnUrl);
                        
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Credencial incorrecta");
                        return View();
                    }
                }
            }
        }

        public IActionResult Adios()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("Nombre");
            HttpContext.Session.Remove("idEstado");
            await HttpContext.SignOutAsync();
            return RedirectToAction("Adios", "Seguridad");
        }

    }
}
