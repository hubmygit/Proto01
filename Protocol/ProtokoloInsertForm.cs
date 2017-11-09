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
            

            tsStatusLblInsUser.Text = "Χρήστης Καταχώρησης: " + UserInfo.WindowsUser + " - " + UserInfo.FullName;
                        

            //Values from database
            //cbCompany.Items.AddRange(GetCompanies());
            //cbProtokoloKind.Items.AddRange(GetProtocolKind()); 
            cbCompany.Items.AddRange(GetObjCompanies());
            IfUniqueSelectIt(cbCompany);

            cbProtokoloKind.Items.AddRange(GetObjProtocolKind());


            //test-->

            //ComboBox comboBox1 = new ComboBox();
            //Location
            //Controls.Add

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
        //public CRUD_Mode formCRUDMode; //

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

        public static ComboboxItem[] GetObjProtocolKind() //(int ProcedId = 999)
        {
            List<Proced> Proceds = new List<Proced>();
            List<ComboboxItem> cbProceds = new List<ComboboxItem>();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT Id, Name FROM [dbo].[Proced] ";

            //if (ProcedId != 999)
            //{
            //    SelectSt += "WHERE ProcedId = " + ProcedId.ToString();
            //}

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
            string SelectSt = "SELECT Id, Name FROM [dbo].[Company] " +
                              " WHERE 1=1 and Id in (" + UserInfo.CompaniesAsCsvString + ") " +
                              "ORDER BY Name ";
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
            string SelectSt = "SELECT Id, Name FROM [dbo].[Company] " +
                              " WHERE 1=1 and Id in (" + UserInfo.CompaniesAsCsvString + ") " +
                              "ORDER BY Name ";
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
            //string SelectSt = "SELECT Id, Name FROM [dbo].[Folders] ";
            string SelectSt = "SELECT F.Id, F.Name, F.CompanyId, C.Name as ComName, F.ProcedId, P.Name as ProcName " +
                              "FROM [dbo].[Folders] F left outer join [dbo].[Company] C on F.CompanyId = C.id left outer join[dbo].[Proced] P on F.ProcedId = P.ProcedId " +
                              " WHERE 1=1 and C.Id in (" + UserInfo.CompaniesAsCsvString + ") " +
                              "ORDER BY C.Name, P.Name, F.Name";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Folders.Add(new Folders() { Id = Convert.ToInt32(reader["Id"].ToString()),
                                                Name = reader["Name"].ToString(),
                                                Com = new Company() { Id = Convert.ToInt32(reader["CompanyId"].ToString()), Name = reader["ComName"].ToString() },
                                                Proc = new Proced() { Id = Convert.ToInt32(reader["ProcedId"].ToString()), Name = reader["ProcName"].ToString() }
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            foreach (Folders fld in Folders)
            {
                //cbFolders.Add(new ComboboxItem() { Value = com, Text = com.Name });
                cbFolders.Add(new ComboboxItem() { Value = fld, Text = "[" + fld.Com.Name + "/" + fld.Proc.Name + "]  " + fld.Name});
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
                IOBoxPanel.Location = new Point(52, 110);

                //IOBoxPanel.Controls["tbInDocNum"].Text = "AA-0000/01";           //to del
                //IOBoxPanel.Controls["tbInProeleusi"].Text = "ABCD";              //to del
                //IOBoxPanel.Controls["tbInSummary"].Text = "Δοκιμαστική εγγραφή"; //to del
                //IOBoxPanel.Controls["tbInToText"].Text = "Mr Abcd";              //to del

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
                IOBoxPanel.Location = new Point(52, 110);

                //IOBoxPanel.Controls["tbOutDocNum"].Text = "AA-0000/01";           //to del
                //IOBoxPanel.Controls["tbOutKateuth"].Text = "ABCD";                //to del
                //IOBoxPanel.Controls["tbOutSummary"].Text = "Δοκιμαστική εγγραφή"; //to del

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

                if (cbProtokoloKind.Text == "Εξερχόμενα")
                {
                    chbPrintClipping.Enabled = false;
                }
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
                //string InsSt = "INSERT INTO [dbo].[ProtokPdf] (ProtokId, PdfText, PdfCont, FileCont) VALUES (@ProtokId, @PdfText, @PdfCont, @FileCont) ";
                string InsSt = "INSERT INTO [dbo].[ProtokPdf] (ProtokId, PdfText, FileCont) VALUES (@ProtokId, @PdfText, @FileCont) ";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@ProtokId", newProtokId);
                    cmd.Parameters.AddWithValue("@PdfText", fileName.Left(100)); //filename
                    //cmd.Parameters.Add("@PdfCont", SqlDbType.VarBinary).Value = fileBytes;
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
                                  "ProeleusiKateuth, Summary, ToText, FolderId, InsDt, InsUsr, RevNo) " +
                                  "VALUES " +
                                  "(@Id, @Sn, year(getdate()), @ProcedureId, @CompanyId, getdate(), @DocumentDate, @DocumentGetSetDate, @DocumentNumber, " +
                                  "@ProeleusiKateuth, @Summary, @ToText, @FolderId, getdate(), @InsUsr, 1) ";

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
                    cmd.Parameters.AddWithValue("@InsUsr", UserInfo.DB_AppUser_Id);

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
                                  //"(Id, Sn, Year, ProcedureId, CompanyId, Date, DocumentGetSetDate, DocumentNumber, " +
                                  "(Id, Sn, Year, ProcedureId, CompanyId, Date, DocumentGetSetDate, " +
                                  "ProeleusiKateuth, Summary, ToText, FolderId, InsDt, InsUsr, RevNo) " +
                                  "VALUES " +
                                  //"(@Id, @Sn, year(getdate()), @ProcedureId, @CompanyId, getdate(), @DocumentGetSetDate, @DocumentNumber, " +
                                  "(@Id, @Sn, year(getdate()), @ProcedureId, @CompanyId, getdate(), @DocumentGetSetDate, " +
                                  "@ProeleusiKateuth, @Summary, @ToText, @FolderId, getdate(), @InsUsr, 1) ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsertSt, sqlConn);

                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Sn", Sn);
                    cmd.Parameters.AddWithValue("@ProcedureId", procedId); //get object from combobox
                    cmd.Parameters.AddWithValue("@CompanyId", companyId); //get object from combobox
                    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(myPanel.Controls["dtpOutSetDate"])); //datepicker - no time
                    //cmd.Parameters.AddWithValue("@DocumentNumber", myPanel.Controls["tbOutDocNum"].Text.Left(50));
                    cmd.Parameters.AddWithValue("@ProeleusiKateuth", myPanel.Controls["tbOutKateuth"].Text.Left(150));
                    cmd.Parameters.AddWithValue("@Summary", myPanel.Controls["tbOutSummary"].Text);
                    cmd.Parameters.AddWithValue("@ToText", myPanel.Controls["tbOutToText"].Text.Left(255));
                    cmd.Parameters.AddWithValue("@FolderId", ((Folders)((ComboboxItem)((ComboBox)myPanel.Controls["cbOutFolders"]).SelectedItem).Value).Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@InsUsr", UserInfo.DB_AppUser_Id);

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

        private bool Update_Protok_UpdatedFlag(int Sn, int Year, int CompanyId, int ProcedId, int ExcludeThisId) //UPDATE [dbo].[Protok] 
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string UpdSt = "UPDATE [dbo].[Protok] SET Updated = 1 WHERE Sn = @Sn AND Year = @Year AND CompanyId = @CompanyId AND ProcedureId = @ProcedId AND Id <> @Id";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@Sn", Sn);
                cmd.Parameters.AddWithValue("@Year", Year);
                cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                cmd.Parameters.AddWithValue("@ProcedId", ProcedId);
                cmd.Parameters.AddWithValue("@Id", ExcludeThisId);

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

            return ret;
        }

        public int getMaxRevNo(int Sn, int Year, int CompanyId, int ProcedId)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT max(RevNo) as MaxRevNo FROM [dbo].[Protok] WHERE Sn = @Sn AND Year = @Year AND CompanyId = @CompanyId AND ProcedureId = @ProcedId  ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);

            cmd.Parameters.AddWithValue("@Sn", Sn);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@CompanyId", CompanyId); 
            cmd.Parameters.AddWithValue("@ProcedId", ProcedId); 

            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["MaxRevNo"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        private bool InsertIntoTable_Protok_Revision(int Id, int Sn, int Year, int companyId, int procedId, Panel myPanel)
        {
            bool ret = false;

            int RevNo = getMaxRevNo(Sn, Year, companyId, procedId);
            if (RevNo < 1)//at least 1 row
            {
                return ret; //or false
            }
            else
            {
                RevNo++;
            }

            if (myPanel.Name == "panelInbox")
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                string InsertSt = "INSERT INTO [dbo].[Protok] " +
                                  "(Id, Sn, Year, ProcedureId, CompanyId, Date, DocumentDate, DocumentGetSetDate, DocumentNumber, " +
                                  "ProeleusiKateuth, Summary, ToText, FolderId, UpdDt, UpdUsr, InsDt, InsUsr, RevNo) " +
                                  "VALUES " +
                                  "(@Id, @Sn, @Year, @ProcedureId, @CompanyId, getdate(), @DocumentDate, @DocumentGetSetDate, @DocumentNumber, " +
                                  "@ProeleusiKateuth, @Summary, @ToText, @FolderId, getdate(), @UpdUsr, getdate(), @InsUsr, @RevNo) ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsertSt, sqlConn);

                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Sn", Sn);
                    cmd.Parameters.AddWithValue("@Year", Year);
                    cmd.Parameters.AddWithValue("@ProcedureId", procedId); //get object from combobox
                    cmd.Parameters.AddWithValue("@CompanyId", companyId); //get object from combobox
                    cmd.Parameters.AddWithValue("@DocumentDate", DatetimePickerToSQLDate(myPanel.Controls["dtpInDocDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(myPanel.Controls["dtpInGetDate"])); //datepicker - no time
                    cmd.Parameters.AddWithValue("@DocumentNumber", myPanel.Controls["tbInDocNum"].Text.Left(50));
                    cmd.Parameters.AddWithValue("@ProeleusiKateuth", myPanel.Controls["tbInProeleusi"].Text.Left(150));
                    cmd.Parameters.AddWithValue("@Summary", myPanel.Controls["tbInSummary"].Text);
                    cmd.Parameters.AddWithValue("@ToText", myPanel.Controls["tbInToText"].Text.Left(255));
                    cmd.Parameters.AddWithValue("@FolderId", ((Folders)((ComboboxItem)((ComboBox)myPanel.Controls["cbInFolders"]).SelectedItem).Value).Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@UpdUsr", UserInfo.DB_AppUser_Id);
                    cmd.Parameters.AddWithValue("@InsUsr", UserInfo.DB_AppUser_Id);
                    cmd.Parameters.AddWithValue("@RevNo", RevNo);

                    cmd.CommandType = CommandType.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        //ret = true;
                        //update all other (old) records
                        ret = Update_Protok_UpdatedFlag(Sn, Year, companyId, procedId, Id);                        
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
                                  //"(Id, Sn, Year, ProcedureId, CompanyId, Date, DocumentGetSetDate, DocumentNumber, " +
                                  "(Id, Sn, Year, ProcedureId, CompanyId, Date, DocumentGetSetDate, " +
                                  "ProeleusiKateuth, Summary, ToText, FolderId, UpdDt, UpdUsr, InsDt, InsUsr, RevNo) " +
                                  "VALUES " +
                                  //"(@Id, @Sn, year(getdate()), @ProcedureId, @CompanyId, getdate(), @DocumentGetSetDate, @DocumentNumber, " +
                                  "(@Id, @Sn, @Year, @ProcedureId, @CompanyId, getdate(), @DocumentGetSetDate, " +
                                  "@ProeleusiKateuth, @Summary, @ToText, @FolderId, getdate(), @UpdUsr, getdate(), @InsUsr, @RevNo) ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsertSt, sqlConn);

                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Sn", Sn);
                    cmd.Parameters.AddWithValue("@Year", Year);
                    cmd.Parameters.AddWithValue("@ProcedureId", procedId); //get object from combobox
                    cmd.Parameters.AddWithValue("@CompanyId", companyId); //get object from combobox
                    cmd.Parameters.AddWithValue("@DocumentGetSetDate", DatetimePickerToSQLDate(myPanel.Controls["dtpOutSetDate"])); //datepicker - no time
                    //cmd.Parameters.AddWithValue("@DocumentNumber", myPanel.Controls["tbOutDocNum"].Text.Left(50));
                    cmd.Parameters.AddWithValue("@ProeleusiKateuth", myPanel.Controls["tbOutKateuth"].Text.Left(150));
                    cmd.Parameters.AddWithValue("@Summary", myPanel.Controls["tbOutSummary"].Text);
                    cmd.Parameters.AddWithValue("@ToText", myPanel.Controls["tbOutToText"].Text.Left(255));
                    cmd.Parameters.AddWithValue("@FolderId", ((Folders)((ComboboxItem)((ComboBox)myPanel.Controls["cbOutFolders"]).SelectedItem).Value).Id); //get object from combobox
                    cmd.Parameters.AddWithValue("@UpdUsr", UserInfo.DB_AppUser_Id);
                    cmd.Parameters.AddWithValue("@InsUsr", UserInfo.DB_AppUser_Id);
                    cmd.Parameters.AddWithValue("@RevNo", RevNo);

                    cmd.CommandType = CommandType.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        //ret = true;
                        //update all other (old) records
                        ret = Update_Protok_UpdatedFlag(Sn, Year, companyId, procedId, Id);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }

        /*
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
        */

        public string createInMailSubject(string protokType, int protokSn, string getDate, string proeleusi, string summary)
        {
            string ret = "";
            ret = protokType.Left(3) + "." + protokSn.ToString() + "/" + getDate + " " + proeleusi.Left(30) + "-" + summary.Left(30);
            return ret;
        }

        public string createInMailBody(string protokType, string company, int protokSn, string getDate, string proeleusi, string summary)
        {
            string ret = "";
            ret = protokType + " " + company + "\r\n" + "Αριθμός Πρωτοκόλλου: " + protokSn.ToString() + "\r\n" + 
                "Ημερομηνία Λήψης: " + getDate + "\r\n" + "Προέλευση: " + proeleusi + "\r\n" + "Περίληψη: " + summary;
            return ret;
        }

        public string createOutMailSubject(int protokSn, string summary)
        {
            string ret = "";
            ret = "ΑΑΠ." + protokSn.ToString() + "/" + summary.Left(30);
            return ret;
        }

        public string createOutMailBody(int protokSn, string summary)
        {
            string ret = "";
            ret = "Αριθμός Πρωτοκόλλου: " + protokSn.ToString() + "\r\n" + "Περίληψη: " + summary;
            return ret;
        }
        public void btnInsert_Click(object sender, EventArgs e)
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

                //non mandatory field
                //if (IOBoxPanel.Controls["tbInDocNum"].Text.Trim() == "")
                //{
                //    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Αριθμός Εισερχομένου Εγγράφου'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

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

                //non mandatory field
                //if (IOBoxPanel.Controls["tbInToText"].Text.Trim() == "")
                //{
                //    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Παράδοση για ενέργεια / Παρατηρήσεις'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

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

                        MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς! \r\nΑριθμός Πρωτοκόλλου: [ " + ProtokSn.inserted.ToString() + " ]");
                        successfulInsertion = wasSuccessful;

                        if (chbSendMail.Checked)
                        {
                            myEmail = new Email();
                            myEmail.ProtokId = ProtokId;

                            //myEmail.Subject = aaa.Left(3) + "." + bbb + "/" + ccc + " " + ddd.Left(30) + "-" + eee.Left(30);
                            myEmail.Subject = createInMailSubject("ΕΙΣΕΡΧΟΜΕΝΑ",
                                                ProtokSn.inserted,
                                                DatetimePickerToReadableDate(IOBoxPanel.Controls["dtpInGetDate"]),
                                                IOBoxPanel.Controls["tbInProeleusi"].Text,
                                                IOBoxPanel.Controls["tbInSummary"].Text);

                            //myEmail.Body = aaa + "\r\n" + "Αριθμός Πρωτοκόλλου: " + bbb + "\r\n" + "Ημερομηνία Λήψης: " + ccc + "\r\n" + "Προέλευση: " + ddd + "\r\n" + "Περίληψη: " + eee;
                            myEmail.Body = createInMailBody("ΕΙΣΕΡΧΟΜΕΝΑ",
                                                ((ComboboxItem)cbCompany.SelectedItem).Text,
                                                ProtokSn.inserted,
                                                DatetimePickerToReadableDate(IOBoxPanel.Controls["dtpInGetDate"]),
                                                IOBoxPanel.Controls["tbInProeleusi"].Text,
                                                IOBoxPanel.Controls["tbInSummary"].Text);
                        }
                        else
                        {
                            myEmail = new Email();
                            myEmail.Body = createInMailBody("ΕΙΣΕΡΧΟΜΕΝΑ",
                                                ((ComboboxItem)cbCompany.SelectedItem).Text,
                                                ProtokSn.inserted,
                                                DatetimePickerToReadableDate(IOBoxPanel.Controls["dtpInGetDate"]),
                                                IOBoxPanel.Controls["tbInProeleusi"].Text,
                                                IOBoxPanel.Controls["tbInSummary"].Text);
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

                //if (IOBoxPanel.Controls["tbOutDocNum"].Text.Trim() == "")
                //{
                //    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Σχετικοί Αριθμοί'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
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

                //non mandatory field
                //if (IOBoxPanel.Controls["tbOutToText"].Text.Trim() == "")
                //{
                //    MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Παρατηρήσεις'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

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

                        if (chbSendMail.Checked)
                        {
                            myEmail = new Email();
                            myEmail.ProtokId = ProtokId;

                            myEmail.Subject = createOutMailSubject(ProtokSn.inserted, IOBoxPanel.Controls["tbOutSummary"].Text);
                            myEmail.Body = createOutMailBody(ProtokSn.inserted, IOBoxPanel.Controls["tbOutSummary"].Text);
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

        public void btnUpdate_Click(object sender, EventArgs e)
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

                int proced_Id = ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id;
                int company_Id = ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id;

                //UPDATE [dbo].[TableIds] 
                int ProtokId = getNextIdAndUpdateTable_TableIds("Protok");

                //UPDATE [dbo].[DocsIds] - id will remain the same!!!!!!!!!
                //UpdatedId ProtokSn = getNextSnAndUpdateTable_DocsIds(company_Id, proced_Id);

                int ProtokSn = Convert.ToInt32(IOBoxPanel.Controls["tbInProtokoloNum"].Text.Trim());
                int ProtokYear = Convert.ToInt32(IOBoxPanel.Controls["tbInYear"].Text.Trim());

                if (ProtokId > 0 && ProtokSn > 0)
                {
                    //INSERT INTO [dbo].[Protok] 
                    bool wasSuccessful = InsertIntoTable_Protok_Revision(ProtokId, ProtokSn, ProtokYear, company_Id, proced_Id, IOBoxPanel);

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

                        MessageBox.Show("Η εγγραφή με αριθμό Πρωτοκόλλου: [ " + ProtokSn.ToString() + " ] ενημερώθηκε επιτυχώς!");
                        successfulInsertion = wasSuccessful;

                        if (chbSendMail.Checked)
                        {
                            myEmail = new Email();
                            myEmail.ProtokId = ProtokId;

                            //myEmail.Subject = aaa.Left(3) + "." + bbb + "/" + ccc + " " + ddd.Left(30) + "-" + eee.Left(30);
                            myEmail.Subject = createInMailSubject("ΕΙΣΕΡΧΟΜΕΝΑ",
                                                ProtokSn,
                                                DatetimePickerToReadableDate(IOBoxPanel.Controls["dtpInGetDate"]),
                                                IOBoxPanel.Controls["tbInProeleusi"].Text,
                                                IOBoxPanel.Controls["tbInSummary"].Text);

                            //myEmail.Body = aaa + "\r\n" + "Αριθμός Πρωτοκόλλου: " + bbb + "\r\n" + "Ημερομηνία Λήψης: " + ccc + "\r\n" + "Προέλευση: " + ddd + "\r\n" + "Περίληψη: " + eee;
                            myEmail.Body = createInMailBody("ΕΙΣΕΡΧΟΜΕΝΑ",
                                                ((ComboboxItem)cbCompany.SelectedItem).Text,
                                                ProtokSn,
                                                DatetimePickerToReadableDate(IOBoxPanel.Controls["dtpInGetDate"]),
                                                IOBoxPanel.Controls["tbInProeleusi"].Text,
                                                IOBoxPanel.Controls["tbInSummary"].Text);
                        }
                        else
                        {
                            myEmail = new Email();
                            myEmail.Body = createInMailBody("ΕΙΣΕΡΧΟΜΕΝΑ",
                                                ((ComboboxItem)cbCompany.SelectedItem).Text,
                                                ProtokSn,
                                                DatetimePickerToReadableDate(IOBoxPanel.Controls["dtpInGetDate"]),
                                                IOBoxPanel.Controls["tbInProeleusi"].Text,
                                                IOBoxPanel.Controls["tbInSummary"].Text);
                        }


                        ShowClosingDialog = false;
                        Close();
                    }
                    else
                    {
                        //UPDATE [dbo].[DocsIds] - id will remain the same!!!!!!!!!
                        //bool resetSn = UpdateTable_DocIds(ProtokSn.deleted, company_Id, proced_Id); //number -= 1

                        //if (resetSn)
                        //{
                        MessageBox.Show("Σφάλμα κατά την καταχώρηση! Παρακαλώ προσπαθήστε ξανά.");
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Σφάλμα κατά την καταχώρηση! Δώθηκε ο αριθμός πρωτοκόλλου " + ProtokSn.inserted.ToString() + " χωρίς να ολοκληρωθεί η καταχώρηση!");
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("Σφάλμα κατά τη μεταβολή του Πρωτοκόλλου! Παρακαλώ προσπαθήστε ξανά.");
                }
                
            }
            else if (IOBoxPanel.Name == "panelOutbox")
            {
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

                int proced_Id = ((Proced)((ComboboxItem)cbProtokoloKind.SelectedItem).Value).Id;
                int company_Id = ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id;

                //UPDATE [dbo].[TableIds] 
                int ProtokId = getNextIdAndUpdateTable_TableIds("Protok");

                //UPDATE [dbo].[DocsIds] - id will remain the same!!!!!!!!!
                //UpdatedId ProtokSn = getNextSnAndUpdateTable_DocsIds(company_Id, proced_Id);

                int ProtokSn = Convert.ToInt32(IOBoxPanel.Controls["tbOutProtokoloNum"].Text.Trim());
                int ProtokYear = Convert.ToInt32(IOBoxPanel.Controls["tbOutYear"].Text.Trim());

                if (ProtokId > 0 && ProtokSn > 0)
                {
                    //INSERT INTO [dbo].[Protok] 
                    bool wasSuccessful = InsertIntoTable_Protok_Revision(ProtokId, ProtokSn, ProtokYear, company_Id, proced_Id, IOBoxPanel);

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

                        MessageBox.Show("Η εγγραφή με αριθμό Πρωτοκόλλου: [ " + ProtokSn.ToString() + " ] ενημερώθηκε επιτυχώς!");
                        successfulInsertion = wasSuccessful;

                        if (chbSendMail.Checked)
                        {
                            myEmail = new Email();
                            myEmail.ProtokId = ProtokId;

                            myEmail.Subject = createOutMailSubject(ProtokSn, IOBoxPanel.Controls["tbOutSummary"].Text);
                            myEmail.Body = createOutMailBody(ProtokSn, IOBoxPanel.Controls["tbOutSummary"].Text);
                        }

                        ShowClosingDialog = false;
                        Close();
                    }
                    else
                    {
                        //UPDATE [dbo].[DocsIds] - id will remain the same!!!!!!!!!
                        //bool resetSn = UpdateTable_DocIds(ProtokSn.deleted, company_Id, proced_Id); //number -= 1

                        //if (resetSn)
                        //{
                        MessageBox.Show("Σφάλμα κατά την καταχώρηση! Παρακαλώ προσπαθήστε ξανά.");
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Σφάλμα κατά την καταχώρηση! Δώθηκε ο αριθμός πρωτοκόλλου " + ProtokSn.inserted.ToString() + " χωρίς να ολοκληρωθεί η καταχώρηση!");
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("Σφάλμα κατά τη μεταβολή του Πρωτοκόλλου! Παρακαλώ προσπαθήστε ξανά.");
                }
                

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
            if (ShowClosingDialog && (this.Text == "Εισαγωγή" || this.Text == "Μεταβολή"))
            {
                DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να ακυρώσετε την καταχώρηση;", "Ακύρωση", MessageBoxButtons.YesNo);

                e.Cancel = (dialogResult == DialogResult.No);
            }
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
            //Font myfont = new Font(comboBox1.SelectedItem.ToString(), 11);

            //lblCompany.Font = myfont;
            //lblProtokoloKind.Font = myfont;
            //btnInsert.Font = myfont;
            //btnCancel.Font = myfont;
        //}

        private void btnShowRecipients_Click(object sender, EventArgs e)
        {
            MailRecipients mailRec = new MailRecipients(Protok_Id_For_Updates);
            mailRec.ShowDialog();

            //do these into constructor...
            /*
            MailRecipients mailRec = new MailRecipients();
            
            //string Recipients = "";
            string RecipientsTo = "";
            string RecipientsCc = "";
            string RecipientsBcc = "";

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT R.ToCcBcc, T.Name, R.MailAddress, R.ExchName " +
                "FROM [dbo].[ReceiverList] R left outer join [dbo].[ToCcBcc] T on T.Id = R.ToCcBcc WHERE R.ProtokId = " + Protok_Id_For_Updates;
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["ToCcBcc"].ToString()) == 1) //to
                    {
                        RecipientsTo += reader["MailAddress"].ToString() + ";";
                    }
                    else if (Convert.ToInt32(reader["ToCcBcc"].ToString()) == 2) //cc
                    {
                        RecipientsCc += reader["MailAddress"].ToString() + ";";
                    }
                    else if (Convert.ToInt32(reader["ToCcBcc"].ToString()) == 3) //bcc
                    {
                        RecipientsBcc += reader["MailAddress"].ToString() + ";";
                    }

                }
                
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            //Recipients = "To: " + RecipientsTo + "\r\n" +
            //    "CC: " + RecipientsCc + "\r\n" +
            //    "BCC: " + RecipientsBcc;
            //MessageBox.Show(Recipients, "Recipients");
            
            mailRec.txtRecipientsTo.Text = RecipientsTo;
            mailRec.txtRecipientsCc.Text = RecipientsCc;
            mailRec.txtRecipientsBcc.Text = RecipientsBcc;
            mailRec.ShowDialog();
            */
        }

        public static void IfUniqueSelectIt(ComboBox cbControl)
        {
            if (cbControl.Items.Count == 1)
            {
                cbControl.SelectedIndex = 0; //zero-base
            }
        }

        private void chbPrintClipping_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Text == "Εμφάνιση" && chbPrintClipping.Checked && cbProtokoloKind.Text == "Εισερχόμενα")
            {
                //print
                myEmail = new Email();
                myEmail.Body = createInMailBody("ΕΙΣΕΡΧΟΜΕΝΑ",
                                    ((ComboboxItem)cbCompany.SelectedItem).Text,
                                    Convert.ToInt32(IOBoxPanel.Controls["tbInProtokoloNum"].Text),
                                    DatetimePickerToReadableDate(IOBoxPanel.Controls["dtpInGetDate"]),
                                    IOBoxPanel.Controls["tbInProeleusi"].Text,
                                    IOBoxPanel.Controls["tbInSummary"].Text);

                if (chbSendMail.Checked)
                {
                    MailRecipientsList mrl = new MailRecipientsList();
                    List<Recipient> recList = mrl.FillRecList(Protok_Id_For_Updates);
                    myEmail.addRecipientsToBody(recList);
                }
                else
                {
                    myEmail.addRecipientsToBody();
                }
                                
                Printings clprint = new Printings();
                clprint.printProtocolClipping(myEmail.Body.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList<string>());

                chbPrintClipping.Checked = false;
            }
                        
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

    //public enum CRUD_Mode
    //{
    //    //None...
    //    SELECT = 1,
    //    INSERT = 2,
    //    UPDATE = 3,
    //    DELETE = 4
    //}
}
