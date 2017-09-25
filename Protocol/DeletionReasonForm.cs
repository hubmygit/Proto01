using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Protocol
{
    public partial class DeletionReasonForm : Form
    {
        public DeletionReasonForm()
        {
            InitializeComponent();
        }

        public bool Successful = false;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDelReason.Text.Trim().Length <= 2) //2 chars minimum
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε την Αιτιολογία Διαγραφής Πρωτοκόλλου!");
            }
            else
            {
                Successful = true;
                Close();
            }
        }
    }
}
