using ProyectoPruebaAleix.Domain;
using System.Collections.Generic;

namespace ProyectoPruebaAleix.Models
{
    public class ClientModel
    {
        public IEnumerable<ClientDto> Clients { get; set; }
        public ModalInformationModel ModalInformacionCliente { get; set; }

        public ClientModel()
        {

        }

    }
}
