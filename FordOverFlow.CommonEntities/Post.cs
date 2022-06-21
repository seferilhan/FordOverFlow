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
    public class Post : CommonProperties
    {

        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required, StringLength(50)]
        public string Text { get; set; }
        [Required, StringLength(50)]
        public DateTime PublishDate { get; set; }
        public DateTime EditDate { get; set; }    
        public bool IsSolved { get; set; }
        public bool IsFavorite { get; set; }

        public virtual User User { get; set; }


        public virtual Category Category { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public virtual List<PostVotes> PostVotes { get; set; }
        public virtual List<PostTags> PostTags { get; set; }



    }
}
