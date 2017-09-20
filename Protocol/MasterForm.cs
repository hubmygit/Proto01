using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocol
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();

            
        }
        
        private void InsertTSMenuItem_Click(object sender, EventArgs e)
        {
            ProtokoloInsertForm frmProtoIns = new ProtokoloInsertForm();
            frmProtoIns.ShowDialog();
        }

        private void UpdateTSMenuItem_Click(object sender, EventArgs e)
        {
            ProtokoloUpdateForm frmProtoUpd = new ProtokoloUpdateForm();
            frmProtoUpd.ShowDialog();
        }

        private void DeleteTSMenuItem_Click(object sender, EventArgs e)
        {
            ProtokoloDeleteForm frmProtoDel = new ProtokoloDeleteForm();
            frmProtoDel.ShowDialog();
        }

        private void InsertToolStripBtn_Click(object sender, EventArgs e)
        {
            ProtokoloInsertForm frmProtoIns = new ProtokoloInsertForm();
            frmProtoIns.ShowDialog();

            if (frmProtoIns.successfulInsertion && frmProtoIns.chbSendMail.Checked)
            {
                //Show Contacts...
                outlookForms oF = new outlookForms();
                oF.showContacts();

                if (oF.RecipientsList.Count > 0)
                {
                    //attachments as parameter........ToDo........filepath as string[] or List<string>
                    //foreach (ListViewItem lvi in frmProtoIns.lvAttFiles.Items)
                    //{
                    //    //string attFileName = lvi.SubItems[1].Text;
                    //}
                    

                    //Show Mail... 
                    oF.ShowMail("Get 'Subject' from Form.Controls", "Get 'Body' from Form.Controls");

                    //Save Mail... ToDo: once complete and test ShowMail, uncomment Save Mail
                    //oF.SaveMail("Get 'Subject' from Form.Controls", "Get 'Body' from Form.Controls");
                }
            }
            else if (frmProtoIns.chbSendMail.Checked)
            {
                MessageBox.Show("Λόγω σφάλματος κατά την καταχώρηση, δεν θα αποσταλεί το e-mail!");
            }

        }

        private void UpdateToolStripBtn_Click(object sender, EventArgs e)
        {
            ProtokoloUpdateForm frmProtoUpd = new ProtokoloUpdateForm();
            frmProtoUpd.ShowDialog();
        }

        private void DeleteToolStripBtn_Click(object sender, EventArgs e)
        {
            ProtokoloDeleteForm frmProtoDel = new ProtokoloDeleteForm();
            frmProtoDel.ShowDialog();
        }
    }
}
