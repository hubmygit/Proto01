using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Protocol
{
    public partial class ProtokoloInsertForm : Form
    {
        public ProtokoloInsertForm()
        {
            InitializeComponent();

            //cbProtokoloKind.Items.AddRange(new object[] { "", "Εισερχόμενα", "Εξερχόμενα" });

            //Values from database
            cbProtokoloKind.Items.AddRange(GetProtocolKind()); 
        }

        InboxOutboxPanels IOPanelsFrm = new InboxOutboxPanels();
        Panel IOBoxPanel = new Panel();

        private string[] GetProtocolKind()
        {
            List<string> KindOfProtocol = new List<string>();

            SqlConnection sqlConn = new SqlConnection("Persist Security Info=False; User ID=" + DBInfo.username + "; Password=" + DBInfo.password + "; Initial Catalog=" + DBInfo.database + "; Server=" + DBInfo.server);
            string SelectSt = "SELECT Name FROM [GramV3-Dev].[dbo].[Proced] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KindOfProtocol.Add(reader["Name"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            
            return KindOfProtocol.ToArray();
        }

        private void cbProtokoloKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProtokoloKind.Text == "Εισερχόμενα")
            {
                Controls.Remove(IOBoxPanel);
                IOBoxPanel = IOPanelsFrm.panelInbox;
                IOBoxPanel.Location = new Point(12, 110);
                Controls.Add(IOBoxPanel);
                cbProtokoloKind.Enabled = false;
            }
            else if (cbProtokoloKind.Text == "Εξερχόμενα")
            {
                Controls.Remove(IOBoxPanel);
                IOBoxPanel = IOPanelsFrm.panelOutbox;
                IOBoxPanel.Location = new Point(12, 110);
                Controls.Add(IOBoxPanel);
                cbProtokoloKind.Enabled = false;
            }
            else
            {
                Controls.Remove(IOBoxPanel);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //ToDo: 
        }
    }
}
