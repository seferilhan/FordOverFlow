using FordOverFlow.CommonEntities;
using FordOverFlow.DataAccessLayer.Interface;
using FordOverFlow.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.BusinessLayer
{
    public class Service : IService
    {
        private readonly IUnitOfWork unitOfWork;
        public Service(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;   
        }

        //Methods about Posts
        public IEnumerable<Post> GetAllPosts()
        {
            return unitOfWork.Post.GetAll();
        }

        public List<Post> ShowSelectedPost(int id)
        {
            return unitOfWork.Post.Find(x =>x.PostID == id).ToList();
        }
    }
}
