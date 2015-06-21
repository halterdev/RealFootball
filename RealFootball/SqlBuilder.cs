using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RealFootball
{
    public class SqlBuilder
    {
        // select an int from a field in the database
        public static int SimpleGetInt(string select, string from, string whereField, string whereValue)
        {
            int result = 0;
            string sql = @"select " + select + " from " + from + 
                    " where " + whereField + " = " + whereValue;
            
            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                result = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
            }
            return result;
        }
        
        // select a string from a field in the database
        public static string SimpleGetString(string select, string from, string whereField, string whereValue)
        {
            string result = "";
            string sql = @"select " + select + " from " + from + " where " + whereField + " = " + whereValue;

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                result = Convert.ToString(command.ExecuteScalar());
                conn.Close();
            }
            return result;
        }
    }
}