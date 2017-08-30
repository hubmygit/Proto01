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
    public partial class ProtokoloInsertForm : Form
    {
        public ProtokoloInsertForm()
        {
            InitializeComponent();

            //ToDo: From get values from database
            cbProtokoloKind.Items.AddRange(new object[] {
            "",
            "Εισερχόμενα",
            "Εξερχόμενα"});
        }

        private void cbProtokoloKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProtokoloKind.Text == "Εισερχόμενα")
            {
                panelInbox.Visible = true;
                panelInbox.Location = new Point(12, 110);
                panelOutbox.Visible = false;
            }
            else if (cbProtokoloKind.Text == "Εξερχόμενα")
            {
                panelInbox.Visible = false;
                panelOutbox.Visible = true;
                panelOutbox.Location = new Point(12, 110);
            }
            else
            {
                panelInbox.Visible = false;
                panelOutbox.Visible = false;
            }
        }

        private void panelInbox_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
