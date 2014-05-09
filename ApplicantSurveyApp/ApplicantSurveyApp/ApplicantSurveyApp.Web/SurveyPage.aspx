<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableViewState="true" CodeBehind="SurveyPage.aspx.cs" Inherits="ApplicantSurveyApp.Web.SurveyPage" MaintainScrollPositionOnPostback="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
        <hgroup class="title">
         <h2>
                Deltek Applicant Experience Survey
         </h2>
        </hgroup>  
        </div>
    </section>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server"> 
 <div class="float-left"> 
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="applicantInformationView" runat="server" OnDeactivate="ApplicantInformationView_Deactivate" OnActivate="ApplicantInformationView_Activate">
               <br />
             <b>
                Applicant Information
            </b>
            <table>
                <tr>  
                    <td>
                        <asp:TextBox runat="server" ID="firstNameTextBox" CssClass="firstNameTextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="firstNameRequiredFieldValidator" ControlToValidate="firstNameTextBox" ErrorMessage="First name required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td> 
                </tr>
                <tr>  
                    <td>
                        <asp:TextBox runat="server" ID="lastNameTextBox" CssClass="lastNameTextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="lastNameRequiredFieldValidator" ControlToValidate="lastNameTextBox" ErrorMessage="Last name required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td> 
                </tr>
            </table>
          
        </asp:View>
        <asp:View ID="questionView" runat="server" >
                 <asp:Label runat="server" ID="countLabel"></asp:Label>
            <table>
                <tr>
                    <td>
                        <b>
                            <asp:Label runat="server" ID="questionLabel" Text=""></asp:Label>
                        </b>
                    </td> 
                </tr>
                <tr>
                    <td>
                        <div class="float-left">
                            <div runat="server" id="ImageButtonsDiv" class="ImageButtonsDivCss"> 
                            </div> 
                            <asp:TextBox runat="server" ID="commentsTextBox" TextMode="MultiLine" Width="250px" Height="50px">
                            </asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    <div class="float-left">
        <asp:ImageButton runat="server" ID="backImageButton"  ImageUrl="~/Images/back.png" CssClass="NavigationButtons" AlternateText="Back" OnClick="backImageButton_Click"/>
        <asp:ImageButton runat="server" ID="nextImageButton" CausesValidation="true" AlternateText="Next" ImageUrl="~/Images/next.png"  CssClass="NavigationButtons" OnClick="nextImageButton_Click"/>
        <asp:ImageButton runat="server" ID="submitImageButton" AlternateText="Submit" ImageUrl="~/Images/submit.png"  CssClass="NavigationButtons" OnClick="submitImageButton_Click"/>
    </div>             
</div>
    

<script type="text/javascript" src="Scripts/WebForms/jquery.watermark.min.js"></script>
<script type="text/javascript" > 
    $(document).ready(function () {
        $('.firstNameTextBox').watermark('First Name', {useNative : false});
        $('.lastNameTextBox').watermark('Last Name', {useNative : false});
             
        });
</script>
<style type="text/css">
    .ImageButtonsDivCss {
        margin-right:100px;
        max-height:450px;
    }
    .NavigationButtons {
        height:40px;
        width:60px;
        margin: 0; 
        padding: 0; 
        border: 0; 
    }
    .imgButtonImg 
    {
    margin: 0; 
    padding: 0; 
    border: 0; 
    } 
</style>
</asp:Content>
