﻿using ProyectoPruebaAleix.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoPruebaAleix.Infrastructure.Services
{
    public interface IClientService
    {
        ClientDto GetClient(int clientId);
        IEnumerable<ClientDto> FindAll();
        ClientDto UpdateClient(ClientDto clientDto);
        ClientDto CreateClient(ClientDto clientDto);
    }
}