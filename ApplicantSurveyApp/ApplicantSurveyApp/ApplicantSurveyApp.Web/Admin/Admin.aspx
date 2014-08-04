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
        <section class="featured">
        <div class="content-wrapper">
        <hgroup class="title">
         <h2>
                Admin Page
         </h2>
        </hgroup>  
        </div>
    </section>
   <link rel="stylesheet" href="../Content/chosen.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <br />
  <br />
    Reminder: be sure to turn off the pop-up blocker for you to open the reports.
  <br />
    <select data-placeholder="Please select a report..." id="selectReports" class="chosen-select" style="width:450px;" tabindex="2">
        <option value=""></option>
    </select> 
    
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js" ></script>  
    <script type="text/javascript" src="../Scripts/WebForms/chosen.jquery.js" ></script>  

        <script type="text/javascript">
            //Get Images

            function popupwindow(url, title, w, h) {
                var left = (screen.width / 2) - (w / 2);
                var top = (screen.height / 2) - (h / 2);
                return window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
            }

            //Populate dropdown
            $.ajax({
                type: "POST",
                async: false,
                url: "Admin.aspx/GetReportNames",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    for (var index = 0 ; index < response.d.length; index++)
                    {
                        $('#selectReports').append(
                            $('<option></option>').val(response.d[index].replace(/\s+/g, '')).html(response.d[index])
                            );
                    }
                },
                failure: function (msg) {
                    alert(msg.d);
                }
            });

            $(document).ready(function () {
                 
                $('#selectReports').chosen('selectReports');
                $('#selectReports').val('');
                 
                $('#selectReports').change(function () {

                    if ($('#selectReports').val() == "") {
                        alert('Please select report');
                        return;
                    }
                    var selectedReport = $('#selectReports option:selected').text();

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "Admin.aspx/ViewReport",
                        data: JSON.stringify({ reportName: selectedReport}),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) { 
                            popupwindow(response.d, selectedReport, 1040, 480)
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
     <br /> 
     <br /> 
     <br /> 
     <br /> 
     <br /> 
</asp:Content>
