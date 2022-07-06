using FordOverFlow.CommonEntities;
using FordOverFlow.DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.DataAccessLayer.Repository.EntityRepository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(DatabaseContext context) : base(context) { }
    }
}
