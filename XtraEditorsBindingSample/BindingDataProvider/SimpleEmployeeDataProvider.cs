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
            if (type.Equals(typeof(TransportCompany)))
                return GetTransportCompanies();
            if (type.Equals(typeof(Flight)))
                return GetFlights();
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
        private List<TransportCompany> GetTransportCompanies()
        {
            List<TransportCompany> transportCompanies = new List<TransportCompany>();
            transportCompanies.Add(new TransportCompany() { TransportCompanyId = 1, Name = "Aeroflot" });
            transportCompanies.Add(new TransportCompany() { TransportCompanyId = 2, Name = "S7" });
            transportCompanies.Add(new TransportCompany() { TransportCompanyId = 3, Name = "Qatar airlines" });
            transportCompanies.Add(new TransportCompany() { TransportCompanyId = 4, Name = "Turkish airlines" });
            transportCompanies.Add(new TransportCompany() { TransportCompanyId = 5, Name = "Transaero" });
            return transportCompanies;
        }

        private List<Flight> GetFlights()
        {
            List<Flight> flights = new List<Flight>();
            flights.Add(new Flight() {FlightId = 1, CityId = 1, TransportCompanyId = 1, Name = "A231"});
            flights.Add(new Flight() {FlightId = 2, CityId = 1, TransportCompanyId = 2, Name = "B234"});
            flights.Add(new Flight() {FlightId = 3, CityId = 2, TransportCompanyId = 1, Name = "C578"});
            flights.Add(new Flight() {FlightId = 4, CityId = 2, TransportCompanyId = 3, Name = "D298"});
            flights.Add(new Flight() {FlightId = 5, CityId = 3, TransportCompanyId = 1, Name = "E190"});
            flights.Add(new Flight() {FlightId = 6, CityId = 3, TransportCompanyId = 3, Name = "F675"});
            flights.Add(new Flight() {FlightId = 7, CityId = 3, TransportCompanyId = 4, Name = "G098"});
            flights.Add(new Flight() {FlightId = 8, CityId = 4, TransportCompanyId = 5, Name = "H593"});
            flights.Add(new Flight() {FlightId = 9, CityId = 4, TransportCompanyId = 4, Name = "I940"});
            flights.Add(new Flight() {FlightId = 10, CityId = 5, TransportCompanyId = 1, Name = "K234"});
            flights.Add(new Flight() {FlightId = 11, CityId = 5, TransportCompanyId = 2, Name = "L283"});
            flights.Add(new Flight() {FlightId = 12, CityId = 5, TransportCompanyId = 3, Name = "P748"});
            return flights;
        }
    }
}
