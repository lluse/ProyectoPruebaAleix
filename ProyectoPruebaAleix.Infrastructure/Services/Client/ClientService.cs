using AutoMapper;
using Microsoft.Extensions.Configuration;
using ProyectoPruebaAleix.Domain;
using ProyectoPruebaAleix.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoPruebaAleix.Infrastructure.Services
{
    public class ClientService : IClientService
    {

        private readonly IClientRepository _clientRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private string _connectionString;

        public ClientService(IClientRepository clientRepository, IMapper mapper, IConfiguration configuration) : base()
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public ClientDto GetClient(int clientId)
        {
            var client = _clientRepository.GetById(clientId);
            return _mapper.Map<Client, ClientDto>(client);
        }

        public IEnumerable<ClientDto> FindAll()
        {
            var clients =  _clientRepository.GetAll();
            return _mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(clients);
        }

        public ClientDto UpdateClient(ClientDto clientDto)
        {
            Client client = _mapper.Map<ClientDto, Client>(clientDto);
            _clientRepository.Update(client);
            return _mapper.Map<Client, ClientDto>(client);
        }

        public ClientDto CreateClient(ClientDto clientDto)
        {
            Client client = _mapper.Map<ClientDto, Client>(clientDto);
            _clientRepository.Insert(client);
            return _mapper.Map<Client, ClientDto>(client);
        }

        public void DeleteClient(int clientId)
        {
            _clientRepository.Delete(clientId);
        }
    }
}
