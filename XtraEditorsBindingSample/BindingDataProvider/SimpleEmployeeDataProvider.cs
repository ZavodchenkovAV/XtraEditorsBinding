using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtraEditorsBinding.Interfaces;
using XtraEditorsBindingSample.DataModel;

namespace XtraEditorsBindingSample.BindingDataProvider
{
    public class SimpleEmployeeDataProvider : IBindingDataProvider
    {
        public IList GetData(Type type)
        {
            if (type.Equals(typeof (Country)))
                return GetCountries();
            throw new NotImplementedException($"for type {type.FullName} no data");
        }

        private List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            countries.Add(new Country() {CountryId = 1,Name = "Russia"});
            countries.Add(new Country() { CountryId = 2, Name = "Spain" });
            countries.Add(new Country() { CountryId = 3, Name = "Tunisia" });
            countries.Add(new Country() { CountryId = 4, Name = "Gobon", Deleted = true});
            countries.Add(new Country() { CountryId = 5, Name = "China" });
            return countries;
        }
    }
}
