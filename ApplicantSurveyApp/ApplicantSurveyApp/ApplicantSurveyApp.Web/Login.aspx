<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ApplicantSurveyApp.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    User Name:
    <asp:TextBox runat="server" ID="txtUserName" Text="ADSDELTEKCOM\"></asp:TextBox>
    <br /> 
    Password: 
    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Label runat="server" ID="labelResult"></asp:Label>
    <asp:Button ID="btnLogin" runat="server" Text="Submit" OnClick="btnLogin_Click" />
</asp:Content>
