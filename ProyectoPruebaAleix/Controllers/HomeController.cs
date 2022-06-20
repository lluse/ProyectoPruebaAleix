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

            ClientModel clientModel = new ClientModel();
            clientModel.Clients = clients;
            clientModel.ModalInformacionCliente = GetModalInformacionCliente();

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

        public JsonResult GetCliente(string clientId)
        {
            int client_id = Convert.ToInt32(clientId);
            ClientDto clientDto = _clientService.GetClient(client_id);

            return Json(clientDto, null);
        }

        public JsonResult CreateClient(ClientDto clientDto)
        {
            ClientDto client = _clientService.CreateClient(clientDto);
            return Json(client, null);
        }

        public JsonResult EditClient(ClientDto clientDto)
        {
            ClientDto client = _clientService.UpdateClient(clientDto);
            return Json(client, null);
        }

        public JsonResult DeleteCliente(string clientId)
        {
            int client_id = Convert.ToInt32(clientId);
            try
            {
                _clientService.DeleteClient(client_id);
            } catch(Exception ex)
            {
                return Json("Error", null);
            }

            return Json("Ok", null);
        }


        private ModalInformationModel GetModalInformacionCliente()
        {
            ModalInformationModel modalCliente = new ModalInformationModel();

            modalCliente.Id_modal = "modalInformacionCliente";
            modalCliente.Titulo = "Cliente";

            modalCliente.Id_Button = "btnGuardarInformacion";
            modalCliente.Name_Button = "Guardar";
            modalCliente.Id_Form = "formInformacionCliente";

            modalCliente.Inputs = new List<ModalInformationModel.InputModal>
            {
                new ModalInformationModel.InputModal("inputClientId", "clientId", "hidden", "", 100),
                new ModalInformationModel.InputModal("inputNombre", "nombre", "text", "Nombre", 100),
                new ModalInformationModel.InputModal("inputApellidos", "apellidos", "text", "Apellidos", 200),
                new ModalInformationModel.InputModal("inputNif", "nif", "text", "Nif", 15),
                new ModalInformationModel.InputModal("inputEmail", "email", "text", "Email", 250)
            };

            return modalCliente;
        }
    }
}
