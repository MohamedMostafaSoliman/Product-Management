using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_Managemnt.Presentation_Layer_PL_
{
    public partial class FRM_LOGIN : MetroFramework.Forms.MetroForm
    {
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void FRM_LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            Business_Layer_BL_.Class_LOGIN  log= new Business_Layer_BL_.Class_LOGIN();
            DataTable dt = log.LOGIN(txtID.Text, txtPWD.Text);
            if(dt.Rows.Count ==1 )
            {
                FRM_MAIN.GetMainForm.المنتجاتToolStripMenuItem.Enabled = true;
                FRM_MAIN.GetMainForm.العملاءToolStripMenuItem.Enabled = true;
                FRM_MAIN.GetMainForm.المستخدمونToolStripMenuItem.Enabled = true;
                FRM_MAIN.GetMainForm.إنشاءنسخهإحتياطيهToolStripMenuItem.Enabled = true;
                FRM_MAIN.GetMainForm.إستعادةنسخهمحفوظهToolStripMenuItem.Enabled = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed !");
            }
             
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPWD.Focus();
            }
        }

        private void txtPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                BTN_Login.Focus();
            }
        }
    }
}
