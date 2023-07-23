using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportCompany.BL;
using TransportCompany.DL;

namespace TransportCompany
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // loading data into lists from files
            CityDL.loadCities(Paths.CityPath());
            SignUpDL.loadData(Paths.SignUpPath());
            VehicleDL.loadVehicleData(Paths.VehiclePath());
            PersonDL.loadData(Paths.PersonDataPath());
            OrderDL.loadOrders(Paths.OrdersDataPath());
            DriverLocationDL.LoadDataFromFile(Paths.DriverLocationDataPath());

            // making admin
            Admin admin = new Admin("Kazim", "123", "Admin", CityDL.getCityFromList("Lahore"), "UET");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginMenuForm(admin));
        }

        
    }
}
