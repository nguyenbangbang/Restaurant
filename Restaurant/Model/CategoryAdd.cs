using Guna.UI2.WinForms;
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
    public partial class CategoryAdd : SampleAdd
    {

        public CategoryAdd()
        {
            InitializeComponent();

        }

        public CategoryAdd(SampleAdd parent)
        {
            InitializeComponent();
        }
        public int id = 0;


        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id==0)// insert
            {
                qry = "Insert into category Values(@Name)";
            }
            else//update
            {
                qry = "Update category set catName=@Name where catID =@id";

            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtNameadd.Text);

            if (MainClass.SQL(qry,ht)>0)
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
