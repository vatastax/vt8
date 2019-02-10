<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPage3.master"
    AutoEventWireup="true" CodeFile="TDSClientPay_Reporting.aspx.cs" Inherits="Presentation_TDSClientPay_Reporting" %>

<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="Scripts/jquery_scripts.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ctl00_ContentPlaceHolder1_VGrid1_GV_VGrid1 tr").each(function () {
                $(this).find("th:last").hide();
                $(this).find("td:last").hide();

                $(this).find("th:eq(2)").hide();
                $(this).find("td:eq(2)").hide();

                $(this).find("th:eq(11)").hide();
                $(this).find("td:eq(11)").hide();

            });

            $("#ctl00_ContentPlaceHolder1_VGrid1_GV_VGrid1 tr").click(function () {
                //alert($(this).find("td:eq(10)").text());
                if ($(this).find("td:eq(10)").text() == 'Short Payment') {
                    document.getElementById('<%=hdnPayment.ClientID %>').value = $(this).find("td:last").text();
                    alert('yeah');
                    $("#btnPayment").show();
                }
                else
                    $("#btnPayment").hide();

                document.getElementById('<%=hdnMP.ClientID %>').value = $(this).find("td:eq(2)").text();
                $("#tdMsg").html($(this).find("td:eq(11)").text());
                alert_custom($('#qq').html(), 1, $(this).find("td:eq(10)").text(), '', '', '', ['x'], '420', '100px');
            });
        });
        function makePayment() {
            //document.getElementById('<%=hdnMP.ClientID %>').value = 'mp';
            document.getElementById('aspnetForm').submit();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:HiddenField ID="hdnMP" runat="server" />
<asp:HiddenField ID="hdnPayment" runat="server" />
    <div id="qq" style="display: none; height: 500px">
        <table>            
            <tr>
                <td id="tdMsg">
                    
                </td>
                <td>
                    <span id="span_sub"></span>
                    <%--<asp:TextBox ID="txtSub" runat="server" onchange="getSub(this);"></asp:TextBox>--%>
                </td>
            </tr>
            
        </table>
        <input id="btnPayment" type="button" value="Make Payment" onclick="makePayment();" class="radius button" />
        <%--<asp:Button ID="btnSave" runat="server" Text="Send" CssClass="radius button"  />--%>
    </div>
    <h4>List of processed Returns</h4>
    <VGrid:VGrid ID="VGrid1" runat="server" />
    <br />
    <input type="button" onclick="javascript:window.location.href='TDSClient.aspx'" value="Add Return" class="radius button" />
    <div class="row">
        <div class="large-12 columns hide-for-small-only">
            <%--<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />--%>
        </div>
    </div>
</asp:Content>
