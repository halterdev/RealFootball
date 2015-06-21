using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealFootball.Logic;

namespace RealFootball
{
    public partial class leagueoverview : System.Web.UI.Page
    {
        public int LeagueID;

        protected void Page_Load(object sender, EventArgs e)
        {
            LeagueID = Convert.ToInt32(Request.QueryString["LeagueID"]);
            lblLeagueName.Text = LeagueLogic.GetLeagueName(LeagueID);

            // fill out the division standings
            NFCEast.DataSource = TeamLogic.GetTeamsByDivisionAndLeague(Main.NFCEAST, LeagueID);
            NFCEast.DataBind();

            NFCNorth.DataSource = TeamLogic.GetTeamsByDivisionAndLeague(Main.NFCNORTH, LeagueID);
            NFCNorth.DataBind();

            NFCSouth.DataSource = TeamLogic.GetTeamsByDivisionAndLeague(Main.NFCSOUTH, LeagueID);
            NFCSouth.DataBind();

            NFCWest.DataSource = TeamLogic.GetTeamsByDivisionAndLeague(Main.NFCWEST, LeagueID);
            NFCWest.DataBind();

            AFCEast.DataSource = TeamLogic.GetTeamsByDivisionAndLeague(Main.AFCEAST, LeagueID);
            AFCEast.DataBind();

            AFCNorth.DataSource = TeamLogic.GetTeamsByDivisionAndLeague(Main.AFCNORTH, LeagueID);
            AFCNorth.DataBind();

            AFCSouth.DataSource = TeamLogic.GetTeamsByDivisionAndLeague(Main.AFCSOUTH, LeagueID);
            AFCSouth.DataBind();

            AFCWest.DataSource = TeamLogic.GetTeamsByDivisionAndLeague(Main.AFCWEST, LeagueID);
            AFCWest.DataBind();
        }

        protected void TeamRow_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int teamID = Convert.ToInt32((e.Row.FindControl("TeamID") as HiddenField).Value);
                HyperLink teamLink = (e.Row.FindControl("TeamLink") as HyperLink);

                teamLink.NavigateUrl = "~/Teams/teamoffice.aspx?TeamID=" + teamID;
                teamLink.Text = TeamLogic.GetTeamName(teamID);
            }
        }
    }
}