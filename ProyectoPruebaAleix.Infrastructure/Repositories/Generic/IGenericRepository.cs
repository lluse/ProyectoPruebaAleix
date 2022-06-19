using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPruebaAleix.Infrastructure.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T Insert(T obj);
        IEnumerable<T> GetAll();
        T GetById(int id);
        Task Delete(int id);
        T Update(T obj);
    }
}
