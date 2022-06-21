using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.CommonEntities
{
    [Table("Comment")]

    public class Comment : CommonProperties
    {
        [Required, StringLength(50)]
        public string Text { get; set; }
        [Required, StringLength(50)]
        public DateTime PublishDate { get; set; }
        public DateTime EditDate { get; set; }
        public bool IsFavorite { get; set; }
        public int ReplyTo { get; set; }   //SubComment. Cevaplanan yorumun Id'si. 
                                           //Sorun çıkarabilir. Farklı bir yaklaşım düşün.
                                           //İlişkilendirmede SubComment olarak belirtildi

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }

        public virtual List<CommentVotes> CommentVotes { get; set; }
        public virtual List<Comment> SubComment { get; set; }



    }
}
