using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.CommonEntities
{

    [Table("Post")]
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostID { get; set; }
        [Required, StringLength(500)]
        public string Title { get; set; }
        [Required, StringLength(500)]
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime EditDate { get; set; }    
        public bool? IsSolved { get; set; }
        public bool? IsFavorite { get; set; }


        //İlişkiler
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }


        
        //[ForeignKey("PostID")]      m - m         ??
        public virtual List<PostTags> PostTags { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<PostVotes> PostVotes { get; set; }


        ////23.10
        //public Post()
        //{
        //    Comments = new List<Comment>();
        //    PostTags = new List<PostTags>();
        //    PostVotes = new List<PostVotes>();

        //    User = new User();
        //    Category = new Category();
        //}

    }
}
