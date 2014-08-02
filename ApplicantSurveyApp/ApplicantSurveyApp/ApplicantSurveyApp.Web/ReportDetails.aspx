<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDetails.aspx.cs" Inherits="ApplicantSurveyApp.Web.Admin.ReportDetails" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%" AsyncRendering="False" SizeToReportContent="True" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" WaitControlDisplayAfter="10000">
            <serverreport reportserverurl="http://makapp64vs/ReportServer_MSSQLSERVER2012/" />

        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
