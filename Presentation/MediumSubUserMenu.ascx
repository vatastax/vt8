<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MediumSubUserMenu.ascx.cs" Inherits="Presentation_MediumSubUserMenu" %>
<script type="text/javascript">
    // This function will be executed when the user scrolls the page.
    $(window).scroll(function (e) {
        // Get the position of the location where the scroller starts.
        var scroller_anchor = $(".scroller_anchor").offset().top;

        // Check if the user has scrolled and the current position is after the scroller start location and if its not already fixed at the top 
        if ($(this).scrollTop() >= scroller_anchor && $('.scroller').css('position') != 'fixed') {    // Change the CSS of the scroller to hilight it and fix it at the top of the screen.
            $('.scroller').css({
                'background': '#008CBA',
                'border': '1px solid gray',
                'position': 'fixed',
                'top': '0px',
                'z-index': '1',
                'border-radius': '10px',
                'width': 'auto'
            });
            // Changing the height of the scroller anchor to that of scroller so that there is no change in the overall height of the page.
            $('.scroller_anchor').css('height', '50px');
        }
        else if ($(this).scrollTop() < scroller_anchor && $('.scroller').css('position') != 'relative') {    // If the user has scrolled back to the location above the scroller anchor place it back into the content.

            // Change the height of the scroller anchor to 0 and now we will be adding the scroller back to the content.
            $('.scroller_anchor').css('height', '0px');

            // Change the CSS and put it back to its original position.
            $('.scroller').css({
                'background': '#008CBA',
                'border': '1px solid #CCC',
                'position': 'relative',
                'z-index': '0',
                'border-radius': '10px',
                'width': 'auto'
            });
        }
    });
</script>
<style type="text/css">
    .container{font-size:14px; margin:0 auto; width:960px}
.test_content{margin:10px 0;}
.scroller_anchor{height:0px; margin:0; padding:0;}
.scroller{background:rgb(0, 140, 186); border:1px solid #CCC; margin:0 0 10px; z-index:2; height:50px; font-size:18px; font-weight:bold; text-align:center; width: border-radius:10px;}
</style>
 <!-- This div is used to indicate the original position of the scrollable fixed div. -->
    <div class="scroller_anchor"></div>

  <div class="scroller">
      <center>
    <table style="padding-top:-20px; border:0; background-color:#008CBA; " >
    <tr>
    <td style="display:none">
  <span style="font-weight:bold;">   <asp:Literal ID="ltMain" runat="server"></asp:Literal> </span> 
    </td>
    <td>
<span  style="color:White">Assessee Name:</span>
    <asp:Label ID="lblUser" runat="server" style="color:White" ForeColor="Red" Text="No Assessee"></asp:Label>
    </td>
    <td>
  <span style="color:White">   <asp:Literal ID="ltTitle" runat="server" Text="PAN"></asp:Literal>:</span>
    <asp:Label ID="lblPAN" runat="server" style="color:White"  Text=""></asp:Label>
    </td>
    <td>
 <span style="color:White" >     AY:</span>
    <asp:Label ID="lblAY" runat="server" style="color:White"  Text=""></asp:Label>
    </td>

    <td>
    <a href="Main.aspx" style="color: black;"  title="Click this link to see list of all users"  >
            <asp:Literal ID="ltSelect" runat="server"> </asp:Literal>
            </a>
    </td>
    </tr>

    </table>
    </center>
    
   </div>
    

    
  