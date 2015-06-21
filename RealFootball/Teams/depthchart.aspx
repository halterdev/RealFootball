<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="depthchart.aspx.cs" Inherits="RealFootball.Teams.depthchart" %>

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
            <asp:LinkButton ID="Office" runat="server" CssClass="AnchorButton" Text="Office" OnClick="TeamOffice_Click"/>
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
            <div>
                <center>
                    <asp:Label ID="lblPosition" runat="server" ForeColor="Black" style="font-family:Arial" Text="Position: " />
                    <asp:DropDownList ID="ddlPositions" runat="server" DataTextField="PositionName" DataValueField="PositionID" AutoPostBack="true" />&nbsp;&nbsp;
                    <asp:HyperLink ID="SetPositions" runat="server" Text="Set Positions" /><br />
                    <asp:Label ID="lblMustSetPositions" runat="server" Text="All players must be assigned a position before continuing" 
                        ForeColor="red" Visible="false" />
                </center>
            </div>
            <br />
            <div style="float:left;width:99%;">
                <center>
                <asp:GridView ID="PlayersGrid" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="WhiteSmoke"  RowStyle-BackColor="#ffffcc"
                        AlternatingRowStyle-BackColor="#ccccff" AllowSorting="true" >
                    <Columns>
                        <asp:BoundField DataField="Player" HeaderText="Player" />
                        <asp:BoundField DataField="Speed" HeaderText="Speed" />
                        <asp:BoundField DataField="Strength" HeaderText="Strength" />
                        <asp:BoundField DataField="Elusiveness" headertext="Elusiveness" />
                        <asp:BoundField DataField="Intelligence" headertext="Intelligence" />
                        <asp:BoundField DataField="WorkEthic" headertext="WorkEthic" />
                        <asp:BoundField DataField="Jump" headertext="Jump" />
                        <asp:BoundField DataField="Agility" headertext="Agility" />
                        <asp:BoundField DataField="Juke" headertext="Juke" />
                        <asp:BoundField DataField="ArmAccuracy" headertext="ArmAccuracy" />
                        <asp:BoundField DataField="RouteRunning" headertext="RouteRunning" />
                        <asp:BoundField DataField="Hands" headertext="Hands" />
                        <asp:BoundField DataField="Blocking" headertext="Blocking" />
                        <asp:BoundField DataField="Tackling" headertext="Tackling" />
                        <asp:BoundField DataField="Coverage" headertext="Coverage" />
                        <asp:BoundField DataField="Kicking" headertext="Kicking" />
                        <asp:BoundField DataField="Punting" headertext="Punting" />
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:HiddenField id="PlayerID" runat="server" Value='<%# Eval("PlayerID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </center>
            </div>
            <br />
            <div style="float:left;width:99%">
                <br /><br />
                <center>
                    <asp:Label ID="lbl1" runat="server" />
                    <asp:DropDownList ID="ddl1" runat="server" DataValueField="PlayerID" DataTextField="Player" /><br />
                    <asp:Label ID="lbl2" runat="server" />
                    <asp:DropDownList ID="ddl2" runat="server" DataValueField="PlayerID" DataTextField="Player" /><br />
                    <asp:Label ID="lbl3" runat="server" />
                    <asp:DropDownList ID="ddl3" runat="server" DataValueField="PlayerID" DataTextField="Player" /> <br />
                    <asp:Label ID="lbl4" runat="server" Visible="false" />
                    <asp:DropDownList ID="ddl4" runat="server" DataValueField="PlayerID" DataTextField="Player" Visible="false"  /><br />
                    <asp:Label ID="lbl5" runat="server" Visible="false" />
                    <asp:DropDownList ID="ddl5" runat="server" Visible="false" DataValueField="PlayerID" DataTextField="Player" /><br />
                    <asp:Label ID="lbl6" runat="server" Visible="false" />
                    <asp:DropDownList ID="ddl6" runat="server" Visible="false" DataValueField="PlayerID" DataTextField="Player" /><br />
                    <asp:Label ID="lbl7" runat="server" Visible="false" />
                    <asp:DropDownList ID="ddl7" runat="server" Visible="false" DataValueField="PlayerID" DataTextField="Player" /><br />
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="Save" />&nbsp;&nbsp
                    <asp:Button ID="btnCancel" runat="server" Text="CANCEL" />
                </center>
            </div>
        </div>
    </form>
</body>
</html>
