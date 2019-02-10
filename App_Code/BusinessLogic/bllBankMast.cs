using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataEntity;
using Taxation.DataAccess;
using System.Collections.Generic;

namespace Taxation.BusinessLogic
{


    /// <summary>
    /// Summary description for bllBankMast
    /// </summary>
    
    public class bllBankMast
    {
        #region Constructor
        public bllBankMast()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        
        #endregion

        #region Functions
        public int InsertDataBankMast(denBankMast objBankMastDEN)
        {
            try
            {
                dalBankMast objBankMastDAL;
                objBankMastDAL = new dalBankMast();
                objBankMastDAL.InsertDataBankMast(objBankMastDEN);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateDataBankMast(denBankMast objBankMastDEN)
        {
            try
            {

                dalBankMast objBankMastDAL;
                objBankMastDAL = new dalBankMast();
                objBankMastDAL.UpdateDataBankMast(objBankMastDEN);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByAssesse(Int64 AssesseeID)
        {
            try
            {
                dalBankMast objBankMastDAL;
                objBankMastDAL = new dalBankMast();
                return objBankMastDAL.SelectByAssesse(AssesseeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<denBankMast> Select(Int32 BankID)
        {
            try
            {
                dalBankMast objBankMastDAL;
                objBankMastDAL = new dalBankMast();
                return objBankMastDAL.Select(BankID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Int32 BankID)
        {
            try
            {
                dalBankMast objBankMastDAL;
                objBankMastDAL = new dalBankMast();
                objBankMastDAL.Delete(BankID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}