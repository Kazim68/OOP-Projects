using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.BL;
using TransportCompany.DL;

namespace TransportCompany.UI
{
    internal class MUser
    {
        // sign in
        public static Person SignIn()
        {
            string name = Input.stringInput("Enter Name: ");
            string password = Input.stringInput("Enter Password: ");
            return PersonDL.checkSignIn(name, password);
        }

        // sign up
        public static void SignUp(string name, string password, string role, string cityName, string address)
        {
            /*
            string name = UniqueName();
            string password = Input.stringInput("Enter Password: ");
            string role = ValidRole();
            City  city = ValidCity();
            string address = Input.stringInput("Enter Address: ");
            */

            City city = CityDL.getCityFromList(cityName);

            if (role.ToLower() == "customer")
            {
                PersonDL.addUserInList(new Customer(name, password, role, city, address));
            }
            else
            {
                //Console.WriteLine("We will process your application...\nFor further details visit our campus.");
                SignUpDL.addInList(new Driver(name, password, role, city, address));
            }
        }

        // admin sign in
        public static bool AdminSignIn(Admin admin, string name, string password)
        {
            if (name == admin.getName() && password == admin.getPassword()) { return true; }
            return false;
        }

        // take unique username
        public static string UniqueName()
        {
            string name;
            do
            {
                name = Input.stringInput("Enter Name: ");
                if (!PersonDL.duplicateName(name))
                {
                    return name;
                }
                Console.WriteLine("Username already exists!");
            }
            while (true);
        }

        // validate city name
        public static City ValidCity()
        {
            string city;
            do
            {
                city = Input.stringInput("Enter name of city: ");
                if (CityDL.isCityInList(city)) { return CityDL.getCityFromList(city); }
                Console.WriteLine("Invalid City name or we donot offer services in this city!");
            }
            while (true);
        }

        // validate vehicle name
        public static Vehicle ValidVehicle()
        {
            string vehicle;
            do
            {
                vehicle = Input.stringInput("Enter name of vehicle: ");
                if (VehicleDL.isVehicleInList(vehicle)) { return VehicleDL.getVehicleFromList(vehicle); }
                Console.WriteLine("Invalid Vehicle name!");
            }
            while (true);
        }

        // get valid role
        public static string ValidRole()
        {
            string role;
            do
            {
                role = Input.stringInput("Enter Role: ");
                if (role.ToLower() == "customer" || role.ToLower() == "driver") { return role; }
                Console.WriteLine("Invalid Role: ");
            }
            while (true);
        }

        // display person
        public static void displayPersonData(Person person)
        {
            Console.WriteLine("Name\t\tCity");
            Console.WriteLine("{0}\t\t{1}", person.getName(), person.getCity().getName());
        }
    }
}
