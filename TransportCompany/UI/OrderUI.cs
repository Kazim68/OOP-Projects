using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.BL;
using TransportCompany.DL;

namespace TransportCompany.UI
{
    internal class OrderUI
    {
        // take new order and return new order object
        public static Order takeOrder(Customer customer, string veh, string pickup, string dropoff)
        {
            Location pick = customer.getCity().getLocation(pickup);
            Location drop = customer.getCity().getLocation(dropoff);
            Vehicle vehicle = VehicleDL.getVehicleFromList(veh);

            Order order = new Order(customer, customer.getCity(), pick, drop, vehicle);
            customer.setCurrentOrder(order);

            OrderDL.addIntoList(order);
            OrderDL.storeOrder(Paths.OrdersDataPath());

            return order;
        }

        // valid location
        public static Location validLocation(City city, string lo)
        {
            do
            {
                Location l = city.getLocation(Input.stringInput("Enter " + lo + " location: "));
                if (l != null) { return l; }
                Console.WriteLine("Invalid Location or we donot offer services in this location!");
            }
            while (true);
        }

        // valid vehicle
        public static Vehicle validVehicle()
        {
            do
            {
                Vehicle vehicle = VehicleDL.getVehicleFromList(Input.stringInput("Enter name of vehicle: "));
                if (vehicle != null) { return vehicle; }
                Console.WriteLine("Invalid Vehicle or we donot offer services in this Vehicle!");
            }
            while (true);
        }

        // get valid location in string
        public static string getValidLocationInString(City city, string l)
        {
            string lo = ""; 
            do
            {
                lo = Input.stringInput("Enter " + l + " location: ");
                if (city.checkLocation(lo))
                {
                    return lo;
                }
                Console.WriteLine("Invalid Location!");
            }
            while (true);
        }

        // display order credentials for driver 
        public static void displayOrder(Order order)
        {
            Console.WriteLine("Customer\t\tPick\t\tDrop\t\tVehicle\t\tBill");
            Console.WriteLine("{0}\t\t\t{1}\t\t{2}\t{3}\t\t{4}", order.GetCustomer().getName(), order.getPickUp().getName(), order.getDropOff().getName(), order.getVehicle().getName(), order.getBill());
        }

