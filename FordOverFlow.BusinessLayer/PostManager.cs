using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FordOverFlow.CommonEntities;
using FordOverFlow.DataAccessLayer;

namespace FordOverFlow.BusinessLayer
{
    public class PostManager
    {
        private Repository<Post> repo_post = new Repository<Post>();

        public List<Post> GetAllPosts(DatabaseContext db) //Tüm postları listele
        {
            return repo_post.List(db);
        }

        public List<Post> SelectPost(DatabaseContext db, int id) //Id'si belli olan posta Select işlemi
        {
            return repo_post.List(db, x => x.PostID == id).ToList();
        }
    }
}
