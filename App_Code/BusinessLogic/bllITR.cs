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
    /// Summary description for bllITR
    /// </summary>
    public class bllITR
    {
        #region Constructors
        public bllITR()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        dalITR objdalITR;
        
        #endregion

        #region Functions
        public denITR fetchData(Int64 ID)
        {
            objdalITR = new dalITR();
            return objdalITR.fetchData(ID);
        }

        public denITR getITRData(Int64 NameID, string AY, string ITRType)
        {
            objdalITR = new dalITR();
            return objdalITR.getITRData(NameID, AY, ITRType);
        }

        public denITR getITRData2(Int64 NameID, string AY, string ITRType)
        {
            objdalITR = new dalITR();
            return objdalITR.getITRData2(NameID, AY, ITRType);
        }

        public denITR getITRData(Int64 NameID, string AY)
        {
            objdalITR = new dalITR();
            return objdalITR.getITRData(NameID, AY);
        }

        public int getITRData_Main(Int64 NameID, string AY)
        {
            objdalITR = new dalITR();
            return objdalITR.getITRData_Main(NameID, AY);
        }

        //To Select ITR Types on the basis of Project Name
        public List<denITR> Select(string Project)
        {
            objdalITR = new dalITR();
            return objdalITR.Select(Project);
        }

        public int getReturnType(string detail, string Project)
        {
            objdalITR = new dalITR();
            return objdalITR.getReturnType(detail, Project);
        }

        //To Select ITR Types on the basis of Project Name
        public DataTable SelectITR(string Project)
        {
            objdalITR = new dalITR();
            return objdalITR.SelectITR(Project);
        }

        #endregion

    }
}