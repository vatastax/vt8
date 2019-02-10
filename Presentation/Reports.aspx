<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Presentation_Reports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
        <link href="../css/big_box_style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:Button ID="btnback" runat="server" Text="Back" Class="button" 
            onclick="btnback_Click" Visible="false" />
    </div>
       <div class="row" id="divErrMsg" runat="server" visible="false">
       <br />
       <br />
         <br />
       <br />  <br />
       <br />  <br />
       <br />  <br />
       <br />
                       <div class="large-12 columns">
                       <div class="login-wrap">
                                    <div class="row">
                                        <div class="large-12 columns">
                                        <center>
                                    <p>Please Generate XML.<br />
                                    for ITR Preview.<br /><br />
                                        <asp:Button ID="btnGenerate" runat="server" Text="Generate XML" 
                                            onclick="btnGenerate_Click" class="button radius" /></p>
                                    </center>
                                        </div>
                                    </div>
                                    </div>
                       </div>
                       </div>
    </form>
</body>
</html>
