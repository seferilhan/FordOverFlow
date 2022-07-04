using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.CommonEntities
{
    [Table("Votes")]
    public class Votes : CommonProperties
    {
        [Required, StringLength(50)]
        public string VoteType { get; set; } //Upvote, Downvote. Sadece 2 değer
                                             //String yerine char kullanılabilir ??

        public virtual List<PostVotes> PostVotes { get; set; }
        public virtual List<CommentVotes> CommentVotes { get; set; }

        //23.10

        //public Votes()
        //{
        //    PostVotes = new List<PostVotes>();
        //    CommentVotes = new List<CommentVotes>();    
        //}
    }
}
