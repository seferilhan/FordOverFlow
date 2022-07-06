using FordOverFlow.CommonEntities;
using FordOverFlow.DataAccessLayer.Interface;
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
        IUserRepository User { get; } 
        IPostRepository Post { get; }

        int Save();
    }
}
