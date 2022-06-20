using ProyectoPruebaAleix.Domain;
using System.Collections.Generic;

namespace ProyectoPruebaAleix.Infrastructure.Services
{
    public interface IClientService
    {
        ClientDto GetClient(int clientId);
        IEnumerable<ClientDto> FindAll();
        ClientDto UpdateClient(ClientDto clientDto);
        ClientDto CreateClient(ClientDto clientDto);
        void DeleteClient(int clientId);
    }
}
