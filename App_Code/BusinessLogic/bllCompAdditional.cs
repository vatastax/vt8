using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Taxation.DataEntity;
using Taxation.DataAccess;
namespace Taxation.BusinessLogic
{
    /// <summary>
    /// Summary description for bllCompAdditional
    /// </summary>
    
    public class bllCompAdditional
    {
       
        public bllCompAdditional()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public List<denCompAdditional> FillGrid(string AssesseeID)
        {
            try
            {
                dalCompAdditional objCompAdditionalDAL=new dalCompAdditional();
                List<denCompAdditional> lstCompAdditional = new List<denCompAdditional>();
                lstCompAdditional = objCompAdditionalDAL.FillGrid(AssesseeID);
                return lstCompAdditional;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}