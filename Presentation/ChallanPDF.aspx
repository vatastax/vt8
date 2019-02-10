<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChallanPDF.aspx.cs" Inherits="Presentation_ChallanPDF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title></title> 
    <script type="text/javascript">
        function hide() {
            document.getElementById("btn1").style.display = 'none';
        }
    </script>
<!-- Begin shared CSS values -->
<style type="text/css" >
.t {
	position: absolute;
	-webkit-transform-origin: top left;
	-moz-transform-origin: top left;
	-o-transform-origin: top left;
	-ms-transform-origin: top left;
	-webkit-transform: scale(0.25);
	-moz-transform: scale(0.25);
	-o-transform: scale(0.25);
	-ms-transform: scale(0.25);
	z-index: 2;
	position:absolute;
	white-space:nowrap;
	overflow:visible;
}
</style>
<!-- End shared CSS values -->

<!-- Begin shared JS -->
<script type="text/javascript">

    // Ensure that we're not replacing any onload events
    function addLoadEvent(func) {
        var oldonload = window.onload;
        if (typeof window.onload != 'function') {
            window.onload = func;
        } else {
            window.onload = function () {
                if (oldonload) {
                    oldonload();
                }
                func();
            }
        }
    }
    addLoadEvent(function () { load1(); });

    function adjustWordSpacing(widths) {
        var i, allLinesDone = false;
        var isDone = [];
        var currentSpacing = [];
        var elements = [];

        // Initialise arrays
        for (i = 0; i < widths.length; i++) {
            elements[i] = document.getElementById(widths[i][0]);
            elements[i].style.wordSpacing = '0px'; //Required if rerunning
        }
        for (i = 0; i < widths.length; i++) {
            if (isIE) widths[i][1] = widths[i][1] * 4;
            currentSpacing[i] = Math.floor((widths[i][1] - elements[i].offsetWidth) / elements[i].innerHTML.match(/\s.|&nbsp;./g).length); //min
            if (isIE) currentSpacing[i] = Math.floor(currentSpacing[i] / 4);
            isDone[i] = false;
        }

        while (!allLinesDone) {
            // Add each adjustment to the render queue without forcing a render
            for (i = 0; i < widths.length; i++) {
                if (!isDone[i]) {
                    elements[i].style.wordSpacing = currentSpacing[i] + 'px';
                }
            }

            allLinesDone = true;
            // If elements still need to be wider, add 1 to the word spacing
            for (i = 0; i < widths.length; i++) {
                if (!isDone[i] && currentSpacing[i] < 160) {
                    if (elements[i].offsetWidth >= widths[i][1]) {
                        isDone[i] = true;
                    } else {
                        currentSpacing[i]++;
                        allLinesDone = false;
                    }
                }
            }
        }

        for (i = 0; i < widths.length; i++) {
            elements[i].style.wordSpacing = (currentSpacing[i] - 1) + 'px';
        }
    }

</script>
<!-- End shared JS -->


<!-- Begin inline CSS -->
<style type="text/css" >

