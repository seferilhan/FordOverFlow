using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DbSet<T> DbSet;
        protected DatabaseContext context;
        public readonly ILogger logger;

        public GenericRepository(DatabaseContext _context, ILogger _logger)
        {
            context = _context;
            logger = _logger;

            DbSet = context.Set<T>();

        }

        public void Delete(long Id)
        {
            var deletedItem = DbSet.Find(Id);
            DbSet.Remove(deletedItem);
        }

        public void DeleteAll()
        {
            DbSet.RemoveRange(GetAll());
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T GetById(long Id)
        {
            return DbSet.Find(Id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
