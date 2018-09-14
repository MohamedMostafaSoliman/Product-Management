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
    public partial class FRM_CUSTOMERS : MetroFramework.Forms.MetroForm
    {
        Business_Layer_BL_.CLS_CUSTOMERS cust = new Business_Layer_BL_.CLS_CUSTOMERS();
        int ID , position;
        public FRM_CUSTOMERS()
        {
            InitializeComponent();
            this.dglist.Refresh();
            this.dglist.DataSource = cust.GET_ALL_CUSTOMERS();
            dglist.Columns[0].Visible = false;
            dglist.Columns[5].Visible = false;
        }

        private void FRM_CUSTOMERS_Load(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(position == 0)
            {
                MessageBox.Show("هذا أول عنصر");
                return;
            }
            position -= 1;
            Navigate(position);
        }

        private void exportToPdfAll_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] picture;
                if(pbox.Image == null)
                {
                    picture = new byte[0];
                    cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, picture, "without_image");
                    MessageBox.Show("تمت الإضافه بنجاح", "الإضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dglist.DataSource = cust.GET_ALL_CUSTOMERS();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtEmail.Clear();
                    txtTel.Clear();
                    pbox.Image = null;
                }
                else{
                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                 picture = ms.ToArray();
                cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, picture , "with_image" );
                MessageBox.Show("تمت الإضافه بنجاح", "الإضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dglist.DataSource = cust.GET_ALL_CUSTOMERS();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtEmail.Clear();
                txtTel.Clear();
                pbox.Image = null;
                }
            }
            catch
            {
                return;
            }
            finally
            {
                btnAdd.Enabled = false;
                btnNew.Enabled = true;
            }
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "ملفات الصور | *.JPG ; *.PNG ; *.GIF ; *.BMP ; *.jpg ; *.gif ; *.png ; *.bmp ; *.JPEG";
            if(op.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(op.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtTel.Clear();
            pbox.Image = null;
            txtFirstName.Focus();
            btnAdd.Enabled = true;
            btnNew.Enabled = false;
        }

        private void btnNew_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtLastName.Focus();
            }
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtTel.Focus();
            }

        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();
            }
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtLastName.Focus();
            }
        }

        private void dglist_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                pbox.Image = null;
                ID = Convert.ToInt32(dglist.CurrentRow.Cells[0].Value);
                this.txtFirstName.Text = dglist.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = dglist.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = dglist.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = dglist.CurrentRow.Cells[4].Value.ToString();
                byte[] picture = (byte[])dglist.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(picture);
                pbox.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID == 0)
                {
                    MessageBox.Show("العميل المراد تعديله غير موجود");
                    return;
                }
                byte[] picture;
                if (pbox.Image == null)
                {
                    picture = new byte[0];
                    cust.EDIT_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, picture, "without_image" , ID);
                    MessageBox.Show("تمت التعديل بنجاح", "الإضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dglist.DataSource = cust.GET_ALL_CUSTOMERS();
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    pbox.Image.Save(ms, pbox.Image.RawFormat);
                    picture = ms.ToArray();
                    cust.EDIT_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, picture, "with_image" , ID);
                    MessageBox.Show("تمت التعديل بنجاح", "الإضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dglist.DataSource = cust.GET_ALL_CUSTOMERS();
                }
            }
            catch
            {
                return;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(ID == 0)
            {
                MessageBox.Show("العميل المراد حذفه غير موجود");
                return;
            }
            if (MessageBox.Show("هل تريد فعلا حذف هذا العميل ؟", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cust.DELETE_CUSTOMER(ID);
                MessageBox.Show("تمت الحذف بنجاح", "الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dglist.DataSource = cust.GET_ALL_CUSTOMERS();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtEmail.Clear();
                txtTel.Clear();
                pbox.Image = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dglist.DataSource = cust.Search_Customer(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        void Navigate(int index)
        {
            try
            {
                pbox.Image = null;
                DataRowCollection DRC = cust.GET_ALL_CUSTOMERS().Rows;
                ID = Convert.ToInt32(DRC[index][0]);
                txtFirstName.Text = DRC[index][1].ToString();
                txtLastName.Text = DRC[index][2].ToString();
                txtTel.Text = DRC[index][3].ToString();
                txtEmail.Text = DRC[index][4].ToString();
                byte[] picture = (byte[])DRC[index][5];
                MemoryStream ms = new MemoryStream(picture);
                pbox.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Navigate(0);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            position = cust.GET_ALL_CUSTOMERS().Rows.Count - 1;
            Navigate(position);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (position == cust.GET_ALL_CUSTOMERS().Rows.Count - 1)
            {
                MessageBox.Show("هذا اخر عنصر");
                return;
            }
            position += 1;
            Navigate(position);
        }
    }
}
