using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.CommonEntities
{

    [Table("User")]

    public class User : CommonProperties
    {

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string SurName { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }   // Guid olması gerekiyor. Araştır

        public bool IsAdmin { get; set; }


        //İlişkiler

        public virtual List<Post> Posts { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<UserDepartments> UserDepartments { get; set; }
        public virtual List<UserTags> UserTags { get; set; }
        public virtual List<PostVotes> PostVotes { get; set; }
        public virtual List<CommentVotes> CommentVotes { get; set; }

         
    }
}
