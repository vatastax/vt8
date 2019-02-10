using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpdateProgress.ExtendedUpdateProgress
{
    /// <summary>
    /// This UpdateProgress control is an extension of the Ajax UpdateProgress control that will hide/show a specified div tag when 
    /// activated. To use this control, you need to specify the DivToHide by Id and AssociatedUpdatePanelID. 
    /// </summary>
    public class ExtendedUpdateProgress : System.Web.UI.UpdateProgress
    {
        #region Public Properties


        private string divToHide;
        /// <summary>
        /// The Div that the UdpateProgress Control will hide and show when activation
        /// </summary>
        public string DivToHide
        {
            get
            {
                return divToHide;
            }
            set
            {
                divToHide = value;
            }
        }

        private string imageToDisplay;

        /// <summary>
        /// Sets or gets the type of animation to be display in the UpdateProgress panel, valid options are Small and Large
        /// </summary>
        public string ImageToDisplay
        {
            get
            {
                return imageToDisplay;
            }
            set
            {
                imageToDisplay = value;
            }
        }
        #endregion

        #region Managed Code

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Register Hidden Fields to page
                RegisteredHiddenFields();

                //Register all function declarations
                RegisterMainFunctions();

                //Register Javascript page events
                RegisterEvents();

                //Initialize/register the control in Javascript
                InitializeControl();
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// Registers any required Hidden input fields to the page.
        /// </summary>
        private void RegisteredHiddenFields()
        {
            Page.ClientScript.RegisterHiddenField("postBackPanel", "");
        }


        /// <summary>
        /// This method will declare the functions and members to be used in the client side browser. These functions will ensure
        /// that the control is registered to the page accordingly and will handle the showing and hiding of the DivToHide control
        /// 
        /// Some additional formatting with Environment.NewLine characters has been added for easier viewing and debugging at runtime.
        /// </summary>
        private void RegisterMainFunctions()
        {
            StringBuilder script = new StringBuilder();
            script.Append("<script type='text/javascript'>" + Environment.NewLine);

            //Array to hold UpdateProgress registrations
            script.Append(" var updateProgressControls " + Environment.NewLine);

            //Update Progress Javascript object
            script.Append(" function UpdateProgress(updatePanelId, controlToHideId, updateProgressId){ " + Environment.NewLine);
            script.Append(" this.ControlToHideId = controlToHideId; " + Environment.NewLine);
            script.Append(" this.UpdatePanelId = updatePanelId; " + Environment.NewLine);
            script.Append(" this.UpdateProgressId = updateProgressId; " + Environment.NewLine);
            script.Append(" }  " + Environment.NewLine);
            script.Append(Environment.NewLine);

            //Set up Update Progress control. 
            script.Append(" function SetUpdateProgressControl(updatePanelId, controlToHideId, updateProgressId){ " + Environment.NewLine);
            script.Append(" /* Intantiate the updateProgressControls array if null */ " + Environment.NewLine);
            script.Append(" if (updateProgressControls == null) " + Environment.NewLine);
            script.Append("   updateProgressControls = new Array(); " + Environment.NewLine);
            script.Append(Environment.NewLine);
            script.Append(" /* if the control already exists replace it, else insert into the array*/ " + Environment.NewLine);
            script.Append(" var controlIndex = 0; " + Environment.NewLine);
            script.Append(" for (var i=0, len=updateProgressControls.length; i<len; ++i ) " + Environment.NewLine);
            script.Append(" { " + Environment.NewLine);
            script.Append("   if (updateProgressControls[i].UpdatePanelId == updatePanelId){ " + Environment.NewLine);
            script.Append("     controlIndex = i; " + Environment.NewLine);
            script.Append("     break;} " + Environment.NewLine);
            script.Append("   controlIndex = controlIndex + 1; " + Environment.NewLine);
            script.Append(" } " + Environment.NewLine);
            script.Append(" updateProgressControls[controlIndex] = new UpdateProgress(updatePanelId, controlToHideId, updateProgressId);} " + Environment.NewLine);
            script.Append(Environment.NewLine);

            //Get's the control to hide or show
            script.Append(" function GetUpdateControl(panelId) { " + Environment.NewLine);
            script.Append(" if (panelId == null || panelId == '') " + Environment.NewLine);
            script.Append("   return null; " + Environment.NewLine);
            script.Append(Environment.NewLine);
            script.Append(" /* get the UpdatePanel ID */ " + Environment.NewLine);
            script.Append(" var rawPanelId = panelId.split('|')[0]; " + Environment.NewLine);
            script.Append(" var updatePanelId = rawPanelId.substring(rawPanelId.lastIndexOf('$')+1, rawPanelId.length) " + Environment.NewLine);
            script.Append(" /* find the update panel in the updateProgressControls array and return */ " + Environment.NewLine);
            script.Append(" for (var i=0, len=updateProgressControls.length; i<len; ++i ) " + Environment.NewLine);
            script.Append(" { ");
            script.Append("   if (updateProgressControls[i].UpdatePanelId == updatePanelId) " + Environment.NewLine);
            script.Append("   { ");
            script.Append("     return updateProgressControls[i]; " + Environment.NewLine);
            script.Append("   } ");
            script.Append(" } ");
            script.Append(" return null; " + Environment.NewLine);
            script.Append(" } " + Environment.NewLine);
            script.Append(Environment.NewLine);

            //Declare BeginRequestHandler
            script.Append(" function BeginRequestHandler(sender, args){ " + Environment.NewLine);
            script.Append(" /* If the postback is called from with a registered UpdatePanel, hide it's ControlToHide */ " + Environment.NewLine);
            script.Append(" var updateControl = GetUpdateControl(sender._postBackSettings.panelID); " + Environment.NewLine);
            script.Append(" if (updateControl != null) { " + Environment.NewLine);
            script.Append("   var postBackPanelControl = document.getElementById('postBackPanel'); " + Environment.NewLine);
            script.Append("   postBackPanelControl.value = sender._postBackSettings.panelID; " + Environment.NewLine);
            script.Append("   var cbk = Function.createCallback(hideControl, {ControlToHideId: updateControl.ControlToHideId");
            script.Append("       , UpdateProgressId: updateControl.UpdateProgressId}); " + Environment.NewLine);
            script.Append("   window.setTimeout(cbk, " + (DisplayAfter + 1) + "); " + Environment.NewLine);
            script.Append("   } " + Environment.NewLine);
            script.Append(" } " + Environment.NewLine);
            script.Append(Environment.NewLine);

            //Declare EndRequestHandler
            script.Append(" function EndRequestHandler(sender, args){ " + Environment.NewLine);
            script.Append(" /* If the postback is called from with a registered UpdatePanel, show it's ControlToHide */ " + Environment.NewLine);
            script.Append(" var postBackPanelControl = document.getElementById('postBackPanel'); " + Environment.NewLine);
            script.Append(" var panelId = (sender._postBackSettings.panelID == null)?postBackPanelControl.value:sender._postBackSettings.panelID; " + Environment.NewLine);
            script.Append(" var updateControl = GetUpdateControl(panelId); " + Environment.NewLine);
            script.Append(" if (updateControl != null) {" + Environment.NewLine);
            script.Append("   showControl(updateControl.ControlToHideId); ");
            script.Append("   } " + Environment.NewLine);
            script.Append(" postBackPanelControl.value = ''; " + Environment.NewLine);
            script.Append(" } " + Environment.NewLine);
            script.Append(Environment.NewLine);

            //Declare hideControl
            script.Append(" function hideControl(e, context){ " + Environment.NewLine);
            script.Append(" var controlId = (e.ControlToHideId == null)?context.ControlToHideId:e.ControlToHideId; " + Environment.NewLine);
            script.Append(" var updateProgressId = (e.UpdateProgressId == null)?context.UpdateProgressId:e.UpdateProgressId; " + Environment.NewLine);
            script.Append(" var divToHide = document.getElementById(controlId); " + Environment.NewLine);
            script.Append(" var progressDiv = document.getElementById(updateProgressId); " + Environment.NewLine);
            script.Append(" /* If the UpdateProgress control for this UpdatePanel is visible, hide the associated div */ " + Environment.NewLine);
            script.Append(" if (progressDiv.style.display != 'none') {" + Environment.NewLine);
            script.Append("   divToHide.style.visibility = 'hidden'; " + Environment.NewLine);
            script.Append("   divToHide.style.display = 'none';} } " + Environment.NewLine);
            script.Append(Environment.NewLine);

            //Declare showControl
            script.Append(" function showControl(controlId){ " + Environment.NewLine);
            script.Append(" var divToHide = document.getElementById(controlId); " + Environment.NewLine);
            script.Append(" /* show the associated div */ " + Environment.NewLine);
            script.Append(" divToHide.style.visibility = 'visible'; " + Environment.NewLine);
            script.Append(" divToHide.style.display = 'block';} " + Environment.NewLine);

            script.Append(" </script> ");

            ScriptManager.RegisterStartupScript(Page, GetType(), "MethodCalls", script.ToString(), false);
        }

        /// <summary>
        /// Register the Begin and End Request events. These will handle the hiding and showing of the DivToHid control when a postback is
        /// initiated and terminated by the browser
        /// </summary>
        private void RegisterEvents()
        {
            StringBuilder RegisterEventsScript = new StringBuilder();
            RegisterEventsScript.Append("<script type='text/javascript'> " + Environment.NewLine);
            //Register Begin and End Request Event Handlers
            RegisterEventsScript.Append(
                " Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler); " + Environment.NewLine);
            RegisterEventsScript.Append(
                " Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler); " + Environment.NewLine);
            RegisterEventsScript.Append(" </script> ");

            Page.ClientScript.RegisterStartupScript(GetType(), "beginRequest", RegisterEventsScript.ToString(),
                                                    false);
        }

        /// <summary>
        /// Call the SetUpdateProgressControl Javascript method with the appropriate values to ensure this control has been
        /// registered properly in the Javascript updateProgressControls array
        /// </summary>
        private void InitializeControl()
        {
            StringBuilder SetUpdateProgress = new StringBuilder();
            SetUpdateProgress.Append("<script type='text/javascript'> " + Environment.NewLine);
            SetUpdateProgress.Append(" SetUpdateProgressControl('" + AssociatedUpdatePanelID + "', '" +
                                     DivToHide + "', '" + ClientID + "'); " + Environment.NewLine);
            SetUpdateProgress.Append(" </script> " + Environment.NewLine);

            Page.ClientScript.RegisterStartupScript(GetType(), "initRequest_" + ClientID, SetUpdateProgress.ToString(),
                                                    false);
        }

        #endregion

        #region Add Img to Template
        /// <summary>
        /// The Template to be added to the UpdateProgress Control
        /// </summary>
        public class ProgressImgTemplate : ITemplate
        {
            private string imageURL;
            private string updateProgressClientId;
            public ProgressImgTemplate(string URLOfImage, string clientId)
            {
                imageURL = URLOfImage;
                updateProgressClientId = clientId;
            }

            /// <summary>
            /// Creates the content of the UpdateProgress Control, in this case a Image.
            /// </summary>
            /// <param name="container"></param>
            public void InstantiateIn(Control container)
            {
                Image img = new Image();
                img.ID = "LoadingImage_" + updateProgressClientId;
                img.AlternateText = "";
                img.ImageUrl = imageURL;

                container.Controls.Add(img);

            }
        }

        /// <summary>
        /// Sets the template of the UpdateProgress Control to a dynamically generated one based on the ImageToDisplay property
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            string imageURL;
            if (imageToDisplay == "Large")
                imageURL = "~/images/loading.gif";
            else
                imageURL = "~/images/loading_small.gif";

            ProgressTemplate = new ProgressImgTemplate(imageURL, ClientID);
        }
        #endregion
    }
}