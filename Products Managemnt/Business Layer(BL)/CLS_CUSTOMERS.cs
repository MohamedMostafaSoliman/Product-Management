using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Products_Managemnt.Business_Layer_BL_
{
    class CLS_CUSTOMERS
    {
        public void ADD_CUSTOMER(string First_Name , string Last_Name , string Tel, string Email ,  byte[] Picture , string Criterion)
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@First_Name", SqlDbType.VarChar , 25);
            param[0].Value = First_Name;

            param[1] = new SqlParameter("@Last_Name", SqlDbType.VarChar, 25);
            param[1].Value = Last_Name;

            param[2] = new SqlParameter("@Tel", SqlDbType.NChar, 15);
            param[2].Value = Tel;

            param[3] = new SqlParameter("@Email", SqlDbType.VarChar, 25);
            param[3].Value = Email;


            param[4] = new SqlParameter("@Picture", SqlDbType.Image);
            param[4].Value = Picture;

            param[5] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[5].Value = Criterion;
            DAL.ExecuteCommand("ADD_CUSTOMER", param);
            DAL.close();
        }

        public void EDIT_CUSTOMER(string First_Name, string Last_Name, string Tel, string Email, byte[] Picture, string Criterion , int ID)
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@First_Name", SqlDbType.VarChar, 25);
            param[0].Value = First_Name;

            param[1] = new SqlParameter("@Last_Name", SqlDbType.VarChar, 25);
            param[1].Value = Last_Name;

            param[2] = new SqlParameter("@Tel", SqlDbType.NChar, 15);
            param[2].Value = Tel;

            param[3] = new SqlParameter("@Email", SqlDbType.VarChar, 25);
            param[3].Value = Email;


            param[4] = new SqlParameter("@Picture", SqlDbType.Image);
            param[4].Value = Picture;

            param[5] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[5].Value = Criterion;

            param[6] = new SqlParameter("@ID", SqlDbType.Int);
            param[6].Value = ID;

            DAL.ExecuteCommand("EDIT_CUSTOMER", param);
            DAL.close();
        }


        public void DELETE_CUSTOMER(int ID)
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            DAL.ExecuteCommand("DELETE_CUSTOMER", param);
            DAL.close();
        }


        public DataTable GET_ALL_CUSTOMERS()
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_ALL_CUSTOMERS", null);
            DAL.close();
            return Dt;
        }

        public DataTable Search_Customer(string Criterion)
        {
            Data_Access_Layer_DAL_.DataAccessLayer DAL = new Data_Access_Layer_DAL_.DataAccessLayer();
            DAL.open();
            DataTable Dt = new DataTable();
            SqlParameter[] param;
            param = new SqlParameter[1];
            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[0].Value = Criterion;
            Dt = DAL.SelectData("Search_Customer", param);
            DAL.close();
            return Dt;
        }


    }
}
