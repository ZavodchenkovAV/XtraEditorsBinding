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
            if (type.Equals(typeof(City)))
                return GetCities();
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
        private List<City> GetCities()
        {
            List<City> cities = new List<City>();
            cities.Add(new City() { CityId = 1,CountryId = 1, Name = "Voronezh" });
            cities.Add(new City() { CityId = 2, CountryId = 1, Name = "Omsk" });
            cities.Add(new City() { CityId = 3, CountryId = 2, Name = "Madrid" });
            cities.Add(new City() { CityId = 4, CountryId = 5, Name = "Nankin", Deleted = true });
            cities.Add(new City() { CityId = 5, CountryId = 5, Name = "Beijing" });
            return cities;
        }
    }
}
