<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leagues.aspx.cs" Inherits="RealFootball.leagues" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="LeaguesGrid" runat="server" AutoGenerateColumns="true" OnRowDataBound="LeaguesGrid_DataBind"></asp:GridView>
    </div>
    </form>
</body>
</html>
