using ProyectoPruebaAleix.Domain;
using System.Collections.Generic;

namespace ProyectoPruebaAleix.Models
{
    public class ClientModel
    {

        public ClientModel(IEnumerable<ClientDto> clients)
        {
            _clients = clients;
        }

        public IEnumerable<ClientDto> _clients { get; set; }


    }
}
