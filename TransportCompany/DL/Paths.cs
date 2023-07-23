using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.DL
{
    internal class Paths
    {
        // file paths globally declared
        protected static string signUpPath = "SignUpData.txt";
        protected static string cityPath = "Cities.txt";
        protected static string vehiclePath = "Vehicle.txt";
        protected static string PersonDLPath = "PersonData.txt";
        protected static string OrdersPath = "Orders.txt";
        protected static string DriverVehiclePath = "DriverVehicle.txt";
        protected static string driverLocationPath = "LocationRecord.txt";
    
        // get sign up path
        public static string SignUpPath() { return signUpPath; }

        public static string CityPath() { return cityPath;}

        public static string VehiclePath() {  return vehiclePath;}

        public static string PersonDataPath() { return PersonDLPath; }

        public static string OrdersDataPath() { return OrdersPath; }

        public static string DriverVehicleDataPath() { return DriverVehiclePath;}

        public static string DriverLocationDataPath() { return driverLocationPath;}
    
    }
}
