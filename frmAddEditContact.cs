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



        }








    }
}
