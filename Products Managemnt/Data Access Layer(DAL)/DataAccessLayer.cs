// This class to make connection with SQL server and put and get data 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;  // to connect with sql server


namespace Products_Managemnt.Data_Access_Layer_DAL_
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection;

        // initialize object connection
        public DataAccessLayer()
        {
            sqlconnection = new SqlConnection(@"Server = EL3ESAWY; Database=Product_DB; Integrated Security=true");
        }

        // Function to open connection
        public void open()
        {
            if(sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }

        // Function to close connection
        public void close()
        {
            if(sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }

        // Function to read Data from Database
        public DataTable SelectData(string Stored_Procedure , SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlconnection;

            if(param != null)
            {
                for(int i = 0 ; i < param.Length ; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Function to Insert,Update and Delete Data from Database
        public void ExecuteCommand(string Stored_Procedure , SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlconnection;

            if(param != null)
            {
                sqlcmd.Parameters.AddRange(param); // Add: add one element , AddRange : add all array
            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}
