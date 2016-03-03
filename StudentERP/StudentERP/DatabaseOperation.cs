using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace StudentERP
{
    public class DatabaseOperation
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
     
        public void savedata(String str, Dictionary<string, object> param)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = str;
            if (param != null)
            {
                foreach (KeyValuePair<string, object> kvp in param)
                {
                    cmd.Parameters.Add(new SqlParameter(kvp.Key, kvp.Value));
                }
            }

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable getdata(String str, Dictionary<string, object> param)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = str;
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            if (param.Count > 0)
            {
                foreach (KeyValuePair<string, object> kvp in param)
                {
                    cmd.Parameters.Add(new SqlParameter(kvp.Key, kvp.Value));
                }
            }

            sdr.Fill(dt);
            return dt;
        }
    }
}