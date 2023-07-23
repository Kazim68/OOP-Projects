using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.DL;

namespace TransportCompany.BL
{
    internal class Customer : Person
    {
        protected Order currentOrder;

        // parameterized constructor
        public Customer(string name, string password, string role, City city, string address) : base(name, password, role, city, address) 
        {
            currentOrder = null;
        }

        // get current order
        public Order getCurrentOrder() { return currentOrder; }

        // set current order
        public void setCurrentOrder(Order order) { currentOrder = order; }

        // set current order of customer if there is any
        public bool initializeCustomer()
        {
            this.currentOrder = OrderDL.getCurrentOrder(this.name);
            if (this.currentOrder == null) { return false; }
            return true;
        }

    }
}
