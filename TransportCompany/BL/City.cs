using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.BL
{
    public class City
    {
        protected string name;
        protected List<Location> areas;

        // parameterized constructor
        public City(string name, List<Location> areas) { this.name = name; this.areas = areas; }

        // get name
        public string getName() { return this.name; }

        public string City_Name { get => this.name; }

        // get areas
        public List<Location> getAreas() {  return this.areas; }

        // get specific location
        public Location getLocation(string name)
        {
            foreach (Location l in this.areas)
            {
                if (l.getName() == name) { return l; }
            }
            return null;
        }

        // returns locations as a list of string
        public List<string> getLocationNamesInList()
        {
            List<string> names = new List<string>();
            foreach (Location l in this.areas)
            {
                names.Add(l.getName());
            }
            return names;
        }

        // add location
        public void addLocation(Location location)
        {
            this.areas.Add(location);
        }

        // checks if location is in city
        public bool checkLocation(string name)
        {
            foreach (Location l in this.areas)
            {
                if (l.getName() == name)
                {
                    return true;
                }
            }
            return false;
        }

        // return the list of locations as a string
        public string LocationsToString()
        {
            string locations = "";
            foreach (Location location in this.areas) 
            {
                locations += "," + location.toString();
            }
            return locations;
        }

        // to string
        public string toString() { return this.name + this.LocationsToString(); }

    }
}
