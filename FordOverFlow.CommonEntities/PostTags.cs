using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.CommonEntities
{
    [Table("PostTags")]
    public  class PostTags
    {
        //public int PostID { get; set; }
        //public int TagID { get; set; }

        ////[ForeignKey("PostID")]        ??
        //public virtual Post Post { get; set; }
        ////[ForeignKey("TagID")]         ??
        //public virtual Tags Tags { get; set; }    //İlk Yöntem

        //İkinci Yöntem

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostTagsID { get; set; }

        public int PostID { get; set; }
        public virtual Post Post { get; set; }

        public int TagID { get; set; }
        public virtual Tags Tags { get; set; }

        //public PostTags()
        //{
        //    Post = new Post();
        //    Tags = new Tags();
        //}
    }
}
