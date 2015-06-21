<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="RealFootball.Admin.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div style="text-align:center; margin-top:10%; width:15%; border:groove;">
            <asp:Button ID="CreateLeague" runat="server" Text="Create League" OnClick="CreateLeague_Click" />
        </div>
    </center>
    </form>
</body>
</html>
