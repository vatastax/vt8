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
using Taxation.DataAccess;
using Taxation.DataEntity;
namespace Taxation.BusinessLogic
{

    /// <summary>
    /// Summary description for bllScreen
    /// </summary>
    public class bllScreen
    {
        #region Variables
        dalScreen objDalScreen;
        denScreen objDenScreen;
        //int voucher, gridindex;
        //string assessyear, combovisible, labeltext, radiovisible;
        #endregion


        #region Constructors

        public bllScreen()
        {
            //
            // TODO: Add constructor logic here
            //
            objDalScreen = new dalScreen();

        }
        #endregion

        #region Utilities

        public List<denScreen> getComboData(int intVtype, string ITR, string AY)
        {

            try
            {

                return objDalScreen.getComboData(intVtype, ITR, AY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        public denScreen getSettings(int intVType)
        {
            try
            {
                dalScreen objDalScreen;
                objDalScreen = new dalScreen();
               return objDalScreen.getSettings(intVType);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string getVTypeByScreenTitle(string screenTitle)
        {
            try
            {
                dalScreen objDalScreen;
                objDalScreen = new dalScreen();
                return objDalScreen.getVTypeByScreenTitle(screenTitle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // following functions are for TDS by Mudit:

        public List<denScreen> getOtherComboData(int intVtype, string ITR, string AY, string TAN, string FormNo, string Regular_Correction, string FY, string Quarter)
        {
            try
            {
                return objDalScreen.getOtherComboData(intVtype, ITR, AY, TAN, FormNo, Regular_Correction, FY, Quarter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getNextPrevVType(string VType, string IsNextCont, string AY, string ITRType, string Tab)
        {
            try
            {
                return objDalScreen.getNextPrevVType(VType, IsNextCont, AY, ITRType, Tab);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 getFirstLast(string VType, string AY, string ITRType)
        {
            try
            {
                return objDalScreen.getFirstLast(VType, AY, ITRType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
