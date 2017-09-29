using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

namespace Protocol
{
    public partial class frmFilter : Form
    {
        int CurTop;
        public string KSleo;
        public frmFilter()
        {
            InitializeComponent();
            CurTop = 0;
        }


        public void PopulateForm(DataGridView Dg)
        {
            foreach (DataGridViewColumn xy in Dg.Columns)
            //                MessageBox.Show(xy.ToString() + ' ' + xy.DataType.ToString());
            {
                if (xy is DataGridViewComboBoxColumn)
                {
                    CreateLCB0(xy.DataPropertyName.ToString(), xy.DataPropertyName.ToString(), 100, xy.DataPropertyName.ToString(), (DataGridViewComboBoxColumn)xy, xy);
                    continue;
                }
                if (xy.ValueType.Name.ToString() == "DateTime") {
                        CreateDateEdit(this, xy.DataPropertyName.ToString(), 10, 100, xy.Name.ToString(), xy.Name.ToString(), xy);
                        continue;
                    }

                if (xy.ValueType.Name.ToString() == "Int32") {
                            CreateNumEdit(this, xy.DataPropertyName.ToString(), 10, 100, xy.Name.ToString(), xy.Name.ToString(), xy);
                            continue;
                        }
                CreateEdit(this, xy.DataPropertyName.ToString(), 10, 100, xy.Name.ToString(), xy.Name.ToString(),xy);
            }
            }

        public void PopulateForm(BindingSource Dg)
        {
            //MessageBox.Show(Dg.DataSource.ToString());
            /*            foreach (DataGridViewColumn xy in Dg.DataSource. ToString())
                        //                MessageBox.Show(xy.ToString() + ' ' + xy.DataType.ToString());
                        {
                            if (xy is DataGridViewComboBoxColumn)
                                CreateLCB0(xy.DataPropertyName.ToString(), xy.DataPropertyName.ToString(), 100, xy.DataPropertyName.ToString(), (DataGridViewComboBoxColumn)xy);
                            if (xy.ValueType.Name.ToString() == "DateTime")
                                CreateDateEdit(this, xy.DataPropertyName.ToString(), 10, 100, xy.Name.ToString(), xy.Name.ToString());

                            CreateEdit(this, xy.DataPropertyName.ToString(), 10, 100, xy.Name.ToString(), xy.Name.ToString());
                        }*/
        }



        public void CreateEdit(object Owner, String Name, int LName, int Width, String LField, String NNField,DataGridViewColumn xy)
        {
            TextBox LEdit, LEdit1;
            Label LLabel, LLabel1;
            Button LBut;



            CurTop = CurTop + 20;
            LEdit = new TextBox();
            LEdit.Name = "EdtF" + Name;
            //  LEdit.Hint   = NNField;
            //  LEdit.Parent = Owner;
            LEdit.Top = CurTop;
            LEdit.Left = 150;
            LEdit.Tag = 1;
            Width = xy.Width;
            if (Width > 200)
                LEdit.Width = 190;
            else
                LEdit.Width = Width;

            LEdit.Visible = true;
            LEdit.Text = "";
            this.toolTip1.SetToolTip(LEdit, Name);
            //LEdit.OnExit  = GeneralEditExit;

            //  if (LField = TDateTimeField)
            //    LEdit.OnDblClick := EditDateEnter;
            this.tabPage1.Controls.Add(LEdit);

            LEdit1 = new TextBox();
            LEdit1.Name = "EdtT" + Name;
            //  LEdit1.Hint   = NNField;
            //  LEdit1.Parent = Owner;
            this.toolTip1.SetToolTip(LEdit1, Name);
            LEdit1.Top = CurTop;
            LEdit1.Left = 370;
            LEdit1.Tag = 2;
            Width = xy.Width;
            if (Width > 200)
                LEdit1.Width = 190;
            else
                LEdit1.Width = Width;

            LEdit1.Visible = true;
            LEdit1.Text = " ";
            //  LEdit1.OnExit  = GeneralEditExit;

            //  if LField = TDateTimeField then
            //    LEdit1.OnDblClick := EditDateEnter;
            this.tabPage1.Controls.Add(LEdit1);

            LLabel = new Label();
            LLabel.Name = 'L' + Name;
            //  LLabel.Parent  = Owner;
            LLabel.Text = Name;
            LLabel.Text = xy.HeaderText;
            LLabel.Top = CurTop;
            LLabel.Left = 10;
            LLabel.Width = 130;
            LLabel.Height = CurTop + 120;
            LLabel.AutoSize = true;
            //  LLabel.Location = new System.Drawing.Point(50, 124);
            //  LLabel.Size = new System.Drawing.Size(35, 13);
            this.tabPage1.Controls.Add(LLabel);

            LBut = new Button();
            LBut.Name = 'B' + Name;
            LBut.Name = Name;
            LBut.AccessibleDescription = NNField;
            //  LBut.Parent  = Owner;

            LBut.Top = CurTop;
            LBut.Left = 350;
            LBut.Width = 20;
            LBut.Text = "->";
            LBut.Tag = 10;
            this.tabPage1.Controls.Add(LBut);
            //  LBut.OnClick := ButtonCopyClick;

        }

