using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportCompany.DL;
using TransportCompany.BL;
using System.Runtime.ExceptionServices;

namespace TransportCompany.UI
{
    public partial class AdminMainMenuForm : Form
    {
        Driver driver = null;
        City city = null;
        Vehicle vehicle = null;
        public AdminMainMenuForm()
        {
            InitializeComponent();
        }

        // hide all panels
        private void hideAllPanels()
        {
            ApproveDriverPnl.Visible = false;
            StaffPnl.Visible = false;
            OrdersPnl.Visible = false;
            CitiesPnl.Visible = false;
            VehiclePnl.Visible = false;
        }

        private void AdminMainMenuForm_Load(object sender, EventArgs e)
        {
            driver = null;
            city = null;
            vehicle = null;
        }

        private void AdminMainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ApproveDriverBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();

            ApproveDriverPnl.Location = CenterPicPnl.Location;
            ApproveDriverPnl.Dock = DockStyle.Fill;

            resetApproveDriversGrid();
            ADVehicleCmbBox.DataSource = VehicleDL.getVehicleNamesInList();
            setADElements(false);

            ApproveDriverPnl.Visible = true;
        }

        // reset approve drivers panel elements
        private void setADElements(bool value)
        {
            ADDoneBtn.Visible = value;
            ADVehicleCmbBox.Visible = value;
            ADVehicleLbl.Visible = value;
        }

        // reset approve drivers grid
        private void resetApproveDriversGrid()
        {
            ApproveDriversDGV.DataSource = null;
            ApproveDriversDGV.DataSource = SignUpDL.getSignUpList();
            ApproveDriversDGV.Columns["Password"].Visible = false;
            ApproveDriversDGV.Columns["Role"].Visible = false;
            ApproveDriversDGV.Columns["Address"].Visible = false;
            ApproveDriversDGV.Refresh();
        }

        private void ApproveDriversDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            driver = null;

            // get user from row click
            Person person = (Person)ApproveDriversDGV.CurrentRow.DataBoundItem;
            
