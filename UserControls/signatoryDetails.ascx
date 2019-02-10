<%@ Control Language="C#" AutoEventWireup="true" CodeFile="signatoryDetails.ascx.cs" Inherits="UserControls_signatoryDetails" %>
<script type="text/javascript">
    function chgData(id) {
        try {
            if (id.value == '1') {
                document.getElementById('<%= txtSignatory.ClientID %>').disabled = true;
                document.getElementById('<%= txtFatherSignatory.ClientID %>').disabled = true;
                document.getElementById('<%= txtPANSignatory.ClientID %>').disabled = true;
                //document.getElementById('<%= txtPlace.ClientID %>').disabled = true;
                //document.getElementById('<%= txtDateofReturn.ClientID %>').disabled = true;
            }
            else {
                document.getElementById('<%= txtSignatory.ClientID %>').disabled = false;
                document.getElementById('<%= txtFatherSignatory.ClientID %>').disabled = false;
                document.getElementById('<%= txtPANSignatory.ClientID %>').disabled = false;
                //document.getElementById('<%= txtPlace.ClientID %>').disabled = false;
                //document.getElementById('<%= txtDateofReturn.ClientID %>').disabled = false;
            }
        }
        catch (e) {
            alert(e);
        }
    }

    function get_PB()
    {

    }
    function submitIt() {
        try
        {
            window.location = 'http://localhost:2263/VatasTaxTFS/Presentation/Salary.aspx?VType=40&sd=dn';// window.URL.toString() + "&sd=dn";
        }
        catch (e) { alert(e);}
        <%--document.getElementById('<%= hdnSD_Data.ClientID %>').value = 'done';
        document.getElementById('form1').submit();--%>
        //document.getElementById('btnSubmitSignatory').click();
    }
</script>

<asp:HiddenField ID="hdnSD_Data" runat="server" />
<table width="100%">
<tr>
<td>
Represenatative/Self
</td>
<td>
<asp:DropDownList ID="ddRepSelf" runat="server" onchange="chgData(this)">
<asp:ListItem Text="Self" Value="1"></asp:ListItem>
<asp:ListItem Text="Representative" Value="2"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td>
Name of Signatory:
</td>
<td>
<asp:TextBox required ID="txtSignatory" runat="server" Enabled="false"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Father Name of Signatory
</td>
<td>
<asp:TextBox required ID="txtFatherSignatory" runat="server" Enabled="false"></asp:TextBox>
</td>
</tr>
<tr>
<td>
PAN of Signatory
</td>
<td>
<asp:TextBox required ID="txtPANSignatory" runat="server" Enabled="false"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Place of Filing of Return:
</td>
<td>
<asp:TextBox required ID="txtPlace" placeholder="Enter Place of Filing" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Date of Filing of Return:
</td>
<td>
<asp:TextBox required ID="txtDateofReturn" placeholder="DD-MM-YYYY" runat="server"></asp:TextBox>
</td>
</tr>
</table>
<div style="margin:0 230px">
<asp:Button ID="btnSubmitSignatory" runat="server" style="background: #25A6E1;	background: -moz-linear-gradient(top,#25A6E1 0%,#188BC0 100%);	background: -webkit-gradient(linear,left top,left bottom,color-stop(0%,#25A6E1),color-stop(100%,#188BC0));	background: -webkit-linear-gradient(top,#25A6E1 0%,#188BC0 100%);	background: -o-linear-gradient(top,#25A6E1 0%,#188BC0 100%);	background: -ms-linear-gradient(top,#25A6E1 0%,#188BC0 100%);	background: linear-gradient(top,#25A6E1 0%,#188BC0 100%);	filter: progid: DXImageTransform.Microsoft.gradient( startColorstr='#25A6E1',endColorstr='#188BC0',GradientType=0);	padding:8px 13px;	color:#fff;	font-family:'Helvetica Neue',sans-serif;	font-size:17px;	border-radius:4px;	-moz-border-radius:4px;	-webkit-border-radius:4px;	border:1px solid #1A87B9" Text="Submit" OnClick="btnSubmitSignatory_Click" OnClientClick="submitIt();" />
</div>