using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FordOverFlow.CommonEntities;
using FordOverFlow.DataAccessLayer;

namespace FordOverFlow.BusinessLayer
{
    public class Test
    {
        

        private Repository<User> user = new Repository<User>();

        public List<User> GetUsers(DatabaseContext _db)
        {
            return user.List(_db);
        }
    }
}
