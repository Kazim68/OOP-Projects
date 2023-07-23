using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.UI;

namespace TransportCompany.BL
{
    public class Person
    {
        protected string name;
        protected string password;
        protected City city;
        protected string address;
        protected string role;

        // parameterized constructor
        public Person(string name, string password, string role, City city, string address)
        {
            this.name = name;
            this.password = password;
            this.city = city;
            this.address = address;
            this.role = role;
        }

        public string Name { get => name; }
        public string Password { get => password; }
        public string City { get => city.getName(); }
        public string Address { get => address; }
        public string Role { get => role; }


        // get name
        public string getName() { return this.name; }

        // get password
        public string getPassword() { return this.password;}

        // get city
        public City getCity() { return this.city;}

        // get address
        public string getAddress() { return this.address;}

        // set password
        public void setPassword(string password) { this.password = password; }

        // set city
        public void setCity(City city) { this.city = city;}

        // set address
        public void setAddress(string address) { this.address = address;}  
        
        // get role
        public string getRole() { return this.role; }

        // to string
        public string toString()
        {
            return this.name + "," + this.password + "," + this.role + "," + this.city.getName() + "," + this.address;
        }

        // change password
        public void changePassword()
        {
            if (this.password == Input.stringInput("Enter current Password: "))
            {
                this.password = Input.newPassword();
                
            }
            else
            {
                Console.WriteLine("Invalid Password!");
            }
        }

        // change city
        public void changeCity()
        {
            this.city = MUser.ValidCity();
        }
    }
}
