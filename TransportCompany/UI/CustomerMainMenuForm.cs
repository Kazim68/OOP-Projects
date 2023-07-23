using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportCompany.BL;
using TransportCompany.DL;

namespace TransportCompany.UI
{
    internal partial class CustomerMainMenuForm : Form
    {
        protected Customer customer;
        protected bool currentRide = false;
        protected bool driverFound = false;
        public CustomerMainMenuForm(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private void CustomerMainMenuForm_Load(object sender, EventArgs e)
        {
            if (customer.initializeCustomer())
            {
                currentRide = true;

                // show current order form
                ShowCurrentRide();

            }
            loadDataInComboBoxes();
        }

        // shows current ride panel
        private void ShowCurrentRide()
        {
            hideAllPanels();

            CurrentRidePnl.Location = CenterPicPnl.Location;
            CurrentRidePnl.Dock = DockStyle.Fill;

            initializeCurrentRideAttributes();

            CancelRideBtn.Visible = false;
            RatingsCmbBox.Visible = false;
            RatingsLbl.Visible = false;
            RideDoneBtn.Visible = false;

            CurrentRidePnl.Visible = true;

            initializeCurrentRidePnl();
        }

        // initialize current order attributes
        private void initializeCurrentRideAttributes()
        {
            RideCustomerNameLbl.Text = "Customer Name: " + customer.getName();
            RideDriverLbl.Text = "Driver Name: " + customer.getCurrentOrder().getDriverName();
            RidePickLbl.Text = "Pick Up: " + customer.getCurrentOrder().getPickUp().getName();
            RideDropLbl.Text = "Drop Off: " + customer.getCurrentOrder().getDropOff().getName();
            RideBillLbl.Text = "Bill: " + customer.getCurrentOrder().getBill().ToString();
        }

        // set current ride panel 
        private void initializeCurrentRidePnl()
        {
            if (customer.getCurrentOrder().GetDriver() == null) // if driver does not exist
            {
                RideMessageLbl.Text = "Searching Driver...";
                
                // show cancel ride option
                driverFound = false;
                CancelRideBtn.Visible = true;
            }
            else // driver exists
            {
                driverFound = true;

                if (DriverLocationDL.getDriverPickUp(customer.getCurrentOrder().GetDriver().getName()) && !DriverLocationDL.getDriverDropOff(customer.getCurrentOrder().GetDriver().getName()))
                {
                    RideMessageLbl.Text = "You are on the way to your Destination!"; // if picked up
                }
                else if (!DriverLocationDL.getDriverPickUp(customer.getCurrentOrder().GetDriver().getName()) && !DriverLocationDL.getDriverDropOff(customer.getCurrentOrder().GetDriver().getName()))
                {
                    RideMessageLbl.Text = "Driver is on the way!"; // if not arrived at pick up yet
                }
                else if (DriverLocationDL.getDriverPickUp(customer.getCurrentOrder().GetDriver().getName()) && DriverLocationDL.getDriverDropOff(customer.getCurrentOrder().GetDriver().getName()))
                {
                    // arrived at destination

                    RideMessageLbl.Text = "You have arrived at your Destination!"; // customer arrived at destination
                    
                    // get ratings on completion of order
                    RatingsLbl.Visible = true;
                    RatingsCmbBox.Visible = true;
                    RideDoneBtn.Visible = true;

                }
            }
        }

        // hide all panels
        private void hideAllPanels()
        {
            BookRidePnl.Visible = false;
            SettingsPnl.Visible = false;
            OrdersHistoryPnl.Visible = false;
            CurrentRidePnl.Visible = false;
        }

        // load data in combo boxes
        private void loadDataInComboBoxes()
        {
            VehicleCmbBox.DataSource = VehicleDL.getVehicleNamesInList();
            PickLocationCmbBox.DataSource = customer.getCity().getLocationNamesInList();
            DropLocationCmbBox.DataSource = customer.getCity().getLocationNamesInList();
        }

        private void CustomerMainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BookRideBtn_Click(object sender, EventArgs e)
        {
            if (!currentRide)
            {
                hideAllPanels();

                BookRidePnl.Location = CenterPicPnl.Location;
                BookRidePnl.Dock = DockStyle.Fill;

                resetBookRidePnl();

                BookRidePnl.Visible = true;
            }
        }


        // reset book ride panel elements
        private void resetBookRidePnl()
        {
            VehicleCmbBox.SelectedItem = null;
            PickLocationCmbBox.SelectedItem = null;
            DropLocationCmbBox.SelectedItem = null;
        }

        private void BookRideEnterBtn_Click(object sender, EventArgs e)
        {
            if (VehicleCmbBox.SelectedItem != null && DropLocationCmbBox.SelectedItem != null && PickLocationCmbBox.SelectedItem != null && DropLocationCmbBox.SelectedItem != PickLocationCmbBox.SelectedItem)
            {
                Order order = OrderUI.takeOrder(customer, VehicleCmbBox.SelectedItem.ToString(), PickLocationCmbBox.SelectedItem.ToString(), DropLocationCmbBox.SelectedItem.ToString());

                // open current order form
                currentRide = true;
                customer.setCurrentOrder(order);
                ShowCurrentRide();
            }
            else
            {
                BookRideInvalidMessageLbl.Visible = true;
            }
        }

        private void OrderHistoryBtn_Click(object sender, EventArgs e)
        {
            if (!currentRide)
            {
                hideAllPanels();

                OrdersHistoryPnl.Location = CenterPicPnl.Location;
                OrdersHistoryPnl.Dock = DockStyle.Fill;

                OrdersDGV.DataSource = OrderDL.getCustomersOrders(customer);

                OrdersHistoryPnl.Visible = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            CurrentCityLbl.Text = "Current City: " + customer.getCity().getName();
        }

        private void CitySettingsBtn_Click(object sender, EventArgs e)
        {
            if (CitySettingsCmbBox.SelectedItem != null)
            {
                customer.setCity(CityDL.getCityFromList(CitySettingsCmbBox.SelectedItem.ToString()));
                SettingsInvalidMessageLbl.Text = "City changed!";
                PersonDL.writeData(Paths.PersonDataPath());
            }
            SettingsInvalidMessageLbl.Visible = true;
        }

        private void PwdSettingsBtn_Click(object sender, EventArgs e)
        {
            if (Input.ValidString(Pwd1TxtBox.Text) && Input.ValidString(Pwd2TxtBox.Text) && Pwd1TxtBox.Text == Pwd2TxtBox.Text)
            {
                customer.setPassword(Pwd1TxtBox.Text);
                SettingsInvalidMessageLbl.Text = "Password changed!";
                PersonDL.writeData(Paths.PersonDataPath());
            }
            else
            {
                SettingsInvalidMessageLbl.Text = "Passwords don't match or they are invalid!";
            }
            SettingsInvalidMessageLbl.Visible = true;
        }

        private void CancelRideBtn_Click(object sender, EventArgs e)
        {
            if (!driverFound)
            {
                OrderUI.cancelOrder(customer.getCurrentOrder());
                RideMessageLbl.Text = "Order Cancelled!";
                currentRide = false;
            }
        }

        private void RideDoneBtn_Click(object sender, EventArgs e)
        {
            if (driverFound && RatingsLbl.Visible && RatingsCmbBox.SelectedItem != null)
            {
                customer.getCurrentOrder().setRating(int.Parse(RatingsCmbBox.SelectedItem.ToString()));
                customer.getCurrentOrder().setStatus(true);
                OrderDL.storeOrder(Paths.OrdersDataPath());
                DriverLocationDL.removeFromList(customer.getCurrentOrder().GetDriver().getName());  // removing ongiong driver location record
                DriverLocationDL.StoreData(Paths.DriverLocationDataPath());

                currentRide = false;
                hideAllPanels();
            }
        }
    }
}
