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
    /// Summary description for bllMain
    /// </summary>
    public class bllMain
    {
        #region Constructor
        public bllMain()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        
        dalMain objMainDAL;
        #endregion

        #region Functions
        public List<denMain> GetAssYear()
        {
            List<denMain> genListAY;
            try
            {
                genListAY = new List<denMain>();
                objMainDAL = new dalMain();
                genListAY = objMainDAL.GetAssYear();
                return genListAY;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<denMain> GetFinYear()
        {
            List<denMain> genListAY;
            try
            {
                genListAY = new List<denMain>();
                objMainDAL = new dalMain();
                genListAY = objMainDAL.GetFinYear();
                return genListAY;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<denMain> GetAssesseeList(string UserName, string TypeOfAss)
        {
            List<denMain> genListMain;
            try
            {
                genListMain = new List<denMain>();

                objMainDAL = new dalMain();
                genListMain= objMainDAL.GetAssesseeList(UserName,TypeOfAss);
                return genListMain;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<BALVatasETDS.TANMaster.tbl_TANMaster> GetTANList(string UserName)
        {
            try
            {                
                objMainDAL = new dalMain();
                return objMainDAL.GetTANList(UserName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<denMain> GetAuditor()
        {
            List<denMain> genListAuditor;
            try
            {
                genListAuditor = new List<denMain>();
                objMainDAL = new dalMain();
                genListAuditor = objMainDAL.GetAuditor();
                return genListAuditor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denMain GetDueDate(string AY, int Status, int Audited, int StateID)
        {
            denMain objMainDEN;
            dalMain objMainDAL;

            try
            {
                objMainDAL = new dalMain();
                objMainDEN = new denMain();
                objMainDEN = objMainDAL.GetDueDate(AY, Status, Audited, StateID);
                return objMainDEN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CountNames(string UserName)
        {
            try
            {
                dalMain objMainDAL;
                objMainDAL = new dalMain();
                return objMainDAL.CountNames(UserName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMenu(string AY, string ITR, string Assessee, string Project, Int64 userID)
        {
            try
            {
                dalMain objMainDAL;
                objMainDAL = new dalMain();
                return objMainDAL.getMenu(AY, ITR, Assessee, Project, userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMenuGlobal(string project, string AY)
        {
            try
            {
                dalMain objMainDAL;
                objMainDAL = new dalMain();
                return objMainDAL.getMenuGlobal(project, AY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int MenuID(string PN, string AY, string MLink)
        {
            try
            {
                dalMain objMainDAL;
                objMainDAL = new dalMain();
                int MID = objMainDAL.getMenuLink(PN, AY, MLink);
                return MID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetDetails(string NameID)
        {
            try
            {
                dalMain objMainDAL;
                objMainDAL = new dalMain();
                return objMainDAL.GetDetails(NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getMainID(string NameID, string Col3)
        {
            try
            {
                dalMain objMainDAL;
                objMainDAL = new dalMain();
                return objMainDAL.getMainID(NameID, Col3);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getT00_Details(int C1, string AY, string ITR)
        {
            try
            {
                dalMain objMainDAL;
                objMainDAL = new dalMain();
                return objMainDAL.getT00_Details(C1, AY, ITR);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To set Main Page Data w.r.t. NameID, AY and MainID
        public void SetMainPageData(string NameID, string AY, string MainID, string EmployerCategory, string TaxStatus, string ReturnFiledUnderSection, string AreYouGovByPortugeseCivilCode, string PANOfSpouse, string WhetherOriginalOrRevisedReturn, string OrgAckNo, string DateOfFilingOrgReturn, string DateofFilingOriginalReturn, string OriginalAcknowledgementNo, string NoticeNo, string DateOfNotice, string TRPPIN, string NameofTRP, string AmtToBePaidToTRP)
        {
            try
            {
                dalMain objMainDAL;
                objMainDAL = new dalMain();
                objMainDAL.SetMainPageData(NameID, AY, MainID, EmployerCategory, TaxStatus, ReturnFiledUnderSection, AreYouGovByPortugeseCivilCode, PANOfSpouse, WhetherOriginalOrRevisedReturn, OrgAckNo, DateOfFilingOrgReturn, DateofFilingOriginalReturn, OriginalAcknowledgementNo, NoticeNo, DateOfNotice, TRPPIN, NameofTRP, AmtToBePaidToTRP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To set Signatory Page Data w.r.t. NameID, AY and MainID
        public void SetSignPageData(string NameID, string AY, string MainID, string NameOfAssessee, string PANOfAssessee, string FatherName, string PlaceOfAssessee, string Date)
        {
            try
            {
                dalMain objMainDAL;
                objMainDAL = new dalMain();
                objMainDAL.SetSignPageData(NameID, AY, MainID, NameOfAssessee, PANOfAssessee, FatherName, PlaceOfAssessee, Date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region TDS
        public void TDSMasterDetails(string TAN, string FY, string RegularCorrection, string Quarter, string FormNo, string AY)
        {
            try
            {
                dalMain objMainDAL;
                objMainDAL = new dalMain();
                objMainDAL.TDSMasterDetails(TAN, FY, RegularCorrection, Quarter, FormNo, AY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable FormQuaeterMapping(string FormNo, string Quarter,string Type)
        {
            dalMain objMainDAL;
            objMainDAL = new dalMain();
            DataTable dt = new DataTable();
            dt = objMainDAL.FormQuaeterMapping(FormNo, Quarter,Type);
            return dt;
        }

        public int IsDataExists(string TAN, string FY, string FormNo, string Quarter, string Type,string Vtype)
        {
            int IsExists = 0;
            try
            {
                
                dalMain objMainDAL;
                objMainDAL = new dalMain();
                IsExists=objMainDAL.IsDataExists(TAN, FY, FormNo, Quarter, Type,Vtype);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsExists;
        }

        public bool IsProject_XML(string ReturnType)
        {
            dalMain objMainDAL = new dalMain();
            return objMainDAL.IsProject_XML(ReturnType);
        }

        #endregion

    }
}