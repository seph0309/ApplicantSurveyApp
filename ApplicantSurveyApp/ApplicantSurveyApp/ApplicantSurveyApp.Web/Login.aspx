<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ApplicantSurveyApp.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <section class="featured">
        <div class="content-wrapper">
        <hgroup class="title">
         <h2>
                Login
         </h2>
        </hgroup>  
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                User Name:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtUserName" Text="ADSDELTEKCOM\"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" ForeColor="Red" ControlToValidate="txtUserName" runat="server" ErrorMessage="UserName Required "></asp:RequiredFieldValidator>
            </td>            
        </tr>   
        <tr>
            <td>
                Password:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" ForeColor="Red" ControlToValidate="txtPassword" runat="server" ErrorMessage="Password Required "></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label runat="server" ForeColor="Red" ID="labelResult"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Submit" OnClick="btnLogin_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
