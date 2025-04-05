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
    public partial class ProductView: SampleView
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private void ProductView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            string qry = " select pID, pName,pPrice, CategoryID, c.catName from products p inner join category c on c.catID= p.CategoryID where pName like '%" + txtSearch.Text + "%'";

            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPrice);
            lb.Items.Add(dgvcatID);
            lb.Items.Add(dgvcat);
            //lb.Items.Add(dgv)
            MainClass.LoadData(qry, guna2DataGridView2, lb);
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            //CategoryAdd form = new CategoryAdd();
            //form.ShowDialog();
            MainClass.BlurBackGround(new Model.ProductAdd());

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

                ProductAdd frm = new ProductAdd();
                frm.id = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvid"].Value);
                frm.cID= Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvcatID"].Value);
                //frm.txtPrice.Text = Convert.ToString(guna2DataGridView2.CurrentRow.Cells["dgvPrice"].Value);
                //frm.cbCat.Text = Convert.ToString(guna2DataGridView2.CurrentRow.Cells["dgvcat"].Value);

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
                    string qry = "Delete from products where pID= " + id + "";
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
