using FordOverFlow.CommonEntities;
using FordOverFlow.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }

        void Save();
    }
}
