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
    public partial class FRM_CUSTOMERS_LIST : MetroFramework.Forms.MetroForm
    {
        Business_Layer_BL_.CLS_CUSTOMERS cust = new Business_Layer_BL_.CLS_CUSTOMERS();
        public FRM_CUSTOMERS_LIST()
        {
            InitializeComponent();
            this.dgvCustomers.DataSource = cust.GET_ALL_CUSTOMERS();
            this.dgvCustomers.Columns[0].Visible = false;
            this.dgvCustomers.Columns[5].Visible = false;

        }

        private void FRM_CUSTOMERS_LIST_Load(object sender, EventArgs e)
        {

        }

        private void dgvCustomers_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
