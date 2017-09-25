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
                if (frmProtoIns.IOBoxPanel.Name.ToUpper() == "PANELINBOX")
                {
                    //Show Contacts...
                    outlookForms oF = new outlookForms();
                    oF.showContacts();

                    if (oF.RecipientsList.Count > 0)
                    {
                        //Show Mail... 
                        //oF.ShowMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                        //Save Mail... 
                        //oF.SaveMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                        //Send Mail...
                        oF.SendMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                    }
                }
                else if (frmProtoIns.IOBoxPanel.Name.ToUpper() == "PANELOUTBOX")
                {
                    //...
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

        private void FolderInsTSMenuItem_Click(object sender, EventArgs e)
        {
            FoldersInsertForm FoldersInsForm = new FoldersInsertForm();
            FoldersInsForm.ShowDialog();
        }

        private void FolderDelTSMenuItem_Click(object sender, EventArgs e)
        {
            FoldersDeleteForm FoldersDelForm = new FoldersDeleteForm();
            FoldersDelForm.ShowDialog();
        }

        private void FolderUpdTSMenuItem_Click(object sender, EventArgs e)
        {
            FoldersUpdateForm FoldersUpdForm = new FoldersUpdateForm();
            FoldersUpdForm.ShowDialog();
        }

        private void FolderToProtokTSMenuItem_Click(object sender, EventArgs e)
        {
            ProtokPerFolderForm ProtokPerFolderForm = new ProtokPerFolderForm();
            ProtokPerFolderForm.ShowDialog();
        }
    }
}
