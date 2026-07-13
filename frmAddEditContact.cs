using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactConsoleApp_PresentationLayer
{
    public partial class frmAddEditContact : Form
    {
      

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {

        }

        public enum enMode { addNew = 0 , Update = 1 };
        private enMode _Mode;

        int _ContactID;
        clsContact _Contact;


        public frmAddEditContact(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;

            if (_ContactID == -1)
                _Mode = enMode.addNew;
            else
                _Mode = enMode.Update;

        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountries.GetAllCountries();

            foreach(DataRow row in dtCountries.Rows)
            {

                cbCountries.Items.Add(row["CountryName"]);


            }




        }

        private void _LoadData()
        {

            _FillCountriesInComboBox();


            cbCountries.SelectedIndex = 0; 

            if(_Mode == enMode.addNew)
            {
                lblMode.Text = "Add New Contact";
                _Contact = new clsContact();
                return;
            }

            _Contact = clsContact.Find(_ContactID);

            if(_Contact == null)
            {
                MessageBox.Show("This Form will be closed because no caontant with this ID");

                this.Close();

            }

            lblMode.Text = "Edit Contact ID = " + _ContactID;
            lblContactID.Text = _ContactID.ToString();

            txtFirstName.Text = _Contact.FirstName;
            txtLastName.Text = _Contact.LastName ;
            txtEmail.Text = _Contact.Email;
            txtPhone.Text = _Contact.Phone;
            txtAddress.Text = _Contact.Address;
            dtDateOfBirth.Text = _Contact.DateOfBirth.ToString();
            if(_Contact.ImagePath != "")
            {
                PictureBox1.Load(_Contact.ImagePath);

            }

            LLremoveImage.Visible = (_Contact.ImagePath != "");


            cbCountries.SelectedIndex = cbCountries.FindString(clsCountries.Find(_Contact.CountryID).CountryName);
            




        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountries.Find((int)cbCountries.SelectedValue).CountryID;

            _Contact.FirstName = txtFirstName.Text;
            _Contact.LastName = txtLastName.Text;
            _Contact.Email = txtEmail.Text;
            _Contact.Phone = txtPhone.Text;
            _Contact.Address = txtPhone.Text;
            _Contact.Phone = txtAddress.Text;
            _Contact.DateOfBirth = dtDateOfBirth.Value;
            _Contact.CountryID = CountryID;

            if(PictureBox1.ImageLocation != null)
            {
                _Contact.ImagePath = PictureBox1.ImageLocation;

            }else
            {
                _Contact.ImagePath = "";
            }


            if(_Contact.Save())
            {
                MessageBox.Show("Data saved Successfully ! ");
            }else
            {
                MessageBox.Show("Error : Data NOT saved Successfully");
            }


            _Mode = enMode.Update;
            lblMode.Text = "Edit Contact = " + _Contact.ID;

            lblContactID.Text = _Contact.ID.ToString();



        }

        struct CountryItem
        {

            public string text;
            public string value; 

            public CountryItem(string text, string value)
            {
                this.text = text;
                this.value = value; 

            }
        
        
        }



    }
}
