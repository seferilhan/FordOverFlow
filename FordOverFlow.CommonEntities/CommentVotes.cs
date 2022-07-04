using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.CommonEntities
{
    [Table("CommentVotes")]
    public class CommentVotes : CommonProperties
    {
        //Tek parametresi ID, commonproperties sınıfından geliyor 
        //Diğer parametrelerini başka tablolardan ForeignKey olarak alıyor
        //Sadece ilişkilendirme yapılacak. 

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public int CommentID { get; set; }
        public virtual Comment Comment { get; set; }

        public int VoteID { get; set; }
        public virtual Votes Vote { get; set; }

        ////23.10
        //public CommentVotes()
        //{
        //    User = new User();
        //    Comment = new Comment();
        //    Vote = new Votes();
        //}
    }
}
