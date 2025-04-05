using Restaurant.Model;
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

namespace Restaurant.View
{
    public partial class StaffView: SampleView
    {
        public StaffView()
        {
            InitializeComponent();
        }

        private void StaffView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            string qry = " Select * From staff where sName like '%" + txtSearch.Text + "%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName); 
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvRole);
            MainClass.LoadData(qry, guna2DataGridView2, lb);
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            //CategoryAdd form = new CategoryAdd();
            //form.ShowDialog();
            MainClass.BlurBackGround(new Model.StaffAdd ());

            GetData();

        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();

        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView2.CurrentCell.OwningColumn.Name == "dgvedit")
            {

                StaffAdd frm = new StaffAdd();
                frm.id = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvid"].Value);
                frm.txtNameadd.Text = Convert.ToString(guna2DataGridView2.CurrentRow.Cells["dgvName"].Value);
                frm.txtPhone.Text = Convert.ToString(guna2DataGridView2.CurrentRow.Cells["dgvPhone"].Value);
                frm.cbRole.Text = Convert.ToString(guna2DataGridView2.CurrentRow.Cells["dgvRole"].Value);

                MainClass.BlurBackGround(frm);
                GetData();

            }
            if (guna2DataGridView2.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                //need to confirm before delete
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete from staff where sID= " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageBox.Show("Delete successfully");
                    GetData();
                }

            }
        }
    }
}
