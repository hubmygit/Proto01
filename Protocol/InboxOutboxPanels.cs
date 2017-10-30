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
using System.IO;

namespace Protocol
{
    public partial class InboxOutboxPanels : Form
    {
        public InboxOutboxPanels()
        {
            InitializeComponent();

            //lvAttachedFiles.AllowDrop = true;
            //lvAttachedFiles.DragDrop += new DragEventHandler(lvAttachedFiles_DragDrop);
            //lvAttachedFiles.DragEnter += new DragEventHandler(lvAttachedFiles_DragEnter);   


            
            //lvAttachedFileCms.Items.Clear();
            //lvAttachedFileCms.Name = "lvAttachedFileCms";
            //lvAttachedFileCms.Items.Add("Open File");
            //lvAttachedFileCms.Items.Add("Remove File");
            //lvAttachedFileCms.Items.Add("Remove All Files");
        }

        //ContextMenuStrip lvAttachedFileCms = new ContextMenuStrip();

        //int lvSelIndex = 0;

        private void btnNewFolders_Click(object sender, EventArgs e)
        {
            ComboBox cbFolders = new ComboBox();
            if (((Button)sender).Parent.Name == "panelInbox")
            {
                cbFolders = cbInFolders;
            }
            else if (((Button)sender).Parent.Name == "panelOutbox")
            {
                cbFolders = cbOutFolders;
            }

            Company objCompany = ((Company)((ComboboxItem)((ComboBox)((Button)sender).TopLevelControl.Controls["cbCompany"]).SelectedItem).Value);
            Proced objProced = ((Proced)((ComboboxItem)((ComboBox)((Button)sender).TopLevelControl.Controls["cbProtokoloKind"]).SelectedItem).Value);

            FoldersInsertForm FoldersInsForm = new FoldersInsertForm(objCompany, objProced);
            FoldersInsForm.ShowDialog();

            if (FoldersInsForm.NewRecord)
            {
                string InsertedFolderName = FoldersInsForm.txtName.Text.Trim();
                cbFolders.Items.Clear();
                cbFolders.Items.AddRange(ProtokoloInsertForm.GetObjFolders(objCompany.Id, objProced.Id));
                if (InsertedFolderName.Trim() != "")
                {
                    cbFolders.SelectedIndex = cbFolders.FindStringExact(InsertedFolderName);
                }
            }
        }

