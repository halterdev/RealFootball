<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leagueoverview.aspx.cs" Inherits="RealFootball.leagueoverview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center; height:5%; font-family:Arial;">
            <asp:Label ID="lblLeagueName" runat="server" />
        </div>
        <br />
        <div style="width:45%; float:left">
            <div style="float:left">
                <asp:GridView ID="NFCEast" runat="server" AutoGenerateColumns="false" OnRowDataBound="TeamRow_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="NFC East" HeaderStyle-Width="150px">
                            <ItemTemplate>
                                <asp:HyperLink ID="TeamLink" runat="server" />
                                <asp:HiddenField ID="TeamID" runat="server" Value='<%# Eval("TeamID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Wins" HeaderText="Wins" />
                        <asp:BoundField DataField="Losses" HeaderText="Losses" />
                        <asp:BoundField DataField="Ties" HeaderText="Ties" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>
            <div style="float:right">
                <asp:GridView ID="NFCNorth" runat="server" AutoGenerateColumns="false" OnRowDataBound="TeamRow_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="NFC East" HeaderStyle-Width="150px">
                            <ItemTemplate>
                                <asp:HyperLink ID="TeamLink" runat="server" />
                                <asp:HiddenField ID="TeamID" runat="server" Value='<%# Eval("TeamID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Wins" HeaderText="Wins" />
                        <asp:BoundField DataField="Losses" HeaderText="Losses" />
                        <asp:BoundField DataField="Ties" HeaderText="Ties" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>
            
            <div style="float:left">
                <asp:GridView ID="NFCSouth" runat="server" AutoGenerateColumns="false" OnRowDataBound="TeamRow_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="NFC East" HeaderStyle-Width="150px">
                            <ItemTemplate>
                                <asp:HyperLink ID="TeamLink" runat="server" />
                                <asp:HiddenField ID="TeamID" runat="server" Value='<%# Eval("TeamID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Wins" HeaderText="Wins" />
                        <asp:BoundField DataField="Losses" HeaderText="Losses" />
                        <asp:BoundField DataField="Ties" HeaderText="Ties" />
                    </Columns>
                </asp:GridView>
            </div>
            <div style="float:right">
                <asp:GridView ID="NFCWest" runat="server" AutoGenerateColumns="false" OnRowDataBound="TeamRow_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="NFC East" HeaderStyle-Width="150px">
                            <ItemTemplate>
                                <asp:HyperLink ID="TeamLink" runat="server" />
                                <asp:HiddenField ID="TeamID" runat="server" Value='<%# Eval("TeamID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Wins" HeaderText="Wins" />
                        <asp:BoundField DataField="Losses" HeaderText="Losses" />
                        <asp:BoundField DataField="Ties" HeaderText="Ties" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div style="width:45%; float:right;">
            <div style="float:left">
                <asp:GridView ID="AFCEast" runat="server" AutoGenerateColumns="false" OnRowDataBound="TeamRow_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="NFC East" HeaderStyle-Width="170px">
                            <ItemTemplate>
                                <asp:HyperLink ID="TeamLink" runat="server" />
                                <asp:HiddenField ID="TeamID" runat="server" Value='<%# Eval("TeamID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Wins" HeaderText="Wins" />
                        <asp:BoundField DataField="Losses" HeaderText="Losses" />
                        <asp:BoundField DataField="Ties" HeaderText="Ties" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>
            <div style="float:right">
                <asp:GridView ID="AFCNorth" runat="server" AutoGenerateColumns="false" OnRowDataBound="TeamRow_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="NFC East" HeaderStyle-Width="150px">
                            <ItemTemplate>
                                <asp:HyperLink ID="TeamLink" runat="server" />
                                <asp:HiddenField ID="TeamID" runat="server" Value='<%# Eval("TeamID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Wins" HeaderText="Wins" />
                        <asp:BoundField DataField="Losses" HeaderText="Losses" />
                        <asp:BoundField DataField="Ties" HeaderText="Ties" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>
            
            <div style="float:left">
                <asp:GridView ID="AFCSouth" runat="server" AutoGenerateColumns="false" OnRowDataBound="TeamRow_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="NFC East" HeaderStyle-Width="170px">
                            <ItemTemplate>
                                <asp:HyperLink ID="TeamLink" runat="server" />
                                <asp:HiddenField ID="TeamID" runat="server" Value='<%# Eval("TeamID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Wins" HeaderText="Wins" />
                        <asp:BoundField DataField="Losses" HeaderText="Losses" />
                        <asp:BoundField DataField="Ties" HeaderText="Ties" />
                    </Columns>
                </asp:GridView>
            </div>
            <div style="float:right">
                <asp:GridView ID="AFCWest" runat="server" AutoGenerateColumns="false" OnRowDataBound="TeamRow_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="NFC East" HeaderStyle-Width="140px">
                            <ItemTemplate>
                                <asp:HyperLink ID="TeamLink" runat="server" />
                                <asp:HiddenField ID="TeamID" runat="server" Value='<%# Eval("TeamID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Wins" HeaderText="Wins" />
                        <asp:BoundField DataField="Losses" HeaderText="Losses" />
                        <asp:BoundField DataField="Ties" HeaderText="Ties" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
