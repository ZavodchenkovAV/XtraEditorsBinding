using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XtraEditorsBindingSample.DataModel
{
    public class Department
    {
        public long DepartmentId { get; set; }
        public long? DepartmentParendId { get; set; }
        public string Name { get; set; }

        [Browsable(false)]
        [Display(AutoGenerateField = false)]
        public bool Deleted { get; set; }
    }
}
