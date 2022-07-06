using FordOverFlow.CommonEntities;
using FordOverFlow.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.BusinessLayer
{
    public interface IService
    {
        public List<Post> ShowSelectedPost(int id);
        public IEnumerable<Post> GetAllPosts();
    }
}
