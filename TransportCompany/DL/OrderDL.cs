using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.BL;

namespace TransportCompany.DL
{
    internal class OrderDL
    {
        protected static List<Order> orders = new List<Order>();

        // add order in list
        public static void addIntoList(Order order)
        {
            orders.Add(order);
        }

        // get all orders
        public static List<Order> getOrders() { return orders; }

        // returns a list of orders which are in this city
        public static List<Order> getOrder(string city)
        {
            List<Order> temp = new List<Order>();
            foreach (Order order in orders)
            {
                if (order.GetCity().getName() == city)
                {
                    temp.Add(order);
                }
            }
            return temp;
        }

        // returns a list of orders which are of this vehicle
        public static List<Order> getOrder(string vehicle, bool isVehicle)
        {
            List<Order> temp = new List<Order>();
            foreach (Order order in orders)
            {
                if (order.getVehicle().getName() == vehicle)
                {
                    temp.Add(order);
                }
            }
            return temp;
        }

        // get total income of a driver
        public static float getIncome(Driver driver)
        {
            float income = 0;
            foreach (Order order in orders)
            {
                if (order.GetDriver() != null && order.GetDriver().getName() ==  driver.getName())
                {
                    income += order.getBill();
                }
            }
            return income;
        }

        

        // find order for driver
        public static Order findOrder(Driver driver)
        {
            foreach (Order order in orders) 
            {
                if (!order.getStatus() && order.GetDriver() == null && order.GetCity().getName() == driver.getCity().getName() && order.getVehicle().getName() == driver.GetVehicle().getName())
                {
                    return order;
                }
            }
            return null;
        }

        // remove from list
        public static void removeFromList(Order order)
        {
            orders.Remove(order);
        }

        // returns a list of orders of customer
        public static List<Order> getCustomersOrders(Customer customer)
        {
            List<Order> cust = new List<Order>();
            foreach (Order order in orders)
            {
                if (order.GetCustomer().getName() == customer.getName())
                {
                    cust.Add(order);
                }
            }
            return cust;
        }

        // returns a list of orders of drivers
        public static List<Order> getDriverOrders(Driver driver)
        {
            List<Order> driv = new List<Order>();
            foreach (Order order in orders)
            {
                if (order.getStatus() && order.GetDriver().getName() == driver.getName())
                {
                    driv.Add(order);
                }
            }
            return driv;
        }

        // return order which is not completed -> customer
        public static Order getCurrentOrder(string name)
        {
            foreach (Order order in orders)
            {
                if (order.GetCustomer().getName() == name && !order.getStatus())
                {
                    return order;
                }
            }
            return null;
        }

        // return order which is not completed -> driver
        public static Order getCurrentOrder(string name, bool fromDriver)
        {
            foreach (Order order in orders)
            {
                if (order.GetDriver() != null && order.GetDriver().getName() == name && !order.getStatus())
                {
                    return order;
                }
            }
            return null;
        }

        // store data on file
        public static void storeOrder(string path)
        {
            StreamWriter file = new StreamWriter(path);
            if (orders.Count == 0) { file.WriteLine(""); }
            foreach (Order order in orders)
            {
                file.WriteLine(order.toString());
            }
            file.Flush();
            file.Close();
        }

        // load data on file
        public static void loadOrders(string path)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null && line != "")
                {
                    string[] data = line.Split(',');

                    Person p = PersonDL.getPersonFromList(data[0]); // get person from list -> customer
                    Customer c = null;
                    if (p is Customer) { c = (Customer)p;} // check and convert it to customer

                    Person d = PersonDL.getPersonFromList(data[6]); // get person from list -> driver
                    Driver driver = null;
                    if (d is Driver) { driver = (Driver)d;} // check and convert it to driver

                    // create order
                    Order o = new Order(c, CityDL.getCityFromList(data[1]), new Location(data[2].Split(':')[0], int.Parse(data[2].Split(':')[1])), new Location(data[3].Split(':')[0], int.Parse(data[3].Split(':')[1])), VehicleDL.getVehicleFromList(data[4]));
                    o.setStatus(bool.Parse(data[5]));
                    o.setRating(int.Parse(data[7]));
                    if (data[6] != "null") { o.setDriver(driver); }
                    else { o.setDriver(null); }

                    // add in list
                    addIntoList(o);
                }
                file.Close();
            }
        }
    }
}
