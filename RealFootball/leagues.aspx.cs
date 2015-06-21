using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealFootball.Logic;

namespace RealFootball
{
    public partial class leagues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeaguesGrid.DataSource = LeagueLogic.GetLeagues();
            LeaguesGrid.DataBind();
        }

        protected void LeaguesGrid_DataBind(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int ID = Convert.ToInt32(e.Row.Cells[1].Text);
                e.Row.Cells[1].Text = "<a href=\"Leagues/leagueoverview.aspx?LeagueID=" + ID + "\">VIEW</a>";
            }
        }
    }
}