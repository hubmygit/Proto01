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
            //List<string> fonts = new List<string>();
            //foreach (FontFamily font in System.Drawing.FontFamily.Families)
            //{
            //    fonts.Add(font.Name);
            //}
            //comboBox1.DataSource = fonts;
            //test<--
        }

        public int Protok_Id_For_Updates = 0;

        //public ProtokoloInsertForm(string FieldNo1)
        //{
        //    InitializeComponent();
        //    cbCompany.Items.AddRange(GetObjCompanies());
        //    cbProtokoloKind.Items.AddRange(GetObjProtocolKind());

        //    //cbProtokoloKind.SelectedText = FieldNo1;
        //    //cbCompany.SelectedText = "Motor Oil Hellas";
        //}

        InboxOutboxPanels IOPanelsFrm = new InboxOutboxPanels();
        Panel IOBoxPanel = new Panel();
        
        private string[] GetProtocolKind() //obsolete / depraced
        {
            List<string> KindOfProtocol = new List<string>();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
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

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
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

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
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

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
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

        public static ComboboxItem[] GetObjFolders()
        {
            List<Folders> Folders = new List<Folders>();
            List<ComboboxItem> cbInFolders = new List<ComboboxItem>();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT Id, Name FROM [dbo].[Folders] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Folders.Add(new Folders() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            foreach (Folders com in Folders)
            {
                cbInFolders.Add(new ComboboxItem() { Value = com, Text = com.Name });
            }

            return cbInFolders.ToArray<ComboboxItem>();
        }

        private void cbProtokoloKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controls.Remove(IOBoxPanel);

            if (cbProtokoloKind.Text == "Εισερχόμενα")
            {
                //Controls.Remove(IOBoxPanel);
                IOBoxPanel = IOPanelsFrm.panelInbox;
                IOBoxPanel.Location = new Point(12, 110);

                //IOBoxPanel.Controls["tbInProtokoloNum"].Text = "138";          //ToDo
                IOBoxPanel.Controls["tbInDocNum"].Text = "AA-0000/01";           //to del
                //IOBoxPanel.Controls["tbInFolderId"].Text = "101";              //to del
                //IOBoxPanel.Controls["cbInFolders"].Text = "...";                 //to del
                IOBoxPanel.Controls["tbInProeleusi"].Text = "ABCD";              //to del
                IOBoxPanel.Controls["tbInSummary"].Text = "Δοκιμαστική εγγραφή"; //to del
                IOBoxPanel.Controls["tbInToText"].Text = "Mr Abcd";              //to del

                Controls.Add(IOBoxPanel);
                //fill folders combobox - add 'items.clear' if needed
                ((ComboBox)IOBoxPanel.Controls["cbInFolders"]).Items.AddRange(GetObjFolders()); //fill folders combobox
                cbProtokoloKind.Enabled = false;
            }
            else if (cbProtokoloKind.Text == "Εξερχόμενα")
            {
                //Controls.Remove(IOBoxPanel);
                IOBoxPanel = IOPanelsFrm.panelOutbox;
                IOBoxPanel.Location = new Point(12, 110);

                //IOBoxPanel.Controls["tbOutProtokoloNum"].Text = "138";          //ToDo
                IOBoxPanel.Controls["tbOutDocNum"].Text = "AA-0000/01";           //to del
                IOBoxPanel.Controls["tbOutKateuth"].Text = "ABCD";                //to del
                IOBoxPanel.Controls["tbOutSummary"].Text = "Δοκιμαστική εγγραφή"; //to del

                Controls.Add(IOBoxPanel);
                cbProtokoloKind.Enabled = false;
            }
            else
            {
                //Controls.Remove(IOBoxPanel);
            }
        }

        string DatetimePickerToSQLDate(Control DatetimePicker)
        {
            return ((DateTimePicker)DatetimePicker).Value.ToString("yyyy-MM-dd");
        }

        private int getNextIdAndUpdateTable_TableIds(string tableName)
        {
            int ret = 0;

            if (tableName.Trim().Length > 0)
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                string UpdSt = "UPDATE [dbo].[TableIds] SET NUM = NUM + 1 " + 
                    "OUTPUT inserted.NUM " + 
                    "WHERE TABLENAME = '" + tableName + "'";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ret = Convert.ToInt32(reader["NUM"].ToString());
                    }
                    reader.Close();
                    //cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }

        private bool UpdateTable_TableIds(string tableName, int newProtokId) //UPDATE [dbo].[TableIds] 
        {
            bool ret = false;
            if (newProtokId > 0 && tableName.Trim().Length > 0)
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                string UpdSt = "UPDATE [dbo].[TableIds] SET num = " + newProtokId.ToString() + " WHERE tablename = '" + tableName + "' ";//" WHERE tablename = 'Protok' ";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                    cmd.CommandType = CommandType.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }                
            }

            return ret;
        }

        private bool UpdateTable_DocIds(int newProtokId, int company, int year, int procedId) //UPDATE [dbo].[DocsIds] 
        {
            bool ret = false;
            if (newProtokId > 0 && company > 0 && year > 0 && procedId > 0)
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                //string UpdSt = "UPDATE [dbo].[DocsIds] SET number = @InsertedSn WHERE docstath = @company and docyear = @year and " +
                //"document = (SELECT [Counter] FROM [dbo].[Proced] WHERE ProcedId = @procedId) ";
                string UpdSt = "UPDATE [dbo].[DocsIds] SET number = @InsertedSn WHERE docstath = @company and docyear = @year and ProcedId = @procedId) ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                    cmd.Parameters.AddWithValue("@InsertedSn", newProtokId);
                    cmd.Parameters.AddWithValue("@company", company);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@procedId", procedId);
                    cmd.CommandType = CommandType.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ret = true;
                    }
                    else
                    {
                        //new record ===> insert
                        //INSERT INTO [dbo].[DocsIds] (Id, number, docstath, docyear, ProcedId) VALUES (?????@Id?????, @InsertedSn, @company, @year, @procedId)
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }

        private bool InertIntoTable_ProtokPdf(int newProtokId, string fileName, byte[] fileBytes) //INSERT [dbo].[ProtokPdf]
        {
            bool ret = false;

            if (newProtokId > 0 && fileName.Trim().Length > 0)
            { 
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                string InsSt = "INSERT INTO [dbo].[ProtokPdf] (ProtokId, PdfText, PdfCont, FileCont) VALUES (@ProtokId, @PdfText, @PdfCont, @FileCont) ";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@ProtokId", newProtokId);
                    cmd.Parameters.AddWithValue("@PdfText", fileName); //filename
                    cmd.Parameters.Add("@PdfCont", SqlDbType.VarBinary).Value = fileBytes;
                    cmd.Parameters.Add("@FileCont", SqlDbType.VarBinary).Value = fileBytes;
                    cmd.CommandType = CommandType.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (Protok_Id_For_Updates != 0)
            {
                MessageBox.Show("Update Mode...");
                return;
            }
                        
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

                //if (IOBoxPanel.Controls["tbInFolderId"].Text.Trim() == "")
                if (IOBoxPanel.Controls["cbInFolders"].Text.Trim() == "")
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

                //UPDATE [dbo].[TableIds] 
                int ProtokId = getNextIdAndUpdateTable_TableIds("Protok"); 
                


                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);

                //string tableId = "select isnull(max(id), 0) + 1 from [dbo].[Protok]";
                //string tableId = ProtokId.ToString();

                string proced_Id = ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id.ToString();
                string company_Id = ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id.ToString();

                string ProtocolId = "select isnull(max(id), 0) + 1 from [dbo].[Protok] where [CompanyId] = " + company_Id + " and [Year] = year(getdate()) and [ProcedureId] = " + proced_Id;

                string InsertSt = "INSERT INTO [dbo].[Protok] " +
                                  "(Id, Sn, Year, ProcedureId, CompanyId, Date, DocumentDate, DocumentGetSetDate, DocumentNumber, " +
                                  "ProeleusiKateuth, Summary, ToText, FolderId) " +
                                  "OUTPUT inserted.Id, inserted.Sn, inserted.Year " +
                                  "VALUES " +
                                  "(@Id, (" + ProtocolId + "), year(getdate()), @ProcedureId, @CompanyId, getdate(), @DocumentDate, @DocumentGetSetDate, @DocumentNumber, " +
                                  "@ProeleusiKateuth, @Summary, @ToText, @FolderId) ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsertSt, sqlConn);

                    //cmd.Parameters.AddWithValue("@Id", 34745); //manually - show [sn + year] & [id] --> company, year, eiserxomena-ekserxomena, 
                    //cmd.Parameters.AddWithValue("@Sn", IOBoxPanel.Controls["tbInProtokoloNum"].Text); //2 users - insert with pdfs? disable field?
                    //cmd.Parameters.AddWithValue("@Year", 2017); //auto - current
                    cmd.Parameters.AddWithValue("@Id", ProtokId.ToString());
                    cmd.Parameters.AddWithValue("@ProcedureId", ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@CompanyId", ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@DocumentDate", DatetimePickerToSQLDate(IOBoxPanel.Controls["dtpInDocDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(IOBoxPanel.Controls["dtpInGetDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentNumber", IOBoxPanel.Controls["tbInDocNum"].Text);
                    cmd.Parameters.AddWithValue("@ProeleusiKateuth", IOBoxPanel.Controls["tbInProeleusi"].Text);
                    cmd.Parameters.AddWithValue("@Summary", IOBoxPanel.Controls["tbInSummary"].Text);
                    cmd.Parameters.AddWithValue("@ToText", IOBoxPanel.Controls["tbInToText"].Text);
                    //cmd.Parameters.AddWithValue("@FolderId", IOBoxPanel.Controls["tbInFolderId"].Text); //int -> char (eg 106A)??
                    cmd.Parameters.AddWithValue("@FolderId", ((Folders)((ComboboxItem)((ComboBox)IOBoxPanel.Controls["cbInFolders"]).SelectedItem).Value).Id); //get object from combobox

                    cmd.CommandType = CommandType.Text;
                    //cmd.ExecuteNonQuery();
                    //--> get output fields!! 
                    //string InsertedId = ProtokId.ToString();
                    string InsertedSn = "";
                    string InsertedYear = "";
                    SqlDataReader reader = cmd.ExecuteReader();
                    //while (reader.Read())
                    if (reader.Read())
                    {
                        //InsertedId = reader["Id"].ToString();
                        InsertedSn = reader["Sn"].ToString();
                        InsertedYear = reader["Year"].ToString();
                    }
                    reader.Close();


                    //UPDATE [dbo].[TableIds] 
                    //bool wasSuccessful = UpdateTable_TableIds("Protok", Convert.ToInt32(InsertedId));

                    //UPDATE [dbo].[DocsIds] 
                    bool wasSuccessful = UpdateTable_DocIds(Convert.ToInt32(InsertedSn), Convert.ToInt32(company_Id), Convert.ToInt32(InsertedYear), Convert.ToInt32(proced_Id));
                    

                    //insert attachments into db
                    ListView lv = ((ListView)IOBoxPanel.Controls["lvInAttachedFiles"]);
                    foreach (ListViewItem lvi in lv.Items)
                    {
                        string attFileName = lvi.SubItems[1].Text;
                        byte[] attFileBytes = System.IO.File.ReadAllBytes(attFileName);


                        //INSERT [dbo].[ProtokPdf]
                        wasSuccessful = InertIntoTable_ProtokPdf(ProtokId, lvi.SubItems[0].Text, attFileBytes);
                        
                    }

                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς! \r\nΑριθμός Πρωτοκόλλου: [" + InsertedSn + "]");
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

                //UPDATE [dbo].[TableIds] 
                int ProtokId = getNextIdAndUpdateTable_TableIds("Protok");
                


                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);

                //string tableId = "select isnull(max(id), 0) + 1 from [dbo].[Protok]";
                //string tableId = ProtokId.ToString();

                string proced_Id = ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id.ToString();
                string company_Id = ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id.ToString(); 

                string ProtocolId = "select isnull(max(id), 0) + 1 from [dbo].[Protok] where [CompanyId] = " + company_Id + " and [Year] = year(getdate()) and [ProcedureId] = " + proced_Id;

                string InsertSt = "INSERT INTO [dbo].[Protok] " +
                                  "(Id, Sn, Year, ProcedureId, CompanyId, Date, DocumentGetSetDate, DocumentNumber, " +
                                  "ProeleusiKateuth, Summary) " +
                                  "OUTPUT inserted.Id, inserted.Sn, inserted.Year " +
                                  "VALUES " +
                                  "(@Id, (" + ProtocolId + "), year(getdate()), @ProcedureId, @CompanyId, getdate(), @DocumentGetSetDate, @DocumentNumber, " +
                                  "@ProeleusiKateuth, @Summary) ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsertSt, sqlConn);

                    //cmd.Parameters.AddWithValue("@Id", 34745); //manually - show [sn + year] & [id]
                    //cmd.Parameters.AddWithValue("@Sn", IOBoxPanel.Controls["tbOutProtokoloNum"].Text); //2 users - insert with pdfs? disable field?
                    //cmd.Parameters.AddWithValue("@Year", 2017); //auto - current
                    cmd.Parameters.AddWithValue("@Id", ProtokId.ToString());
                    cmd.Parameters.AddWithValue("@ProcedureId", ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@CompanyId", ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(IOBoxPanel.Controls["dtpOutSetDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentNumber", IOBoxPanel.Controls["tbOutDocNum"].Text);
                    cmd.Parameters.AddWithValue("@ProeleusiKateuth", IOBoxPanel.Controls["tbOutKateuth"].Text);
                    cmd.Parameters.AddWithValue("@Summary", IOBoxPanel.Controls["tbOutSummary"].Text);

                    cmd.CommandType = CommandType.Text;
                    //cmd.ExecuteNonQuery();
                    //--> get output fields!!  
                    //string InsertedId = ProtokId.ToString();
                    string InsertedSn = "";
                    string InsertedYear = "";
                    SqlDataReader reader = cmd.ExecuteReader();
                    //while (reader.Read())
                    if (reader.Read())
                    {
                        //InsertedId = reader["Id"].ToString();
                        InsertedSn = reader["Sn"].ToString();
                        InsertedYear = reader["Year"].ToString();
                    }
                    reader.Close();


                    //UPDATE [dbo].[TableIds] 
                    //bool wasSuccessful = UpdateTable_TableIds("Protok", Convert.ToInt32(InsertedId));

                    //UPDATE [dbo].[DocsIds] 
                    bool wasSuccessful = UpdateTable_DocIds(Convert.ToInt32(InsertedSn), Convert.ToInt32(company_Id), Convert.ToInt32(InsertedYear), Convert.ToInt32(proced_Id));


                    //insert attachments into db
                    ListView lv = ((ListView)IOBoxPanel.Controls["lvOutAttachedFiles"]);
                    foreach (ListViewItem lvi in lv.Items)
                    {
                        string attFileName = lvi.SubItems[1].Text;
                        byte[] attFileBytes = System.IO.File.ReadAllBytes(attFileName);


                        //INSERT [dbo].[ProtokPdf]
                        wasSuccessful = InertIntoTable_ProtokPdf(ProtokId, lvi.SubItems[0].Text, attFileBytes);

                    }

                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς! \r\nΑριθμός Πρωτοκόλλου: [" + InsertedSn + "]");
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

        private void ProtokoloInsertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να ακυρώσετε την καταχώρηση;", "Ακύρωση", MessageBoxButtons.YesNo);

            e.Cancel = (dialogResult == DialogResult.No);
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Id: " + ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id + ", Name: " +((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Name +  ", Text: " + ((ComboboxItem)cbCompany.SelectedItem).Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Font myfont = new Font(comboBox1.SelectedItem.ToString(), 11);

            //lblCompany.Font = myfont;
            //lblProtokoloKind.Font = myfont;
            //btnInsert.Font = myfont;
            //btnCancel.Font = myfont;
        }

        
    }
}
