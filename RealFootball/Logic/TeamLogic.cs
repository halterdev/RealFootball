using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RealFootball.Logic
{
    public class TeamLogic
    {
        #region *** DATA MODIFICATION ***
        public static int CreateNewTeam(int teamDetailsID, int leagueID)
        {
            int teamID = 0;
            string sql = @"insert into Teams (TeamDetailsID, LeagueID, CoachID, Championships)
                            values (@TeamDetailsID, @LeagueID, @CoachID, @Championships)
                            select scope_identity()";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@TeamDetailsID", teamDetailsID);
                command.Parameters.AddWithValue("@LeagueID", leagueID);
                command.Parameters.AddWithValue("@CoachID", 0);
                command.Parameters.AddWithValue("@Championships", 0);
                conn.Open();
                teamID = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
            }

            GenerateRoster(teamID);
            return teamID;
        }
        private static void GenerateRoster(int teamID)
        {
            int totalQbs, totalRbs, totalWrs, totalTes, totalFbs, totalOls, totalCbs, totalOlbs, totalMlbs, totalDls, totalSs, totalKs, totalPs; 
            totalQbs = totalRbs = totalWrs = totalTes = totalFbs = totalOls = totalCbs = totalOlbs = totalMlbs = totalDls = totalSs = 
                totalKs = totalPs = 0;
            int totalPlayers = 0;
            bool rosterComplete = false;
            
            while (!rosterComplete)
            {
                if (totalQbs < Main.MINQUARTERBACKS)
                {
                    PlayerLogic.CreatePlayer(Main.QUARTERBACK, teamID);
                    totalQbs++;
                    totalPlayers++;
                }
                else if (totalRbs < Main.MINRUNNINGBACKS)
                {
                    PlayerLogic.CreatePlayer(Main.RUNNINGBACK, teamID);
                    totalRbs++;
                    totalPlayers++;
                }
                else if (totalFbs < Main.MINFULLBACKS)
                {
                    PlayerLogic.CreatePlayer(Main.FULLBACK, teamID);
                    totalFbs++;
                    totalPlayers++;
                }
                else if (totalWrs < Main.MINWIDERECEIVERS)
                {
                    PlayerLogic.CreatePlayer(Main.WIDERECEIVER, teamID);
                    totalWrs++;
                    totalPlayers++;
                }
                else if (totalTes < Main.MINTIGHTENDS)
                {
                    PlayerLogic.CreatePlayer(Main.TIGHTEND, teamID);
                    totalTes++;
                    totalPlayers++;
                }
                else if (totalOls < Main.MINOFFENSIVELINEMAN)
                {
                    PlayerLogic.CreatePlayer(Main.OFFENSIVELINEMAN, teamID);
                    totalOls++;
                    totalPlayers++;
                }
                else if (totalCbs < Main.MINCORNERBACKS)
                {
                    PlayerLogic.CreatePlayer(Main.CORNERBACK, teamID);
                    totalCbs++;
                    totalPlayers++;
                }
                else if (totalOlbs < Main.MINOUTSIDELINEBACKERS)
                {
                    PlayerLogic.CreatePlayer(Main.OUTSIDELINEBACKER, teamID);
                    totalOlbs++;
                    totalPlayers++;
                }
                else if (totalMlbs < Main.MINMIDDLELINEBACKERS)
                {
                    PlayerLogic.CreatePlayer(Main.MIDDLELINEBACKER, teamID);
                    totalMlbs++;
                    totalPlayers++;
                }
                else if (totalDls < Main.MINDEFENSIVELINEMAN)
                {
                    PlayerLogic.CreatePlayer(Main.DEFENSIVELINEMAN, teamID);
                    totalDls++;
                    totalPlayers++;
                }
                else if (totalSs < Main.MINSAFETIES)
                {
                    PlayerLogic.CreatePlayer(Main.SAFETY, teamID);
                    totalSs++;
                    totalPlayers++;
                }
                else if (totalKs < Main.MINKICKERS)
                {
                    PlayerLogic.CreatePlayer(Main.KICKER, teamID);
                    totalKs++;
                    totalPlayers++;
                }
                else if (totalPs < Main.MINPUNTERS)
                {
                    PlayerLogic.CreatePlayer(Main.PUNTER, teamID);
                    totalPs++;
                    totalPlayers++;
                }
                else
                {
                    // all minimums have been met, just make random players
                    PlayerLogic.CreatePlayer(teamID);
                    totalPlayers++;
                }

                if (totalPlayers == 60)
                {
                    // roster is complete, kill loop
                    rosterComplete = true;
                }
            }
        }
        #endregion

        #region *** DATA RETRIEVAL ***
        public static DataSet GetTeamsByDivisionAndLeague(int divisionID, int leagueID)
        {
            DataSet result = new DataSet();
            string sql = @"select (td.City) + ' ' + (td.Nickname) as Team, t.Wins, t.Losses, t.Ties,
                                t.TeamID
                            from Teams t
                            join TeamDetails td on td.TeamDetailsID = t.TeamDetailsID
                            where td.DivisionID = @DivisionID
                            and t.LeagueID = @LeagueID";
            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@DivisionID", divisionID);
                command.Parameters.AddWithValue("@LeagueID", leagueID);
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(result);
            }
            return result;
        }
        public static string GetTeamName(int teamID)
        {
            string result = "";
            string sql = @"select rtrim(td.City) + ' ' + rtrim(td.Nickname)
                            from Teams t
                            join TeamDetails td on td.TeamDetailsID = t.TeamDetailsID
                            where t.TeamID = @TeamID";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@TeamID", teamID);
                conn.Open();
                result = Convert.ToString(command.ExecuteScalar());
                conn.Close();
            }
            return result;
        }
        public static DataSet GetTeamsRoster(int teamID)
        {
            DataSet result = new DataSet();
            string sql = @"select rtrim(p.FirstName) + ' ' + rtrim(p.LastName) as Player,
                                rtrim(p.Hometown) + ', ' + rtrim(p.State) as Hometown, rtrim(p.College) as College,
                                isnull(pos.Abbreviation, '') as Position
                              from Players p
                              left join Positions pos on pos.PositionID = p.PositionID
                              where p.TeamID = @TeamID
                              order by pos.PositionID asc";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@TeamID", teamID);
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(result);
            }
            return result;
        }
        public static string GetTeamsLocation(int teamID)
        {
            string result = "";
            string sql = @"select rtrim(td.City) + ', ' + rtrim(td.State) as Location
                            from Teams t
                            join TeamDetails td on td.TeamDetailsID = t.TeamDetailsID
                            where t.TeamID = @TeamID";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@TeamID", teamID);
                conn.Open();
                result = Convert.ToString(command.ExecuteScalar());
                conn.Close();
            }
            return result;
        }
        public static bool DoAllTeamsPlayersHavePositions(int teamID)
        {
            bool result = true;
            string sql = @"select count(*) from Players where TeamID = @TeamID and PositionID = 0";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@TeamID", teamID);
                conn.Open();
                result = Convert.ToInt32(command.ExecuteScalar()) == 0;
                conn.Close();
            }
            return result;
        }
        public static DataSet GetTeamsStartingLineup(int teamID)
        {
            DataSet result = new DataSet();
            string sql = @"select * from Players where DepthChartNumber <> 0 and TeamID = @TeamID";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@TeamID", teamID);
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(result);
            }
            return result;
        }
        #endregion
    }
}