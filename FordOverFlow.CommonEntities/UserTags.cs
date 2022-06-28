using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.CommonEntities
{
    [Table("UserTags")]
    public class UserTags
    {
        //public int UserID { get; set; }
        //public int TagID { get; set; }

        ////[ForeignKey("UserID")]         ??
        //public User User { get; set; }
        ////[ForeignKey("TagID")]          ??
        //public Tags Tags { get; set; }        M - M İçin ilk yol




        // M - M İçin ikinci yol | Tags.cs ve User.cs ilk yol ile aynı

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTagsID { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public int TagID { get; set; }
        public virtual Tags Tags { get; set; }

    }
}
