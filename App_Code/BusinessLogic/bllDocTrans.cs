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
namespace Taxation.BusinessLogic
{


    /// <summary>
    /// Summary description for bllDocTrans
    /// </summary>
    public class bllDocTrans
    {
        #region Constructors
        public bllDocTrans()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        
        dalDoctrans objDocTransDAL;
        #endregion

        #region Functions
        public int InsertMiscDetails(denDocTrans objDocTransDEN, out Int32 IsExists)
        {
            try
            {
                objDocTransDAL = new dalDoctrans();
                return objDocTransDAL.InsertMiscDetails(objDocTransDEN, out IsExists);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateMiscDetails(denDocTrans objDocTransDEN)
        {
            try
            {
                objDocTransDAL = new dalDoctrans();
                return objDocTransDAL.updateMiscDetails(objDocTransDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateBankDetails(denDocTrans objDocTransDEN)
        {
            try
            {
                objDocTransDAL = new dalDoctrans();
                return objDocTransDAL.UpdateBankDetails(objDocTransDEN);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateRepresentativeDetails(denDocTrans objDocTransDEN)
        {
            try
            {
                objDocTransDAL = new dalDoctrans();
                return objDocTransDAL.UpdateRepresentativeDetails(objDocTransDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateField(string field, string val, string NameID)
        {
            try
            {
                objDocTransDAL = new dalDoctrans();
                return objDocTransDAL.UpdateField(field, val, NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateAuthorisedSignatory(denDocTrans objDocTransDEN)
        {
            try
            {
                objDocTransDAL = new dalDoctrans();
                return objDocTransDAL.UpdateAuthorisedSignatory(objDocTransDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public denDocTrans GetBankDetails(string NameID)
        {
            try
            {
                denDocTrans objDocTransDEN;
                objDocTransDAL = new dalDoctrans();
                objDocTransDEN = objDocTransDAL.GetBankDetails(NameID);
                return objDocTransDEN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public denDocTrans GetRepresentativeDetails(string NameID)
        {
            try
            {
                denDocTrans objDocTransDEN;
                objDocTransDAL = new dalDoctrans();
                objDocTransDEN = objDocTransDAL.GetRepresentativeDetails(NameID);
                return objDocTransDEN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int IsExists(string NameID)
        {
            try
            {
                objDocTransDAL = new dalDoctrans();
                return objDocTransDAL.IsExists(NameID);   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getState(string NameID)
        {
            try
            {
                objDocTransDAL = new dalDoctrans();
                return objDocTransDAL.getState(NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Function Added by Mudit on 01/09/2015 to enter main page data in storetrans
        public int InsertMainDataInStoreTrans(denDocTrans objDocTransDEN, string AY, string ITRType, string EmpCategory, string DueDate,int FlagPri)
        {
            try
            {
                objDocTransDAL = new dalDoctrans();
                return objDocTransDAL.InsertMainDataInStoreTrans(objDocTransDEN,AY,ITRType,EmpCategory,DueDate,FlagPri);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}