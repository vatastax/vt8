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
    public class bllBankBranches
    {
        public bllBankBranches()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        #region Variables
        dalAssetTrans objAssetTransDAL;

        #endregion

        #region Functions

        public string SelectSingle(string BSRCode)
        {
            dalBankBranches objdalBankBranches;
            try
            {
                objdalBankBranches = new dalBankBranches();
                return objdalBankBranches.SelectSingle(BSRCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SelectBankByIFSC(string IFSC)
        {
            dalBankBranches objdalBankBranches;
            try
            {
                objdalBankBranches = new dalBankBranches();
                return objdalBankBranches.SelectBankByIFSC(IFSC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}