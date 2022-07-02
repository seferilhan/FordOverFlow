using FordOverFlow.CommonEntities;
using FordOverFlow.DataAccessLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration configuration;
        private readonly DatabaseContext context;
        private readonly ILogger logger;

        public IGenericRepository<User> UserRepository {get; private set;}

        public UnitOfWork(DatabaseContext _context, ILoggerFactory _logger, IConfiguration _config)
        {
            context = _context;
            logger = _logger.CreateLogger("Log");
            configuration = _config;

            UserRepository = new GenericRepository<User>(context, logger);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
