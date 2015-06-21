using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealFootball.Logic;

namespace RealFootball
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LeaguesGrid.DataSource = LeagueLogic.GetLeagues();
            //LeaguesGrid.DataBind();
        }

        public void About_Click(object sender, EventArgs e)
        {
            
        }
    }
}