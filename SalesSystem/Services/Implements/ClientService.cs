using SalesSystem.Models;
using SalesSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Services.Implements
{
    public class ClientService : GenericService<Client>, IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository) : base(clientRepository)
        {
            this.clientRepository = clientRepository;
        }
    }
}
