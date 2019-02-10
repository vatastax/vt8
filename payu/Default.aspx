<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div id="frmError" runat="server">
        <span style="color: red">Please fill all mandatory fields.</span>
        <br />
        <br />
    </div>
    <input type="hidden" runat="server" id="key" name="key" />
    <input type="hidden" runat="server" id="hash" name="hash" />
    <input type="hidden" runat="server" id="txnid" name="txnid" />
    <input type="hidden" runat="server" id="enforce_paymethod" name="enforce_paymethod" />
    <table>
        <tr>
            <td>
                <b>Mandatory Parameters</b>
            </td>
        </tr>
        <tr>
            <td>
                Amount:
            </td>
            <td>
            
                <asp:HiddenField ID="amount" runat="server" Value="149" />
            </td>
            <td>
                First Name:
            </td>
            <td>
                <asp:HiddenField ID="firstname" runat="server" Value="Ankush" />
            </td>
        </tr>
        <tr>
            <td>
                Email:
            </td>
            <td>
                <asp:HiddenField ID="email" runat="server" Value="ankush.passion@gmail.com" />
            </td>
            <td>
                Phone:
            </td>
            <td>
                <asp:HiddenField ID="phone" runat="server" Value="9412312345" />
            </td>
        </tr>
        <tr>
            <td>
                Product Info:
            </td>
            <td colspan="3">
                <asp:HiddenField ID="productinfo" runat="server" Value="ITR-1" />
            </td>
        </tr>
        <tr>
            <td>
                Success URI:
            </td>
            <td colspan="3">
                <asp:HiddenField ID="surl" runat="server" Value="http://www.echarteredaccountants.com" />
            </td>
        </tr>
        <tr>
            <td>
                Failure URI:
            </td>
            <td colspan="3">
                <asp:HiddenField ID="furl" runat="server" Value="http://www.echarteredaccountants.com" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Optional Parameters</b>
            </td>
        </tr>
        <tr>
            <td>
                Last Name:
            </td>
            <td>
                <asp:HiddenField ID="lastname" runat="server" Value="Bhanot" />
            </td>
            <td>
                Cancel URI:
            </td>
            <td>
                <asp:HiddenField ID="curl" runat="server" Value="http://www.echarteredaccountants.com" />
            </td>
        </tr>
        <tr>
            <td>
                Address1:
            </td>
            <td>
                <asp:HiddenField ID="address1" runat="server" Value="123 Central Town" />
            </td>
            <td>
                Address2:
            </td>
            <td>
                <asp:HiddenField ID="address2" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td>
                City:
            </td>
            <td>
                <asp:HiddenField ID="city" runat="server" Value="Jalandhar" />
            </td>
            <td>
                State:
            </td>
            <td>
                <asp:HiddenField ID="state" runat="server" Value="Punjab" />
            </td>
        </tr>
        <tr>
            <td>
                Country:
            </td>
            <td>
                <asp:HiddenField ID="country" runat="server" Value="India" />
            </td>
            <td>
                Zipcode:
            </td>
            <td>
                <asp:HiddenField ID="zipcode" runat="server" Value="144001" />
            </td>
        </tr>
        <tr>
            <td>
                UDF1:
            </td>
            <td>
                <asp:HiddenField ID="udf1" runat="server" Value="" />
            </td>
            <td>
                UDF2:
            </td>
            <td>
                <asp:HiddenField ID="udf2" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td>
                UDF3:
            </td>
            <td>
                <asp:HiddenField ID="udf3" runat="server" Value="" />
            </td>
            <td>
                UDF4:
            </td>
            <td>
                <asp:HiddenField ID="udf4" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td>
                UDF5:
            </td>
            <td>
                <asp:HiddenField ID="udf5" runat="server" Value="" />
            </td>
            <td>
                PG:
            </td>
            <td>
                <asp:HiddenField ID="pg" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td>
                Service Provider:
            </td>
            <td>
                <asp:HiddenField ID="service_provider" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
        </tr>
    </table>
    <br />
    <%--<asp:Button ID="submit" Text="submit" Width="100px" runat="server" OnClick="Button1_Click" />--%>
    
    </form>
</body>
</html>