        public void CreateNumEdit(object Owner, String Name, int LName, int Width, String LField, String NNField,DataGridViewColumn xy)
        {
            MaskedTextBox LEdit, LEdit1;
            Label LLabel, LLabel1;
            Button LBut;

            CurTop = CurTop + 20;
            LEdit = new MaskedTextBox();
            LEdit.Name = "EdtF" + Name;
            LEdit.Top = CurTop;
            LEdit.Left = 150;
            LEdit.Tag = 1;
            if (Width > 200)
                LEdit.Width = 190;
            else
                LEdit.Width = Width;
            LEdit.Visible = true;
            LEdit.Text = "";
            LEdit.Mask = "00000";
            this.toolTip1.SetToolTip(LEdit, Name);
            this.tabPage1.Controls.Add(LEdit);

            LEdit1 = new MaskedTextBox();
            LEdit1.Name = "EdtT" + Name;
            //  LEdit1.Hint   = NNField;
            //  LEdit1.Parent = Owner;
            this.toolTip1.SetToolTip(LEdit1, Name);
            LEdit1.Top = CurTop;
            LEdit1.Left = 370;
            LEdit1.Tag = 2;
            if (Width > 200)
                LEdit1.Width = 190;
            else
                LEdit1.Width = Width;
            LEdit1.Visible = true;
            LEdit1.Text = " ";
            LEdit1.Mask = "00000";
            this.tabPage1.Controls.Add(LEdit1);

            LLabel = new Label();
            LLabel.Name = 'L' + Name;
            LLabel.Text = Name;
            LLabel.Text = xy.HeaderText;
            LLabel.Top = CurTop;
            LLabel.Left = 10;
            LLabel.Width = 130;
            LLabel.Height = CurTop + 120;
            LLabel.AutoSize = true;
            this.tabPage1.Controls.Add(LLabel);

            LBut = new Button();
            LBut.Name = 'B' + Name;
            LBut.Name = Name;
            LBut.AccessibleDescription = NNField;
            LBut.Top = CurTop;
            LBut.Left = 350;
            LBut.Width = 20;
            LBut.Text = "->";
            LBut.Tag = 10;
            this.tabPage1.Controls.Add(LBut);
        }




        public void CreateLCB0(String Name, String LName, int Width, //ValueType LField,
               String NNField, DataGridViewComboBoxColumn Field, DataGridViewColumn xy)
        {


            CheckedListBox LChlb;
            TabPage LTab;
            String LeoName, FldName;
            int x;
            String LEditListField, LEditKeyField, LEditName, LEdit1Name;

            /*  if ((GHonorRequired=True) And(Field.Required= False)) then
                exit;

                LeoName := TStringField(Field).LookupDataSet.Name;
              LeoName := 'ds' + LeoName;
              for x   := 0 to PDM.ComponentCount - 1 do
                begin
                  if PDM.Components[x].Name = LeoName then
                    begin
                      LEditListSource := TDataSource(PDM.Components[x]);
                end
            end;
            */
            LEditListField = Field.DisplayMember;
            LEditKeyField = Field.ValueMember;

            LTab = new TabPage();
            LTab.Name = "Tab" + Name;
            LTab.Text = LName;
            LTab.Visible = true;
            LTab.AutoScroll = true;

            LChlb = new CheckedListBox();
            //  LChlb.Align      := alClient;
            LChlb.Name = "Chib" + Name;
            //  LChlb.Parent     := LTab;
            //  LChlb.DataBindings.BindableComponent. = Field.DataSource;
            //  LChlb.Hint       = Field.KeyFields;
            LChlb.Left = 1;
            LChlb.Width = 1;
            LChlb.Dock = System.Windows.Forms.DockStyle.Fill;

            ((ListBox)LChlb).DataSource = Field.DataSource;
            ((ListBox)LChlb).DisplayMember = Field.DisplayMember;
            ((ListBox)LChlb).ValueMember = Field.ValueMember;

            LTab.Controls.Add(LChlb);
            this.tabControl1.Controls.Add(LTab);


            //  LChlb.PopupMenu  := PopChLstBox;


            //  FillCheckListBoxName(LChlb, LEditListSource.DataSet, LEditListField, LEditKeyField);

            //    LChlb.Sorted = true;


        }