#t1_1{left:81px;top:62px;}
#t2_1{left:81px;top:78px;}
#t3_1{left:638px;top:62px;}
#t4_1{left:98px;top:100px;}
#t5_1{left:352px;top:100px;}
#t6_1{left:449px;top:100px;}
#t7_1{left:513px;top:100px;}
#t8_1{left:124px;top:120px;}
#t9_1{left:217px;top:120px;}
#ta_1{left:362px;top:120px;}
#tb_1{left:710px;top:120px;}
#tc_1{left:106px;top:141px;}
#td_1{left:217px;top:141px;}
#te_1{left:781px;top:141px;}
#tf_1{left:217px;top:162px;}
#tg_1{left:217px;top:179px;}
#th_1{left:81px;top:207px;}
#ti_1{left:81px;top:245px;}
#tj_1{left:81px;top:288px;}
#tk_1{left:81px;top:356px;}
#tl_1{left:90px;top:353px;}
#tm_1{left:96px;top:353px;}
#tn_1{left:100px;top:353px;}
#to_1{left:107px;top:353px;}
#tp_1{left:118px;top:353px;}
#tq_1{left:125px;top:353px;}
#tr_1{left:656px;top:356px;}
#ts_1{left:664px;top:353px;}
#tt_1{left:668px;top:353px;}
#tu_1{left:379px;top:374px;}
#tv_1{left:488px;top:374px;}
#tw_1{left:81px;top:396px;}
#tx_1{left:715px;top:396px;}
#ty_1{left:81px;top:418px;}
#tz_1{left:447px;top:418px;}
#t10_1{left:81px;top:439px;}
#t11_1{left:492px;top:439px;}
#t12_1{left:103px;top:463px;}
#t13_1{left:444px;top:461px;}
#t14_1{left:630px;top:461px;}
#t15_1{left:81px;top:482px;}
#t16_1{left:618px;top:482px;}
#t17_1{left:81px;top:504px;}
#t18_1{left:89px;top:504px;}
#t19_1{left:96px;top:504px;}
#t1a_1{left:101px;top:504px;}
#t1b_1{left:107px;top:504px;}
#t1c_1{left:115px;top:504px;}
#t1d_1{left:121px;top:504px;}
#t1e_1{left:126px;top:504px;}
#t1f_1{left:133px;top:504px;}
#t1g_1{left:659px;top:504px;}
#t1h_1{left:764px;top:504px;}
#t1i_1{left:81px;top:525px;}
#t1j_1{left:601px;top:525px;}
#t1k_1{left:699px;top:525px;}
#t1l_1{left:727px;top:525px;}
#t1m_1{left:799px;top:525px;}
#t1n_1{left:827px;top:525px;}
#t1o_1{left:81px;top:547px;}
#t1p_1{left:86px;top:547px;}
#t1q_1{left:93px;top:547px;}
#t1r_1{left:97px;top:547px;}
#t1s_1{left:103px;top:547px;}
#t1t_1{left:108px;top:547px;}
#t1u_1{left:115px;top:547px;}
#t1v_1{left:120px;top:547px;}
#t1w_1{left:631px;top:547px;}
#t1x_1{left:81px;top:568px;}
#t1y_1{left:89px;top:568px;}
#t1z_1{left:95px;top:568px;}
#t20_1{left:103px;top:568px;}
#t21_1{left:109px;top:568px;}
#t22_1{left:113px;top:568px;}
#t23_1{left:117px;top:568px;}
#t24_1{left:81px;top:590px;}
#t25_1{left:91px;top:590px;}
#t26_1{left:95px;top:590px;}
#t27_1{left:103px;top:590px;}
#t28_1{left:109px;top:590px;}
#t29_1{left:114px;top:590px;}
#t2a_1{left:81px;top:611px;}
#t2b_1{left:90px;top:611px;}
#t2c_1{left:97px;top:611px;}
#t2d_1{left:101px;top:611px;}
#t2e_1{left:108px;top:611px;}
#t2f_1{left:81px;top:633px;}
#t2g_1{left:87px;top:654px;}
#t2h_1{left:167px;top:654px;}
#t2i_1{left:228px;top:654px;}
#t2j_1{left:332px;top:654px;}
#t2k_1{left:435px;top:654px;}
#t2l_1{left:511px;top:654px;}
#t2m_1{left:81px;top:696px;}
#t2n_1{left:212px;top:696px;}
#t2o_1{left:425px;top:696px;}
#t2p_1{left:81px;top:718px;}
#t2q_1{left:369px;top:739px;}
#t2r_1{left:81px;top:787px;}
#t2s_1{left:305px;top:803px;}
#t2t_1{left:585px;top:803px;}
#t2u_1{left:153px;top:849px;}
#t2v_1{left:324px;top:852px;}
#t2w_1{left:631px;top:849px;}
#t2x_1{left:81px;top:874px;}
#t2y_1{left:89px;top:874px;}
#t2z_1{left:99px;top:874px;}
#t30_1{left:81px;top:895px;}
#t31_1{left:301px;top:917px;}
#t_for_Name{left:350px;top:917px;}
#t32_1{left:81px;top:938px;}
#t33_1{left:398px;top:938px;}
#tforRs{left:450px;top:938px;}
#t34_1{left:81px;top:960px;}
#t35_1{left:81px;top:981px;}
#t36_1{left:231px;top:1003px;}
#t37_1{left:81px;top:1045px;}
#t38_1{left:273px;top:1045px;}
#t39_1{left:81px;top:1066px;}
#t3a_1{left:360px;top:1066px;}
#t3b_1{left:81px;top:1087px;}
#t3c_1{left:317px;top:1087px;}
#t3d_1{left:81px;top:1109px;}
#t3e_1{left:372px;top:1109px;}
#t3f_1{left:585px;top:1109px;}
#t3g_1{left:110px;top:1154px;}
#t3h_1{left:762px;top:1154px;}
#t10D_1{left:627px;top:525px;}

