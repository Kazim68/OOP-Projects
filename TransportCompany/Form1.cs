using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TransportCompany.BL;
using TransportCompany.DL;
using TransportCompany.UI;

namespace TransportCompany
{
    public partial class LoginMenuForm : Form
    {
        protected Admin admin;
        public LoginMenuForm(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void LoginMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void hideAllPanels()
        {
            SignInPnl.Visible = false;
            SignUpPnl.Visible = false;  
            GoAdminPnl.Visible = false;
        }

        private void resetTxtBox(TextBox txt)
        {
            txt.Text = "";
        }

        // reset sign in panel elements
        private void resetSignInPanelElements()
        {
            SignInPnlInvalidMessageLbl.Visible = false;
            resetTxtBox(SignInNameTxtBox);
            resetTxtBox(SignInPwdTxtBox);
        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();

            SignInPnl.Location = CenterPicPnl.Location;
            SignInPnl.Dock = DockStyle.Fill;

            resetSignInPanelElements();

            SignInPnl.Visible = true;
        }

        private void SignInPnlBtn_Click(object sender, EventArgs e)
        {
            if (ValidString(SignInNameTxtBox.Text) && ValidString(SignInPwdTxtBox.Text))
            {
                Person User = PersonDL.checkSignIn(SignInNameTxtBox.Text, SignInPwdTxtBox.Text);
                // check if user is valid
                if (User != null)
                {
                    this.Visible = false; // hide this form  -> use visible, hide won't reopen

                    // then hide this form and open user form
                    if (User is Customer)
                    {
                        Customer customer = (Customer)User;

                        // present customer main menu
                        CustomerMainMenuForm form = new CustomerMainMenuForm(customer);
                        form.ShowDialog();
                    }
                    else if (User is Driver)
                    {
                        Driver driver = (Driver)User;
                        PersonDL.initiateDriverVehicles(driver, Paths.DriverVehicleDataPath());

                        // present driver main menu
                        DriverMainMenuForm form = new DriverMainMenuForm(driver);
                        form.ShowDialog();
                    }

                    this.Visible = true;        // show back this form when form closed
                    resetSignInPanelElements();
                    hideAllPanels() ;
                }
            }
            else
            {
                // if user is invalid or invalid input
                SignInPnlInvalidMessageLbl.Visible = true;
            }
        }

        // check for any invalid inputs
        private bool ValidString(string text)
        {
            if (text.Trim() == string.Empty || text.Contains(","))
            {
                return false;
            }
            return true;
        }

        // reset elements of sign up panel
        private void resetSignUpPanelElements()
        {
            resetTxtBox(SignUpNameTxtBox);
            resetTxtBox(SignUpPwdTxtBox);
            resetTxtBox(SignUpAddressTxtBox);

            SignUpCityCmbBox.Text = "Choose City";
            SignUpCityCmbBox.SelectedItem = null;

            SignUpRoleCmbBox.Text = "Choose Role";
            SignUpRoleCmbBox.SelectedItem = null;
        }

        // for going to sign up menu
        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();

            SignUpPnl.Location = CenterPicPnl.Location;
            SignUpPnl.Dock = DockStyle.Fill;

            SignUpCityCmbBox.DataSource = CityDL.getCitiesNamesInListForm();

            resetSignUpPanelElements();

            SignUpPnl.Visible = true;

        }

        // for completing sign up
        private void SignUpPnlBtn_Click(object sender, EventArgs e)
        {
            if (ValidString(SignUpNameTxtBox.Text) && ValidString(SignUpPwdTxtBox.Text) && ValidString(SignUpAddressTxtBox.Text) && SignUpCityCmbBox.SelectedItem != null && SignUpRoleCmbBox.SelectedItem != null)
            {
                if (!PersonDL.duplicateName(SignUpNameTxtBox.Text) && !SignUpDL.duplicateName(SignUpNameTxtBox.Text))
                {

                    MUser.SignUp(SignUpNameTxtBox.Text, SignUpPwdTxtBox.Text, SignUpRoleCmbBox.SelectedItem.ToString(), SignUpCityCmbBox.SelectedItem.ToString(), SignUpAddressTxtBox.Text);

                    // write in file
                    PersonDL.writeData(Paths.PersonDataPath());
                    SignUpDL.writeData(Paths.SignUpPath());

                    resetSignUpPanelElements();
                }
            }
            else
            {
                SignUpPnlInvalidMessageLbl.Visible = true;
            }
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            hideAllPanels();

            GoAdminPnl.Location = CenterPicPnl.Location;
            GoAdminPnl.Dock = DockStyle.Fill;

            GoAdminIncorrectMessageLbl.Visible = false;
            resetTxtBox(GoAdminNameTxtBox);
            resetTxtBox(GoAdminPwdTxtBox);

            GoAdminPnl.Visible = true;
        }

        private void GoAdminEnterBtn_Click(object sender, EventArgs e)
        {
            if (ValidString(GoAdminNameTxtBox.Text) && ValidString(GoAdminPwdTxtBox.Text))
            {
                // check if user is valid
                if (MUser.AdminSignIn(admin, GoAdminNameTxtBox.Text, GoAdminPwdTxtBox.Text))
                {
                    // then hide this form and open user form
                    AdminMainMenuForm form = new AdminMainMenuForm();
                    form.ShowDialog();

                    this.Visible = true;        // show back this form when form closed
                    resetSignInPanelElements();
                    hideAllPanels();
                }
            }
            else
            {
                // if user is invalid or invalid input
                GoAdminIncorrectMessageLbl.Visible = true;
            }
        }

        private void LoginMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
