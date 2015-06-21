using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RealFootball.Logic
{
    public class LeagueLogic
    {
        #region *** DATA MODIFICATION ***
        public static int CreateLeague(string leagueName)
        {
            int leagueID = 0;
            string sql = @"insert into Leagues (LeagueName, LeagueTypeID, CreateDate, SeasonNumber)
                            values (@LeagueName, @LeagueTypeID, @CreateDate, @SeasonNumber)
                            select scope_identity()";
            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@LeagueName", leagueName);
                command.Parameters.AddWithValue("@LeagueTypeID", 0);
                command.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                command.Parameters.AddWithValue("@SeasonNumber", Main.ONE);
                conn.Open();
                leagueID = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
            }

            // generate the teams based upon all of the team details
            for (int i = Main.FIRSTTEAMDETAIL; i <= Main.LASTTEAMDETAIL; i++)
            {
                TeamLogic.CreateNewTeam(i, leagueID);
            }

            return leagueID;
        }
        #endregion

        #region *** DATA RETRIEVAL ***
        public static DataSet GetLeagues()
        {
            DataSet result = new DataSet();
            string sql = @"select LeagueName, LeagueID from Leagues";
            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(result);
            }
            return result;
        }
        public static string GetLeagueName(int leagueID)
        {
            string result = "";
            string sql = @"select LeagueName from Leagues where LeagueID = @LeagueID";
            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@LeagueID", leagueID);
                conn.Open();
                result = Convert.ToString(command.ExecuteScalar());
                conn.Close();
            }
            return result;
        }
        #endregion
    }
}