#data1{left:389px;top:504px;}
#data2{left:389px;top:526px;}
#data3{left:389px;top:483px;}
#data4{left:389px;top:548px;}
#data5{left:389px;top:614px;}
#dataAmt{left:176px;top:638px;}
#dataAmt2{left:110px;top:899px;}
#forAY{left:196px;top:1110px;}

#data6{left:671px;top:211px;font-weight: bold}
#data_AY{left:728px;top:141px;}
#data_PIN{left:700px;top:357px;}
#data_TEL{left:148px;top:356px;}
#data_ADD{left:87px;top:308px;}
#data_NAME{left:87px;top:264px;}

#data_CRORES{left:85px;top:673px;}
#data_LACS{left:160px;top:673px;}
#data_THOUSAND{left:241px;top:673px;}
#data_HUNDRED{left:340px;top:673px;}
#data_TENS{left:426px;top:673px;}
#data_UNITS{left:503px;top:673px;}

#data_BANK{left:122px;top:758px;}

#data_PAN{left:180px;top:873px;}

#data_DATE{left:125px;top:787px;}

#data_NAME2{left:179px;top:963px;}


#line1{left:69px;top:80px;}
#line2{left:69px;top:181px;}
#line3{left:69px;top:440px;}
#line4{left:69px;top:804px;}
#line5{left:185px;top:200px;}
#line6{left:647px;top:200px;}
#line7{left:553px;top:1135px;}
#line8{left:69px;top:460px;}
#line9{left:69px;top:482px;}
#line10{left:69px;top:504px;}
#line11{left:69px;top:526px;}
#line12{left:69px;top:548px;}
#line13{left:69px;top:570px;}
#line14{left:69px;top:592px;}
#line15{left:69px;top:614px;}
#line16{left:69px;top:633px;}
#line17{left:69px;top:652px;}
#line18{left:69px;top:674px;}
#line19{left:69px;top:699px;}
#line20{left:69px;top:718px;}
#line21{left:355px;top:634px;}
#line22{left:69px;top:916px;}
#line23{left:69px;top:938px;}
#line24{left:69px;top:960px;}
#line25{left:69px;top:980px;}
#line26{left:69px;top:1025px;}


#box1{left:305px;top:393px;}
#box2{left:305px;top:414px;}
#box3{left:305px;top:435px;}
#box4{left:800px;top:393px;}
#box5{left:800px;top:414px;}
#box6{left:800px;top:435px;}
#box7{left:593px;top:503px;}
#box8{left:620px;top:503px;}
#box9{left:693px;top:503px;}
#box10{left:720px;top:503px;}
#box11{left:792px;top:503px;}
#box12{left:819px;top:503px;}
#box13{left:689px;top:138px;}
#box14{left:638px;top:209px;}
#box15{left:81px;top:262px;}
#box16{left:81px;top:306px;}
#box17{left:81px;top:330px;}
#box18{left:140px;top:353px;}
#box19{left:692px;top:353px;}
#box20{left:122px;top:784px;}
#box21{left:267px;top:784px;}
#box22{left:175px;top:871px;}
#box23{left:175px;top:895px;}
#boxRecieved{left:182px;top:895px;}
#box24{left:275px;top:1107px;}
#box25{left:491px;top:120px;}
#box26{left:491px;top:160px;}
#box_TOTAL{left:275px;top:1107px;};

#tick_ADVT{left:311px;top:398px;}
#tick_SAT{left:311px;top:418px;}
#tick_TRA{left:311px;top:439px;}
#tick_ST{left:805px;top:398px;}
#tick_TDC{left:805px;top:418px;}
#tick_UH{left:805px;top:440px;}

#tick_0020{left:497px;top:123px;}
#tick_0021{left:497px;top:164px;}
#tick_Self{left:311px;top:416px;}

