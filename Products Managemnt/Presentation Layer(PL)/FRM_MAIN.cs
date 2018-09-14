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
    public partial class FRM_MAIN : MetroFramework.Forms.MetroForm
    {
        //single object
        private static FRM_MAIN frm;
        static void frm_FormClosed(object sender , FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FRM_MAIN GetMainForm
        {
            get
            {
                if(frm == null)
                {
                    frm = new FRM_MAIN();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }
        public FRM_MAIN()
        {
            InitializeComponent();
            if(frm == null)
            {
                frm = this;
            }
            this.المنتجاتToolStripMenuItem.Enabled = false;
            this.العملاءToolStripMenuItem.Enabled = false;
            this.المستخدمونToolStripMenuItem.Enabled = false;
            this.إنشاءنسخهإحتياطيهToolStripMenuItem.Enabled = false;
            this.إستعادةنسخهمحفوظهToolStripMenuItem.Enabled = false;

        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {

        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_LOGIN k = new FRM_LOGIN();
            k.ShowDialog();
        }

        private void إضافةصنفجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void إضافةمنتججديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT adp = new FRM_ADD_PRODUCT();
            adp.ShowDialog();
        }

        private void إدارةالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_PRODUCTS frm = new FRM_PRODUCTS();
            frm.ShowDialog();
        }

        private void المنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void إدارةالاصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CATEGORIES frm = new FRM_CATEGORIES();
            frm.ShowDialog();
        }

        private void إدارةالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS frm = new FRM_CUSTOMERS();
            frm.ShowDialog();
        }

        private void إدارةالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDERS frm = new FRM_ORDERS();
            frm.Show();
        }
    }
}
