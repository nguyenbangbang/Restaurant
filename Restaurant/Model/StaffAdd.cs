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
    public partial class StaffAdd : SampleAdd
    {
        public StaffAdd()
        {
            InitializeComponent();
        }
    

        public int id = 0;


        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)// insert
            {
                qry = "Insert into staff Values(@Name, @phone, @role)";
            }
            else//update
            {
                qry = "Update staff set sName=@Name,sPhone = @phone,sRole= @role where sID =@id";

            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtNameadd.Text);
            ht.Add("@phone", txtPhone.Text);
            ht.Add("@role", cbRole.Text);

            if (MainClass.SQL(qry, ht) > 0)
            {
                //
                MessageBox.Show("Save successfully...");
                id = 0;
                txtNameadd.Text = "";
                txtPhone.Text = "";
                cbRole.SelectedIndex = -1;
                txtNameadd.Focus();
            }
        }
    }
}
