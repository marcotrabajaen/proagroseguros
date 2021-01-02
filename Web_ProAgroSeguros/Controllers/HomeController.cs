using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using AspCoreConsumingWebApi.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Web_ProAgroSeguros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Web_ProAgroSeguros.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _IConfiguration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {            
            _logger = logger;
            _IConfiguration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.Nombre = HttpContext.Session.GetString("Nombre");
            ViewBag.idEstado = HttpContext.Session.GetInt32("idEstado");
            return View();
        }              

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<ActionResult<List<Ubicacion>>> GetAPIUbicaciones(int id)
        {
            List<Ubicacion> ubicaciones = new List<Ubicacion>();

            using (HttpClient client = new HttpClient())
            {
                string apiBaseUrl = _IConfiguration.GetSection("WebAPIBaseUrl").GetSection("URL").Value;
                string endpoint = apiBaseUrl + "CatGeorreferencias/GetCatGeorreferenciaByIdEstado/" + id;
                
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        ubicaciones =  JsonConvert.DeserializeObject<List<Ubicacion>>(apiResponse);
                    }
                }
            }
            return ubicaciones;
        }

    }
}
