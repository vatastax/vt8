<%@ Page Title="" Language="C#" MasterPageFile="~/VatasMaster.master" AutoEventWireup="true" CodeFile="Pricing.aspx.cs" Inherits="Pricing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
        var pathname = document.URL;
        pathname = pathname.substring(pathname.lastIndexOf("/"));
        pathname = pathname.substring(1);
        //alert(pathname);
        $('ul>li').each(function () {
            $(this).find('a').removeClass('activebutton');
            if ($(this).find('a').attr('href') == pathname) {
                //alert($(this).find('a').attr('href'));
                $(this).addClass('activebutton');
                //alert('done');
            }

        })
        // $(this).addClass('active');
    });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">

  
    <div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200; ">
              Pricing
             </div>
             <div class="large-12 small-12 columns ">
                        <div class="login-wrap" >
                    <p>Get CA Assisted E-Filing @Rs. 999.</p>
                        <%--<h2 style="font-size:20px">Continue with ITR Process</h2>--%>
                        <hr />
                        <div class="form" style="margin-top: -115px; margin-left: 80px">
                            <asp:Button ID="btnPricing" runat="server" Style="border-radius: 10px; margin-top: 105px;
                                margin-left: -35px" Text="Price" CssClass="button"  />
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" Runat="Server">
    
                                 <div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200;">
                                    Pricing
                                 </div>
                                <div class="medium-12  columns ">
                                          <div class="login-wrap" >
                    <p>Get CA Assisted E-Filing @Rs. 999.</p>
                        <%--<h2 style="font-size:20px">Continue with ITR Process</h2>--%>
                        <hr />
                        <div class="form" style="margin-top: -115px; margin-left: 80px">
                            <asp:Button ID="Button1" runat="server" Style="border-radius: 10px; margin-top: 105px;
                                margin-left: -35px" Text="Price" CssClass="button"  />
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                                </div>                                            
                            
</asp:Content>