.s4_1{
	FONT-SIZE: 45px;
	FONT-FAMILY: TimesNewRomanPSMT;
	color: rgb(0,0,0);
}

.s1_1{
	FONT-SIZE: 57px;
	FONT-FAMILY: TimesNewRomanPSMT;
	color: rgb(0,0,0);
}

.s6_1{
	FONT-SIZE: 51px;
	FONT-FAMILY: TimesNewRomanPSMT;
	color: rgb(0,0,0);
}

.s3_1{
	FONT-SIZE: 57px;
	FONT-FAMILY: TimesNewRomanPS-BoldMT;
	color: rgb(0,0,0);
	FONT-WEIGHT: bold;
}

.s5_1{
	FONT-SIZE: 45px;
	FONT-FAMILY: TimesNewRomanPS-BoldMT;
	color: rgb(0,0,0);
	FONT-WEIGHT: bold;
}

.s7_1{
	FONT-SIZE: 48px;
	FONT-FAMILY: Arial1;
	color: rgb(0,0,0);
}

.s2_1{
	FONT-SIZE: 68px;
	FONT-FAMILY: TimesNewRomanPS-BoldMT;
	color: rgb(0,0,0);
	FONT-WEIGHT: bold;
}
.s_line{
  FONT-SIZE: 68px;
	color: rgb(0,0,0);
	FONT-WEIGHT: bold;
}

.s_vline{
  FONT-SIZE: 25px;
	color: rgb(0,0,0);
	transform: rotate(-90deg);
}


.s_box{
	border:5px solid black;
  width:85px;
  height:75px;
}

.s_box_AY{
	border:5px solid black;
  width:555px;
  height:75px;
}

.s_box_PAN{
	border:5px solid black;
  width:675px;
  height:75px;
}

.s_box_NAME{
	border:5px solid black;
  width:3000px;
  height:75px;
}

.s_box_ADD{
	border:5px solid black;
  width:3000px;
  height:75px;
}

.s_box_TEL{
	border:5px solid black;
  width:1170px;
  height:75px;
}

.s_box_SIGN{
	border:5px solid black;
  width:1195px;
  height:75px;
}

.s_box_PAN2{
	border:5px solid black;
  width:1315px;
  height:75px;
}

.s_box_RCVD{
	border:5px solid black;
  width:1314px;
  height:75px;
}

.s_box_tot
{
  border:5px solid black;
  width:190px;
  height:60px;
}

.s_box_box
{
  border:5px solid black;
  width:190px;
  height:60px;
  text-align:center;
}


.s_box_bank
{
    border:5px solid black;
  width:1773px;
  height:80px;
}

</style>
<!-- End inline CSS -->

<!-- Begin embedded font definitions -->
<style id="fonts1" type="text/css" >

@font-face {
	font-family: Arial1;
	src :url("1/fonts/Arial.woff") format("woff");
}

</style>
<!-- End embedded font definitions -->
<script id="ld1" type="text/javascript">

    var isIE = false;
    var f1 = [['t1_1', 1049], ['t2_1', 477], ['t3_1', 834], ['t5_1', 375], ['t6_1', 254], ['t9_1', 551], ['ta_1', 450], ['tb_1', 397], ['tc_1', 281], ['td_1', 611], ['tf_1', 967], ['th_1', 657], ['ti_1', 244], ['tj_1', 844], ['tu_1', 418], ['tv_1', 254], ['tw_1', 462], ['tx_1', 305], ['ty_1', 637], ['tz_1', 1377], ['t10_1', 818], ['t11_1', 1196], ['t12_1', 546], ['t13_1', 504], ['t14_1', 682], ['t15_1', 275], ['t16_1', 776], ['t1i_1', 356], ['t1j_1', 146], ['t1w_1', 669], ['t2f_1', 373], ['t2m_1', 493], ['t2n_1', 388], ['t2p_1', 228], ['t2q_1', 736], ['t2s_1', 849], ['t2u_1', 669], ['t2v_1', 676], ['t2w_1', 669], ['t30_1', 339], ['t32_1', 734], ['t33_1', 169], ['t34_1', 327], ['t35_1', 228], ['t36_1', 736], ['t37_1', 313], ['t38_1', 897], ['t39_1', 347], ['t3a_1', 817], ['t3b_1', 395], ['t3c_1', 991], ['t3d_1', 563], ['t3g_1', 869], ['t3h_1', 250]];
    function load1() {
        var timeout = 100;
        if (navigator.userAgent.match(/iPhone|iPad|iPod|Android/i)) timeout = 500;
        setTimeout(function () { adjustWordSpacing(f1); }, timeout);
    }
