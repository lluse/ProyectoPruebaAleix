using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoPruebaAleix.Domain;
using ProyectoPruebaAleix.Infrastructure.Services;
using ProyectoPruebaAleix.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPruebaAleix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientService _clientService;

        public HomeController(ILogger<HomeController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            IEnumerable<ClientDto> clients = _clientService.FindAll();
            ClientModel clientModel = new ClientModel(clients);

            return View(clientModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
