using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.Response
{
    public class Location
    {
        public string address;
        public string city;
        public string state;
        public string zip;
        Coordinates coordinates;

        public Location(string address, string city, string state, string zip, Coordinates cooridnates)
        {
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.coordinates = coordinates;
        }

        
    }

    public class Coordinates
    {
        public string lat;
        public string lon;

        public Coordinates(string lat, string lon)
        {
            this.lat = lat;
            this.lon = lon;
        }
    }
}
