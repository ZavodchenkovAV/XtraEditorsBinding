using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtraEditorsBinding.Attributes;

namespace XtraEditorsBindingSample.DataModel
{
    public class Trip
    {
        [SearchLookupBinding(DataSourceType = typeof(Country), DisplayMember = "Name", ValueMember = "CountryId")]
        [CustomFilter(FilterString = "[Deleted]=false")]
        [Display(Name = "Country", GroupName = "Destination-")]
        public long TripCountryId { get; set; }

        [SearchLookupBinding(DataSourceType = typeof(City), DisplayMember = "Name", ValueMember = "CityId")]
        [CustomFilter(FilterString = "[Deleted]=false and CountryId=?", Parameters = "TripCountryId")]
        [Display(Name = "City", GroupName = "Destination-")]
        public long TripCityId { get; set; }

        [SearchLookupBinding(DataSourceType = typeof(TransportCompany), DisplayMember = "Name", ValueMember = "TransportCompanyId")]
        [Display(Name = "TransportCompany")]
        public long TripTransportCompanyId { get; set; }

        [SearchLookupBinding(DataSourceType = typeof(Flight), DisplayMember = "Name", ValueMember = "FlightId")]
        [CustomFilter(FilterString = "[Deleted]=false and TransportCompanyId=? and CityId=?", Parameters = "TripTransportCompanyId,TripCityId")]
        [Display(Name = "Flight")]
        public long FlightId { get; set; }
    }
}
