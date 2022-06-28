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
        public DateTime PublishDate { get; set; }
        public DateTime EditDate { get; set; }
        public bool? IsFavorite { get; set; }
        public int? ReplyTo { get; set; }                      //Sub comment ise, ait olduğu top comment'in id'si.             


        public int commentOwnerID { get; set; }              //Yorumu yapan kişinin İd'si burada tutulabilir ???  
        public virtual User User { get; set; }               // İlişki Hatası Var. Commentin sahibi ve ait olduğu post aynı anda ilişkilendirilemiyor. => Şimdilik Çözüldü => Detay için DbContext incele


        public int ownerPostID { get; set; }
        public virtual Post Post { get; set; }               

        
        public virtual List<CommentVotes> CommentVotes { get; set; }


    }
}