        ImageList imList = new ImageList();
        void lvAttachedFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        void lvAttachedFiles_DragDrop(object sender, DragEventArgs e)
        {
            /*
            //lvAttachedFiles.Items.Add(e.Data.ToString());

            //ImageList imList = new ImageList();
            imList.ImageSize = new Size(20, 20);
            ((ListView)sender).SmallImageList = imList;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            System.IO.FileInfo newFile = new System.IO.FileInfo(files[0]);

            if (newFile.Attributes == System.IO.FileAttributes.Directory)
            {
                MessageBox.Show("Please drop only archives not directories!");

                return;
            }

            Icon iconForFile = SystemIcons.WinLogo;
            //ListViewItem lvItem = new ListViewItem(newFile.Name, 1);
            ListViewItem lvItem = new ListViewItem(new string[] { newFile.Name, newFile.FullName }, 1);
            iconForFile = Icon.ExtractAssociatedIcon(newFile.FullName);
            // Check to see if the image collection contains an image
            // for this extension, using the extension as a key.
            //if (!((lvAttachedFiles.SmallImageList)).Images.ContainsKey(newFile.Extension))
            if (!((((ListView)sender).SmallImageList)).Images.ContainsKey(newFile.Extension))
            {
                // If not, add the image to the image list.
                iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(newFile.FullName);
                //((lvAttachedFiles.SmallImageList)).Images.Add(newFile.Extension, iconForFile);
                ((((ListView)sender).SmallImageList)).Images.Add(newFile.Extension, iconForFile);
            }
            lvItem.ImageKey = newFile.Extension;

            //lvAttachedFiles.Items.Add(lvItem);
            ((ListView)sender).Items.Add(lvItem);
            */


            //allow to drag n drop file from outlook
            /*
            try
            {
                if (e.Data.GetDataPresent("FileGroupDescriptor"))
                {
                    //
                    // the first step here is to get the filename
                    // of the attachment and
                    // build a full-path name so we can store it
                    // in the temporary folder
                    //

                    // set up to obtain the FileGroupDescriptor
                    // and extract the file name
                    Stream theStream = (Stream)e.Data.GetData("FileGroupDescriptor");
                    byte[] fileGroupDescriptor = new byte[512];
                    theStream.Read(fileGroupDescriptor, 0, 512);
                    // used to build the filename from the FileGroupDescriptor block
                    StringBuilder fileName = new StringBuilder("");
                    // this trick gets the filename of the passed attached file
                    for (int i = 76; fileGroupDescriptor[i] != 0; i++)
                    { fileName.Append(Convert.ToChar(fileGroupDescriptor[i])); }
                    theStream.Close();
                    string path = Path.GetTempPath();
                    // put the zip file into the temp directory
                    string theFile = path + fileName.ToString();
                    // create the full-path name

                    //
                    // Second step:  we have the file name.
                    // Now we need to get the actual raw
                    // data for the attached file and copy it to disk so we work on it.
                    //

                    // get the actual raw file into memory
                    MemoryStream ms = (MemoryStream)e.Data.GetData(
                        "FileContents", true);
                    // allocate enough bytes to hold the raw data
                    byte[] fileBytes = new byte[ms.Length];
                    // set starting position at first byte and read in the raw data
                    ms.Position = 0;
                    ms.Read(fileBytes, 0, (int)ms.Length);
                    // create a file and save the raw zip file to it
                    FileStream fs = new FileStream(theFile, FileMode.Create);
                    fs.Write(fileBytes, 0, (int)fileBytes.Length);

                    fs.Close();  // close the file

                    FileInfo tempFile = new FileInfo(theFile);

                    // always good to make sure we actually created the file
                    if (tempFile.Exists == true)
                    {
                        // for now, just delete what we created
                        tempFile.Delete();
                    }
                    else
                    { MessageBox.Show("File was not created!"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in DragDrop function: " + ex.Message);
            }
            */

            addFilesIntoListView((ListView)sender, (string[])e.Data.GetData(DataFormats.FileDrop));
        }

        /*
        //original function with images into ListView
        void addFilesIntoListView(ListView myListView, string[] fileNames)
        {
            //lvAttachedFiles.Items.Add(e.Data.ToString());

            //ImageList imList = new ImageList();
            imList.ImageSize = new Size(20, 20);
            myListView.SmallImageList = imList;

            foreach (string thisFile in fileNames)
            {
                System.IO.FileInfo newFile = new System.IO.FileInfo(thisFile);

                if (newFile.Attributes == System.IO.FileAttributes.Directory)
                {
                    MessageBox.Show("Please drop only archives not directories!");

                    return;
                }

                Icon iconForFile = SystemIcons.WinLogo;
                //ListViewItem lvItem = new ListViewItem(newFile.Name, 1);
                ListViewItem lvItem = new ListViewItem(new string[] { newFile.Name, newFile.FullName }, 1);
                iconForFile = Icon.ExtractAssociatedIcon(newFile.FullName);
                // Check to see if the image collection contains an image
                // for this extension, using the extension as a key.
                //if (!((lvAttachedFiles.SmallImageList)).Images.ContainsKey(newFile.Extension))
                if (!((myListView.SmallImageList)).Images.ContainsKey(newFile.Extension))
                {
                    // If not, add the image to the image list.
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(newFile.FullName);
                    //((lvAttachedFiles.SmallImageList)).Images.Add(newFile.Extension, iconForFile);
                    ((myListView.SmallImageList)).Images.Add(newFile.Extension, iconForFile);
                }
                lvItem.ImageKey = newFile.Extension;

                //lvAttachedFiles.Items.Add(lvItem);
                myListView.Items.Add(lvItem);
            }
        }
        */

