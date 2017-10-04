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
    public partial class ContactsToEmail : Form
    {
        public ContactsToEmail()
        {
            InitializeComponent();
        }

        public bool frmSaved = false;

        private void btnRecipientsTo_Click(object sender, EventArgs e)
        {
            GetRecipients(txtRecipientsTo);
        }

        private void btnRecipientsCc_Click(object sender, EventArgs e)
        {
            GetRecipients(txtRecipientsCc);
        }

        private void btnRecipientsBcc_Click(object sender, EventArgs e)
        {
            GetRecipients(txtRecipientsBcc);
        }

        private void GetRecipients(TextBox txtRecipients)
        {
            //show contacts form
            Contacts contactsFrm = new Contacts("GoToSelected!");
            contactsFrm.ShowDialog();

            //get Contacts
            //txtRecipientsTo.Text = "";
            foreach (string thisContact in contactsFrm.ReturnEmailList)
            {
                txtRecipients.Text += thisContact + "; ";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtRecipientsTo.Text.Trim().Length + txtRecipientsCc.Text.Trim().Length + txtRecipientsBcc.Text.Trim().Length) > 5) //x@x.x : >= 5 chars
            {
                frmSaved = true;
                Close();
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε πρώτα παραλήπτες!");
            }

            
        }
    }
}
