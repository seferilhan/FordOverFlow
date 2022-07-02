using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.CommonEntities
{
    [Table("Deparment")]
    public class Department : CommonProperties
    {
        [Required, StringLength(100)]
        public string DepartmentName { get; set; }//Kullanıcıların departman türü burada
                                                  //Yazılım geliştirme, R&D, H&R vb. vb. vb.

        public virtual List<User> Users { get; set; }

        ////23.10
        //public Department()
        //{
        //    Users = new List<User>();
        //}
    }
}
