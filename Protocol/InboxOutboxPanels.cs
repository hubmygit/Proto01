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
    public partial class InboxOutboxPanels : Form
    {
        public InboxOutboxPanels()
        {
            InitializeComponent();
        }

        private void btnNewFolders_Click(object sender, EventArgs e)
        {
            FoldersInsertForm FoldersInsForm = new FoldersInsertForm();
            FoldersInsForm.ShowDialog();

            if (FoldersInsForm.NewRecord)
            {
                string InsertedFolderName = FoldersInsForm.txtName.Text.Trim();

                cbInFolders.Items.Clear();

                cbInFolders.Items.AddRange(ProtokoloInsertForm.GetObjFolders());

                if (InsertedFolderName.Trim() != "")
                {
                    cbInFolders.SelectedText = InsertedFolderName;
                }
            }
        }
    }
}
