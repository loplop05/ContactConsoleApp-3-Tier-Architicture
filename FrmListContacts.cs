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
    public partial class FrmListContacts : Form
    {
        public FrmListContacts()
        {
            InitializeComponent();
        }

        private void _RefreshContactsList()
        {
            dgvAllContacts.DataSource = clsContact.GetAllContacts();
        }

        private void dgvAllContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void FrmListContacts_Load(object sender, EventArgs e)
        {
            _RefreshContactsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact((int)dgvAllContacts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshContactsList();
        }
    }
}