            if (ApproveDriversDGV.Columns["RejectBtn"].Index == e.ColumnIndex)
            {
                SignUpDL.RemoveUser(person); // deleting from list

                SignUpDL.writeData(Paths.SignUpPath());
                resetApproveDriversGrid();

            }
            else if (ApproveDriversDGV.Columns["ApproveBtn"].Index == e.ColumnIndex)
            {
                // approve driver;
                driver = new Driver(person.getName(), person.getPassword(), person.getRole(), person.getCity(), person.getAddress());
                setADElements(true);

            }

        }

        private void ADDoneBtn_Click(object sender, EventArgs e)
        {
            if (ADVehicleCmbBox.SelectedItem != null)
            {
                driver.setVehicle(VehicleDL.getVehicleFromList(ADVehicleCmbBox.SelectedItem.ToString()));
                driver.saveInFile(Paths.DriverVehicleDataPath());
                SignUpDL.RemoveUser(driver.Name);
                SignUpDL.writeData(Paths.SignUpPath());
                PersonDL.addUserInList(driver);
                PersonDL.writeData(Paths.PersonDataPath());

                driver = null;
                resetApproveDriversGrid();
                setADElements(false);
            }
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void StaffBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();

            StaffPnl.Location = CenterPicPnl.Location;
            StaffPnl.Dock = DockStyle.Fill;

            StaffDGV.DataSource = AdminUI.getAllStaff();
            StaffDGV.Columns["Location"].Visible = false;
            StaffDGV.Columns["Role"].Visible = false;
            StaffDGV.Columns["Address"].Visible = false;
            StaffDGV.Columns["Password"].Visible = false;
            StaffDGV.Columns["CurrentOrder"].Visible = false;

            StaffPnl.Visible = true;
        }

        private void OrdersBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();

            OrdersPnl.Location = CenterPicPnl.Location;
            OrdersPnl.Dock= DockStyle.Fill;

            OrdersGDV.DataSource = OrderDL.getOrders();
            CityCmbBox.DataSource = CityDL.getCitiesNamesInListForm();
            VehicleCmbBox.DataSource = VehicleDL.getVehicleNamesInList();

            OrdersPnl.Visible = true;
        }

        private void AllOrdersBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void setOrderDGV(List<Order> orders)
        {
            OrdersGDV.DataSource = null;
            OrdersGDV.DataSource = orders;
            OrdersGDV.Refresh();
        }

        private void CityBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void VehicleBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void CityBtn_Click_1(object sender, EventArgs e)
        {
            if (CityCmbBox.SelectedItem != null)
            {
                setOrderDGV(OrderDL.getOrder(CityCmbBox.SelectedItem.ToString()));
            }
        }

        private void VehicleBtn_Click_1(object sender, EventArgs e)
        {
            if (VehicleCmbBox.SelectedItem != null)
            {
                setOrderDGV(OrderDL.getOrder(VehicleCmbBox.SelectedItem.ToString(), true));
            }
        }

        private void AllOrdersBtn_Click_1(object sender, EventArgs e)
        {
            setOrderDGV(OrderDL.getOrders());
        }

        private void CitiesBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();

            CitiesPnl.Location = CenterPicPnl.Location;
            CitiesPnl.Dock = DockStyle.Fill;

            city = null;
            CitiesDGV.DataSource = CityDL.getCities();
            LocationsVisibility(false);

            CitiesPnl.Visible = true;

        }

        // set locaions visibility true or false
        private void LocationsVisibility(bool visibility)
        {
            LocationsDGV.Visible = visibility;
            AddLocationBtn.Visible = visibility;
            LocationNameTxt.Text = "";
        }

        // set locations dgv 
        private void setLocationsDGV(List<Location> locations)
        {
            LocationsDGV.DataSource = null;
            LocationsDGV.DataSource = locations;
            LocationsDGV.Refresh();
            LocationsVisibility(true);
        }

        private void CitiesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            city = (City)CitiesDGV.CurrentRow.DataBoundItem;

            if (CitiesDGV.Columns["ModifyBtn"].Index == e.ColumnIndex)
            {
                setLocationsDGV(city.getAreas());
            }
        }

        private void AddLocationBtn_Click(object sender, EventArgs e)
        {
            if (AddLocationBtn.Visible && LocationNameTxt.Text != null && DistanceCmbBox.SelectedItem != null && city != null && Input.ValidString(LocationNameTxt.Text))
            {
                city.addLocation(new BL.Location(LocationNameTxt.Text, int.Parse(DistanceCmbBox.SelectedItem.ToString())));
                setLocationsDGV(city.getAreas());
            }
        }

        private void AddCityBtn_Click(object sender, EventArgs e)
        {
            // checking for valid time of click
            if (AddCityTxtBox.Text != null && LocationNameTxt.Text != null && DistanceCmbBox.SelectedItem != null && Input.ValidString(AddCityTxtBox.Text) && Input.ValidString(LocationNameTxt.Text) && !CityDL.isCityInList(AddCityTxtBox.Text))
            {
                // making a list of locations so that city has atleast one location
                List<BL.Location> locations = new List<BL.Location>();
                locations.Add(new BL.Location(LocationNameTxt.Text, int.Parse(DistanceCmbBox.SelectedItem.ToString())));
                
                // making new city object and adding in list and storing in file
                city = new City(AddCityTxtBox.Text, locations);
                CityDL.addCityInList(city);
                CityDL.writeData(Paths.CityPath());

                // update data grid view for this new city -> this city is selected
                setLocationsDGV(city.getAreas());
            }
        }

        // set visibility of vehicle elements
        private void setModifyVehicleVisibility(bool visibility)
        {
            ChangeCostDistanceLbl.Visible = visibility;
            ChangeCostTxtBox.Visible = visibility;
            ChangeCostBtn.Visible = visibility;
            CurrentVehicleNameLbl.Visible = visibility;
            ChangeCostTxtBox.Text = "";
            AddVehicleNameTxtBox.Text = "";
            AddVehicleCostTxtBox.Text = ""; 
        }

        private void VehiclesBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();

            VehiclePnl.Location = CenterPicPnl.Location;
            VehiclePnl.Dock = DockStyle.Fill;

            vehicle = null;
            InvalidLbl.Visible = false;
            VehicleDGV.DataSource = VehicleDL.getAllVehicles();
            setModifyVehicleVisibility(false);

            VehiclePnl.Visible = true;
        }

        // update vehicle dgv
        private void updateVehicleDGV()
        {
            VehicleDGV.DataSource = null;
            VehicleDGV.DataSource = VehicleDL.getAllVehicles();
            VehicleDGV.Refresh();
        }

        private void VehicleDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vehicle = (Vehicle)VehicleDGV.CurrentRow.DataBoundItem;
            InvalidLbl.Visible = false;

            if (VehicleDGV.Columns["Modify"].Index == e.ColumnIndex)
            {
                // show modify vehicle elements
                CurrentVehicleNameLbl.Text = vehicle.Name;
                setModifyVehicleVisibility(true);
            }
        }

        private void ChangeCostBtn_Click(object sender, EventArgs e)
        {
            if (ChangeCostBtn.Visible && ChangeCostTxtBox.Text != null && Input.validInt(ChangeCostTxtBox.Text, 500) && vehicle != null)
            {
                // updating the value and writing in file
                vehicle.setCostIndex(int.Parse(ChangeCostTxtBox.Text));
                updateVehicleDGV();
                VehicleDL.WriteData(Paths.VehiclePath());
                InvalidLbl.Visible = false;
                ChangeCostTxtBox.Text = "";
                vehicle = null;
            }
            else            // invalid message display
            {
                InvalidLbl.Visible = true;
            }
        }

        private void AddVehicleBtn_Click(object sender, EventArgs e)
        {
            if (AddVehicleCostTxtBox.Text != null && AddVehicleNameTxtBox.Text != null && Input.validInt(AddVehicleCostTxtBox.Text, 500) && Input.ValidString(AddVehicleNameTxtBox.Text) && !VehicleDL.isVehicleInList(AddVehicleNameTxtBox.Text))
            {
                InvalidLbl.Visible=false;
                VehicleDL.addIntoList(new Vehicle(AddVehicleNameTxtBox.Text, int.Parse(AddVehicleCostTxtBox.Text)));
                VehicleDL.WriteData(Paths.VehiclePath());
                ChangeCostTxtBox.Text = "";
                AddVehicleNameTxtBox.Text = "";
                AddVehicleCostTxtBox.Text = "";
                vehicle = null;
                updateVehicleDGV();
            }
            else
            {
                InvalidLbl.Visible = true;
            }
        }
    }
}
