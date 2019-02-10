<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test2.aspx.cs" Inherits="test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script src= "angular.min.js"></script>
    <title></title>

    <script type="text/javascript">
        function checkDate() {
            var d = new Date();
            alert(d.getDate());
        }
        function page_Load() {
            alert(isFutureDate('08/05/2015'));
        }
        function isFutureDate(idate) {
            var today = new Date().getTime(),
            idate = idate.split("/");
            idate = new Date(idate[2], idate[1] - 1, idate[0]).getTime();
            return (today - idate) < 0 ? true : false;
        }
        function chkit() {
        var DOB = new Date();
        
        }
    </script>

    <script language="javascript" type="text/javascript">
  //<![CDATA[
        function HandleClose() {
            alert("Killing the session on the server!!");
            PageMethods.AbandonSession();
        }
   //]]>
</script>
<script type="text/javascript">
    function movePage(val) {
        window.location = 'testService.aspx';
    }

    function showArray(Element, Indx, Array) {
        //if (Element != null)
           //document.write(Element.id + ' at ' + Indx);
//        if (Element.value == '')
        //Element.setAttribute('color', 'red');
        if (Element.value == '')
            Element.style.backgroundColor = "yellow";
        //}
    }


    function getArrayData() {
        try {
            var items = document.getElementsByTagName('input');
            var arrItems = new Array();
            for (var i = 0; i < items.length; i++) {
                arrItems.push(items[i].id);
            }
            
            var input = document.getElementsByTagName("input");
            var inputList = Array.prototype.slice.call(input);
            //alert(inputList.length);
            inputList.forEach(showArray);
            
        }
        catch (e) { alert('error is : ' + e); }
    }
</script>
</head>
<body onload="getArrayData();">
    <form id="form1" runat="server" autocomplete="on">
    <asp:LinkButton ID="lalal" runat="server" Text="click iiit" PostBackUrl="~/testService.aspx"></asp:LinkButton>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:Button ID="btnZip" runat="server" Text="ZipIt" OnClick="btnZip_Click" />
    <asp:Button ID="btnUnzip" runat="server" Text="Unzip It" OnClick="btnUnzip_Click" />
    <asp:Button ID="btn3" runat="server" Text="click this one" OnClick="btn3_Click" />
    <div ng-app="">
    <asp:TextBox ID="txt1" runat="server" ng-model="name2" style="width:1px;" BorderColor="White" BorderWidth="0px"></asp:TextBox>
    <p ng-bind="name2"></p>
    <p> Sum : {(10+5)}</p>
    <br /><br />
    <asp:TextBox ID="txt2" runat="server" placeholder="Enter Your Name Here!!"></asp:TextBox>
    <br />
    New Types:
    <br /><br />
    <asp:TextBox ID="txt3" runat="server" type="color"></asp:TextBox>    
    <asp:TextBox ID="TextBox1" runat="server" type="date" ></asp:TextBox>
<asp:TextBox ID="TextBox2" runat="server" type="datetime"></asp:TextBox>
<asp:TextBox ID="TextBox3" runat="server" type="datetime-local"></asp:TextBox>
<asp:TextBox ID="TextBox4" runat="server" type="email"></asp:TextBox>
<asp:TextBox ID="TextBox5" runat="server" type="month"></asp:TextBox>
<asp:TextBox ID="TextBox6" runat="server" type="number"></asp:TextBox>
<asp:TextBox ID="TextBox7" runat="server" type="range" ng-model="aa" OnTextChanged="TextBox7_TextChanged" AutoPostBack="true"></asp:TextBox>
<p ng-bind="aa"></p>
<asp:TextBox ID="TextBox8" runat="server" type="search"></asp:TextBox>
<asp:TextBox ID="TextBox9" runat="server" type="tel"></asp:TextBox>
<asp:TextBox ID="TextBox10" runat="server" type="time"></asp:TextBox>
<asp:TextBox ID="TextBox11" runat="server" type="url" autofocus></asp:TextBox>
<asp:TextBox ID="TextBox12" runat="server" type="week"></asp:TextBox>
<asp:TextBox ID="txtEMail" runat="server"  ></asp:TextBox>

<asp:TextBox ID="txttt1" runat="server" BorderWidth="0" BorderColor="White" Text="asd" readonly   />
<asp:FileUpload ID="fup1" runat="server" allowmultiple="true" multiple />
<asp:TextBox ID="ttt" runat="server" ReadOnly ></asp:TextBox>
<asp:TextBox ID="text341" runat="server" Enabled="false"></asp:TextBox>
<label for="inpChocType">Chocolates</label>
<input type="text" id="inpChocType" list="chocType">
<datalist id="chocType">
  <option value="white" />
  <option value="milk" />
  <option value="dark" />
  <option value="darker" />
  <option value="darkest" />
  <option value="darkest232" />
</datalist>

<asp:Image ID="img1" runat="server" alt="asd" AlternateText="asdd" ImageUrl="images/AboutIco.jpg" />
<input type="number" min="0" max="100" step="5">

<label>Start Date: <input type="text" size="12" required pattern="\d{1,2}/\d{1,2}/\d{4}" placeholder="dd/mm/yyyy" name="startdate"></label>

<asp:Button ID="btn1" runat="server" Text="Submit" />
    </div>
    
    <input type="text" Pattern="^[1-9][0-9]*$" required />

    <a href="#" onclick="movePage('40');">click here</a>
    <br /><br />
    <asp:FileUpload ID="fupl" runat="server" />
    <asp:Button ID="btnC" runat="server" Text="Import XML" OnClick="btnC_Click" />
    
    </form>
</body>
</html>