using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.DL
{
    internal class DriverLocationDL
    {
        protected static List<string> driverCurrentLocations = new List<string>();

        // add in list
        public static void addInList(string driverName, string currentLocation, bool pick, bool drop)
        {
            if (currentLocation == null || currentLocation == "") { currentLocation = " "; }
            driverCurrentLocations.Add(driverName + "," + currentLocation + "," + pick + "," + drop);
        }

        // add in list -> from file 
        public static void addInList(string line)
        {
            driverCurrentLocations.Add(line);
        }

        // get list
        public static List<string> getDriverCurrentLocationsList() { return driverCurrentLocations; }

        // remove from list
        public static void removeFromList(string driverName) 
        {
            foreach (string line in driverCurrentLocations)
            {
                string[] data = line.Split(',');
                if (data[0] == driverName)
                {
                    driverCurrentLocations.Remove(line);
                    break;
                }
            }
        }  


        // get certain driver's location
        public static string getDriverCurrentLocation(string driverName)
        {
            if (driverCurrentLocations.Count == 0) { return null; }
            foreach (string location in driverCurrentLocations)
            {
                string[] data = location.Split(',');
                if (data[0] == driverName) { return data[1]; }
            }
            return null;
        }

        // get certian driver pick
        public static bool getDriverPickUp(string driverName)
        {
            if (driverCurrentLocations.Count == 0) { return false; }
            foreach (string location in driverCurrentLocations)
            {
                string[] data = location.Split(',');
                if (data[0] == driverName) { return bool.Parse(data[2]); }
            }
            return false;
        }

        // get certian driver drop
        public static bool getDriverDropOff(string driverName)
        {
            if (driverCurrentLocations.Count == 0) { return false; }
            foreach (string location in driverCurrentLocations)
            {
                string[] data = location.Split(',');
                if (data[0] == driverName) { return bool.Parse(data[3]); }
            }
            return false;
        }

        // print list
        public static void printList()
        {
            foreach (string location in driverCurrentLocations)
            {
                Console.WriteLine(location);
            }
            Console.ReadKey();
        }

        // store in file
        public static void StoreData(string path)
        {
            StreamWriter file = new StreamWriter(path);
            foreach (string data in  driverCurrentLocations)
            {
                file.WriteLine(data);
            }
            file.Flush();
            file.Close();
        }

        // load from file
        public static void LoadDataFromFile(string path)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    addInList(line);
                }
                file.Close ();
            }
        }
    }
}
