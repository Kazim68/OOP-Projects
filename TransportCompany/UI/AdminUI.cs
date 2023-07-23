using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.BL;
using TransportCompany.DL;

namespace TransportCompany.UI
{
    internal class AdminUI
    {
        // approve new driver 
        public static void ApproveDriver(string usersPath, string driverVehiclePath)
        {
            if (SignUpDL.getSignUpList().Count > 0)
            {
                Person person = SignUpDL.getSignUpList()[0]; // getting person from list

                SignUpDL.RemoveUser(person); // removing from list
                SignUpDL.writeData(usersPath); // storing in file

                MUser.displayPersonData(person); // display person info

                Menus.DriverApproveMenu();

                string option = "";
                do
                {
                    option = Input.Option();
                    if (option == "1")
                    {
                        // approve driver
                        Driver driver = (Driver)person;
                        driver.setVehicle(MUser.ValidVehicle());
                        driver.saveInFile(driverVehiclePath);
                        PersonDL.addUserInList(driver);
                        break;
                    }
                    else if (option == "2")
                    {
                        // reject driver
                        break;
                    }
                    else
                    {
                        Menus.incorrectOption();
                    }
                } while (true);

                Menus.Transition();
            }
            else
            {
                Console.WriteLine("No Records!");
            }
        }

        // modify city
        public static void modifyCity()
        {
            CityUI.printAllCitiesInfo(); // print all cities
            City city = MUser.ValidCity();

            city.addLocation(new Location(Input.stringInput("Enter name of area: "), CityUI.validSize("Enter the distance cost you want to associate with it: ", 10)));
        }

        // add vehicle
        public static void addVehicle()
        {
            string name = uniqueVehicle();
            int distanceCostRatio = CityUI.validSize("Enter cost per Distance unit: ", 500);
            VehicleDL.addIntoList(new Vehicle(name, distanceCostRatio));
        }

        // get uique vehicle name
        public static string uniqueVehicle()
        {
            do
            {
                string vehicle = Input.stringInput("Enter Vehicle name: ");
                if (!VehicleDL.isVehicleInList(vehicle) && vehicle != "") { return vehicle; }
                Console.WriteLine("Invalid Input or Vehicle already exists!");
            } while (true);
        }

        // modify vehicle
        public static void modifyVehicle()
        {
            printVehicleInfo(); // showing all vehicles

            Vehicle v = MUser.ValidVehicle();

            v.setCostIndex(CityUI.validSize("Enter new cost index: ", 500));

        }

        // print all vehicle info
        public static void printVehicleInfo()
        {
            int c = 1;
            Console.WriteLine("Sr#\tName\t\tCost Index");
            foreach (Vehicle v in VehicleDL.getAllVehicles())
            {
                Console.WriteLine(c + "\t" + v.getName() + "\t\t" + v.getCostIndex());
                c++;
            }
        }

        // view staff
        public static List<Driver> getAllStaff()
        {
            List<Driver> list = new List<Driver>();
            foreach (Person person in PersonDL.getUsersList())
            {
                if (person.getRole().ToLower() == "driver")
                {
                    Driver driver = (Driver)person;
                    list.Add(driver);
                    PersonDL.initiateDriverVehicles(driver, Paths.DriverVehicleDataPath());
                }
            }
            return list;
        }

        // view all orders
        public static void viewAllOrders()
        {
            int c = 1;
            Console.WriteLine("Sr#\tCustomer Name\t\tDriver Name\t\tCity\t\tRating");
            foreach (Order order in OrderDL.getOrders())
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t\t{4}", c, order.GetCustomer().getName(), order.GetDriver().getName(), order.GetCity().getName(), order.getRating());
            }
        }

        // view orders of a specific vehicle
        public static void VehicleOrders()
        {
            Vehicle vehicle = MUser.ValidVehicle(); // taking valid vehicle input from user

            int c = 1;
            Console.WriteLine("Sr#\tCustomer Name\t\tDriver Name\t\tCity\t\tRating");
            foreach (Order order in OrderDL.getOrders())
            {
                if (order.getVehicle().getName() == vehicle.getName())
                {
                    Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t\t{4}", c, order.GetCustomer().getName(), order.GetDriver().getName(), order.GetCity().getName(), order.getRating());
                }
            }
        }

        // view orders of a specific city
        public static void CityOrders()
        {
            City city = MUser.ValidCity(); // taking valid city input from user

            int c = 1;
            Console.WriteLine("Sr#\tCustomer Name\t\tDriver Name\t\tCity\t\tRating");
            foreach (Order order in OrderDL.getOrders())
            {
                if (order.GetCity().getName() == city.getName())
                {
                    Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t\t{4}", c, order.GetCustomer().getName(), order.GetDriver().getName(), order.GetCity().getName(), order.getRating());
                }
            }
        }
    }
}
