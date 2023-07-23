using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportCompany.BL;
using TransportCompany.DL;
using TransportCompany.UI;

namespace TransportCompany.UI
{
    internal partial class DriverMainMenuForm : Form
    {
        protected Driver driver;
        protected bool currentRide = false;
        protected Order order = null;
        public DriverMainMenuForm(Driver driver)
        {
            InitializeComponent();
            this.driver = driver;
        }

        //hide all panels
        private void hideAllPanels()
        {
            OrdersHistoryPnl.Visible = false;
            SettingsPnl.Visible = false;
            SummaryPnl.Visible = false;
            RideRequestPnl.Visible = false;
            CurrentOrderPnl.Visible = false;
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DriverMainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void DriverMainMenuForm_Load(object sender, EventArgs e)
        {
            if (driver.initializeDriver())
            {
                currentRide = true;

                // show current order form
                showCurrentRidePnl();

            }
        }

        private void OrderHistoryBtn_Click(object sender, EventArgs e)
        {
            if (!currentRide)
            {
                hideAllPanels();

                OrdersHistoryPnl.Location = CenterPicPnl.Location;
                OrdersHistoryPnl.Dock = DockStyle.Fill;

                OrdersDGV.DataSource = OrderDL.getDriverOrders(driver);

                OrdersHistoryPnl.Visible = true;
            }
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            if (!currentRide)
            {
                hideAllPanels();

                SettingsPnl.Location = CenterPicPnl.Location;
                SettingsPnl.Dock = DockStyle.Fill;

                CitySettingsCmbBox.DataSource = CityDL.getCitiesNamesInListForm();

                resetSettingsPnl();

                SettingsPnl.Visible = true;
            }
        }

        private void resetSettingsPnl()
        {
            CitySettingsCmbBox.SelectedItem = null;
            Pwd1TxtBox.Text = "";
            Pwd2TxtBox.Text = "";
            SettingsInvalidMessageLbl.Visible = false;
            SettingsInvalidMessageLbl.Text = "Choose Option!";
            CurrentCityLbl.Text = "Current City: " + driver.getCity().getName();
        }

        private void CitySettingsBtn_Click(object sender, EventArgs e)
        {
            if (CitySettingsCmbBox.SelectedItem != null)
            {
                driver.setCity(CityDL.getCityFromList(CitySettingsCmbBox.SelectedItem.ToString()));
                SettingsInvalidMessageLbl.Text = "City changed!";
                PersonDL.writeData(Paths.PersonDataPath());
            }
            SettingsInvalidMessageLbl.Visible = true;
        }

        private void PwdSettingsBtn_Click(object sender, EventArgs e)
        {
            if (Input.ValidString(Pwd1TxtBox.Text) && Input.ValidString(Pwd2TxtBox.Text) && Pwd1TxtBox.Text == Pwd2TxtBox.Text)
            {
                driver.setPassword(Pwd1TxtBox.Text);
                SettingsInvalidMessageLbl.Text = "Password changed!";
                PersonDL.writeData(Paths.PersonDataPath());
            }
            else
            {
                SettingsInvalidMessageLbl.Text = "Passwords don't match or they are invalid!";
            }
            SettingsInvalidMessageLbl.Visible = true;
        }

        private void SummaryBtn_Click(object sender, EventArgs e)
        {
            if (!currentRide)
            {
                hideAllPanels();

                SummaryPnl.Location = CenterPicPnl.Location;
                SummaryPnl.Dock = DockStyle.Fill;

                SummaryCityLbl.Text = "City Name: " + driver.getCity().getName();
                SummaryNameLbl.Text = "Driver Name: " + driver.getName();
                SummaryVehicleLbl.Text = "Vehicle: " + driver.GetVehicle().getName();
                SummaryIncomeLbl.Text = "Income: " + OrderDL.getIncome(driver);
                SummaryRatingsLbl.Text = "Ratings:" + driver.getRating();

                SummaryPnl.Visible = true;
            }
        }

        private void RideRequestBtn_Click(object sender, EventArgs e)
        {
            if (!currentRide)
            {
                hideAllPanels();

                RideRequestPnl.Location = CenterPicPnl.Location;
                RideRequestPnl.Dock = DockStyle.Fill;

                resetRideRequestAtributes();

                RideRequestPnl.Visible = true;

                // get ride
                order = OrderDL.findOrder(driver);

                if (order != null)
                {
                    // display order
                    showRideRequest();
                }
                else
                {
                    // say that no orders
                    NoOrderLbl.Visible = true;
                }
            }
        }

        // reset ride request attributes
        private void resetRideRequestAtributes()
        {
            RideCityLbl.Visible = false;
            RideCustomerNameLbl.Visible = false;
            RideBillLbl.Visible = false;
            RideDropLbl.Visible = false;
            RidePickLbl.Visible = false;
            PickRideBtn.Visible = false;
            NoOrderLbl.Visible = false;
        }

        // shows ride got from ride request
        private void showRideRequest()
        {
            RideCityLbl.Text = "City: " + order.GetCity().getName();
            RideCustomerNameLbl.Text = "Customer Name: " + order.GetCustomer().getName();   
            RideBillLbl.Text = "Bill: " + order.getBill();
            RideDropLbl.Text = "Drop: " + order.getDropOff().getName();
            RidePickLbl.Text = "Pick: " + order.getPickUp().getName();

            RideCityLbl.Visible = true;
            RideCustomerNameLbl.Visible = true;
            RideBillLbl.Visible = true;
            RideDropLbl.Visible = true;
            RidePickLbl.Visible = true;
            PickRideBtn.Visible = true;
        }

        private void PickRideBtn_Click(object sender, EventArgs e)
        {
            order.setDriver(driver);
            driver.setCurrentOrder(order); // setters and storing in file
            OrderDL.storeOrder(Paths.OrdersDataPath());
            DriverLocationDL.addInList(driver.getName(), null, false, false);
            DriverLocationDL.StoreData(Paths.DriverLocationDataPath()); // added in list and stored in file

            // open current order panel
            currentRide = true;
            showCurrentRidePnl();
        }

        // current ride pnl working
        private void showCurrentRidePnl()
        {
            hideAllPanels();

            CurrentOrderPnl.Location = CenterPicPnl.Location;
            CurrentOrderPnl.Dock = DockStyle.Fill;

            CRCityLocationsCmbBox.DataSource = driver.getCity().getLocationNamesInList();

            CRCancelRideBtn.Visible = false;
            CRDoneBtn.Visible = false;
            initiateCurrentRideAttributes();
            Journey();

            CurrentOrderPnl.Visible = true;
        }

        // initiate current ride panel attributes
        private void initiateCurrentRideAttributes()
        {
            CRDriverNameLbl.Text = "Driver: " + driver.getName();
            CRCustomerNameLbl.Text = "Customer Name: " + driver.getCurrentOrder().GetCustomer().getName();
            CRBillLbl.Text = "Bill: " + driver.getCurrentOrder().getBill();
            CRVehicleLBL.Text = "Vehicle: " + driver.GetVehicle().getName();
            CRDropLbl.Text = "Drop: " + driver.getCurrentOrder().getDropOff().getName();
            CRPickLbl.Text = "Pick: " + driver.getCurrentOrder().getPickUp().getName();
            CRMessageLbl.Text = "In Journey";

            // get current location
            driver.setLocation(DriverLocationDL.getDriverCurrentLocation(driver.getName()));
            if (driver.getLocation() == null) // if starting journey -> haven't started yet
            {
                CRCurrentLocationLbl.Text = "No Location";
            }
            else        // in journey
            {
                CRCurrentLocationLbl.Text = "Current Location: " + driver.getLocation();
            }

            if (!DriverLocationDL.getDriverPickUp(driver.getName()))
            {
                // haven't picked up yet 
                // so ride can still be cancelled
                CRCancelRideBtn.Visible = true;
                CRMessageLbl.Text = "In Journey.";
            }
        }

        // check status of driver journey
        private void Journey()
        {
            // if arrived at pick up location
            if (driver.pickedUp() && !DriverLocationDL.getDriverPickUp(driver.getName()))
            {
                DriverLocationDL.removeFromList(driver.getName()); // removing from list
                DriverLocationDL.addInList(driver.getName(), driver.getLocation(), true, false); // adding in list
                DriverLocationDL.StoreData(Paths.DriverLocationDataPath()); // updating file
                CRMessageLbl.Text = "In Journey after Pick up location!";
            }

            // if picked up and in journey
            if (DriverLocationDL.getDriverPickUp(driver.getName()) && !DriverLocationDL.getDriverDropOff(driver.getName()))
            {

                // check if this is drop off location
                if (driver.droppedOff())
                {
                    DriverLocationDL.removeFromList(driver.getName()); // removing from list
                    DriverLocationDL.addInList(driver.getName(), driver.getLocation(), true, true); // adding in list
                    DriverLocationDL.StoreData(Paths.DriverLocationDataPath()); // updating file
                    CRMessageLbl.Text = "You have arrived at your destination!";
                    CRDoneBtn.Visible = true;
                }
            }

            // dropped off
            if (DriverLocationDL.getDriverDropOff(driver.getName())) 
            {
                CRMessageLbl.Text = "You have reached your destination!";
                CRDoneBtn.Visible = true;
            }
        }
        private void CRUpdateLocationBtn_Click(object sender, EventArgs e)
        {
            if (CRCityLocationsCmbBox.SelectedItem != null)
            {
                CRCancelRideBtn.Visible = false;

                // change current location
                driver.setLocation(CRCityLocationsCmbBox.SelectedItem.ToString());

                Journey();

            }
        }

        private void CRCancelRideBtn_Click(object sender, EventArgs e)
        {
            if (CRCancelRideBtn.Visible)
            {
                OrderUI.cancelRide(driver);
                currentRide = false;
                hideAllPanels();
            }
        }

        private void CRDoneBtn_Click(object sender, EventArgs e)
        {
            currentRide = false;
            order = null;
            hideAllPanels();
        }
    }
}
