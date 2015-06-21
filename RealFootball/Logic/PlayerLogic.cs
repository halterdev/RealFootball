using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RealFootball.Datasets;

namespace RealFootball.Logic
{
    public class PlayerLogic
    {
        private static Random random = new Random();

        #region *** DATA MODIFICATION ***
        public static int CreatePlayer(int teamID)
        {
            int playerID = 0;
            PlayerDS newPlayerDS = new PlayerDS();
            newPlayerDS.Tables[0].Rows.Add(newPlayerDS.Tables[0].NewRow());

            int index = random.Next(0, Main.FIRSTNAMES.Length);
            newPlayerDS.Tables[0].Rows[0]["FirstName"] = Main.FIRSTNAMES[index];
            index = random.Next(0, Main.LASTNAMES.Length);
            newPlayerDS.Tables[0].Rows[0]["LastName"] = Main.LASTNAMES[index];
            index = random.Next(0, Main.HOMETOWNS.Length);
            newPlayerDS.Tables[0].Rows[0]["Hometown"] = Main.HOMETOWNS[index];
            newPlayerDS.Tables[0].Rows[0]["State"] = Main.STATES[index];
            newPlayerDS.Tables[0].Rows[0]["BirthDate"] = Convert.ToString(Main.GetRandomDate(Main.BEGINYEAR, Main.ENDYEAR));
            newPlayerDS.Tables[0].Rows[0]["TeamID"] = teamID.ToString();
            index = random.Next(0, Main.COLLEGES.Length);
            newPlayerDS.Tables[0].Rows[0]["College"] = Main.COLLEGES[index];
            newPlayerDS.Tables[0].Rows[0]["PositionID"] = "0";
            newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
            newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXWEIGHT).ToString();
            newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();

