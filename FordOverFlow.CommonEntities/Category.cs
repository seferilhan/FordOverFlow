using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.CommonEntities
{
    public  class Category : CommonProperties
    {
        [Required, StringLength(50)]
        public string CategoryName { get; set; }//Kategori türümüz. Postların türü değişebielceğinden
                                                //Soru, paylaşım, bestpractice vb. vb. vb.

        public virtual List<Post> Post { get; set; }
    }
}
