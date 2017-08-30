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

        InboxOutboxPanels IOPanelsFrm = new InboxOutboxPanels();
        Panel IOBoxPanel = new Panel();

        private void cbProtokoloKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProtokoloKind.Text == "Εισερχόμενα")
            {
                Controls.Remove(IOBoxPanel);
                IOBoxPanel = IOPanelsFrm.panelInbox;
                IOBoxPanel.Location = new Point(12, 110);
                Controls.Add(IOBoxPanel);
            }
            else if (cbProtokoloKind.Text == "Εξερχόμενα")
            {
                Controls.Remove(IOBoxPanel);
                IOBoxPanel = IOPanelsFrm.panelOutbox;
                IOBoxPanel.Location = new Point(12, 110);
                Controls.Add(IOBoxPanel);
            }
            else
            {
                Controls.Remove(IOBoxPanel);
            }
        }
    }
}
