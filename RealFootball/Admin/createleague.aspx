<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createleague.aspx.cs" Inherits="RealFootball.Admin.createleague" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <asp:TextBox ID="LeagueName" runat="server" /><br />
            <asp:Button ID="CreateLeague" runat="server" Text="Create" OnClick="Create_Click" />
        </center>
    </div>
    </form>
</body>
</html>
