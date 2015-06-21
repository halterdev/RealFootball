<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teamoffice.aspx.cs" Inherits="RealFootball.Teams.teamoffice" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="top">
            <asp:Label ID="lblTeamName" runat="server" CssClass="HeaderLabel" />
        </div>
        <br />
        <div class="anchor">
            <asp:LinkButton ID="Office" runat="server" CssClass="AnchorButton" Text="Office" OnClick="TeamOffice_Click" />
            <asp:LinkButton ID="DepthChart" runat="server" CssClass="AnchorButton" Text="Depth Chart" OnClick="DepthChart_Click" />
            <asp:LinkButton ID="Schedule" runat="server" CssClass="AnchorButton" Text="Schedule" />
            <asp:LinkButton ID="Standings" runat="server" CssClass="AnchorButton" Text="Standings" />
            <asp:LinkButton ID="SignOut" runat="server" Text="Sign Out" CssClass="AnchorButtonRight" />
            <asp:LinkButton ID="Forum" runat="server" Text="Forum" CssClass="AnchorButtonRight" />
        </div>
        <br />
        <div class="underAnchor">
            <asp:Label ID="lblSeason" runat="server" CssClass="UnderAnchorLabel" />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblWeek" runat="server" CssClass="UnderAnchorLabel" />
        </div>
        <br /><br />
        <div class="main">
            <div style="float:left; width:50%">
                    <%--<center>
                <asp:Label ID="Roster" runat="server" Text="Roster" style="display:inline-block; vertical-align:central; 
                    font-family:Arial; color:black" Font-Bold="true" />
                 </center>--%>
                <asp:GridView ID="RosterGrid" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="WhiteSmoke"  RowStyle-BackColor="#ffffcc"
                        AlternatingRowStyle-BackColor="#ccccff">
                    <Columns>
                        <asp:BoundField DataField="Player" HeaderText="Player" ItemStyle-Width="20%" />
                        <asp:BoundField DataField="Position" HeaderText="Position" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                        <asp:BoundField DataField="Hometown" HeaderText="Hometown" ItemStyle-Width="30%" />
                        <asp:BoundField DataField="College" HeaderText="College" ItemStyle-Width="30%" />
                    </Columns>
                </asp:GridView>
            </div>
            <div style="float:right; margin-right:2%; width:30%">
                <div style="border-style:groove; border-radius:4%; padding-left:2px; padding-bottom:2px">
                    <center>
                        <asp:Label ID="lblCoachOverview" runat="server" ForeColor="Black" style="font-family:Arial" Font-Bold="true"
                            Text="Coaching Status" />
                    </center>
                        <asp:Label ID="lblJobStatus" runat="server" ForeColor="Black" style="font-family:Arial" Text="Job Status: Moderate" /><br />
                        <asp:Label ID="lblSeasonsWithTeam" runat="server" ForeColor="Black" style="font-family:Arial" />
                </div>

                <br /><br />

                <div style="border-style:groove; border-radius:4%; padding-left:2px; padding-bottom:2px">
                    <center>
                    <asp:Label ID="lblSeasonOverview" runat="server" Text="Season Overview" Font-Bold="true" ForeColor="Black"
                            style="font-family:Arial" /><br />
                    </center>
                    <asp:Label ID="lblCurrentRecord" runat="server" forecolor="Black" style="font-family:Arial" /><br />
                    <asp:Label ID="lblPreviousGame" runat="server" ForeColor="Black" style="font-family:Arial" Text="Previous Game: N/A" /><br />
                    <asp:Label ID="lblNextGame" runat="server" ForeColor="Black" style="font-family:Arial" Text="Next Game: N/A" />
                </div>

                <br /><br />

                <div style="border-style:groove; border-radius:4%; padding-left:2px; padding-bottom:2px">
                    <center>
                    <asp:Label ID="lblTeamInfo" runat="server" Text="Team Summary" ForeColor="Black" Font-Bold="true" style="font-family:Arial" /><br />
                        </center>
                    <asp:Label ID="lblLocation" runat="server" ForeColor="Black" style="font-family:Arial" /><br />
                    <asp:Label ID="lblChampionships" runat="server" ForeColor="Black" style="font-family:Arial" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