        public void CreateDateEdit(object Owner, String Name, int LName, int Width, String LField, String NNField,DataGridViewColumn xy)
        {
            DateTimePicker LEdit, LEdit1;
            Label LLabel, LLabel1;
            Button LBut;

            CurTop = CurTop + 20;
            LEdit = new DateTimePicker();
            LEdit.Name = "EdtF" + Name;
            LEdit.Top = CurTop;
            LEdit.Left = 150;
            LEdit.Tag = 1;
            if (Width > 200)
                LEdit.Width = 190;
            else
                LEdit.Width = Width;
            LEdit.Visible = true;
            LEdit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toolTip1.SetToolTip(LEdit, Name);
            this.tabPage1.Controls.Add(LEdit);

            LEdit1 = new DateTimePicker();
            LEdit1.Name = "EdtT" + Name;
            this.toolTip1.SetToolTip(LEdit1, Name);
            LEdit1.Top = CurTop;
            LEdit1.Left = 370;
            LEdit1.Tag = 2;
            if (Width > 200)
                LEdit1.Width = 190;
            else
                LEdit1.Width = Width;
            LEdit1.Visible = true;
            LEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tabPage1.Controls.Add(LEdit1);

            LLabel = new Label();
            LLabel.Name = 'L' + Name;
            LLabel.Text = Name;
            LLabel.Text = xy.HeaderText;
            LLabel.Top = CurTop;
            LLabel.Left = 10;
            LLabel.Width = 130;
            LLabel.Height = CurTop + 120;
            LLabel.AutoSize = true;
            LLabel.Parent = this.tabPage1;
            this.tabPage1.Controls.Add(LLabel);

            LBut = new Button();
            LBut.Name = 'B' + Name;
            LBut.Name = Name;
            LBut.AccessibleDescription = NNField;
            LBut.Top = CurTop;
            LBut.Left = 350;
            LBut.Width = 20;
            LBut.Text = "->";
            LBut.Tag = 10;
            LBut.Parent = this.tabPage1;
            this.tabPage1.Controls.Add(LBut);
        }

        public List<Control> GetAllControls(Control searchWithin,List<Control> returnList)
        {

            foreach (Control ctrlt in searchWithin.Controls)
            {
                if (ctrlt.HasChildren)
                    foreach (Control ctrl in ctrlt.Controls)
                        if (ctrl.HasChildren)
                            GetAllControls(ctrl, returnList);
                        else
                            returnList.Add(ctrl);
                else //if searchWithin.HasChildren = False Then
                    foreach (Control ctrl in ctrlt.Controls)
                        returnList.AddRange(GetAllControls(ctrl, returnList));
            }
            return returnList;
    }
        


        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            int ii;
            int Val1;
            int Val2;
            object Leo;

            KSleo = "";
            ii    = 0;

            List<Control> FormControls = new List<Control>();

            FormControls = GetAllControls(this, FormControls);

            foreach (Control x in FormControls)
            {
                if (x is TextBox)
                    if (((TextBox)x).Text.Trim() != "")
                    {
                        if (ii > 0)
                            KSleo = KSleo + " AND ";
                        KSleo = KSleo + toolTip1.GetToolTip(x);
                        if (x.Tag.ToString() == "1")
                            KSleo = KSleo + " >= " + "'" + (((TextBox)x).Text.Trim()) + "'";
                        else
                            KSleo = KSleo + " <= " + "'" + (((TextBox)x).Text.Trim()) + "'";
                        ii++;
                    }
                if (x is MaskedTextBox)
                    if (((MaskedTextBox)x).Text.Trim() != "")
                    {
                        if (ii > 0)
                            KSleo = KSleo + " AND ";
                        KSleo = KSleo + toolTip1.GetToolTip(x);
                        if (x.Tag.ToString() == "1")
                            KSleo = KSleo + " >= " +  Int32.Parse(((MaskedTextBox)x).Text.Trim());
                        else
                            KSleo = KSleo + " <= " + Int32.Parse(((MaskedTextBox)x).Text.Trim());
                        ii++;
                    }




            }
            this.Close();
        }


    }
}


