using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealFootball.Logic;

namespace RealFootball.Teams
{
    public partial class setpositions : System.Web.UI.Page
    {
        public int TeamID;
        public int LeagueID;
        public int TeamDetailsID;

        protected void Page_Load(object sender, EventArgs e)
        {
            TeamID = Convert.ToInt32(Request.QueryString["TeamID"]);
            TeamDetailsID = SqlBuilder.SimpleGetInt("TeamDetailsID", "Teams", "TeamID", TeamID.ToString());
            LeagueID = SqlBuilder.SimpleGetInt("LeagueID", "Teams", "TeamID", TeamID.ToString());

            if (!IsPostBack)
            {
                ddlPositions.DataSource = PositionLogic.GetPositionsForDDL();
                ddlPositions.DataBind();
                ddlPositions.Items.Insert(0, new ListItem("Players w/out positions", "0"));
            }

            if (TeamID != 0)
            {
                lblTeamName.Text = TeamLogic.GetTeamName(TeamID);
                lblSeason.Text = "Season: " +
                    SqlBuilder.SimpleGetInt("SeasonNumber", "Leagues", "LeagueID", LeagueID.ToString());
                lblWeek.Text = "Off-Season";
            }

            if (ShouldGridRepopulate())
            {
                SetPositionsGrid();
            }
        }

        private void SetPositionsGrid()
        {
            PlayersGrid.DataSource = PlayerLogic.GetPlayersByTeamAndPosition(TeamID, Convert.ToInt32(ddlPositions.SelectedValue));
            PlayersGrid.DataBind();

            for (int i = 0; i < PlayersGrid.Rows.Count; i++)
            {
                int playerID = Convert.ToInt32((PlayersGrid.Rows[i].Cells[16].FindControl("PlayerID") as HiddenField).Value);
                DropDownList ddlPos = (DropDownList)PlayersGrid.Rows[i].Cells[16].FindControl("ddlPos");
                ddlPos.DataSource = PositionLogic.GetPositionAbbreviationsForDDL();
                ddlPos.DataBind();
                ddlPos.Items.Insert(0, new ListItem("N/A", "0"));
                
                ddlPos.SelectedValue = Convert.ToString(SqlBuilder.SimpleGetInt("PositionID", "Players", "PlayerID", playerID.ToString()));
            }
        }
        private bool ShouldGridRepopulate()
        {
            // grid should only repopulate if the page is first loading or if the position was not changed
            bool result = false;
            if (IsPostBack)
            {
                if (PlayersGrid.Rows.Count > 0)
                {
                    int playerID = Convert.ToInt32((PlayersGrid.Rows[0].Cells[16].FindControl("PlayerID") as HiddenField).Value);
                    int positionID = SqlBuilder.SimpleGetInt("PositionID", "Players", "PlayerID", playerID.ToString());
                    if (positionID != Convert.ToInt32(ddlPositions.SelectedValue))
                    {
                        result = true;
                    }
                }
                else
                {
                    result = true;
                }
            }
            else
            {
                result = true;
            }
            return result;
        }

        protected void PlayersGrid_DataBound(object sender, GridViewRowEventArgs e)
        {
            GridView grid = (GridView)sender;
            int index = grid.Rows.Count - 1;
        }
        protected void Save(object sender, EventArgs e)
        {
            for (int i = 0; i < PlayersGrid.Rows.Count; i++)
            {
                int playerID = Convert.ToInt32((PlayersGrid.Rows[i].Cells[16].FindControl("PlayerID") as HiddenField).Value);
                DropDownList ddlPos = (DropDownList)PlayersGrid.Rows[i].Cells[16].FindControl("ddlPos");
                PlayerLogic.UpdatePlayerPosition(playerID, Convert.ToInt32(ddlPos.SelectedValue));
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