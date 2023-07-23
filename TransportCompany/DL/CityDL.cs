using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.BL;

namespace TransportCompany.DL
{
    internal class CityDL
    {
        protected static List<City> cities = new List<City>();

        // add in list
        public static void addCityInList(City city) { cities.Add(city); }

        // get cities list
        public static List<City> getCities() {  return cities; }

        // return a list of cities names
        public List<string> getCitiesNamesInList()
        {
            List<string> list  = new List<string>();
            foreach (City city in cities)
            {
                list.Add(city.getName());
            }
            return list;
        }

        // check if city is in list and return a bool
        public static bool isCityInList(string name)
        {
            foreach (City city in cities)
            {
                if (city.getName() == name) { return true; }
            }
            return false;
        }

        // returns a string of all city names
        public static List<string> getCitiesNamesInListForm()
        {
            List<string> citiesList = new List<string>();
            foreach (City city in cities)
            {
                citiesList.Add(city.getName());
            }
            return citiesList;
        }

        // get city from list
        public static City getCityFromList(string name)
        {
            foreach (City city in cities)
            {
                if (city.getName() == name) { return city; }
            }
            return null;
        }

        // file handling
        public static void writeData(string path)
        {
            StreamWriter file = new StreamWriter(path);
            if (cities.Count == 0) { file.WriteLine(""); }
            foreach (City c in cities)
            {
                file.WriteLine(c.toString());
            }
            file.Flush();
            file.Close();
        }

        // load cites from file
        public static bool loadCities(string path)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null && line != "")
                {
                    string[] data = line.Split(',');
                    List<Location> locations = new List<Location>();
                    for (int i = 1; i < data.Count(); i++)
                    {
                        string[] lst = data[i].Split(':');
                        locations.Add(new Location(lst[0], int.Parse(lst[1])));
                    }
                    cities.Add(new City(data[0], locations));
                }
                file.Close();
                return true;
            }
            return false;
        }
    }
}
