
//Sys.Application.add_init(AppInit);

//function AppInit(sender) {
//    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(End);
//}

//function End(sender, args) {
////        try {
////            //var prm = Sys.WebForms.PageRequestManager.getInstance();
////            //if (prm != null) {
//////                prm.add_endRequest(function (sender, e) {
//////                    if (sender._postBackSettings.panelsToUpdate != null) {

//////                        $("#<%=grdState.ClientID %>").find("input[type=text][id*=txtAmount]").each(function () {
//////                            $("#<%=grdState.ClientID %>").find("input[type=text][id*=txtAmount]").onkeyup(function () {
//////                                //alert('focus');
//////                                try {
//////                                    $(this).focus();
//////                                }
//////                                catch (e) {
//////                                     alert(e);
//////                                }
//////                            });
//////                        });
//////                    }
//////                });
////            //}
////        }
////        catch (e) {
////            //document.write(e.ToString());
////            setTimeout(Sys.WebForms.PageRequestManager.getInstance().add_endRequest(End), 500);
////        }
// }


////$(document).ready(function ($) {
////    //alert('asd');

////    try {
////        var prm = Sys.WebForms.PageRequestManager.getInstance();
////        if (prm != null) {
////            prm.add_endRequest(function (sender, e) {
////                if (sender._postBackSettings.panelsToUpdate != null) {

////                    $("#<%=grdState.ClientID %>").find("input[type=text][id*=txtAmount]").each(function () {
////                        $("#<%=grdState.ClientID %>").find("input[type=text][id*=txtAmount]").onkeyup(function () {
////                            //alert('focus');
////                            try {
////                                $(this).focus();
////                            }
////                            catch (e) {
////                                document.write(e.ToString()); // alert(e);
////                            }
////                        });
////                    });
////                }
////            });
////        };
////    }
////    catch (e) {
////        document.write(e.ToString());
////        //alert(e);
////    }
////});