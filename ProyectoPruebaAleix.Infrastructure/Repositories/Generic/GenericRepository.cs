using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPruebaAleix.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly DbSet<T> _dbSet;
        protected ApplicationDbContext _context;
        protected string _className; 


        public GenericRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
            _className = this.GetType().Name;
        }

        public async Task Delete(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Insert(T obj)
        {
            _dbSet.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public T Update(T obj)
        {
            //_context.Entry(obj).State = EntityState.Modified;
            _dbSet.Update(obj);
            _context.SaveChanges();
            _context.Entry(obj).State = EntityState.Detached;
            return obj;
        }
    }
}
