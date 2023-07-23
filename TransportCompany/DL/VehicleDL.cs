using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.BL;

namespace TransportCompany.DL
{
    internal class VehicleDL
    {
        protected static List<Vehicle> vehicles = new List<Vehicle>();

        // add vehicle in list
        public static void addIntoList(Vehicle vehicle) { vehicles.Add(vehicle); }

        // get all vehicles
        public static List<Vehicle> getAllVehicles() { return vehicles; }

        // get vehicle from list based on name
        public static Vehicle getVehicleFromList(string name)
        {
            foreach (Vehicle vehicle in vehicles) 
            {
                if (vehicle.getName() == name)
                {
                    return vehicle;
                }
            }
            return  null;
        }

        // returns a list of vehicle names
        public static List<string> getVehicleNamesInList()
        {
            List<string> list = new List<string>();
            foreach (Vehicle vehicle in vehicles)
            {
                list.Add(vehicle.getName());
            }
            return list;
        }

        // return bool from list based on name
        public static bool isVehicleInList(string name)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.getName() == name)
                {
                    return true;
                }
            }
            return false;
        }

        // write in file
        public static void WriteData(string path)
        {
            StreamWriter file = new StreamWriter(path);
            if (vehicles.Count == 0) { file.WriteLine(""); }
            foreach (Vehicle v in vehicles)
            {
                file.WriteLine(v.getName()+ "," + v.getCostIndex());
            }
            file.Flush();
            file.Close();
        }

        // get data from file
        public static bool loadVehicleData(string path)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null && line != "")
                {
                    string[] data = line.Split(',');
                    addIntoList(new Vehicle(data[0], int.Parse(data[1]))); // created a new vehicle and added in list
                }
                file.Close();
                return true;
            }
            return false;
        }
    }
}