        // show all orders for driver
        public static void showAllOrders(Driver driver)
        {
            Console.WriteLine("Driver name: " + driver.getName() + "\n");
            Console.WriteLine("Customer\t\tCity\t\tPick\t\tDrop\t\tVehicle\t\tBill\t\tRatings");

            foreach (Order order in OrderDL.getOrders())
            {
                if (order.GetDriver() != null && order.GetDriver().getName() == driver.getName())
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}", order.GetCustomer().getName(), driver.getCity().getName(), order.getPickUp().getName(), order.getDropOff().getName(), order.getVehicle().getName(), order.getBill(), order.getRating());
                }
            }
        }

        // show all orders for customer
        public static void showAllOrders(Customer customer)
        {
            Console.WriteLine("Customer\t\tDriver\t\tCity\t\tPick\t\tDrop\t\tVehicle\t\tBill\t\tRatings");
            foreach (Order order in OrderDL.getOrders()) 
            {
                if (order.GetCustomer().getName() == customer.getName())
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}", customer.getName(), order.GetDriver().getName(), customer.getCity().getName(), order.getPickUp().getName(), order.getDropOff().getName(), order.getVehicle().getName(), order.getBill(), order.getRating());
                }
            }
        }

        // cancel order from driver
        public static void cancelRide(Driver driver)
        {
            // cancelling current ride
            driver.getCurrentOrder().setDriver(null);
            driver.setCurrentOrder(null);
            OrderDL.storeOrder(Paths.OrdersDataPath());
        }

        // cancel order from customer
        public static void cancelOrder(Order currentOrder)
        {
            OrderDL.removeFromList(currentOrder); // cancelling current order
            currentOrder = null;
            OrderDL.storeOrder(Paths.OrdersDataPath());
        }

        // current order screen of customer
        public static void currentOrderScreen(Order currentOrder, string path, string driverLocationPath)
        {
            displayOrder(currentOrder); // order printed on screen

            // driver
            if (currentOrder.GetDriver() == null) // if no driver
            { 
                Console.WriteLine("Searching Driver..."); 

                // asking if user wants to cancel order
                cancelOrder(currentOrder);

            }
            else // if driver exists
            {
                if (DriverLocationDL.getDriverPickUp(currentOrder.GetDriver().getName()) && !DriverLocationDL.getDriverDropOff(currentOrder.GetDriver().getName()))
                {
                    Console.WriteLine("You are on the way to your Destination!"); // if picked up
                }
                else if (!DriverLocationDL.getDriverPickUp(currentOrder.GetDriver().getName()) && !DriverLocationDL.getDriverDropOff(currentOrder.GetDriver().getName()))
                {
                    Console.WriteLine("Driver is on the way!"); // if not arrived at pick up yet
                }
                else if (DriverLocationDL.getDriverDropOff(currentOrder.GetDriver().getName())) // arrived at destination
                {
                    Console.WriteLine("You have arrived at your Destination!"); // customer arrived at destination
                    //currentOrder.setRating(Input.validInt("Rate our services out of 5: ", 5)); // getting rating from customer
                    currentOrder.setStatus(true);
                    OrderDL.storeOrder(path);
                    DriverLocationDL.removeFromList(currentOrder.GetDriver().getName());  // removing ongiong driver location record
                    DriverLocationDL.StoreData(driverLocationPath);
                }
            }

            Menus.Transition();
        }

        // current order screen of driver
        public static void currentOrderScreen(Driver driver, string path, string driverLocationPath)
        {
            Console.WriteLine("Driver: " + driver.getName() + "\n");

            displayOrder(driver.getCurrentOrder()); // printing current order

            driver.setLocation(DriverLocationDL.getDriverCurrentLocation(driver.getName())); // get current location

            if (driver.getLocation() == null) { Console.WriteLine("Leave in a moment!"); } 
            else { Console.WriteLine("Your current location: " + driver.getLocation() + "\n"); }

            if (DriverLocationDL.getDriverPickUp(driver.getName()) && !DriverLocationDL.getDriverDropOff(driver.getName())) // if picked up and in journey
            {
                // change current location
                driver.setLocation(getValidLocationInString(driver.getCity(), "current"));
                // check if this is drop off location
                if (driver.droppedOff())
                {
                    DriverLocationDL.removeFromList(driver.getName()); // removing from list
                    DriverLocationDL.addInList(driver.getName(), driver.getLocation(), true, true); // adding in list
                    DriverLocationDL.StoreData(driverLocationPath); // updating file
                    Console.WriteLine("You have arrived at your destination!");
                }
            }
            else if (!DriverLocationDL.getDriverPickUp(driver.getName())) // havent picked up yet
            {
                Menus.driverPickUpMenu();
                string option = "";
                do
                {
                    option = Input.Option();
                    if (option == "1")
                    {
                        // change current location
                        driver.setLocation(getValidLocationInString(driver.getCity(), "current"));

                        if (driver.pickedUp()) // if arrived at pick up location
                        {
                            DriverLocationDL.removeFromList(driver.getName()); // removing from list
                            DriverLocationDL.addInList(driver.getName(), driver.getLocation(), true, false); // adding in list
                            DriverLocationDL.StoreData(driverLocationPath); // updating file
                            Console.WriteLine("You have arrived at the Pick up location!");
                        }
                    }
                    else if (option == "2")
                    {
                        // cancel ride
                        cancelRide(driver);
                    }
                    else if (option != "0")
                    {
                        Menus.incorrectOption();
                    }
                } while (option != "0");
            }
            if (DriverLocationDL.getDriverDropOff(driver.getName())) // dropped off
            {
                Console.WriteLine("You have reached your destination!");
            }

            Menus.Transition();
        }

    }
}