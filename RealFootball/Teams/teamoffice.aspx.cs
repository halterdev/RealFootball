using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealFootball.Logic;

namespace RealFootball.Teams
{
    public partial class teamoffice : System.Web.UI.Page
    {
        public int LeagueID;
        public int TeamID;
        public int TeamDetailsID;

        protected void Page_Load(object sender, EventArgs e)
        {
            TeamID = Convert.ToInt32(Request.QueryString["TeamID"]);
            LeagueID = SqlBuilder.SimpleGetInt("LeagueID", "Teams", "TeamID", TeamID.ToString());
            TeamDetailsID = SqlBuilder.SimpleGetInt("TeamDetailsID", "Teams", "TeamID", TeamID.ToString());

            if (TeamID != 0)
            {
                lblTeamName.Text = TeamLogic.GetTeamName(TeamID);
                lblSeason.Text = "Season: " + 
                    SqlBuilder.SimpleGetInt("SeasonNumber", "Leagues", "LeagueID", LeagueID.ToString());
                lblWeek.Text = "Off-Season";

                RosterGrid.DataSource = TeamLogic.GetTeamsRoster(TeamID);
                RosterGrid.DataBind();

                lblLocation.Text = "Location: " + TeamLogic.GetTeamsLocation(TeamID);
                lblChampionships.Text = "Championships: " + SqlBuilder.SimpleGetInt("Championships", "Teams", "TeamID", TeamID.ToString());

                lblCurrentRecord.Text = "Record: " + SqlBuilder.SimpleGetInt("Wins", "Teams", "TeamID", TeamID.ToString()) + " - " +
                    SqlBuilder.SimpleGetInt("Losses", "Teams", "teamID", TeamID.ToString());

                lblSeasonsWithTeam.Text = "Seasons with " + SqlBuilder.SimpleGetString("City", "TeamDetails", "TeamDetailsID", TeamDetailsID.ToString()) +
                    ": 1";
            }
        }

        #region *** ANCHOR REDIRECTS ***
        protected void TeamOffice_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Teams/teamoffice.aspx?TeamID=" + TeamID);
        }
        protected void DepthChart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Teams/depthchart.aspx?TeamID=" + TeamID);
        }
        #endregion
    }
}