using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Products_Managemnt.Business_Layer_BL_
{
    class CLS_PRODUCTS
    {
        public DataTable GET_ALL_CATEGORIES()
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_ALL_CATEGORIES", null);
            DAL.close();
            return Dt;
        }

        public void ADD_PRODUCT(int ID_Cat , string label_product , string ID_product , int Qte , string Price , byte[] img)
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_CAT" , SqlDbType.Int);
            param[0].Value = ID_Cat;

            param[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar , 30);
            param[1].Value = ID_product;

            param[2] = new SqlParameter("@Label", SqlDbType.VarChar , 30);
            param[2].Value = label_product;

            param[3] = new SqlParameter("@Qte", SqlDbType.Int);
            param[3].Value = Qte;

            param[4] = new SqlParameter("@PRICE", SqlDbType.VarChar , 50);
            param[4].Value = Price;

            param[5] = new SqlParameter("@Img", SqlDbType.Image);
            param[5].Value = img;

            DAL.ExecuteCommand("ADD_PRODUCT", param);
            DAL.close();
       }

        public void UPDATE_PRODUCT(int ID_Cat, string label_product, string ID_product, int Qte, string Price, byte[] img)
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[0].Value = ID_Cat;

            param[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            param[1].Value = ID_product;

            param[2] = new SqlParameter("@Label", SqlDbType.VarChar, 30);
            param[2].Value = label_product;

            param[3] = new SqlParameter("@Qte", SqlDbType.Int);
            param[3].Value = Qte;

            param[4] = new SqlParameter("@PRICE", SqlDbType.VarChar, 50);
            param[4].Value = Price;

            param[5] = new SqlParameter("@Img", SqlDbType.Image);
            param[5].Value = img;

            DAL.ExecuteCommand("UPDATE_PRODUCT", param);
            DAL.close();
        }

        public DataTable VerifyProductID(string ID)
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            Dt = DAL.SelectData("VerifyProductID", param);
            DAL.close();
            return Dt;
        }

        public DataTable GET_ALL_PRODUCTS()
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_ALL_PRODUCTS", null);
            DAL.close();
            return Dt;
        }

        public DataTable GET_IMAGE_PRODUCT(string ID)
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            Dt = DAL.SelectData("GET_IMAGE_PRODUCT", param);
            DAL.close();
            return Dt;
        }

        public DataTable SearchProduct(string ID)
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            Dt = DAL.SelectData("SearchProduct", param);
            DAL.close();
            return Dt;
        }
        public void DeleteProduct(string ID)
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar , 50);
            param[0].Value = ID;


            DAL.ExecuteCommand("DeleteProduct", param);
            DAL.close();
        }

    }
}
