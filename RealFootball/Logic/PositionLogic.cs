using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RealFootball.Logic
{
    public class PositionLogic
    {
        #region *** DATA RETRIEVAL ***
        public static DataSet GetPositionsForDDL()
        {
            DataSet result = new DataSet();
            string sql = @"select PositionID, PositionName from Positions";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(result);
            }
            return result;
        }
        public static DataSet GetPositionAbbreviationsForDDL()
        {
            DataSet results = new DataSet();
            string sql = @"select PositionID, Abbreviation from Positions";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(results);
            }
            return results;
        }
        #endregion
    }
}