</script>
<script language="javascript" type="text/javascript">
    function CallPrint() {
        try {
            alert('jhj');
            var prtContent = document.getElementById('challan');
            var WinPrint = window.open("", "", "top=50,left=100,width=800, height=600");
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.name = "Print Challan";
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            //prtContent.innerHTML = strOldOne;
        }
        catch (e) {
            alert(e);
        }
    }
</script>

</head>
<body>
    <form id="form1" runat="server">
    <center>
  <div id ="challan" >  
   <div style="border: 1px solid black;margin-left: 40px;width: 781px;margin-top: 20px;height:1075px">
<div id="jpedal" style="overflow: hidden; position:relative; width: 935px; height: 1150px;margin-left: -70px;margin-top: -60px;">
<!-- Begin text definitions (Positioned/styled in CSS) -->
<div id="box1" class="t s_box"></div>
<div id="box2" class="t s_box"></div>
<div id="tick_Self" class="t">
<img alt="" src="../images/tick.png" style="width: 50px;height: 50px;"/>
</div>
<div id="box3" class="t s_box"></div>
<div id="box4" class="t s_box"></div>
<div id="box5" class="t s_box"></div>
<div id="box6" class="t s_box"></div>
<div id="box7" class="t s_box"></div>
<div id="box8" class="t s_box"></div>
<div id="box9" class="t s_box"></div>
<div id="box10" class="t s_box"></div>
<div id="box11" class="t s_box"></div>
<div id="box12" class="t s_box"></div>
<div id="box_TOTAL" class="t s_box"></div>
<div id="box25" class="t s_box"></div>
<div id="box26" class="t s_box"></div>

<div id="tick_ADVT" class="t" runat="server"><img alt="" src="../images/tick.png" style="width: 50px;height: 50px;" /></div>
<div id="tick_SAT" class="t" runat="server"><img alt="" src="../images/tick.png" style="width: 50px;height: 50px;" /></div>
<div id="tick_TRA" class="t" runat="server"><img alt="" src="../images/tick.png" style="width: 50px;height: 50px;" /></div>
<div id="tick_ST" class="t" runat="server"><img alt="" src="../images/tick.png" style="width: 50px;height: 50px;" /></div>
<div id="tick_TDC" class="t" runat="server"><img alt="" src="../images/tick.png" style="width: 50px;height: 50px;" /></div>
<div id="tick_UH" class="t" runat="server"><img alt="" src="../images/tick.png" style="width: 50px;height: 50px;" /></div>
<div id="tick_0020" class="t" runat="server"><img alt="" src="../images/tick.png" style="width: 50px;height: 50px;" /></div>
<div id="tick_0021" class="t" runat="server"><img alt="" src="../images/tick.png" style="width: 50px;height: 50px;" /></div>

<div id="data1" class="t" runat="server" style="font-size:60px; text-align:right;  width:750px; font-family:TimesNewRomanPSMT" ></div>
<div id="data2" class="t" runat="server" style="font-size:60px; text-align:right;  width:750px; font-family:TimesNewRomanPSMT" ></div>
<div id="data3" class="t" runat="server" style="font-size:60px; text-align:right;  width:750px; font-family:TimesNewRomanPSMT" ></div>
<div id="data4" class="t" runat="server" style="font-size:60px; text-align:right;  width:750px; font-family:TimesNewRomanPSMT" ></div>
<div id="data5" class="t" runat="server" style="font-size:60px; text-align:right;  width:750px; font-family:TimesNewRomanPSMT" ></div>
<div id="dataAmt" class="t" runat="server" style="font-size:40px; text-align:right;  width:750px; font-family:TimesNewRomanPSMT" ></div>
<div id="dataAmt2" class="t" runat="server" style="font-size:60px; text-align:right;  width:750px; font-family:TimesNewRomanPSMT" ></div>
<div id="forAY" class="t" runat="server" style="font-size:60px; text-align:right;  width:750px; font-family:TimesNewRomanPSMT" ></div>

