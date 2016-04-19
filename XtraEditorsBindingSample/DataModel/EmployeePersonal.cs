using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtraEditorsBinding.Attributes;

namespace XtraEditorsBindingSample.DataModel
{
    public class EmployeePersonal
    {  //The two items below will go to a horizontally oriented Personal group.  
        [Display( Name = "Birth date")]
        public DateTime BirthDate { get; set; }
        [EnumDataType(typeof(GenderEnum))]
        [Display(GroupName = "<Name->")]
        public int? Gender { get; set; }
        [SearchLookUpBinding(DataSourceType = typeof(Country), DisplayMember = "Name", ValueMember = "CountryId")]
        [CustomFilter(FilterString = "[Deleted]=false")]
        [Display(Name = "CountryBirthPlace")]
        public long CountryBirthPlaceId { get; set; }

        [SearchLookUpBinding(DataSourceType = typeof(City), DisplayMember = "Name", ValueMember = "CityId")]
        [CustomFilter(FilterString = "[Deleted]=false and CountryId=?", Parameters = "CountryBirthPlaceId")]
        [Display(Name = "CityBirthPlace")]
        public long CityBirthPlaceId { get; set; }
        [Display(Name = "Alien", GroupName = "<Name->")]
        public bool? Alien { get; set; }
        public enum GenderEnum { Male, Female }
        
    }
}
