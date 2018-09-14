using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Products_Managemnt.Presentation_Layer_PL_
{
    public partial class FRM_ADD_PRODUCT : MetroFramework.Forms.MetroForm
    {
        public string state = "add";
        Business_Layer_BL_.CLS_PRODUCTS prd = new Business_Layer_BL_.CLS_PRODUCTS();
        public FRM_ADD_PRODUCT()
        {
            InitializeComponent();
            cmbCategories.DataSource = prd.GET_ALL_CATEGORIES();
            cmbCategories.DisplayMember = "DESCRIPTION_CAT";
            cmbCategories.ValueMember = "ID_CAT";
        }

        private void FRM_ADD_PRODUCT_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ملفات الصور | *.JPG ; *.PNG ; *.GIF ; *.BMP ; *.jpg ; *.gif ; *.png ; *.bmp ; *.JPEG";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Pbbox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                // convert image to binary
                MemoryStream ms = new MemoryStream();
                Pbbox.Image.Save(ms, Pbbox.Image.RawFormat);
                byte[] byteimage = ms.ToArray();

                prd.ADD_PRODUCT(Convert.ToInt32(cmbCategories.SelectedValue), txtDes.Text, txtRef.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text, byteimage);
                MessageBox.Show("تمت الإضافه بنجاح", "عملية الإضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                Pbbox.Image.Save(ms, Pbbox.Image.RawFormat);
                byte[] byteimage = ms.ToArray();

                prd.UPDATE_PRODUCT(Convert.ToInt32(cmbCategories.SelectedValue), txtDes.Text, txtRef.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text, byteimage);
                MessageBox.Show("تمت التعديل بنجاح", "عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //to make products updates instantly without needing to close form and  start it
                FRM_PRODUCTS.GetMainForm.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
            }
            //to make products updates instantly without needing to close form and  start it
            FRM_PRODUCTS.GetMainForm.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
        }

        private void txtRef_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRef_Validated(object sender, EventArgs e)
        {
            if (state == "add")
            {
                DataTable Dt = new DataTable();
                Dt = prd.VerifyProductID(txtRef.Text);
                if (Dt.Rows.Count > 0)
                {
                    MessageBox.Show("هذا التعريف موجود مسبقا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRef.Focus();
                    txtRef.SelectionStart = 0;
                    txtRef.SelectionLength = txtRef.TextLength;
                }
            } 
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
