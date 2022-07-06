using FordOverFlow.CommonEntities;
using FordOverFlow.DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.DataAccessLayer.Repository.EntityRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }
    }
}
