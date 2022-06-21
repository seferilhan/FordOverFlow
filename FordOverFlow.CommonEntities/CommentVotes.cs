using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.CommonEntities
{
    public class CommentVotes : CommonProperties
    {
        //Tek parametresi ID, commonproperties sınıfından geliyor 
        //Diğer parametrelerini başka tablolardan ForeignKey olarak alıyor
        //Sadece ilişkilendirme yapılacak. 

        public virtual User User { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Votes Vote { get; set; }

    }
}
