<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popup.aspx.cs" Inherits="popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/UserControls/signatoryDetails.ascx" TagName="Signatory" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Popup/jquery.min.js" type="text/javascript"></script>
    <script src="Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="Popup/jquery-ui.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        $("#dialog").dialog({
            title: "Signatory Details                         ",
            buttons: {
                Close: function () {
                    $(this).dialog('close');
                }
            }
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dialog" style="display: none; width:600px">
    <asp:Signatory ID="s1" runat="server" />
    </div>
    </form>
</body>
</html>
