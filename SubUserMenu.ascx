<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubUserMenu.ascx.cs" Inherits="SubUserMenu" %>

<%@ Register Src="~/UserControls/FileUploadDirectoryCtrk.ascx" TagPrefix="fileupload" TagName="fu"  %>

<script src="../Popup/jquery.min.js" type="text/javascript"></script>
    <script src="../Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="../Popup/jquery-ui.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(document).ready(function ($) {
        $('#aProfile').click(function () {
            $("#popupdiv").dialog({
                title: "Error Message",
                width: 430,
                height: 200,
                modal: true,
                buttons: { Yes: function () {
                    window.location = "saveAssessee.aspx?wx=1"

                },
                    No: function () {
                        //$(this).dialog('close');
                        window.location = "saveAssessee.aspx"
                    },
                    Cancel: function () {
                        $(this).dialog('close');
                    }
                }
            });

        });

        $('#a2').click(function () {
            $("#popupdiv").dialog({
                title: "Error Message",
                width: 430,
                height: 200,
                modal: true,
                buttons: { Yes: function () {
                    window.location = "saveAssessee.aspx?wx=1"

                },
                    No: function () {
                        //$(this).dialog('close');
                        window.location = "saveAssessee.aspx"
                    },
                    Cancel: function () {
                        $(this).dialog('close');
                    }
                }
            });

        });

    });

    $(document).ready(function ($) {
        $('#Submenu2_aAY').click(function () {
            $("#popupdiv").dialog({
                title: "Error Message",
                width: 430,
                height: 200,
                modal: true,
                buttons: { Yes: function () {
                    window.location = "saveAssessee.aspx?wx=1&ay=1"

                },
                    No: function () {
                        //$(this).dialog('close');
                        window.location = "saveAssessee.aspx?ay=1"
                    },
                    Cancel: function () {
                        $(this).dialog('close');
                    }
                }
            });

        });

    });

    $(document).ready(function ($) {
        $('#Submenu2_aAY2').click(function () {
            $("#popupdiv").dialog({
                title: "Error Message",
                width: 430,
                height: 200,
                modal: true,
                buttons: { Yes: function () {
                    window.location = "saveAssessee.aspx?wx=1&ay=1"

                },
                    No: function () {
                        //$(this).dialog('close');
                        window.location = "saveAssessee.aspx?ay=1"
                    },
                    Cancel: function () {
                        $(this).dialog('close');
                    }
                }
            });

        });

        $('#Submenu2_a1').click(function () {
            $("#popupdiv").dialog({
                title: "Error Message",
                width: 430,
                height: 200,
                modal: true,
                buttons: { Yes: function () {
                    window.location = "saveAssessee.aspx?wx=1&ay=1"

                },
                    No: function () {
                        //$(this).dialog('close');
                        window.location = "saveAssessee.aspx?ay=1"
                    },
                    Cancel: function () {
                        $(this).dialog('close');
                    }
                }
            });

        });

    });

    $(document).ready(function ($) {
        $('#aFiles').click(function () {
            $("#popup_Files").dialog({
                title: "Error Message",
                width: 430,
                height: 700,
                modal: true,
                buttons: { Yes: function () {
                    window.location = "saveAssessee.aspx?wx=1&ay=1"

                },
                    No: function () {
                        //$(this).dialog('close');
                        window.location = "saveAssessee.aspx?ay=1"
                    },
                    Cancel: function () {
                        $(this).dialog('close');
                    }
                }
            });

        });

    });

    $(document).ready(function ($) {
        $('#aLogout').click(function () {
            $("#divLogout").dialog({
                title: "Session Out Message",
                width: 330,
                height: 250,
                modal: true,
                buttons: { Yes: function () {
                    TimerStopBit = 1;
                    $(this).dialog('close');
                },
                    No: function () {
                        window.location = "Logout.aspx"
                    }
                }
            });

        });

    });

    function openFU() {
        try {
            alert('clicked');
            document.getElementById('btnPopupFU').click();
        }
        catch (e)
        { alert(e); }
    }

    function showFUPop() {
        //alert('show popup');
        try {
            if (document.getElementById('popup_Files') != null)
                document.getElementById('popup_Files').style.display = 'block';
        } catch (e) { alert(e); }
    }

    function gotoMain() {
        $(document).ready(function () {
            $("aProfile").click();
        });
        
    }
