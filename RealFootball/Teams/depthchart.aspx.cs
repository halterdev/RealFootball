using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealFootball.Logic;

namespace RealFootball.Teams
{
    public partial class depthchart : System.Web.UI.Page
    {
        public int TeamID;
        public int LeagueID;
        public int TeamDetailsID;

        protected void Page_Load(object sender, EventArgs e)
        {
            TeamID = Convert.ToInt32(Request.QueryString["TeamID"]);
            LeagueID = SqlBuilder.SimpleGetInt("LeagueID", "Teams", "TeamID", TeamID.ToString());
            TeamDetailsID = SqlBuilder.SimpleGetInt("TeamDetailsID", "Teams", "TeamID", TeamID.ToString());
            SetPositions.NavigateUrl = "../Teams/setpositions.aspx?TeamID=" + TeamID;

            if (!IsPostBack)
            {
                ddlPositions.DataSource = PositionLogic.GetPositionsForDDL();
                ddlPositions.DataBind();
            }

            if (TeamID != 0)
            {
                lblTeamName.Text = TeamLogic.GetTeamName(TeamID);
                lblSeason.Text = "Season: " +
                    SqlBuilder.SimpleGetInt("SeasonNumber", "Leagues", "LeagueID", LeagueID.ToString());
                lblWeek.Text = "Off-Season";

                if (!TeamLogic.DoAllTeamsPlayersHavePositions(TeamID))
                {
                    ddlPositions.Enabled = false;
                    lblMustSetPositions.Visible = true;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;

                    // hide the dropdowns since not all players have positions
                    string posAbbr = SqlBuilder.SimpleGetString("Abbreviation", "Positions", "PositionID", ddlPositions.SelectedValue);
                    for (int i = 1; i < 8; i++)
                    {
                        Label lbl = FindControl("lbl" + i) as Label;
                        lbl.Visible = false;
                        DropDownList ddl = FindControl("ddl" + i) as DropDownList;
                        ddl.Visible = false;
                    }
                }
                else
                {
                    SetPageBasedOnPosition();
                }
            }
        }

        private void SetPageBasedOnPosition()
        {
            PlayersGrid.DataSource = PlayerLogic.GetPlayersByTeamAndPosition(TeamID, Convert.ToInt32(ddlPositions.SelectedValue));
            PlayersGrid.DataBind();

            string position = SqlBuilder.SimpleGetString("PositionName", "Positions", "PositionID", ddlPositions.SelectedValue);
            string posAbbr = SqlBuilder.SimpleGetString("Abbreviation", "Positions", "PositionID", ddlPositions.SelectedValue);

            // set the text of the labels based on number
            if (ShouldDepthChartRebind())
            {
                for (int i = 1; i < 8; i++)
                {
                    Label lbl = FindControl("lbl" + i) as Label;
                    lbl.Text = posAbbr + i + ": ";

                    DropDownList ddl = FindControl("ddl" + i) as DropDownList;
                    ddl.DataSource = PlayerLogic.GetPlayersByTeamAndPosition(TeamID, Convert.ToInt32(ddlPositions.SelectedValue));
                    ddl.DataBind();

                    int playerSetForPos = PlayerLogic.GetPlayerAtDepthChartPosition(TeamID, Convert.ToInt32(ddlPositions.SelectedValue), i);
                    if (playerSetForPos == 0)
                    {
                        // no player has been set yet
                        ddl.Items.Insert(0, new ListItem("-- Please Select --", "0"));
                        ddl.SelectedIndex = 0;
                    }
                    else
                    {
                        ddl.SelectedValue = Convert.ToString(playerSetForPos);
                    }
                }
            }
        }
        private bool ShouldDepthChartRebind()
        {
            // should only repopulate if the page is first loading or if the position was not changed
            bool result = false;
            if (IsPostBack)
            {
                string abbrev = SqlBuilder.SimpleGetString("Abbreviation", "Positions", "PositionID", ddlPositions.SelectedValue);
                if (!lbl1.Text.Contains(abbrev))
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
        protected void Save(object sender, EventArgs e)
        {
            // loop through the ddls and save the depthchartnumbers
            for (int i = 1; i < 8; i++)
            {
                DropDownList ddl = FindControl("ddl" + i) as DropDownList;
                PlayerLogic.UpdatePlayersDepthChartNumber(Convert.ToInt32(ddl.SelectedValue), i);
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