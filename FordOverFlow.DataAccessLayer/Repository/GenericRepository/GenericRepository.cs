using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //public DbSet<T> DbSet;
        protected readonly DatabaseContext context;

        public GenericRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {

            return context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }
    }
}