        //new function without images
        void addFilesIntoListView(ListView myListView, string[] fileNames)
        {
            bool exists = false;

            if (fileNames is null)
            {
                MessageBox.Show("Δε βρέθηκε η τοποθεσία του αρχείου. \r\nΠαρακαλώ επιλέξτε αρχεία που είναι αποθηκευμένα τοπικά στο δίσκο σας!");
                return;
            }

            foreach (string thisFile in fileNames)
            {
                exists = false;
                System.IO.FileInfo newFile = new System.IO.FileInfo(thisFile);

                //if (newFile.Attributes == System.IO.FileAttributes.Directory)
                //{
                //    MessageBox.Show("Παρακαλώ επιλέξτε μόνο αρχεία!");//Please drop only archives not directories!");
                //    continue;
                //}
                
                //only pdf allowed!
                if (newFile.Extension.ToUpper() != ".PDF")
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε μόνο αρχεία τύπου '.pdf'!");//Please drop only archives not directories!");
                    continue;
                }

                foreach (ListViewItem lvi in myListView.Items)
                {
                    if (lvi.SubItems[0].Text.ToUpper() == newFile.Name.ToUpper())
                    {
                        exists = true;
                        break; 
                    }
                }

                if (exists)
                {
                    MessageBox.Show("Υπάρχει ήδη αρχείο στη λίστα με όνομα '" + newFile.Name + "'");//File already exists!");
                    continue;
                }

                ListViewItem lvItem = new ListViewItem(new string[] { newFile.Name, newFile.FullName });
                myListView.Items.Add(lvItem);
            }
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            //Open File Dialog...
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Add Files";
            ofd.Multiselect = true; //array of files
            ofd.ShowDialog();

            ListView lvToAddFiles = new ListView();
            if (((Control)sender).Parent.Name.ToUpper() == "PANELINBOX")
            {
                lvToAddFiles = ((ListView)((Control)sender).Parent.Controls["lvInAttachedFiles"]);
            }
            else if (((Control)sender).Parent.Name.ToUpper() == "PANELOUTBOX")
            {
                lvToAddFiles = ((ListView)((Control)sender).Parent.Controls["lvOutAttachedFiles"]);
            }

            //Add Files into listView...
            addFilesIntoListView(lvToAddFiles, ofd.FileNames);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            //get the right listview
            Control ctrl = ((Control)sender).Parent;
            //Control ctrl2 = ((Control)sender)
            //check if selected

            ListView lv = new ListView();

            if (ctrl.Name == "panelOutbox")
            {
                lv = lvOutAttachedFiles;
            }
            else if (ctrl.Name == "panelInbox")
            {
                lv = lvInAttachedFiles;
            }

