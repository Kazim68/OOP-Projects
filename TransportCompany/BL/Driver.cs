using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.DL;

namespace TransportCompany.BL
{
    internal class Driver : Person
    {
        protected string location;
        protected Vehicle vehicle;
        protected Order currentOrder;

        // parameterized constructor
        public Driver(string name, string password, string role, City city, string address) : base(name, password, role, city, address) 
        {
            this.vehicle = null;
            this.currentOrder = null;
            this.location = null;
        }

        public bool initializeDriver()
        {
            this.currentOrder = OrderDL.getCurrentOrder(this.name, true);
            if (this.currentOrder == null) { return false; }
            return true;
        }

        public string Location { get => "null"; }

        public string Vehicle { get => this.vehicle.getName(); }
        public string CurrentOrder { get => "null"; }
        public float Rating { get => this.getRating(); }

        // get current location
        public string getLocation() { return this.location; }

        // set current location
        public void setLocation(string location) { this.location = location;}

        // get rating
        public float getRating()
        {
            float rating = 0;
            int count = 0;
            foreach (Order order in OrderDL.getOrders())
            {
                if (order.GetDriver() != null && order.GetDriver().getName() == this.name)
                { rating += order.getRating(); count++; }
            }
            return rating / count;
        }

        // get vehicle
        public Vehicle GetVehicle() { return this.vehicle; }

        // set vehicle 
        public void setVehicle(Vehicle vehicle) { this.vehicle = vehicle;}

        // get current order
        public Order getCurrentOrder() { return this.currentOrder; }

        // set current order
        public void setCurrentOrder(Order order) { this.currentOrder = order;}

        // returns true if customer picked at location
        public bool pickedUp()
        {
            if (this.location == null) { return false; }
            if (this.location == this.currentOrder.getPickUp().getName()) { return true; }
            return false;
        }

        // returns true if customer dropped at location
        public bool droppedOff()
        {
            if (this.location == null) { return false; }
            if (this.location == this.currentOrder.getDropOff().getName()) { return true; }
            return false;
        }

        // save driver and vehicle info on file
        public void saveInFile(string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(base.name + "," + this.vehicle.getName());
            file.Flush();
            file.Close();
        }
    }
}
