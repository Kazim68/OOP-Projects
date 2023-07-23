using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.BL;

namespace TransportCompany.DL
{
    internal class PersonDL
    {
        public static List<Person> users = new List<Person>();

        // add a new user
        public static void addUserInList(Person person) { users.Add(person); }

        // get users list
        public static List<Person> getUsersList() { return users; }


        // get person based on name
        public static Person getPersonFromList(string name)
        {
            foreach (Person person in users)
            {
                if (person.getName() == name) { return person; }
            }
            return null;
        }

        // check sign in 
        public static Person checkSignIn(string name, string password)
        {
            foreach (Person person in users)
            {
                if (person.getName() == name && person.getPassword() == password) { return person; }
            }
            return null;
        }

        // check for duplicate name
        public static bool duplicateName(string name)
        {
            foreach (Person p in users)
            {
                if (p.getName() == name) { return true; }
            }
            return false;
        }

        // create user on the basis of role
        public static Person createAppropriateUser(string name, string password, string role, string city, string address)
        {
            if (role.ToLower() == "customer")
            {
                return new Customer(name, password, role, CityDL.getCityFromList(city), address);
            }
            return new Driver(name, password, role, CityDL.getCityFromList(city), address);
        }

        // initialize driver vehicles
        public static void initiateDriverVehicles(Driver driver, string path)
        {
            driver.setVehicle(VehicleDL.getVehicleFromList(loadDriverVehicleInfo(driver.getName(), path)));
        }

        // load driver vehicle info
        public static string loadDriverVehicleInfo(string name, string path)
        {
           if (File.Exists(path))
           {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data[0] == name) { file.Close(); return data[1]; }
                }
                file.Close();
           }
            return null;
        }

        // write data on file
        public static void writeData(string path)
        {
            StreamWriter file = new StreamWriter(path);
            foreach (Person person in users)
            {
                file.WriteLine(person.toString());
            }
            file.Flush();
            file.Close();
        }

        // load data
        public static void loadData(string path)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null && line != "")
                {
                    string[] data = line.Split(',');
                    addUserInList(createAppropriateUser(data[0], data[1], data[2], data[3], data[4]));
                }
                file.Close();
            }
        }

    }
}
