using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ICompanyDetails
/// </summary>
/// 
namespace Taxation.Interface
{
    interface ICompanyDetails
    {
        int Company_Nature
        {
            get;
            set;
        }
        string CompName
        {
            get;
            set;
        }
        string Address1
        {
            get;
            set;
        }
        string Address2
        {
            get;
            set;
        }
        string Address3
        {
            get;
            set;
        }
        string Address4
        {
            get;
            set;
        }
        string City
        {
            get;
            set;
        }
        int State
        {
            get;
            set;
        }
        string PIN
        {
            get;
            set;
        }
        string CompPan
        {
            get;
            set;
        }
        string AssesseeID
        {
            get;
            set;
        }
        string FormNO
        {
            get;
            set;
        }
    }
}