using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.BL;
using TransportCompany.DL;

namespace TransportCompany.UI
{
    internal class CityUI
    {
        // take inputs for a new a city and return it
        public static City CityInput()
        {
            string name = uniqueCity();
            int size = validSize("Enter how many locations to add in city:  ", 10);
            List<Location> locations = new List<Location>();
            for (int i = 0; i < size; i++) // locations donot need to be unique
            {
                locations.Add(new Location(Input.stringInput("Enter name of area: "), validSize("Enter the distance cost you want to associate with it: ", 10)));
            }
            return new City(name, locations);
        }

        // get unique city
        public static string uniqueCity()
        {
            do
            {
                string city = Input.stringInput("Enter name of City: ");
                if (!CityDL.isCityInList(city)) { return city; }
                Console.WriteLine("City already exists!");
            } while (true);
        }

        // size validation
        public static int validSize(string message, int length)
        {
            do
            {
                int size = Input.intInput(message);
                if (size < length) { return size; }
                Console.WriteLine("Size limit Exceeded!");
            } while (true);
        }

        // print all info of a city
        public static void printAllCitiesInfo()
        {
            int count = 1;
            foreach (City city in CityDL.getCities())
            {
                Console.WriteLine(count + ". " + city.getName());
                count++;
            }
        }

        // print city locations
        public static void printCityLocations(City city)
        {
            Console.WriteLine("City Name: {0}", city.getName());
            Console.WriteLine("Sr#\t\tArea");
            int serial = 1;
            foreach (Location location in city.getAreas())
            {
                Console.WriteLine("{0}\t\t{1}", serial, location.getName());
                serial++;
            }
        }

    }
}
