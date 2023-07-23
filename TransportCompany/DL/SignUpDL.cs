using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.BL;
using TransportCompany.UI;

namespace TransportCompany.DL
{
    internal class SignUpDL
    {
        protected static List<Person> SignUps = new List<Person>();

        // get list
        public static List<Person> getSignUpList() { return  SignUps; }

        // add in list
        public static void addInList(Person p) { SignUps.Add(p); }

        // remove from list
        public static void RemoveUser(Person p) { SignUps.Remove(p); }

        // remove user from list using name
        public static void RemoveUser(string name)
        {
            foreach (Person p in SignUps)
            {
                if (p.getName() == name)
                {
                    SignUps.Remove(p);
                    break;
                }
            }
        }

        // check for duplicate name
        public static bool duplicateName(string name)
        {
            foreach (Person p in SignUps)
            {
                if (p.getName() == name) { return true; }
            }
            return false;
        }


        // load data
        public static void loadData(string path)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    addInList(new Person(data[0], data[1], data[2], CityDL.getCityFromList(data[3]), data[4]));
                }
                file.Close();
            }
        }

        // write data
        public static void writeData(string path)
        {
            StreamWriter file = new StreamWriter(path);
            foreach (Person p in SignUps)
            {
                file.WriteLine(p.toString());
            }
            file.Flush();
            file.Close();
        }
    }
}