</script>
<%
    string IfVType = "";
    if (Request.QueryString["VType"] != null)
    {
        if (Request.QueryString["VType"].ToString() != "106")
        {
            IfVType = "Fine";
        }
    }
    else
    {
        IfVType = "Fine";
    }
    if (IfVType == "Fine")
    {
        %>
<asp:Literal ID="ltMain" runat="server" Visible="false"> </asp:Literal>
  <% 
        string strIsMaster = "";
        if (Session["IsMaster"] != null)
        {
            if (Session["IsMaster"].ToString() != "1")
            {
                strIsMaster = "0";
                  %>    
    <%}
        }
        else if (Session["IsMaster"] == null)
        {
            strIsMaster = "0";
        }
        if(strIsMaster=="0"){
        %>
        <div style="font-size:small; background-color:white; color:#494e6b;  margin-left:5px;">
    <table  style="font-size:small; background-color:white; color:#494e6b;margin-bottom: 0px;">
    <tr >
    <td style=" color:#494e6b;padding-top: 5px; padding-bottom:5px">Name:</td>
    <td style=" color:#494e6b;padding-top: 5px;padding-bottom:5px"><asp:Label ID="lblUser" runat="server" Font-Bold="true" Font-Size="12px"  Text="No Assessee" ForeColor="#494e6b" style=" font-size:12px; color:#494E6B; font-weight:bold " ></asp:Label></td>
    </tr>
      <tr>
    <td style=" color:#494e6b;padding-top: 5px;padding-bottom:5px" ><asp:Literal ID="ltTitle" runat="server" Text="PAN"></asp:Literal>:</td>
    <td style=" color:#494e6b;padding-top: 5px;padding-bottom:5px"><asp:Label ID="lblPAN" runat="server" Font-Bold="true" Font-Size="12px" Text="" ForeColor="#494e6b" style=" font-size:12px; color:#494E6B; font-weight:bold " ></asp:Label></td>
    </tr>
    <tr >
    <td style=" color:#494e6b;padding-top: 5px;padding-bottom:5px" >AY:</td>
    <td style=" color:#494e6b;padding-top: 5px;padding-bottom:5px"> <asp:Label ID="lblAY" runat="server" Font-Bold="true" Font-Size="12px" Text="" ForeColor="#494e6b" style=" font-size:12px; color:#494E6B; font-weight:bold " ></asp:Label></td>
    </tr>
    <tr>
    <td style="padding-top: 5px;padding-bottom:5px; font-size:13px"> Change:
   
  
<%--<asp:LinkButton ID="lbtnEditProf" runat="server" Text="Edit Profile" OnClick="lbtnEditProf_Click" ToolTip="Click this link to Change Current Profile Details" style="color:rgba(25, 185, 154, 0.97); font-size:13px" ForeColor="White">
</asp:LinkButton>--%></td><%--<%}
        } %>--%>
<td style="padding-top: 5px;padding-bottom:5px">
<%
        if (Session["IsMaster"] != null && Session["Account_Type"] != null)
        {
            if (Session["IsMaster"].ToString() != "1" && Session["Account_Type"].ToString() == "S")
            {  
     %>
<a id="aAY" runat="server"   title="Change Assessment Year" style="color:rgba(25, 185, 154, 0.97); font-size:13px" >
            Assessment Year
            
</a>
 
 <% }
    else if (Session["IsMaster"].ToString() != "1" && Session["Account_Type"].ToString() != "S")
            {  %>
            
            <a id="aAY2" runat="server"   title="Change Assessment Year" style="color:rgba(25, 185, 154, 0.97); font-size:13px" >
            AY            
</a>
/ 
  <a id="aProfile" title="Click this link to see list of all users" style="color:rgba(25, 185, 154, 0.97); font-size:13px" >
            <asp:Literal ID="ltSelect" runat="server"> </asp:Literal>
            <%--</span>--%>
</a>
<%}
    
        }
        
        else if (Session["Project"].ToString() == "tds")
        {
        %>
       <%--  <a id="a1" runat="server"   title="Change Assessment Year" style="color:rgba(25, 185, 154, 0.97); font-size:13px" >
            AY            
</a>
/ --%>
  <a id="a2" href="#" title="Click this link to see list of all users" style="color:rgba(25, 185, 154, 0.97); font-size:13px" >
            <asp:Literal ID="ltSelectTDS" runat="server"> </asp:Literal>
            <%--</span>--%>
</a>
&nbsp;
<%--<a id="a3" href="#" onclick="showFUPop();"  style="text-decoration:none; border-radius:10px; background-color: #e14658;border: none;color: white;text-align: center;font-size: 12px;cursor: pointer;height:20px; padding:3px 5px 5px 5px;">My Files</a>--%>
        <%} %>
        &nbsp;
<a id="aFiles2" href="#" onclick="showFUPop();"  style="text-decoration:none; border-radius:10px; background-color: #e14658;border: none;color: white;text-align: center;font-size: 12px;cursor: pointer;height:20px; padding:3px 5px 5px 5px;">My Files</a>
        </td>
    
    </tr>
    </table>
<%--    <div>
  <span >   </span>&nbsp;&nbsp; 
    </div>
    <div>
   <span > </span>:&nbsp;&nbsp;&nbsp;&nbsp; 
    </div>
    <div>
   <span > AY:</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    </div>--%>
    <div style="margin-left:5px">
   
    </div>
    </div>
        <%} %>
     <div  id="popupdiv" style="display: none">
 <p>
 All Your Data will be lost for the current Assessee. Do you want to save it anyway before leaving?
 </p>
 </div>
 <div  id="divLogout" style="display: none">
 <p>
    Your Session is going to expire in <span id="stimer"></span> minutes<br>
    Do you want to resume the Session?<br />

 </p>
 </div>
 <a href="#" id="aLogout">&nbsp;</a>
 <%--<asp:Button ID="btnPopupFU" runat="server" Style="display: none" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlPopFU"
    TargetControlID="btnPopupFU" CancelControlID="btnPopClose">
</ajaxToolkit:ModalPopupExtender>

<asp:Panel ID="pnlPopFU" runat="server">
 <fileupload:fu ID="fu1" runat="server" />
</asp:Panel>--%>

<%--
 <div  id="popup_Files" style="display: none">
 <table width="100%">
 <tr>
 <td>
 Upload File
 </td>
 <td>
 <asp:FileUpload ID="fupl1" runat="server" />
 </td>
 </tr>
 <tr>
 <td colspan="2" align="center">
 <asp:Button ID="btnSubmit_Files" runat="server" Text="Upload" />
 </td>
 </tr>
 </table>
 </div>
 --%>
  <%} %>