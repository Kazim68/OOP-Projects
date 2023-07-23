using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.BL
{
    internal class Order
    {
        protected Customer customer;
        protected Driver driver;
        protected City city;
        protected Vehicle vehicle;
        protected Location pickUp;
        protected Location dropOff;
        protected float bill;
        protected int ratings;
        protected bool isComplete;

        // this encapsulation is just for data grid view
        public string Customer { get => customer.getName(); }
        public string Driver { get =>  getDriverName(); }
        public string City { get => city.getName(); }
        public  string Vehicle { get => vehicle.getName(); }
        public string PickUp { get => pickUp.getName(); }
        public string DropOff { get => dropOff.getName(); }
        public float Bill { get => bill; set => bill = value; }
        public int Ratings { get => ratings; set => ratings = value; }
        public bool IsComplete { get => isComplete; set => isComplete = value; }

        // parameterized constructor
        public Order(Customer customer, City city, Location pickUp, Location dropOff, Vehicle vehicle)
        {
            this.customer = customer;
            this.city = city;
            this.pickUp = pickUp;
            this.dropOff = dropOff;
            this.vehicle = vehicle;
            this.driver = null;
            this.IsComplete = false;
            this.Bill = this.calculateBill();
            this.Ratings = 0;
        }

        // return driver name
        public string getDriverName()
        {
            if (this.driver == null)
            { return "Null"; }
            return this.driver.getName();
        }

        // get customer
        public Customer GetCustomer() { return this.customer; }

        // get driver
        public Driver GetDriver() { return this.driver;}

        // get city
        public City GetCity() { return this.city;}

        // get vehicle
        public Vehicle getVehicle() { return this.vehicle; }

        // get pick up
        public Location getPickUp() { return this.pickUp;}

        // get drop off
        public Location getDropOff() { return this.dropOff;}

        // get ratings 
        public int getRating() { return this.Ratings;}

        // set ratings
        public void setRating(int r) { this.Ratings = r;}

        // // get order status
        public bool getStatus() { return this.IsComplete; }

        // set order status
        public void setStatus(bool status) { this.IsComplete = status;}

        // set driver
        public void setDriver(Driver driver) { this.driver = driver;}

        // get bill
        public float getBill() { return this.Bill;}

        // calculate bill
        public float calculateBill()
        {
            return this.vehicle.getCostIndex() * Math.Abs(this.dropOff.getDistance() - this.pickUp.getDistance()) + 10;
        }

        // to string
        public string toString()
        {   
            string d;
            if (this.driver == null)
            {d = "null";}
            else
            {d = this.driver.getName();}
            return this.customer.getName() + "," + this.city.getName() + "," + this.pickUp.toString() + "," + this.dropOff.toString() + "," + this.vehicle.getName() + "," + this.IsComplete + "," + d + "," + this.Ratings;
        }
        
    }
}