<div id="box13" class="t s_box_AY"></div>
<div id="data_AY" class="t" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT"></div>
<div id="box14" class="t s_box_PAN"></div>
<div id="data6" class="t" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT"></div>
<div id="box15" class="t s_box_NAME"></div>
<div id="data_NAME" class="t" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT"></div>
<div id="box16" class="t s_box_ADD"></div>
<div id="data_ADD" class="t" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT"></div>
<div id="box17" class="t s_box_ADD"></div>
<div id="box18" class="t s_box_TEL"></div>
<div id="data_TEL" class="t" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT"></div>
<div id="box19" class="t s_box_AY"></div>
<div id="data_PIN" class="t" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT"></div>

<div id="data_CRORES" class="t s_box_box" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT" ></div>
<div id="data_LACS" class="t s_box_box" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT" ></div>
<div id="data_THOUSAND" class="t s_box_box" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT"></div>
<div id="data_HUNDRED" class="t s_box_box" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT"></div>
<div id="data_TENS" class="t s_box_box" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT" ></div>
<div id="data_UNITS" class="t s_box_box" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT"></div>

<div id="data_BANK" class="t s_box_bank" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT" ></div>

<div id="box20" class="t s_box_AY"></div>
<div id="data_DATE" class="t" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT" runat="server" ></div>
<div id="box21" class="t s_box_SIGN"></div>
<div id="box22" class="t s_box_PAN2"></div>
<div id="data_PAN" class="t" runat="server" style="font-size:60px; font-family:TimesNewRomanPSMT" runat="server" ></div>
<div id="box23" class="t s_box_RCVD"></div>
<div id="boxRecieved" runat="server" class="t" style="font-size:60px; font-family:TimesNewRomanPSMT"> </div>
<div id="data_NAME2" class="t" runat="server" style="font-size:40px; font-family:TimesNewRomanPSMT"></div>
<div id="box24" class="t s_box_AY"></div>
<div id="line22" class="t s_line">____________________________________________________________</div>
<div id="line23" class="t s_line">____________________________________________________________</div>
<div id="line24" class="t s_line">____________________________________________________________</div>
<div id="line25" class="t s_line">____________________________________________________________</div>
<div id="line26" class="t s_line">____________________________________________________________</div>
<div id="t3_1" class="t s1_1">Single Copy (to be sent to the ZAO) </div>
<div id="line1" class="t s_line">____________________________________________________________________________________________</div>
<div id="t4_1" class="t s2_1">CHALLAN</div>
<div id="line5" class="t s_vline">________</div>
<div id="line6" class="t s_vline">________</div>
<div id="t5_1" class="t s3_1">Tax Applicable </div>
<div id="t6_1" class="t s1_1">(Tick One)</div>
<div id="t7_1" class="t s3_1">* </div>
<div id="t8_1" class="t s2_1">NO./</div>
<div id="t9_1" class="t s3_1">(0020) INCOME-TAX </div>
<div id="ta_1" class="t s3_1">ON COMPANIES </div>
<div id="tb_1" class="t s1_1">Assessment Year</div>
<div id="tc_1" class="t s2_1">ITNS 280</div>
<div id="td_1" class="t s3_1">(CORPORATION TAX)</div>
<%--<div id="te_1" class="t s4_1">-</div>--%>
<div id="tf_1" class="t s3_1">(0021) INCOME TAX (OTHER THAN </div>
<div id="tg_1" class="t s3_1">COMPANIES)</div>
<div id="line2" class="t s_line">____________________________________________________________________________________________</div>
<div id="th_1" class="t s1_1">Permanent Account Number </div>
<div id="ti_1" class="t s1_1">Full Name </div>
<div id="tj_1" class="t s1_1">Complete Address with City &amp; State </div>
<div id="tk_1" class="t s1_1">Tel No.</div>
<div id="tr_1" class="t s1_1">Pin</div>
<div id="tu_1" class="t s3_1">Type of Payment </div>
<div id="tv_1" class="t s1_1">(Tick One)</div>
<div id="tw_1" class="t s3_1">Advance Tax (100) </div>
<div id="tx_1" class="t s3_1">Surtax (102) </div>
<div id="ty_1" class="t s3_1">Self Assessment Tax (300) </div>
<div id="tz_1" class="t s3_1">Tax on Distributed Profits of Domestic Companies (106) </div>
<div id="t10_1" class="t s3_1">Tax on Regular Assessment (400) </div>
<div id="t11_1" class="t s3_1">Tax on Distributed Income to Unit Holders (107) </div>
<div id="line3" class="t s_line">____________________________________________________________________________________________</div>
<div id="t12_1" class="t s5_1">DETAILS OF PAYMENTS </div>
<div id="line21" class="t s_vline">______________</div>
<div id="line7" class="t s_vline">______________________________________________________</div>
<div id="line8" class="t s_line">____________________________________________________________</div>
<div id="line9" class="t s_line">____________________________________________________________</div>
<div id="line10" class="t s_line" runat="server" >____________________________________________________________</div>
<div id="line11" class="t s_line">____________________________________________________________</div>
<div id="line12" class="t s_line">____________________________________________________________</div>
<div id="line13" class="t s_line">____________________________________________________________</div>
<div id="line14" class="t s_line">____________________________________________________________</div>
<div id="line15" class="t s_line">____________________________________________________________</div>
<div id="line16" class="t s_line">____________________________________________________________</div>
<div id="line17" class="t s_line">____________________________________________________________</div>
<div id="line18" class="t s_line">____________________________________________________________</div>
<div id="line19" class="t s_line">____________________________________________________________</div>
<div id="line20" class="t s_line">____________________________________________________________</div>
<div id="t13_1" class="t s1_1">Amount (in Rs. Only)</div>
<div id="t14_1" class="t s5_1">FOR USE IN RECEIVING BANK </div>
<div id="t15_1" class="t s1_1">Income Tax </div>
<div id="t16_1" class="t s1_1">Debit to A/c / Cheque credited on </div>
<div id="t17_1" class="t s1_1">S</div>
<div id="t18_1" class="t s1_1">u</div>
<div id="t19_1" class="t s1_1">r</div>
<div id="t1a_1" class="t s1_1">c</div>
<div id="t1b_1" class="t s1_1">h</div>
<div id="t1c_1" class="t s1_1">a</div>
<div id="t1d_1" class="t s1_1">r</div>
<div id="t1e_1" class="t s1_1">g</div>
<div id="t1f_1" class="t s1_1">e</div>
<div id="t1g_1" class="t s1_1">-</div>
<div id="t1h_1" class="t s1_1">-</div>
<div id="t1i_1" class="t s1_1">Education Cess </div>
<div id="t1j_1" class="t s1_1">D</div>
<div id="t10D_1" class="t s1_1">D</div>
<div id="t1k_1" class="t s1_1">M </div>
<div id="t1l_1" class="t s1_1">M </div>
<div id="t1m_1" class="t s1_1">Y </div>
<div id="t1n_1" class="t s1_1">Y </div>
<div id="t1o_1" class="t s1_1">I</div>
<div id="t1p_1" class="t s1_1">n</div>
<div id="t1q_1" class="t s1_1">t</div>
<div id="t1r_1" class="t s1_1">e</div>
<div id="t1s_1" class="t s1_1">r</div>
<div id="t1t_1" class="t s1_1">e</div>
<div id="t1u_1" class="t s1_1">s</div>
<div id="t1v_1" class="t s1_1">t</div>
<div id="t1w_1" class="t s3_1">SPACE FOR BANK SEAL </div>
<div id="t1x_1" class="t s1_1">P</div>
<div id="t1y_1" class="t s1_1">e</div>
<div id="t1z_1" class="t s1_1">n</div>
<div id="t20_1" class="t s1_1">a</div>
<div id="t21_1" class="t s1_1">l</div>
<div id="t22_1" class="t s1_1">t</div>
<div id="t23_1" class="t s1_1">y</div>
<div id="t24_1" class="t s1_1">O</div>
<div id="t25_1" class="t s1_1">t</div>
<div id="t26_1" class="t s1_1">h</div>
<div id="t27_1" class="t s1_1">e</div>
<div id="t28_1" class="t s1_1">r</div>
<div id="t29_1" class="t s1_1">s</div>
<div id="t2a_1" class="t s1_1">T</div>
<div id="t2b_1" class="t s1_1">o</div>
<div id="t2c_1" class="t s1_1">t</div>
<div id="t2d_1" class="t s1_1">a</div>
<div id="t2e_1" class="t s1_1">l</div>
<div id="t2f_1" class="t s1_1">Total (in words) </div>
<div id="t2g_1" class="t s6_1">CRORES </div>
<div id="t2h_1" class="t s6_1">LACS </div>
<div id="t2i_1" class="t s6_1">THOUSANDS </div>
<div id="t2j_1" class="t s6_1">HUNDREDS </div>
<div id="t2k_1" class="t s6_1">TENS </div>
<div id="t2l_1" class="t s6_1">UNITS </div>
<div id="t2m_1" class="t s1_1">Paid in Cash/Debit to </div>
<div id="t2n_1" class="t s1_1">A/c /Cheque No. </div>
<div id="t2o_1" class="t s1_1">Dated </div>
<div id="t2p_1" class="t s1_1">Drawn on </div>
<div id="t2q_1" class="t s1_1">(Name of the Bank and Branch) </div>
<div id="t2r_1" class="t s1_1">Date: </div>
<div id="t2s_1" class="t s1_1">Signature of person making payment </div>
<div id="t2t_1" class="t s1_1">Rs. </div>
<div id="line4" class="t s_line">____________________________________________________________________________________________</div>
<div id="t2u_1" class="t s2_1">Taxpayers Counterfoil</div>
<div id="t2v_1" class="t s1_1">(To be filled up by tax payer) </div>
<div id="t2w_1" class="t s3_1">SPACE FOR BANK SEAL </div>
<div id="t2x_1" class="t s1_1">P</div>
<div id="t2y_1" class="t s1_1">A</div>
<div id="t2z_1" class="t s1_1">N</div>
<div id="t30_1" class="t s1_1">Received from </div>
<div id="t31_1" class="t s1_1">(Name) </div>
<div id="t_for_Name" runat="server" class="t s1_1" ></div>
<div id="t32_1" class="t s1_1">Cash/ Debit to A/c /Cheque No. </div>
<div id="t33_1" class="t s1_1">For Rs. </div>
<div id="tforRs" class="t s1_1" runat="server"></div>
<div id="t34_1" class="t s1_1">Rs. (in words) </div>
<div id="t35_1" class="t s1_1">Drawn on </div>
<div id="t36_1" class="t s1_1">(Name of the Bank and Branch) </div>
<div id="t37_1" class="t s1_1">on account of </div>
<div id="t38_1" class="t s1_1">Other than Companies </div>
<div id="t39_1" class="t s1_1">Income Tax on </div>
<div id="t3a_1" class="t s6_1"><%--(Strike out whichever is not applicable)--%> </div>
<div id="t3b_1" class="t s1_1">Type of Payment </div>
<div id="t3c_1" class="t s6_1">Self Assessment Tax </div>
<div id="t3d_1" class="t s1_1">for the Assessment Year </div>
<div id="t3f_1" class="t s1_1">Rs. </div>
</div>
</div>
</div>
<br />
<div style=" font-family:TimesNewRomanPSMT">
Generated by www.echarteredaccountants.com
</div>
</center>
   <%-- <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="javascript:CallPrint('challan');">Print</asp:LinkButton>--%>
    <%--<a href="#" onclick ="javascript:CallPrint('challan');">Print</a>--%>
    <br />
    <div style="padding-left:623px;">
    <asp:Button ID="btn1" runat="server" Text="Print" OnClientClick="javascript:hide(),window.print();"  style=" background-color:#e14658; border-color:#007095; text-align:center; border-style:none; border-radius:3px; border-width:0; font-weight: normal; padding-top:1rem; padding-bottom:1.0625rem; padding-left:0rem; font-size:1rem ; color:white; width:200px; cursor:pointer; " />
  <%--  &nbsp;
    <asp:Button ID="Button1" runat="server" Text="Print" OnClientClick="javascript:hide(),window.print();" style=" background-color:#e14658; border-color:#007095; text-align:center; border-style:none; border-radius:3px; border-width:0; font-weight: normal; padding-top:1rem; padding-bottom:1.0625rem; padding-left:0rem; font-size:1rem ; color:white; width:200px; cursor:pointer; "  />--%>
    </div>
    <br />
</form>
</body>
</html>