            if (lv.SelectedItems.Count > 0)
            {
                string lvPath = "";

                if (ctrl.Parent.Text == "Μεταβολή" || ctrl.Parent.Text == "Εμφάνιση") //update mode
                {
                    string ext = "";
                    string tempPath = Path.GetTempPath(); //C:\Users\hkylidis\AppData\Local\Temp\
                    //string tempFile = Path.Combine(Application.StartupPath + "\\Temp\\", Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
                    //string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
                    string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(lv.SelectedItems[0].SubItems[0].Text) + "~" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
                    try
                    {
                        //if (!Directory.Exists(Application.StartupPath + "\\Temp\\"))
                        if (!Directory.Exists(tempPath))
                        {
                            //Directory.CreateDirectory(Application.StartupPath + "\\Temp\\");
                            MessageBox.Show("Σφάλμα. Παρακαλώ ελέγξτε τα δικαιώματά σας στο " + tempPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                        return;
                    }

                    SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                    string SelectSt = "SELECT [FileCont] FROM [dbo].[ProtokPdf] WHERE ProtokId = @ProtokId and PdfText = @PdfText";
                    SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
                    try
                    {
                        sqlConn.Open();
                                                
                        ProtokoloInsertForm pif = (ProtokoloInsertForm)ctrl.FindForm();

                        cmd.Parameters.AddWithValue("@ProtokId", pif.Protok_Id_For_Updates);
                        cmd.Parameters.AddWithValue("@PdfText", lv.SelectedItems[0].SubItems[0].Text);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string fname = lv.SelectedItems[0].SubItems[0].Text;
                            ext = fname.Substring(fname.LastIndexOf("."));
                            lvPath = tempFile + ext;
                            //reader["FileCont"].ToString()
                            File.WriteAllBytes(tempFile + ext, (byte[])reader["FileCont"]);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                        return;
                    }
                }
                else //insert mode
                {
                    //get text
                    lvPath = lv.SelectedItems[0].SubItems[1].Text;
                }

                System.Diagnostics.Process.Start(lvPath);
            }



        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            //get the right listview
            Control ctrl = ((Control)sender).Parent;
            //Control ctrl2 = ((Control)sender)
            //check if selected

            ListView lv = new ListView();

            if (ctrl.Name == "panelOutbox")
            {
                lv = lvOutAttachedFiles;
            }
            else if (ctrl.Name == "panelInbox")
            {
                lv = lvInAttachedFiles;
            }

            if (lv.SelectedItems.Count > 0)
            {
                //get text
                //string lvIndex = lv.SelectedItems[0].Index;

                lv.SelectedItems[0].Remove();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            //get the right listview
            Control ctrl = ((Control)sender).Parent;
            //Control ctrl2 = ((Control)sender)
            //check if selected

            ListView lv = new ListView();

            if (ctrl.Name == "panelOutbox")
            {
                lv = lvOutAttachedFiles;
            }
            else if (ctrl.Name == "panelInbox")
            {
                lv = lvInAttachedFiles;
            }

            lv.Items.Clear();
        }


        /*
        private void lvAttachedFileCms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //MessageBox.Show("Clicked Item: " + e.ClickedItem.Text);
            if (e.ClickedItem.Text.ToUpper() == "OPEN FILE")
            {
                var cms = ((ContextMenuStrip)sender);
                Control ctrl = cms.SourceControl;
                string lvPath = ((ListView)ctrl).SelectedItems[0].SubItems[1].Text;

                //System.Diagnostics.Process.Start(@"file path");
                System.Diagnostics.Process.Start(lvPath);
                //lvAttachedFiles
            }
            else if (e.ClickedItem.Text.ToUpper() == "REMOVE FILE")
            {
                
                var cms = ((ContextMenuStrip)sender);
                Control ctrl = cms.SourceControl;

                
                ////Point mousePos = ((ListView)ctrl).PointToClient(Control.MousePosition);
                ////ListViewHitTestInfo hitTest = ((ListView)ctrl).HitTest(mousePos);
                ////int lvIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);

                //int lvIndex2 = -1;
                //try
                //{
                //    lvIndex2 = ((ListView)ctrl).FocusedItem.Index;
                //}
                //catch (Exception ex)
                //{
                //    string aa = ex.Message;
                //}


                //int lvIndex = -1;
                //try
                //{
                //    lvIndex = ((ListView)ctrl).SelectedItems[0].Index;
                //}
                //catch (Exception ex)
                //{
                //    string aa = ex.Message;
                //}

                //if (lvIndex == -1)
                //{
                //    lvIndex = lvIndex2;
                //}
                //else
                //{
                //    int zzz = 0;
                //}

                //((ListView)ctrl).Items.RemoveAt(lvIndex);

                //((ListView)ctrl).SelectedItems.Clear();
                


                ((ListView)ctrl).Items.RemoveAt(lvSelIndex);

            }
            else if (e.ClickedItem.Text.ToUpper() == "REMOVE ALL FILES")
            {
                var cms = ((ContextMenuStrip)sender);
                Control ctrl = cms.SourceControl;
                ((ListView)ctrl).Items.Clear();
            }

        }
        */

        /*
        private void lvAttachedFiles_MouseClick(object sender, MouseEventArgs e)
        {




            ((ListView)sender).ContextMenuStrip = lvAttachedFileCms;

         //   lvAttachedFileCms.TopLevel = false;
         //   ((ListView)sender).Controls.Add(lvAttachedFileCms);
         //lvAttachedFileCms.Parent = ((ListView)sender);



            lvAttachedFileCms.ItemClicked += new ToolStripItemClickedEventHandler(lvAttachedFileCms_ItemClicked);

            if (e.Button == MouseButtons.Right)
            {
                if (((ListView)sender).FocusedItem.Bounds.Contains(e.Location) == true)
                {

                    Point mousePos = ((ListView)sender).PointToClient(Control.MousePosition);
                    ListViewHitTestInfo hitTest = ((ListView)sender).HitTest(mousePos);
                    lvSelIndex = hitTest.Item.Index;
                    //int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);

                    lvAttachedFileCms.Show(Cursor.Position);

                    //((ContextMenuStrip)((ListView)sender).Controls["lvAttachedFileCms"]).Show(Cursor.Position);

                }
            }
            
        }
        */

    }
}
