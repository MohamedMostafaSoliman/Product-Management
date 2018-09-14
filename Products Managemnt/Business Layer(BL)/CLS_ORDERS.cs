using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Products_Managemnt.Business_Layer_BL_
{
    class CLS_ORDERS
    {
        public DataTable GET_LAST_ORDER_ID()
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_LAST_ORDER_ID", null);
            DAL.close();
            return Dt;  
        }
    }
}
