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
    public partial class FRM_ORDERS : MetroFramework.Forms.MetroForm
    {
        Business_Layer_BL_.CLS_ORDERS order = new Business_Layer_BL_.CLS_ORDERS();
        public FRM_ORDERS()
        {
            InitializeComponent();
        }

        private void FRM_ORDERS_Load(object sender, EventArgs e)
        {
            this.btnPrintBill.Enabled = false;
            this.btnSaveSale.Enabled = false;
            this.btnDeleteSelected.Enabled = false;


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            this.txtOrderID.Text = order.GET_LAST_ORDER_ID().Rows[0][0].ToString();
            btnSaveSale.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS_LIST frm = new FRM_CUSTOMERS_LIST();
            frm.ShowDialog();
            if (frm.dgvCustomers.CurrentRow.Cells[5].Value is DBNull)
            {
                MessageBox.Show("هذا العميل ليس لديه صوره");
                this.txtCustomerID.Text = frm.dgvCustomers.CurrentRow.Cells[0].Value.ToString();
                this.txtFirstName.Text = frm.dgvCustomers.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = frm.dgvCustomers.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = frm.dgvCustomers.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = frm.dgvCustomers.CurrentRow.Cells[4].Value.ToString();
                pbox.Image = null;
                return;
            }
                this.txtCustomerID.Text = frm.dgvCustomers.CurrentRow.Cells[0].Value.ToString();
                this.txtFirstName.Text = frm.dgvCustomers.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = frm.dgvCustomers.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = frm.dgvCustomers.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = frm.dgvCustomers.CurrentRow.Cells[4].Value.ToString();
                byte[] custpicture = (byte[])frm.dgvCustomers.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(custpicture);
                this.pbox.Image = Image.FromStream(ms);
            
        }
    }
}
