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

/// <summary>
/// Summary description for bllFloating
/// </summary>
/// 
namespace Taxation.BusinessLogic
{
    public class bllFloating
    {

        #region Variables
        denFloating objFloatingDEO;
        dalFloating objFloatingDAO;
        #endregion

        #region Constructors
        public bllFloating()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Utilities
        public List<denFloating> GetFlaotingHeaders(string strnameID, int intC16, int intconstID,int intSelection, string mainID)
        {
            List<denFloating> genFloating;
            try
            {
                objFloatingDAO = new dalFloating();
                denFloating objFloatingDEO2 = new denFloating();
                genFloating = new List<denFloating>();
                
                genFloating = objFloatingDAO.GetFloatHeaders(strnameID, intC16, intconstID, mainID);
                if (intSelection == 1)                
                    genFloating.Add(objFloatingDEO2);
                            
                return genFloating;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertFloatGridData(denFloating objFloatingDEO)
        {
            try
            {
                objFloatingDAO = new dalFloating();
                //objFloatingDEO = new denFloating();
                //objFloatingDAO = new dalFloating();
                return objFloatingDAO.InsertFloatGridData(objFloatingDEO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertFloatManagedData(denFloating objFloatingDEO)
        {
            try
            {
                objFloatingDAO = new dalFloating();
                objFloatingDAO.InsertFloatManagedData(objFloatingDEO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string IsFloatSec(int H1)
        {
            try
            {
                objFloatingDAO = new dalFloating();
                return objFloatingDAO.IsFloatSec(H1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(denFloating objFloatingDEO)
        {
            try
            {
                objFloatingDAO = new dalFloating();
                objFloatingDAO.Delete(objFloatingDEO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertOrUpdate(denFloating objFloatingDEO)
        {
            try
            {
                objFloatingDAO = new dalFloating();
                return objFloatingDAO.InsertOrUpdate(objFloatingDEO);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int getTabCnt(string VType, string AY)
        {
            try
            {
                objFloatingDAO = new dalFloating();
                return objFloatingDAO.getTabCnt(VType, AY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectT1000_Rules(int H1, string AY, string ITR)
        {
            try
            {
                objFloatingDAO = new dalFloating();
                return objFloatingDAO.SelectT1000_Rules(H1, AY, ITR);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectFloatData(string AY, string NameID, int CID)
        {
            try
            {
                objFloatingDAO = new dalFloating();
                return objFloatingDAO.SelectFloatData(AY, NameID, CID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}