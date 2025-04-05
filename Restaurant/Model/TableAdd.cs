using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Model
{
    public partial class TableAdd: SampleAdd
    {
        public TableAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)// insert
            {
                qry = "Insert into tables Values(@Name)";
            }
            else//update
            {
                qry = "Update tables set tName=@Name where tID =@id";

            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtNameadd.Text);

            if (MainClass.SQL(qry, ht) > 0)
            {
                //
                MessageBox.Show("Save successfully...");
                id = 0;
                txtNameadd.Text = "";
                txtNameadd.Focus();
            }
        }
    }
}
