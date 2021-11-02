using SalesSystem.Models;

namespace SalesSystem.Repositories.Implements
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly LESAContext lESAContext;

        public ClientRepository(LESAContext lESAContext) : base(lESAContext)
        {
            this.lESAContext = lESAContext;
        }

    }
}