            string sql = @"insert into Players (FirstName, LastName, Hometown, State, BirthDate, TeamID, College, PositionID,
                                Height, Weight, Speed, Strength, Elusiveness, Intelligence, WorkEthic, Jump, Agility, Juke, ArmAccuracy,
                                RouteRunning, Hands, Blocking, Coverage, Tackling, Kicking, Punting)
                            values (@FirstName, @LastName, @Hometown, @State, @BirthDate, @TeamID, @College, @PositionID,
                                @Height, @Weight, @Speed, @Strength, @Elusiveness, @Intelligence, @WorkEthic, @Jump, @Agility, @Juke, @ArmAccuracy,
                                @RouteRunning, @Hands, @Blocking, @Coverage, @Tackling, @Kicking, @Punting)
                            select scope_identity()";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@FirstName", newPlayerDS.Tables[0].Rows[0]["FirstName"]);
                command.Parameters.AddWithValue("@LastName", newPlayerDS.Tables[0].Rows[0]["LastName"]);
                command.Parameters.AddWithValue("@Hometown", newPlayerDS.Tables[0].Rows[0]["Hometown"]);
                command.Parameters.AddWithValue("@State", newPlayerDS.Tables[0].Rows[0]["State"]);
                command.Parameters.AddWithValue("@BirthDate", newPlayerDS.Tables[0].Rows[0]["BirthDate"]);
                command.Parameters.AddWithValue("@TeamID", newPlayerDS.Tables[0].Rows[0]["TeamID"]);
                command.Parameters.AddWithValue("@College", newPlayerDS.Tables[0].Rows[0]["College"]);
                command.Parameters.AddWithValue("@PositionID", newPlayerDS.Tables[0].Rows[0]["PositionID"]);
                command.Parameters.AddWithValue("@Height", newPlayerDS.Tables[0].Rows[0]["Height"]);
                command.Parameters.AddWithValue("@Weight", newPlayerDS.Tables[0].Rows[0]["Weight"]);
                command.Parameters.AddWithValue("@Speed", newPlayerDS.Tables[0].Rows[0]["Speed"]);
                command.Parameters.AddWithValue("@Strength", newPlayerDS.Tables[0].Rows[0]["Strength"]);
                command.Parameters.AddWithValue("@Elusiveness", newPlayerDS.Tables[0].Rows[0]["Elusiveness"]);
                command.Parameters.AddWithValue("@Intelligence", newPlayerDS.Tables[0].Rows[0]["Intelligence"]);
                command.Parameters.AddWithValue("@WorkEthic", newPlayerDS.Tables[0].Rows[0]["WorkEthic"]);
                command.Parameters.AddWithValue("@Jump", newPlayerDS.Tables[0].Rows[0]["Jump"]);
                command.Parameters.AddWithValue("@Agility", newPlayerDS.Tables[0].Rows[0]["Agility"]);
                command.Parameters.AddWithValue("@Juke", newPlayerDS.Tables[0].Rows[0]["Juke"]);
                command.Parameters.AddWithValue("@ArmAccuracy", newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"]);
                command.Parameters.AddWithValue("@RouteRunning", newPlayerDS.Tables[0].Rows[0]["RouteRunning"]);
                command.Parameters.AddWithValue("@Hands", newPlayerDS.Tables[0].Rows[0]["Hands"]);
                command.Parameters.AddWithValue("@Blocking", newPlayerDS.Tables[0].Rows[0]["Blocking"]);
                command.Parameters.AddWithValue("@Coverage", newPlayerDS.Tables[0].Rows[0]["Coverage"]);
                command.Parameters.AddWithValue("@Tackling", newPlayerDS.Tables[0].Rows[0]["Tackling"]);
                command.Parameters.AddWithValue("@Kicking", newPlayerDS.Tables[0].Rows[0]["Kicking"]);
                command.Parameters.AddWithValue("@Punting", newPlayerDS.Tables[0].Rows[0]["Punting"]);
                conn.Open();
                playerID = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
            }
            return playerID;
        }
        public static int CreatePlayer(int positionID, int teamID)
        {
            int playerID = 0;
            PlayerDS newPlayerDS = new PlayerDS();
            newPlayerDS.Tables[0].Rows.Add(newPlayerDS.Tables[0].NewRow());

            int index = random.Next(0, Main.FIRSTNAMES.Length);
            newPlayerDS.Tables[0].Rows[0]["FirstName"] = Main.FIRSTNAMES[index];
            index = random.Next(0, Main.LASTNAMES.Length);
            newPlayerDS.Tables[0].Rows[0]["LastName"] = Main.LASTNAMES[index];
            index = random.Next(0, Main.HOMETOWNS.Length);
            newPlayerDS.Tables[0].Rows[0]["Hometown"] = Main.HOMETOWNS[index];
            newPlayerDS.Tables[0].Rows[0]["State"] = Main.STATES[index];
            newPlayerDS.Tables[0].Rows[0]["BirthDate"] = Convert.ToString(Main.GetRandomDate(Main.BEGINYEAR, Main.ENDYEAR));
            newPlayerDS.Tables[0].Rows[0]["TeamID"] = teamID.ToString();
            index = random.Next(0, Main.COLLEGES.Length);
            newPlayerDS.Tables[0].Rows[0]["College"] = Main.COLLEGES[index];
            newPlayerDS.Tables[0].Rows[0]["PositionID"] = positionID.ToString();
          
            #region *** CHANGES BASED UPON POSITION GIVEN ***
            if (positionID == Main.QUARTERBACK)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXMINWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
            }
            else if (positionID == Main.RUNNINGBACK)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXMINWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
            }
            else if (positionID == Main.WIDERECEIVER)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXMINWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
            }
            else if (positionID == Main.TIGHTEND)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXMINWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
            }
            else if (positionID == Main.FULLBACK)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
            }
            else if (positionID == Main.OFFENSIVELINEMAN)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MAXMINWEIGHT, Main.MAXWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
            }
            else if (positionID == Main.DEFENSIVELINEMAN)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MAXMINWEIGHT, Main.MAXWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
            }
            else if (positionID == Main.CORNERBACK)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXMINWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
            }
            else if (positionID == Main.SAFETY)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXMINWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
            }
            else if (positionID == Main.OUTSIDELINEBACKER)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXMINWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString(); 
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
            }
            else if (positionID == Main.MIDDLELINEBACKER)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXMINWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString(); 
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString(); //
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
            }
            else if (positionID == Main.KICKER)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXMINWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            }
            else if (positionID == Main.PUNTER)
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXMINWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINRATING, Main.MAXNONCORERATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINCORERATING, Main.MAXRATING).ToString();
            }
            else
            {
                newPlayerDS.Tables[0].Rows[0]["Height"] = random.Next(Main.MINFEET, Main.MAXFEET) + "'" + random.Next(Main.MININCHES, Main.MAXINCHES);
                newPlayerDS.Tables[0].Rows[0]["Weight"] = random.Next(Main.MINWEIGHT, Main.MAXMINWEIGHT).ToString();
                newPlayerDS.Tables[0].Rows[0]["Strength"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Speed"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Elusiveness"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Intelligence"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["WorkEthic"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Jump"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Agility"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Juke"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["RouteRunning"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Hands"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Blocking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Coverage"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Tackling"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Kicking"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
                newPlayerDS.Tables[0].Rows[0]["Punting"] = random.Next(Main.MINRATING, Main.MAXRATING).ToString();
            }
            #endregion

            string sql = @"insert into Players (FirstName, LastName, Hometown, State, BirthDate, TeamID, College, PositionID,
                                Height, Weight, Speed, Strength, Elusiveness, Intelligence, WorkEthic, Jump, Agility, Juke, ArmAccuracy,
                                RouteRunning, Hands, Blocking, Coverage, Tackling, Kicking, Punting)
                            values (@FirstName, @LastName, @Hometown, @State, @BirthDate, @TeamID, @College, @PositionID,
                                @Height, @Weight, @Speed, @Strength, @Elusiveness, @Intelligence, @WorkEthic, @Jump, @Agility, @Juke, @ArmAccuracy,
                                @RouteRunning, @Hands, @Blocking, @Coverage, @Tackling, @Kicking, @Punting)
                            select scope_identity()";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@FirstName", newPlayerDS.Tables[0].Rows[0]["FirstName"]);
                command.Parameters.AddWithValue("@LastName", newPlayerDS.Tables[0].Rows[0]["LastName"]);
                command.Parameters.AddWithValue("@Hometown", newPlayerDS.Tables[0].Rows[0]["Hometown"]);
                command.Parameters.AddWithValue("@State", newPlayerDS.Tables[0].Rows[0]["State"]);
                command.Parameters.AddWithValue("@BirthDate", newPlayerDS.Tables[0].Rows[0]["BirthDate"]);
                command.Parameters.AddWithValue("@TeamID", newPlayerDS.Tables[0].Rows[0]["TeamID"]);
                command.Parameters.AddWithValue("@College", newPlayerDS.Tables[0].Rows[0]["College"]);
                command.Parameters.AddWithValue("@PositionID", newPlayerDS.Tables[0].Rows[0]["PositionID"]);
                command.Parameters.AddWithValue("@Height", newPlayerDS.Tables[0].Rows[0]["Height"]);
                command.Parameters.AddWithValue("@Weight", newPlayerDS.Tables[0].Rows[0]["Weight"]);
                command.Parameters.AddWithValue("@Speed", newPlayerDS.Tables[0].Rows[0]["Speed"]);
                command.Parameters.AddWithValue("@Strength", newPlayerDS.Tables[0].Rows[0]["Strength"]);
                command.Parameters.AddWithValue("@Elusiveness", newPlayerDS.Tables[0].Rows[0]["Elusiveness"]);
                command.Parameters.AddWithValue("@Intelligence", newPlayerDS.Tables[0].Rows[0]["Intelligence"]);
                command.Parameters.AddWithValue("@WorkEthic", newPlayerDS.Tables[0].Rows[0]["WorkEthic"]);
                command.Parameters.AddWithValue("@Jump", newPlayerDS.Tables[0].Rows[0]["Jump"]);
                command.Parameters.AddWithValue("@Agility", newPlayerDS.Tables[0].Rows[0]["Agility"]);
                command.Parameters.AddWithValue("@Juke", newPlayerDS.Tables[0].Rows[0]["Juke"]);
                command.Parameters.AddWithValue("@ArmAccuracy", newPlayerDS.Tables[0].Rows[0]["ArmAccuracy"]);
                command.Parameters.AddWithValue("@RouteRunning", newPlayerDS.Tables[0].Rows[0]["RouteRunning"]);
                command.Parameters.AddWithValue("@Hands", newPlayerDS.Tables[0].Rows[0]["Hands"]);
                command.Parameters.AddWithValue("@Blocking", newPlayerDS.Tables[0].Rows[0]["Blocking"]);
                command.Parameters.AddWithValue("@Coverage", newPlayerDS.Tables[0].Rows[0]["Coverage"]);
                command.Parameters.AddWithValue("@Tackling", newPlayerDS.Tables[0].Rows[0]["Tackling"]);
                command.Parameters.AddWithValue("@Kicking", newPlayerDS.Tables[0].Rows[0]["Kicking"]);
                command.Parameters.AddWithValue("@Punting", newPlayerDS.Tables[0].Rows[0]["Punting"]);
                conn.Open();
                playerID = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
            }
            return playerID;
        }
        public static void UpdatePlayerPosition(int playerID, int positionID)
        {
            string sql = @"update Players 
                            set PositionID = @PositionID 
                            where PlayerID = @PlayerID";
            
            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@PositionID", positionID);
                command.Parameters.AddWithValue("@PlayerID", playerID);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        public static void UpdatePlayersDepthChartNumber(int playerID, int depthChartNumber)
        {
            string sql = @"update Players set DepthChartNumber = @DepthChartNumber
                                where PlayerID = @PlayerID";
            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@DepthChartNumber", depthChartNumber);
                command.Parameters.AddWithValue("@PlayerID", playerID);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        #endregion

        #region *** DATA RETRIEVAL ***
        public static DataSet GetPlayersByTeamAndPosition(int teamID, int positionID)
        {
            DataSet results = new DataSet();
            string sql = @"select p.PlayerID, rtrim(p.FirstName) + ' ' + rtrim(p.LastName) as Player,
                            p.Speed, p.Strength, p.Elusiveness, p.Intelligence, p.WorkEthic, p.Jump, p.Agility,
                            p.Juke, p.ArmAccuracy, p.RouteRunning, p.Hands, p.Blocking, p.Tackling,
                            p.Coverage, p.Kicking, p.Punting
                           from Players p 
                           where p.TeamID = @TeamID and p.PositionID = @PositionID
                            order by p.DepthChartNumber asc";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@TeamID", teamID);
                command.Parameters.AddWithValue("@PositionID", positionID);
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(results);
            }
            return results;
        }
        public static int GetPlayerAtDepthChartPosition(int teamID, int positionID, int depthPosition)
        {
            int result = 0;
            string sql = @"select PlayerID
                            from Players 
                            where PositionID = @PositionID and DepthChartNumber = @DepthPosition
                                and TeamID = @TeamID";

            using (SqlConnection conn = new SqlConnection(Main.GetDSN()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@PositionID", positionID);
                command.Parameters.AddWithValue("@TeamID", teamID);
                command.Parameters.AddWithValue("@DepthPosition", depthPosition);
                conn.Open();
                result = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
            }
            return result;
        }
        #endregion
    }
}