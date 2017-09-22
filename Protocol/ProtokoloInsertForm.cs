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

            //MessageBox.Show(Environment.MachineName + Environment.UserName + Environment.OSVersion.VersionString + Environment.UserDomainName);

            //test<--
        }


        public int Protok_Id_For_Updates = 0;
        public bool ShowClosingDialog = true;
        public bool successfulInsertion = false;
        public Email myEmail;

        //public ProtokoloInsertForm(string FieldNo1)
        //{
        //    InitializeComponent();
        //    cbCompany.Items.AddRange(GetObjCompanies());
        //    cbProtokoloKind.Items.AddRange(GetObjProtocolKind());

        //    //cbProtokoloKind.SelectedText = FieldNo1;
        //    //cbCompany.SelectedText = "Motor Oil Hellas";
        //}

        InboxOutboxPanels IOPanelsFrm = new InboxOutboxPanels();
        public Panel IOBoxPanel = new Panel();

        public List<string> AttFilesList = new List<string>();

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

        public static ComboboxItem[] GetObjProtocolKind()
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

        public static ComboboxItem[] GetObjCompanies()
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
                    Companies.Add(new Company() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            foreach (Company com in Companies)
            {
                cbCompanies.Add(new ComboboxItem() { Value = com, Text = com.Name });
            }

            return cbCompanies.ToArray<ComboboxItem>();
        }

        public static ComboboxItem[] GetObjFolders()
        {
            List<Folders> Folders = new List<Folders>();
            List<ComboboxItem> cbFolders = new List<ComboboxItem>();

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
                cbFolders.Add(new ComboboxItem() { Value = com, Text = com.Name });
            }

            return cbFolders.ToArray<ComboboxItem>();
        }

        public static ComboboxItem[] GetObjFolders(int CompanyId, int ProcedId)
        {
            List<Folders> Folders = new List<Folders>();
            List<ComboboxItem> cbFolders = new List<ComboboxItem>();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT Id, Name FROM [dbo].[Folders] WHERE CompanyId = @company and ProcedId = @proced";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            cmd.Parameters.AddWithValue("@company", CompanyId);
            cmd.Parameters.AddWithValue("@proced", ProcedId);
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
                cbFolders.Add(new ComboboxItem() { Value = com, Text = com.Name });
            }

            return cbFolders.ToArray<ComboboxItem>();
        }

        void ShowPanel()
        {
            Controls.Remove(IOBoxPanel);

            if (cbProtokoloKind.Text == "Εισερχόμενα" && cbCompany.Text.Trim() != "")
            {
                //Controls.Remove(IOBoxPanel);
                IOBoxPanel = IOPanelsFrm.panelInbox;
                IOBoxPanel.Location = new Point(12, 110);

                IOBoxPanel.Controls["tbInDocNum"].Text = "AA-0000/01";           //to del
                IOBoxPanel.Controls["tbInProeleusi"].Text = "ABCD";              //to del
                IOBoxPanel.Controls["tbInSummary"].Text = "Δοκιμαστική εγγραφή"; //to del
                IOBoxPanel.Controls["tbInToText"].Text = "Mr Abcd";              //to del

                Controls.Add(IOBoxPanel);
                //fill folders combobox - add 'items.clear' if needed
                int comId = ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id;
                int procedId = ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id;
                ((ComboBox)IOBoxPanel.Controls["cbInFolders"]).Items.AddRange(GetObjFolders(comId, procedId)); //fill folders combobox
                
            }
            else if (cbProtokoloKind.Text == "Εξερχόμενα" && cbCompany.Text.Trim() != "")
            {
                //Controls.Remove(IOBoxPanel);
                IOBoxPanel = IOPanelsFrm.panelOutbox;
                IOBoxPanel.Location = new Point(12, 110);

                IOBoxPanel.Controls["tbOutDocNum"].Text = "AA-0000/01";           //to del
                IOBoxPanel.Controls["tbOutKateuth"].Text = "ABCD";                //to del
                IOBoxPanel.Controls["tbOutSummary"].Text = "Δοκιμαστική εγγραφή"; //to del

                Controls.Add(IOBoxPanel);
                //fill folders combobox - add 'items.clear' if needed
                int comId = ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id;
                int procedId = ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id;
                ((ComboBox)IOBoxPanel.Controls["cbOutFolders"]).Items.AddRange(GetObjFolders(comId, procedId)); //fill folders combobox

            }
            else
            {
                //Controls.Remove(IOBoxPanel);
            }
        }
        private void cbProtokoloKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProtokoloKind.Text.Trim() != "")
            {
                cbProtokoloKind.Enabled = false;
            }

            ShowPanel();
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCompany.Text.Trim() != "")
            {
                cbCompany.Enabled = false;
            }

            ShowPanel();
            //MessageBox.Show("Id: " + ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id + ", Name: " +((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Name +  ", Text: " + ((ComboboxItem)cbCompany.SelectedItem).Text);
        }

        string DatetimePickerToSQLDate(Control DatetimePicker)
        {
            return ((DateTimePicker)DatetimePicker).Value.ToString("yyyy-MM-dd");
        }

        string DatetimePickerToReadableDate(Control DatetimePicker)
        {
            return ((DateTimePicker)DatetimePicker).Value.ToString("dd.MM.yyyy");
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

        private UpdatedId getNextSnAndUpdateTable_DocsIds(int company, int procedId)
        {
            //int ret = 0;
            UpdatedId ret = new UpdatedId();
            //UpdSn.inserted = 0;

            if (company > 0 && procedId > 0)
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                string UpdSt = "UPDATE [dbo].[DocsIds] SET number = number + 1 " +
                    "OUTPUT deleted.number as oldValue, inserted.number as newValue " +
                    "WHERE company = @company and docyear = year(getdate()) and ProcedId = @procedId";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                    cmd.Parameters.AddWithValue("@company", company);
                    //cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@procedId", procedId);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        //ret = Convert.ToInt32(reader["number"].ToString());
                        ret.deleted = Convert.ToInt32(reader["oldValue"].ToString());
                        ret.inserted = Convert.ToInt32(reader["newValue"].ToString());
                    }
                    reader.Close();
                    //cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }

                if (ret.inserted == 0)
                {
                    //UPDATE [dbo].[TableIds] 
                    int DocsIdsId = getNextIdAndUpdateTable_TableIds("DocsIds");

                    if (DocsIdsId > 0)
                    {
                        //INSERT [dbo].[DocsIds]
                        bool Inserted = InertIntoTable_DocsIds(DocsIdsId, 1, company, procedId);
                        if (Inserted)
                        {
                            ret.deleted = 0;
                            ret.inserted = 1;
                        }
                        //else
                        //{
                        //}
                    }
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

        private bool InertIntoTable_DocsIds(int id, int number, int company, int procedId) //INSERT [dbo].[DocsIds]
        {
            bool ret = false;

            if (id > 0 && number > 0 && company > 0 && procedId > 0)
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                string InsSt = "INSERT INTO [dbo].[DocsIds] (Id, number, company, docyear, ProcedId) VALUES (@Id, @Sn, @Company, year(getdate()), @ProcedId) ";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Sn", number);
                    cmd.Parameters.AddWithValue("@Company", company);
                    cmd.Parameters.AddWithValue("@ProcedId", procedId);

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


        private bool UpdateTable_DocIds(int newProtokId, int company, int procedId) //UPDATE [dbo].[DocsIds] 
        {
            bool ret = false;
            if (newProtokId > 0 && company > 0 && procedId > 0)
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                string UpdSt = "UPDATE [dbo].[DocsIds] SET number = @Sn WHERE company = @company and docyear = year(getdate()) and ProcedId = @procedId ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                    cmd.Parameters.AddWithValue("@Sn", newProtokId);
                    cmd.Parameters.AddWithValue("@company", company);
                    cmd.Parameters.AddWithValue("@procedId", procedId);
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
                    cmd.Parameters.AddWithValue("@PdfText", fileName.Left(100)); //filename
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

        private bool InsertIntoTable_Protok(int Id, int Sn, int procedId, int companyId, Panel myPanel)
        {
            bool ret = false;

            if (myPanel.Name == "panelInbox")
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
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

                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Sn", Sn);
                    cmd.Parameters.AddWithValue("@ProcedureId", procedId); //get object from combobox
                    cmd.Parameters.AddWithValue("@CompanyId", companyId); //get object from combobox
                    cmd.Parameters.AddWithValue("@DocumentDate", DatetimePickerToSQLDate(myPanel.Controls["dtpInDocDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(myPanel.Controls["dtpInGetDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentNumber", myPanel.Controls["tbInDocNum"].Text.Left(50));
                    cmd.Parameters.AddWithValue("@ProeleusiKateuth", myPanel.Controls["tbInProeleusi"].Text.Left(150));
                    cmd.Parameters.AddWithValue("@Summary", myPanel.Controls["tbInSummary"].Text);
                    cmd.Parameters.AddWithValue("@ToText", myPanel.Controls["tbInToText"].Text.Left(255));
                    cmd.Parameters.AddWithValue("@FolderId", ((Folders)((ComboboxItem)((ComboBox)myPanel.Controls["cbInFolders"]).SelectedItem).Value).Id); //get object from combobox

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
            else if (myPanel.Name == "panelOutbox")
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
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

                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Sn", Sn);
                    cmd.Parameters.AddWithValue("@ProcedureId", procedId); //get object from combobox
                    cmd.Parameters.AddWithValue("@CompanyId", companyId); //get object from combobox
                    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(myPanel.Controls["dtpOutSetDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentNumber", myPanel.Controls["tbOutDocNum"].Text.Left(50));
                    cmd.Parameters.AddWithValue("@ProeleusiKateuth", myPanel.Controls["tbOutKateuth"].Text.Left(150));
                    cmd.Parameters.AddWithValue("@Summary", myPanel.Controls["tbOutSummary"].Text);
                    cmd.Parameters.AddWithValue("@FolderId", ((Folders)((ComboboxItem)((ComboBox)myPanel.Controls["cbOutFolders"]).SelectedItem).Value).Id); //get object from combobox

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

        //ToDo...
        private bool UpdateTable_Protok(int ProtokId, Panel myPanel) //UPDATE [dbo].[Protok] 
        {
            bool ret = false;
            if (ProtokId > 0)
            {
                if (myPanel.Name == "panelInbox")
                {
                    SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                    string UpdSt = "UPDATE [dbo].[Protok] SET field1 = @field1, ................., upddt = getdate() WHERE id = @Id ";
                    //                  "(DocumentDate, DocumentGetSetDate, DocumentNumber, ProeleusiKateuth, Summary, ToText, FolderId) " +
                    //                  "VALUES " +
                    //                  "(@DocumentDate, @DocumentGetSetDate, @DocumentNumber, @ProeleusiKateuth, @Summary, @ToText, @FolderId) ";
                    
                    try
                    {
                        sqlConn.Open();
                        SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                        cmd.Parameters.AddWithValue("@Id", ProtokId);
                        //    cmd.Parameters.AddWithValue("@DocumentDate", DatetimePickerToSQLDate(myPanel.Controls["dtpInDocDate"])); //datepicker - no time
                        //    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(myPanel.Controls["dtpInGetDate"])); //datepicker - no time
                        //    cmd.Parameters.AddWithValue("@DocumentNumber", myPanel.Controls["tbInDocNum"].Text.Left(50));
                        //    cmd.Parameters.AddWithValue("@ProeleusiKateuth", myPanel.Controls["tbInProeleusi"].Text.Left(150));
                        //    cmd.Parameters.AddWithValue("@Summary", myPanel.Controls["tbInSummary"].Text);
                        //    cmd.Parameters.AddWithValue("@ToText", myPanel.Controls["tbInToText"].Text.Left(255));
                        //    cmd.Parameters.AddWithValue("@FolderId", ((Folders)((ComboboxItem)((ComboBox)myPanel.Controls["cbInFolders"]).SelectedItem).Value).Id); //get object from combobox
                        //...
                        //...
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
                else if (myPanel.Name == "panelOutbox")
                {
                    SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                    string UpdSt = "UPDATE [dbo].[Protok] SET field1 = @field1, ................., upddt = getdate() WHERE id = @Id ";
                    //              "(DocumentGetSetDate, DocumentNumber, ProeleusiKateuth, Summary) " +
                    //              "VALUES " +
                    //              "(@DocumentGetSetDate, @DocumentNumber, @ProeleusiKateuth, @Summary) ";
                    
                    try
                    {
                        sqlConn.Open();
                        SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                        cmd.Parameters.AddWithValue("@Id", ProtokId);
                        //    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(myPanel.Controls["dtpOutSetDate"])); //datepicker - no time
                        //    cmd.Parameters.AddWithValue("@DocumentNumber", myPanel.Controls["tbOutDocNum"].Text.Left(50));
                        //    cmd.Parameters.AddWithValue("@ProeleusiKateuth", myPanel.Controls["tbOutKateuth"].Text.Left(150));
                        //    cmd.Parameters.AddWithValue("@Summary", myPanel.Controls["tbOutSummary"].Text);
                        //...
                        //...
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
            }

            return ret;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //No updates in this phase...
            //if (Protok_Id_For_Updates != 0)
            //{
            //    MessageBox.Show("Update Mode...");

            //    //UPDATE [dbo].[Protok] 
            //    bool xxx = UpdateTable_Protok(Protok_Id_For_Updates, IOBoxPanel); 

            //    return;
            //}

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

                int proced_Id = ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id;
                int company_Id = ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id;

                //UPDATE [dbo].[TableIds] 
                int ProtokId = getNextIdAndUpdateTable_TableIds("Protok");

                //UPDATE [dbo].[DocsIds] 
                //int ProtokSn = getNextSnAndUpdateTable_DocsIds(company_Id, proced_Id);
                UpdatedId ProtokSn = getNextSnAndUpdateTable_DocsIds(company_Id, proced_Id);

                if (ProtokId > 0 && ProtokSn.inserted > 0)
                {
                    //INSERT INTO [dbo].[Protok] 
                    bool wasSuccessful = InsertIntoTable_Protok(ProtokId, ProtokSn.inserted, proced_Id, company_Id, IOBoxPanel);

                    if (wasSuccessful)
                    {
                        //insert attachments into db
                        ListView lv = ((ListView)IOBoxPanel.Controls["lvInAttachedFiles"]);

                        foreach (ListViewItem lvi in lv.Items)
                        {
                            string attFileName = lvi.SubItems[1].Text;
                            AttFilesList.Add(attFileName);
                            byte[] attFileBytes = System.IO.File.ReadAllBytes(attFileName);

                            //INSERT [dbo].[ProtokPdf]
                            wasSuccessful = InertIntoTable_ProtokPdf(ProtokId, lvi.SubItems[0].Text, attFileBytes);

                            if (!wasSuccessful)
                            {
                                MessageBox.Show("Αποτυχία αποθήκευσης του αρχείου: " + lvi.SubItems[0].Text);
                            }
                        }

                        MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς! \r\nΑριθμός Πρωτοκόλλου: [" + ProtokSn.inserted.ToString() + "]");
                        successfulInsertion = wasSuccessful;

                        if (chbSendMail.Checked)
                        {
                            myEmail = new Email();
                            myEmail.ProtokId = ProtokId;

                            string aaa = "ΕΙΣΕΡΧΟΜΕΝΑ";
                            string bbb = ProtokSn.inserted.ToString();
                            string ccc = DatetimePickerToReadableDate(IOBoxPanel.Controls["dtpInGetDate"]);
                            string ddd = IOBoxPanel.Controls["tbInProeleusi"].Text;
                            string eee = IOBoxPanel.Controls["tbInSummary"].Text;

                            myEmail.Subject = aaa.Left(3) + "." + bbb + "/" + ccc + " " + ddd.Left(30) + "-" + eee.Left(30);
                            myEmail.Body = aaa + "\r\n" + "Αριθμός Πρωτοκόλλου: " + bbb + "\r\n" + "Ημερομηνία Λήψης: " + ccc + "\r\n" + "Προέλευση: " + ddd + "\r\n" + "Περίληψη: " + eee;
                        }

                        ShowClosingDialog = false;
                        Close();
                    }
                    else
                    {
                        //UPDATE [dbo].[DocsIds] 
                        bool resetSn = UpdateTable_DocIds(ProtokSn.deleted, company_Id, proced_Id); //number -= 1

                        if (resetSn)
                        {
                            MessageBox.Show("Σφάλμα κατά την καταχώρηση! Παρακαλώ προσπαθήστε ξανά.");
                        }
                        else
                        {
                            MessageBox.Show("Σφάλμα κατά την καταχώρηση! Δώθηκε ο αριθμός πρωτοκόλλου " + ProtokSn.inserted.ToString() + " χωρίς να ολοκληρωθεί η καταχώρηση!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Σφάλμα κατά την απόδοση νέου Αριθμού Πρωτοκόλλου! Παρακαλώ προσπαθήστε ξανά.");
                }


                /*
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
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

                    //cmd.Parameters.AddWithValue("@Id", 34745); //manually - show [sn + year] & [id] --> company, year, eiserxomena-ekserxomena, 
                    //cmd.Parameters.AddWithValue("@Sn", IOBoxPanel.Controls["tbInProtokoloNum"].Text); //2 users - insert with pdfs? disable field?
                    cmd.Parameters.AddWithValue("@Id", ProtokId);
                    cmd.Parameters.AddWithValue("@Sn", ProtokSn);
                    cmd.Parameters.AddWithValue("@ProcedureId", proced_Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@CompanyId", company_Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@DocumentDate", DatetimePickerToSQLDate(IOBoxPanel.Controls["dtpInDocDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(IOBoxPanel.Controls["dtpInGetDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentNumber", IOBoxPanel.Controls["tbInDocNum"].Text);
                    cmd.Parameters.AddWithValue("@ProeleusiKateuth", IOBoxPanel.Controls["tbInProeleusi"].Text);
                    cmd.Parameters.AddWithValue("@Summary", IOBoxPanel.Controls["tbInSummary"].Text);
                    cmd.Parameters.AddWithValue("@ToText", IOBoxPanel.Controls["tbInToText"].Text);
                    //cmd.Parameters.AddWithValue("@FolderId", IOBoxPanel.Controls["tbInFolderId"].Text); //int -> char (eg 106A)??
                    cmd.Parameters.AddWithValue("@FolderId", ((Folders)((ComboboxItem)((ComboBox)IOBoxPanel.Controls["cbInFolders"]).SelectedItem).Value).Id); //get object from combobox

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
                */



            }
            else if (IOBoxPanel.Name == "panelOutbox")
            {
                //tbInProtokoloNum ---> max + 1

                if (IOBoxPanel.Controls["tbOutDocNum"].Text.Trim() == "")
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Σχετικοί Αριθμοί'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (IOBoxPanel.Controls["cbOutFolders"].Text.Trim() == "")
                {
                    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Αριθμός Φακέλου Αρχείου'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                int proced_Id = ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id;
                int company_Id = ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id;

                //UPDATE [dbo].[TableIds] 
                int ProtokId = getNextIdAndUpdateTable_TableIds("Protok");

                //UPDATE [dbo].[DocsIds] 
                //int ProtokSn = getNextSnAndUpdateTable_DocsIds(company_Id, proced_Id);
                UpdatedId ProtokSn = getNextSnAndUpdateTable_DocsIds(company_Id, proced_Id);

                if (ProtokId > 0 && ProtokSn.inserted > 0)
                {
                    //INSERT INTO [dbo].[Protok] 
                    bool wasSuccessful = InsertIntoTable_Protok(ProtokId, ProtokSn.inserted, proced_Id, company_Id, IOBoxPanel);

                    if (wasSuccessful)
                    {
                        //insert attachments into db
                        ListView lv = ((ListView)IOBoxPanel.Controls["lvOutAttachedFiles"]);

                        foreach (ListViewItem lvi in lv.Items)
                        {
                            string attFileName = lvi.SubItems[1].Text;
                            AttFilesList.Add(attFileName);
                            byte[] attFileBytes = System.IO.File.ReadAllBytes(attFileName);

                            //INSERT [dbo].[ProtokPdf]
                            wasSuccessful = InertIntoTable_ProtokPdf(ProtokId, lvi.SubItems[0].Text, attFileBytes);

                            if (!wasSuccessful)
                            {
                                MessageBox.Show("Αποτυχία αποθήκευσης του αρχείου: " + lvi.SubItems[0].Text);
                            }
                        }

                        MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς! \r\nΑριθμός Πρωτοκόλλου: [" + ProtokSn.inserted.ToString() + "]");
                        successfulInsertion = wasSuccessful;
                        ShowClosingDialog = false;
                        Close();
                    }
                    else
                    {
                        //UPDATE [dbo].[DocsIds] 
                        bool resetSn = UpdateTable_DocIds(ProtokSn.deleted, company_Id, proced_Id); //number -= 1

                        if (resetSn)
                        {
                            MessageBox.Show("Σφάλμα κατά την καταχώρηση! Παρακαλώ προσπαθήστε ξανά.");
                        }
                        else
                        {
                            MessageBox.Show("Σφάλμα κατά την καταχώρηση! Δώθηκε ο αριθμός πρωτοκόλλου " + ProtokSn.inserted.ToString() + " χωρίς να ολοκληρωθεί η καταχώρηση!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Σφάλμα κατά την απόδοση νέου Αριθμού Πρωτοκόλλου! Παρακαλώ προσπαθήστε ξανά.");
                }



                /*
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
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

                    //cmd.Parameters.AddWithValue("@Id", 34745); //manually - show [sn + year] & [id]
                    //cmd.Parameters.AddWithValue("@Sn", IOBoxPanel.Controls["tbOutProtokoloNum"].Text); //2 users - insert with pdfs? disable field?
                    //cmd.Parameters.AddWithValue("@Year", 2017); //auto - current
                    cmd.Parameters.AddWithValue("@Id", ProtokId);
                    cmd.Parameters.AddWithValue("@Sn", ProtokSn);
                    cmd.Parameters.AddWithValue("@ProcedureId", proced_Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@CompanyId", company_Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(IOBoxPanel.Controls["dtpOutSetDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentNumber", IOBoxPanel.Controls["tbOutDocNum"].Text);
                    cmd.Parameters.AddWithValue("@ProeleusiKateuth", IOBoxPanel.Controls["tbOutKateuth"].Text);
                    cmd.Parameters.AddWithValue("@Summary", IOBoxPanel.Controls["tbOutSummary"].Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
                */




            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να ακυρώσετε την καταχώρηση;", "Ακύρωση", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
                Close();
            //}
        }

        private void ProtokoloInsertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ShowClosingDialog)
            {
                DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να ακυρώσετε την καταχώρηση;", "Ακύρωση", MessageBoxButtons.YesNo);

                e.Cancel = (dialogResult == DialogResult.No);
            }
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

    public static class MyExtensions
    {
        /// <summary>
        /// Haris' method - Extended method of string class. 
        /// Gets first N:len characters starting from the left side of string.
        /// </summary>
        /// <param name="str">your string</param>
        /// <param name="len">length of new string</param>
        /// <returns></returns>
        public static string Left(this String str, int len)
        {
            string formattedString = str;

            if (len > 0 && str.Length >= len)
            {
                formattedString = str.Substring(0, len);
            }

            return formattedString;
        }
    }
}
