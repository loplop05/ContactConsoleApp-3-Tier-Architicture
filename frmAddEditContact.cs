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
using System.IO;
namespace ContactConsoleApp_PresentationLayer
{
    public partial class frmAddEditContact : Form
    {
      

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        public enum enMode { addNew = 0 , Update = 1 };
        private enMode _Mode;

        int _ContactID;
        clsContact _Contact;



        public frmAddEditContact()
        {
            InitializeComponent();

            _Mode = enMode.addNew;
        }

        public frmAddEditContact(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;
            _Mode = enMode.Update;
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountries.GetAllCountries();

            cbCountries.DataSource = dtCountries;
            cbCountries.DisplayMember = "CountryName";
            cbCountries.ValueMember = "CountryID";




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
                return;
            }

            lblMode.Text = "Edit Contact ID =   " + _ContactID;
            lblContactID.Text = _ContactID.ToString();

            txtFirstName.Text = _Contact.FirstName;
            txtLastName.Text = _Contact.LastName ;
            txtEmail.Text = _Contact.Email;
            txtPhone.Text = _Contact.Phone;
            txtAddress.Text = _Contact.Address;
            if (_Contact.DateOfBirth >= dtDateOfBirth.MinDate && _Contact.DateOfBirth <= dtDateOfBirth.MaxDate)
            {
                dtDateOfBirth.Value = _Contact.DateOfBirth;
            }
            else
            {
                dtDateOfBirth.Value = DateTime.Now;
            }
            if (!string.IsNullOrEmpty(_Contact.ImagePath))
            {
                if (File.Exists(_Contact.ImagePath))
                {
                    PictureBox1.Load(_Contact.ImagePath);
                }
            }

            LLremoveImage.Visible = (_Contact.ImagePath != "");


            var Country = clsCountries.Find(_Contact.CountryID);

            if (Country != null)
            {
                cbCountries.SelectedIndex = cbCountries.FindString(Country.CountryName);
            }




        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = (int)cbCountries.SelectedValue;
            _Contact.FirstName = txtFirstName.Text;
            _Contact.LastName = txtLastName.Text;
            _Contact.Email = txtEmail.Text;
            _Contact.Phone = txtPhone.Text;
            _Contact.Address = txtAddress.Text;
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
            lblMode.Text = "Edit Contact =   " + _Contact.ID;

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

        private void LLsetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Entered Event");

            OpenFileDialog ofd = new OpenFileDialog();

            MessageBox.Show("Dialog Created");

            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            DialogResult result = ofd.ShowDialog();

            MessageBox.Show("Dialog Closed");

            if (result == DialogResult.OK)
            {
                PictureBox1.ImageLocation = ofd.FileName;
                LLremoveImage.Visible = true;
            }
        }

        private void lblMode_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
