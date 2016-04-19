using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils.OAuth;
using XtraEditorsBinding.Attributes;

namespace XtraEditorsBindingSample.DataModel
{
    public class Employee
    {
        public Employee()
        {
            Personal = new EmployeePersonal();
        }
        // The two items below will be displayed by DataLayoutControl   
        // in a borderless Name group without a title 
        [Display(GroupName = "<Name|>", Name = "Last name")]
        public string LastName { get; set; }

        [Display(GroupName = "<Name|>", Name = "First name", Order = 0)]
        public string FirstName { get; set; }

        [Display(GroupName = "{Tabs}/Personal", Name = "Personal", Order = 1)]
        public EmployeePersonal Personal { get; set; }

        //The four items below will go to a Contact tab within tabbed Tabs group.  
        [Display(GroupName = "{Tabs}/Contact", Order = 2), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(GroupName = "{Tabs}/Contact", Order = 4), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //The four items below will go to the Job tab of the tabbed Tabs group  
        [Display(GroupName = "{Tabs}/Job", Order = 6)]
        public string Group { get; set; }

        [Display(GroupName = "{Tabs}/Job", Name = "Hire date")]
        public DateTime HireDate { get; set; }

        [Display(GroupName = "{Tabs}/Job"), DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(GroupName = "{Tabs}/Job", Order = 7)]
        public string Title { get; set; }



        [TreeListLookUpBinding(DataSourceType = typeof (Department), DisplayMember = "Name",
            ValueMember = "DepartmentId", KeyFieldName = "DepartmentId", ParentKeyFieldName = "DepartmentParendId")]
        [CustomFilter(FilterString = "[Deleted]=false")]
        [Display(GroupName = "{Tabs}/Job", Name = "Department")]
        public long? DepartmentId { get; set; }

        //public List<Flight> Flights { get; set; }

    }
}
