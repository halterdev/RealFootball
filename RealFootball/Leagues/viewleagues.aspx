<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RealFootball._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Real Football</title>
    <link rel="stylesheet" type="text/css" href="main.css" />
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/style2.css" />
    <script type="text/javascript" src="js/modernizr.custom.28468.js"></script>
    <link href='http://fonts.googleapis.com/css?family=Economica:700,400italic' rel='stylesheet' type='text/css'>
    <noscript>
			<link rel="stylesheet" type="text/css" href="css/nojs.css" />
    </noscript>
</head>
<body>
    <form id="form1" runat="server">
    <div class="head">
        <div class="headPullLeft">
            <asp:Button ID="btnHome" Text="Home" runat="server" CssClass="btn" /> &nbsp; &nbsp;
            <asp:Button ID="btnAbout" Text="About" runat="server" CssClass="btn" OnClick="About_Click" />
        </div>
        <div class="headPullRight">
            <asp:Button ID="btnSignup" Text="Sign Up" runat="server" CssClass="btn" /> &nbsp; &nbsp;
            <asp:Button ID="btnLogin" Text="Login" runat="server" CssClass="btn" />
        </div>
    </div>
        <br /><br />
    <div id="da-slider" class="da-slider">
				<div class="da-slide">
					<h2>Leagues</h2>
					<p>Get started by selecting one of the current leagues to the right of the screen. If no Leagues are open, be sure to check back periodically.</p>
					
					<div class="da-box">
                        <asp:GridView ID="LeaguesGrid" runat="server" AutoGenerateColumns="true"></asp:GridView>
					</div>
				</div>
	</div>
    </form>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
		<script type="text/javascript" src="js/jquery.cslider.js"></script>
		<script type="text/javascript">
		    $(function () {

		        $('#da-slider').cslider();

		    });
		</script>	
</body>
</html>
