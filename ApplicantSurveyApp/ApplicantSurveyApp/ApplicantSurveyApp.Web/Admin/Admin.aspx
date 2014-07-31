<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ApplicantSurveyApp.Web.Admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 750px;
            height: 180px;
            margin-right: 0px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
   <link rel="stylesheet" href="../Content/chosen.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div id="loadingDiv">
          <b>Generating report please wait.... </b>
          <img src="../Images/LoadingBar.gif" />
      </div>
      <div id="doneDiv">
          <b>
              Download complete.
          </b>
      </div>
  <br />
    <select data-placeholder="Please select a report..." id="selectReports" class="chosen-select" style="width:350px;" tabindex="2">
        <option value=""></option>
        <option value="SurveyStatistics">Statistics Report</option>
        <option value="SurveyPercentage">Percentage Report</option>
        <option value="CommentsAndPositionCount">Comments and Position Count Report</option>
    </select> 
    
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js" ></script>  
    <script type="text/javascript" src="../Scripts/WebForms/chosen.jquery.js" ></script>  

        <script type="text/javascript">
            //Get Images
            $(document).ready(function () {

                var $loading = $('#loadingDiv').hide();
                var $doneDiv = $('#doneDiv').hide();

                $('#selectReports').chosen('selectReports');
                $('#selectReports').val('');

                $(document)
                  .ajaxStart(function () {
                      $loading.show();
                      $doneDiv.hide();
                  })
                .ajaxComplete(function () {
                    $doneDiv.show();
                    $loading.hide();
                });

                $('#selectReports').change(function () {

                    if ($('#selectReports').val() == "") {
                        alert('Please select report');
                        return;
                    }

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "Admin.aspx/GetReport",
                        data: JSON.stringify({ reportName: $('#selectReports').val() }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            //window.location.href = response.d;
                            window.open(response.d, '_blank');
                        },
                        failure: function (msg) {
                            alert(msg.d);
                        }
                    });

                });
        
            });
 
    </script>
     <br />
     <br />
    <b>
         Steps on opening the file:<br />
         <br />
         1.)
        <br />
         <img alt="" class="auto-style1" src="../Images/csv_Step1.png" />
        <br />
        <br />
        2.)
        <br />
         <img alt="" class="auto-style1" src="../Images/csv_Step2.png" />
        <br />
        <br />
        3.)
        <br />
         <img alt="" class="auto-style1" src="../Images/csv_Step3.png" />

    </b>
</asp:Content>
