using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtraEditorsBinding.Attributes;

namespace XtraEditorsBindingSample.DataModel
{
    public class Flight
    {
        public long FlightId { get; set; }
        //[SearchLookupBinding(DataSourceType = typeof(Country), DisplayMember = "Name", ValueMember = "CountryId")]
        //[CustomFilter(FilterString = "[Deleted]=false")]
        //[Display(Name = "Country", GroupName = "Destination-")]
        //public long CountryId { get; set; }

        [SearchLookupBinding(DataSourceType = typeof(City), DisplayMember = "Name", ValueMember = "CityId")]
        [CustomFilter(FilterString = "[Deleted]=false", Parameters = "CountryId")]
        [Display(Name = "City", GroupName = "Destination-")]
        public long CityId { get; set; }

        [SearchLookupBinding(DataSourceType = typeof(TransportCompany), DisplayMember = "Name", ValueMember = "CountryId")]
        [CustomFilter(FilterString = "[Deleted]=false")]
        [Display(Name = "TransportCompany")]
        public long TransportCompanyId { get; set; }

        public string Name { get; set; }

        [Browsable(false)]
        public bool Deleted { get; set; }
    }
}
