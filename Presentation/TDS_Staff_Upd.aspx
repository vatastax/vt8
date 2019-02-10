<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPage3.master" AutoEventWireup="true" CodeFile="TDS_Staff_Upd.aspx.cs" Inherits="Presentation_TDS_Staff_Upd" %>
<%@ Register Assembly="DynamicButtons_Service" TagPrefix="db" Namespace="DynamicButtons_Service"  %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    $('document').ready(function () {
        if (document.getElementById('<%=hdn1.ClientID %>').value != '') {
            if (document.getElementById('<%=hdn1.ClientID %>').value == 'Uploaded') {
                setTimeout(uploadFile, 1200);
            }
            else {
                $("#span_sub").html(document.getElementById('<%=hdn1.ClientID %>').value);
                //alert_custom('' + document.getElementById('<%=hdn1.ClientID %>').value + '', 1, 'Error', '', '', '', ['OK'], '200', '100px');
                alert_custom($('#qq').html(), 1, 'Send E-mail to Customer', '', '', '', ['x'], '420', '100px');

            }
        }
        else {
            //window.location.href = document.URL.toString();
        }
        $('#ctl00_ContentPlaceHolder1_dny_BOBtn_Pnl_DynamicControlContainer').children().addClass('radius button')
        $('#ctl00_ContentPlaceHolder1_dny_BOBtn_Pnl_DynamicControlContainer').removeAttr('style');
    });
    function uploadFile() {
        $("#aFiles2").click();
    }
    function sendMail() {
        alert(document.getElementById('<%=hdnID.ClientID %>').value);
        var pdata = { From: "register@vatasinfotech.com", To: $("#ctl00_ContentPlaceHolder1_ltMailTo").text(), subject: document.getElementById('<%=hdn1.ClientID %>').value, msg: document.getElementById('<%=hdnMsg.ClientID %>').value, ID: document.getElementById('<%=hdnID.ClientID %>').value, amt: document.getElementById('<%=hdnAmt.ClientID %>').value };
        $.ajax({
            type: "POST",
            url: "../Service_Banks.asmx/Send_Mail",
            data: JSON.stringify(pdata),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, status) {
                alert('Email Sent To Ankush Bhanot');
                $(".ui-button-text").click();
                document.getElementById('<%=hdn1.ClientID %>').value = '';
            },
            error: function (request, status, error) { alert(request.responseText); }
        });
    }

    function Success(data, status) {
        try {
            element_val = data.d;
        }
        catch (e) { alert(e); }
    }


    function getMsg(id) {
        document.getElementById('<%=hdnMsg.ClientID %>').value = id.value;
    }

    function getAmt(id) {
        document.getElementById('<%=hdnAmt.ClientID %>').value = id.value;
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:HiddenField ID="hdn1" runat="server" />
<asp:HiddenField ID="hdnID" runat="server" />


<asp:HiddenField ID="hdnAmt" runat="server" />
<asp:HiddenField ID="hdnMsg" runat="server" />
<div id="qq" style="display:none; height:500px">
      <table>
      <tr><td> To : </td><td> 
      <asp:Label ID="ltMailTo" runat="server" Text="ankush.passion@gmail.com"></asp:Label>
      </td>
      </tr>
    
      <tr><td>  Subject:</td><td>
      <span id="span_sub"></span>
      <%--<asp:TextBox ID="txtSub" runat="server" onchange="getSub(this);"></asp:TextBox>--%></td></tr>
         <tr><td>Message</td><td><asp:TextBox ID="txtDOB" runat="server" TextMode="MultiLine" onchange="getMsg(this);"></asp:TextBox></td></tr>
         <tr><td>Amount Left</td><td><asp:TextBox ID="txtAmt" runat="server" TextMode="MultiLine" onchange="getAmt(this);"></asp:TextBox></td></tr>
      </table>
        <input type="button" value="Send Mail" onclick="sendMail();" class="radius button" />
        <asp:Button ID="btn11" runat="server" OnClick="btn11_Click" Text="Click it" />
          <%--<asp:Button ID="btnSave" runat="server" Text="Send" CssClass="radius button"  />--%>
      </div>
<div class="row">
    <div class="large-12 columns hide-for-small-only">
<VGrid:VGrid ID="VGrid1" runat="server" />
    </div>
</div>

<div class="row" style="display:none;">
    <div class="large-12 columns hide-for-small-only">
        <DB:DynamicButtons_Service ID="dny_BOBtn" runat="server" Control_ID="pnl_TDS_Staff"
            Page_ID="100" Page_ModuleID="100" />
    </div>
</div>
</asp:Content>