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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;

namespace Products_Managemnt.Presentation_Layer_PL_
{
    public partial class FRM_PRODUCTS : MetroFramework.Forms.MetroForm
    {

        //single object
        private static FRM_PRODUCTS frm;
        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FRM_PRODUCTS GetMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new FRM_PRODUCTS();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }
        Business_Layer_BL_.CLS_PRODUCTS prd = new Business_Layer_BL_.CLS_PRODUCTS();
        public FRM_PRODUCTS()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
        }

        private void FRM_PRODUCTS_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = prd.SearchProduct(txtSearch.Text);
            this.dataGridView1.DataSource = Dt;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
            frm.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("هل تريد حذف المنتج المحدد" , "عملية الحذف" , MessageBoxButtons.YesNo , MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                prd.DeleteProduct(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("تمت عملية الحذف", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
            }
            else
            {
                MessageBox.Show("تم إلغاء عملية الحذف", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
            frm.txtRef.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtDes.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtQte.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txtPrice.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.cmbCategories.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.Text = "تحديث المنتج" + " :" + this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.BTN_Login.Text = "تحديث";
            frm.state = "update";
            frm.txtRef.ReadOnly = true;
            byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            frm.Pbbox.Image = Image.FromStream(ms); 
            frm.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            FRM_PREVIEW frm = new FRM_PREVIEW();
            byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            frm.pictureBox1.Image = Image.FromStream(ms);
            frm.ShowDialog();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            RPT.rpt_prd_single myreport = new RPT.rpt_prd_single();
            myreport.SetParameterValue("@ID", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RPT.FRM_RPT_PRODUCT myform = new RPT.FRM_RPT_PRODUCT();
            myform.crystalReportViewer1.ReportSource = myreport;
            myform.ShowDialog();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_products myReport = new RPT.rpt_all_products();
            RPT.FRM_RPT_PRODUCT myForm = new RPT.FRM_RPT_PRODUCT();
            myForm.crystalReportViewer1.ReportSource = myReport;
            myForm.ShowDialog();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_products myReport = new RPT.rpt_all_products();

            // Create Export options 
            ExportOptions export = new ExportOptions();

            // Create object for destination
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();

            ExcelFormatOptions excelformat = new ExcelFormatOptions();
            // Set the path of destination
            dfoptions.DiskFileName = @"D:\scienses\life with c#\projects\Products Managemnt\Reports\ProductsList.xls";

            export = myReport.ExportOptions;

            export.ExportDestinationType = ExportDestinationType.DiskFile;

            export.ExportFormatType = ExportFormatType.Excel;

            export.ExportFormatOptions = excelformat;
            export.ExportDestinationOptions = dfoptions;

            myReport.Refresh();
            myReport.Export();

            MessageBox.Show("List Eported Successfully ", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
