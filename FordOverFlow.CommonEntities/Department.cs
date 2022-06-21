using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.CommonEntities
{
    public class Department : CommonProperties
    {
        [Required, StringLength(50)]
        public string DepartmentName { get; set; }//Kullanıcıların departman türü burada
                                                  //Yazılım geliştirme, R&D, H&R vb. vb. vb.

        public virtual List<UserDepartments> UserDepartments { get; set; }

    }
}
