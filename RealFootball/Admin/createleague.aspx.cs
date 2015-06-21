using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealFootball.Logic;

namespace RealFootball.Admin
{
    public partial class createleague : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Create_Click(object sender, EventArgs e)
        {
            int leagueID = LeagueLogic.CreateLeague(LeagueName.Text);
            Response.Redirect("~/Leagues/leagueoverview.aspx?LeagueID=" + leagueID);
        }
    }
}