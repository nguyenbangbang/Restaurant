using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Model
{
    public partial class ProductAdd: SampleAdd
    {
        public ProductAdd()
        {
            InitializeComponent();
        }
        
        public int id = 0;
        public int cID= 0;

        private void ProductAdd_Load(object sender, EventArgs e)
        {
            string qry = "Select catID 'id', catName 'name' from category";
            MainClass.CBFill(qry, cbCat);

            if (cID>0)
            {
                cbCat.SelectedValue = cID;
            }

        }
        string filePath;
        Byte[] imageByArray;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image(.jpg, .png)|* .png; *.jpg";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtImage.Image = new Bitmap(filePath);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)// insert
            {
                qry = "Insert into products Values(@Name, @price, @cat, @img)";
            }
            else//update
            {
                qry = "Update products set pName=@Name,pPrice = @price,CategoryID= @id,pImange=@img  where pID =@id";

            }
            //For image
            Image temp = new Bitmap(txtImage.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByArray = ms.ToArray();


            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtNameadd.Text);
            ht.Add("@price", txtPrice.Text);
            ht.Add("@cat", Convert.ToInt32(cbCat.SelectedValue));
            ht.Add("@img", imageByArray);

            if (MainClass.SQL(qry, ht) > 0)
            {
                //
                MessageBox.Show("Save successfully...");
                id = 0;
                txtNameadd.Text = "";
                txtPrice.Text = "";
                cbCat.SelectedIndex = -1;
                txtNameadd.Focus();
            }
        }
    }
}
