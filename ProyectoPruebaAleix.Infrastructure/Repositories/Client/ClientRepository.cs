using Microsoft.EntityFrameworkCore;
using ProyectoPruebaAleix.Domain;

namespace ProyectoPruebaAleix.Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {

        private readonly DbSet<Client> _dbSet;

        public ClientRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbSet = applicationDbContext.Set<Client>();
        }
    }
}
