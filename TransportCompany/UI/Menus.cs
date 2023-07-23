using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.BL;

namespace TransportCompany.UI
{
    internal class Menus
    {
        // login screen menu
        public static void LoginMenu()
        {
            Console.WriteLine("1. Sign in");
            Console.WriteLine("2. Sign up");
            Console.WriteLine("3. Admin");
            Console.WriteLine("0. Exit");
        }

        // driver hiring menu
        public static void DriverApproveMenu()
        {
            Console.WriteLine("1. Approve Driver");
            Console.WriteLine("2. Reject Driver");
        }

        // admin menu
        public static void AdminMenu()
        {
            Console.WriteLine("1. Approve Driver");
            Console.WriteLine("2. Add City");
            Console.WriteLine("3. Modify City");
            Console.WriteLine("4. Add Vehicle");
            Console.WriteLine("5. Modify Vehicle");
            Console.WriteLine("6. View Staff");
            Console.WriteLine("7. View All Orders");
            Console.WriteLine("8. View Ordes of a specific Vehicle");
            Console.WriteLine("9. View Orders of a specific City");
            Console.WriteLine("0. Exit");
        }

        // customer menu
        public static void CustomerMenu()
        {
            Console.WriteLine("1. Book a ride!");
            Console.WriteLine("2. View ride history");
            Console.WriteLine("3. Settings");
            Console.WriteLine("0. Exit");
        }

        // driver menu
        public static void DriverMenu()
        {
            Console.WriteLine("1. Ride Requests");
            Console.WriteLine("2. My Income");
            Console.WriteLine("3. Ratings");
            Console.WriteLine("4. History");
            Console.WriteLine("5. Settings");
            Console.WriteLine("0. Exit");
        }

        // driver current order menu
        public static void driverPickUpMenu()
        {
            Console.WriteLine("1. Update Current Location");
            Console.WriteLine("2. Cancel Ride");
            Console.WriteLine("0. Exit");
        }

        // settings menu
        public static void settingsMenu()
        {
            Console.WriteLine("1. Change Password");
            Console.WriteLine("2. Change City");
            Console.WriteLine("3. Terms and Conditions");
            Console.WriteLine("0. Exit");
        }

        // terms and conditions for customer
        public static void TermAndConditions(Customer customer)
        {
            Console.WriteLine("1. Respect your driver.");
            Console.WriteLine("2. Your privacy is our priority.");
            Console.WriteLine("3. Payment is done on the spot to the driver.");
            Console.WriteLine("4. Keep the Vehicle clean.");
            Console.WriteLine("5. Travel Safe & Sound.");
        }

        // terms and conditions for customer
        public static void TermAndConditions(Driver driver)
        {
            Console.WriteLine("1. Respect your Rider.");
            Console.WriteLine("2. Your privacy is our priority.");
            Console.WriteLine("3. Recieve Payment on the spot at drop off.");
            Console.WriteLine("4. Keep your Vehicle maintained.");
            Console.WriteLine("5. Travel Safe & Sound.");
        }

        // transition screen
        public static void Transition()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            clearScreen();
        }

        // invalid option selection 
        public static void incorrectOption()
        {
            Console.WriteLine("Invalid option!");
        }

        // clear screen
        public static void clearScreen()
        {
            Console.Clear();
        }
    }
}
