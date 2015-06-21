<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RealFootball._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Real Football</title>
    <link rel="stylesheet" type="text/css" href="main.css" />
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
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
            <asp:HyperLink ID="ViewLeagues" Text="LEAGUES" runat="server" NavigateUrl="~/leagues.aspx" ForeColor="white" />
        </div>
        <div class="headPullRight">
            <asp:Button ID="btnSignup" Text="Sign Up" runat="server" CssClass="btn" /> &nbsp; &nbsp;
            <asp:Button ID="btnLogin" Text="Login" runat="server" CssClass="btn" /> &nbsp;&nbsp;
            <asp:HyperLink ID="AdminLink" Text="ADMIN" runat="server" NavigateUrl="~/Admin/admin.aspx" ForeColor="white" />
        </div>
    </div>
        <br /><br />
    <div id="da-slider" class="da-slider">
				<div class="da-slide">
					<h2>Real Football</h2>
					<p>Real Football is an online, multiplayer simulation football game. This is your chance to take over a professional football franchise and take it to the top of the football world.</p>
					<a href="leagues.aspx" class="da-link">Get Started</a>
					<div class="da-img"><img src="images/1.png" alt="image01" /></div>
				</div>
				<div class="da-slide">
					<h2>32 Teams, One Prize</h2>
					<p>Just like the pro-style football you're accustomed to. 32 teams split up into two conferences, the Natural Football League (NFC) and the Artifical Football League (AFC). Four divisions
                        in each conference. Compete for a playoff spot and take home a championship.
					</p>
					<a href="#" class="da-link">Read more</a>
					<div class="da-img"><img src="images/2.png" alt="image01" /></div>
				</div>
				<div class="da-slide">
					<h2>Build Your Resume</h2>
					<p>Build your resume up like a real coach. Work your way up the ranks and eventually land your dream job.</p>
					<a href="#" class="da-link">Read more</a>
					<div class="da-img"><img src="images/3.png" alt="image01" /></div>
				</div>
				<div class="da-slide">
					<h2>Community</h2>
					<p>The Real Football community is a competitive, fun, football-oriented environment. Talk trash, strategy and more on the forums.</p>
					<a href="#" class="da-link">Read more</a>
					<div class="da-img"><img src="images/4.png" alt="image01" /></div>
				</div>
				<nav class="da-arrows">
					<span class="da-arrows-prev"></span>
					<span class="da-arrows-next"></span>
				</nav>
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
