using FordOverFlow.CommonEntities;
using FordOverFlow.DataAccessLayer.Interface;
using FordOverFlow.DataAccessLayer.Repository;
using FordOverFlow.DataAccessLayer.Repository.EntityRepository;
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
        private DatabaseContext context;
        public UnitOfWork(DatabaseContext context)
        {
            this.context = context;
            Post = new PostRepository(this.context);
            User = new UserRepository(this.context);
        }

        public IUserRepository User { get; set; }
        public IPostRepository Post { get; set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
