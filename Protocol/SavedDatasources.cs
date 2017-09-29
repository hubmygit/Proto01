using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Protocol
{
        public partial class SavedDatasources
        {
            public String DBField;
            public Control FormField;
            public Binding BindingProc;

            public SavedDatasources(String DBField, Control FormField, Binding BindingProc)
            {
                this.DBField = DBField;
                this.FormField = FormField;
                this.BindingProc = BindingProc;
            }
        }
    
}
