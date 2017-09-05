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
            
            //Values from database
            //cbCompany.Items.AddRange(GetCompanies());
            //cbProtokoloKind.Items.AddRange(GetProtocolKind()); 
            cbCompany.Items.AddRange(GetObjCompanies());
            cbProtokoloKind.Items.AddRange(GetObjProtocolKind());


            //test-->
            List<string> fonts = new List<string>();
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font.Name);
            }
            comboBox1.DataSource = fonts;
            //test<--
        }

        InboxOutboxPanels IOPanelsFrm = new InboxOutboxPanels();
        Panel IOBoxPanel = new Panel();
        
        private string[] GetProtocolKind() //obsolete / depraced
        {
            List<string> KindOfProtocol = new List<string>();

            SqlConnection sqlConn = new SqlConnection("Persist Security Info=False; User ID=" + DBInfo.username + "; Password=" + DBInfo.password + "; Initial Catalog=" + DBInfo.database + "; Server=" + DBInfo.server);
            string SelectSt = "SELECT Name FROM [dbo].[Proced] ";
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

        private ComboboxItem[] GetObjProtocolKind()
        {
            List<Proced> Proceds = new List<Proced>();
            List<ComboboxItem> cbProceds = new List<ComboboxItem>();

            SqlConnection sqlConn = new SqlConnection("Persist Security Info=False; User ID=" + DBInfo.username + "; Password=" + DBInfo.password + "; Initial Catalog=" + DBInfo.database + "; Server=" + DBInfo.server);
            string SelectSt = "SELECT Id, Name FROM [dbo].[Proced] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Proceds.Add(new Proced() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });// reader["Name"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            foreach (Proced proced in Proceds)
            {
                cbProceds.Add(new ComboboxItem() { Value = proced, Text = proced.Name });
            }

            return cbProceds.ToArray<ComboboxItem>();
        }

        private string[] GetCompanies() //obsolete / depraced
        {
            List<string> Companies = new List<string>();

            SqlConnection sqlConn = new SqlConnection("Persist Security Info=False; User ID=" + DBInfo.username + "; Password=" + DBInfo.password + "; Initial Catalog=" + DBInfo.database + "; Server=" + DBInfo.server);
            string SelectSt = "SELECT Id, Name FROM [dbo].[Company] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Companies.Add(reader["Name"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return Companies.ToArray();
        }

        private ComboboxItem[] GetObjCompanies()
        {
            List<Company> Companies = new List<Company>();
            List<ComboboxItem> cbCompanies = new List<ComboboxItem>();

            SqlConnection sqlConn = new SqlConnection("Persist Security Info=False; User ID=" + DBInfo.username + "; Password=" + DBInfo.password + "; Initial Catalog=" + DBInfo.database + "; Server=" + DBInfo.server);
            string SelectSt = "SELECT Id, Name FROM [dbo].[Company] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Companies.Add(new Company() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() } );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            foreach(Company com in Companies)
            {
                cbCompanies.Add(new ComboboxItem() { Value = com, Text = com.Name });
            }

            return cbCompanies.ToArray<ComboboxItem>();
        }

        private void cbProtokoloKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProtokoloKind.Text == "Εισερχόμενα")
            {
                Controls.Remove(IOBoxPanel);
                IOBoxPanel = IOPanelsFrm.panelInbox;
                IOBoxPanel.Location = new Point(12, 110);

                IOBoxPanel.Controls["tbInProtokoloNum"].Text = "131";            //ToDo
                IOBoxPanel.Controls["tbInDocNum"].Text = "AA-0000/01";           //to del
                IOBoxPanel.Controls["tbInFolderId"].Text = "101";                //to del
                IOBoxPanel.Controls["tbInProeleusi"].Text = "ABCD";              //to del
                IOBoxPanel.Controls["tbInSummary"].Text = "Δοκιμαστική εγγραφή"; //to del
                IOBoxPanel.Controls["tbInToText"].Text = "Mr Abcd";              //to del

                Controls.Add(IOBoxPanel);
                cbProtokoloKind.Enabled = false;
            }
            else if (cbProtokoloKind.Text == "Εξερχόμενα")
            {
                Controls.Remove(IOBoxPanel);
                IOBoxPanel = IOPanelsFrm.panelOutbox;
                IOBoxPanel.Location = new Point(12, 110);

                IOBoxPanel.Controls["tbOutProtokoloNum"].Text = "131";            //ToDo
                IOBoxPanel.Controls["tbOutDocNum"].Text = "AA-0000/01";           //to del
                IOBoxPanel.Controls["tbOutKateuth"].Text = "ABCD";                //to del
                IOBoxPanel.Controls["tbOutSummary"].Text = "Δοκιμαστική εγγραφή"; //to del

                Controls.Add(IOBoxPanel);
                cbProtokoloKind.Enabled = false;
            }
            else
            {
                Controls.Remove(IOBoxPanel);
            }
        }

        string DatetimePickerToSQLDate(Control DatetimePicker)
        {
            return ((DateTimePicker)DatetimePicker).Value.ToString("yyyy-MM-dd");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {            
            if (cbCompany.Text.Trim() == "")
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Εταιρία'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbProtokoloKind.Text.Trim() == "")
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Κατηγορία Πρωτοκόλλου'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IOBoxPanel.Name == "panelInbox")
            {
                //tbInProtokoloNum ---> max + 1

                if (IOBoxPanel.Controls["tbInDocNum"].Text.Trim() == "")
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Αριθμός Εισερχομένου Εγγράφου'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (IOBoxPanel.Controls["tbInFolderId"].Text.Trim() == "")
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Αριθμός Φακέλου Αρχείου'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (IOBoxPanel.Controls["tbInProeleusi"].Text.Trim() == "")
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Προέλευση'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (IOBoxPanel.Controls["tbInSummary"].Text.Trim() == "")
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Περίληψη'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (IOBoxPanel.Controls["tbInToText"].Text.Trim() == "")
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Παράδοση για ενέργεια / Παρατηρήσεις'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                

                //ToDo: new class - object

                SqlConnection sqlConn = new SqlConnection("Persist Security Info=False; User ID=" + DBInfo.username + "; Password=" + DBInfo.password + "; Initial Catalog=" + DBInfo.database + "; Server=" + DBInfo.server);
                string InsertSt = "INSERT INTO [dbo].[Protok] " +
                                  "(Id, Sn, Year, ProcedureId, CompanyId, Date, DocumentDate, DocumentGetSetDate, DocumentNumber, " +
                                  "ProeleusiKateuth, Summary, ToText, FolderId) " +
                                  "VALUES " +
                                  "(@Id, @Sn, year(getdate()), @ProcedureId, @CompanyId, getdate(), @DocumentDate, @DocumentGetSetDate, @DocumentNumber, " +
                                  "@ProeleusiKateuth, @Summary, @ToText, @FolderId) ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsertSt, sqlConn);

                    cmd.Parameters.AddWithValue("@Id", 34739); //manually - show [sn + year] & [id] --> company, year, eiserxomena-ekserxomena, 
                    cmd.Parameters.AddWithValue("@Sn", IOBoxPanel.Controls["tbInProtokoloNum"].Text); //2 users - insert with pdfs? disable field?
                    //cmd.Parameters.AddWithValue("@Year", 2017); //auto - current
                    cmd.Parameters.AddWithValue("@ProcedureId", ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@CompanyId", ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@DocumentDate", DatetimePickerToSQLDate(IOBoxPanel.Controls["dtpInDocDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(IOBoxPanel.Controls["dtpInGetDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentNumber", IOBoxPanel.Controls["tbInDocNum"].Text);
                    cmd.Parameters.AddWithValue("@ProeleusiKateuth", IOBoxPanel.Controls["tbInProeleusi"].Text);
                    cmd.Parameters.AddWithValue("@Summary", IOBoxPanel.Controls["tbInSummary"].Text);
                    cmd.Parameters.AddWithValue("@ToText", IOBoxPanel.Controls["tbInToText"].Text);
                    cmd.Parameters.AddWithValue("@FolderId", IOBoxPanel.Controls["tbInFolderId"].Text); //int -> char (eg 106A)??

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }

            }
            else if (IOBoxPanel.Name == "panelOutbox")
            {
                //tbInProtokoloNum ---> max + 1

                if (IOBoxPanel.Controls["tbOutDocNum"].Text.Trim() == "")
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Σχετικοί Αριθμοί'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (IOBoxPanel.Controls["tbOutKateuth"].Text.Trim() == "")
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Κατεύθυνση'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (IOBoxPanel.Controls["tbOutSummary"].Text.Trim() == "")
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Περίληψη'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                //ToDo: new class - object

                SqlConnection sqlConn = new SqlConnection("Persist Security Info=False; User ID=" + DBInfo.username + "; Password=" + DBInfo.password + "; Initial Catalog=" + DBInfo.database + "; Server=" + DBInfo.server);
                string InsertSt = "INSERT INTO [dbo].[Protok] " +
                                  "(Id, Sn, Year, ProcedureId, CompanyId, Date, DocumentGetSetDate, DocumentNumber, " +
                                  "ProeleusiKateuth, Summary) " +
                                  "VALUES " +
                                  "(@Id, @Sn, year(getdate()), @ProcedureId, @CompanyId, getdate(), @DocumentGetSetDate, @DocumentNumber, " +
                                  "@ProeleusiKateuth, @Summary) ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsertSt, sqlConn);

                    cmd.Parameters.AddWithValue("@Id", 34739); //manually - show [sn + year] & [id]
                    cmd.Parameters.AddWithValue("@Sn", IOBoxPanel.Controls["tbOutProtokoloNum"].Text); //2 users - insert with pdfs? disable field?
                    //cmd.Parameters.AddWithValue("@Year", 2017); //auto - current
                    cmd.Parameters.AddWithValue("@ProcedureId", ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@CompanyId", ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(IOBoxPanel.Controls["dtpOutSetDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentNumber", IOBoxPanel.Controls["tbOutDocNum"].Text);
                    cmd.Parameters.AddWithValue("@ProeleusiKateuth", IOBoxPanel.Controls["tbOutKateuth"].Text);
                    cmd.Parameters.AddWithValue("@Summary", IOBoxPanel.Controls["tbOutSummary"].Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }



            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να ακυρώσετε την καταχώρηση;", "Ακύρωση", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Id: " + ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id + ", Name: " +((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Name +  ", Text: " + ((ComboboxItem)cbCompany.SelectedItem).Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font myfont = new Font(comboBox1.SelectedItem.ToString(), 10);

            lblCompany.Font = myfont;
            lblProtokoloKind.Font = myfont;
            btnInsert.Font = myfont;
        }

    }
}
