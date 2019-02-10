using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataAccess;
using Taxation.DataEntity;
using System.Collections.Generic;

namespace Taxation.BusinessLogic
{
    /// <summary>
    /// Summary description for bllAssessee
    /// </summary>
    public class bllAssessee
    {
#region Constructor

        public bllAssessee()
        {
            //
            // TODO: Add constructor logic here
            //
        }
#endregion
        #region Variables
        dalAssessee objAssesseeDAL;
        #endregion

        #region Functions
        public denAssesseeIndividual GetDataIndividual(string PAN)
        {
            try
            {
                objAssesseeDAL = new dalAssessee();
                denAssesseeIndividual objAssesseeIndividualDEN;
                objAssesseeIndividualDEN = objAssesseeDAL.GetDataIndividual(PAN);
                return objAssesseeIndividualDEN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         //Function to Select Data of AssesseeIndividual w.r.t. NameID
        public denAssesseeIndividual GetDataIndividualByNameID(string NameID)
        {
            try
            {
                objAssesseeDAL = new dalAssessee();
                denAssesseeIndividual objAssesseeIndividualDEN;
                objAssesseeIndividualDEN = objAssesseeDAL.GetDataIndividualByNameID(NameID);
                return objAssesseeIndividualDEN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denAssesseeIndividual GetDataIndividual(string PAN, string User)
        {
            try
            {
                objAssesseeDAL = new dalAssessee();
                denAssesseeIndividual objAssesseeIndividualDEN;
                objAssesseeIndividualDEN = objAssesseeDAL.GetDataIndividual(PAN, User);
                return objAssesseeIndividualDEN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denAssesseePartner GetDataPartner(string PAN)
        {
            try
            {
                objAssesseeDAL = new dalAssessee();
                denAssesseePartner objAssesseePartnerDEN;
                objAssesseePartnerDEN = objAssesseeDAL.GetDataPartner(PAN);
                return objAssesseePartnerDEN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public denAssesseeMain GetDataGeneral(string PAN)
        {
            try
            {
                objAssesseeDAL = new dalAssessee();
                denAssesseeMain objAssesseeMainDEN;
                objAssesseeMainDEN = objAssesseeDAL.GetDataGeneral(PAN);
                return objAssesseeMainDEN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public denAssesseeCompany GetDataCompany(string PAN)
        {
            try
            {
                objAssesseeDAL = new dalAssessee();
                denAssesseeCompany objAssesseeCompanyDEN;
                objAssesseeCompanyDEN = objAssesseeDAL.GetDataCompany(PAN);
                return objAssesseeCompanyDEN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertNameMastIndividual(denAssesseeIndividual objAssesseeDEN)
        {
            objAssesseeDAL = new dalAssessee();
            return objAssesseeDAL.InsertDataIndividual(objAssesseeDEN);
        }
        public int InsertDataIndividualDirect(denAssesseeIndividual objAssesseeIndividualDEN)
        {
            objAssesseeDAL = new dalAssessee();
            return objAssesseeDAL.InsertDataIndividualDirect(objAssesseeIndividualDEN);
        }
        public int InsertDataGeneral(denAssesseeMain objAssesseeMainDEN)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.InsertDataGeneral(objAssesseeMainDEN);
            return 0;
        }
        public int InsertDataCompany(denAssesseeCompany objAssesseeCompanyDEN)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.InsertDataCompany(objAssesseeCompanyDEN);
            return 0;
        }
        public int InsertDataPartner(denAssesseePartner objAssesseePartnerDEN)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.InsertDataPartner(objAssesseePartnerDEN);
            return 0;
        }
        public void InsertBankMastData(string AssessId, string BankName, string Address, string AccountType, string AccountNo, string IFSCCode)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.AddBankMast(AssessId, BankName, Address, AccountType, AccountNo, IFSCCode);
            
        }
        public DataTable GetBankDetail(string Name_ID)
        { objAssesseeDAL = new dalAssessee();
            DataTable dt = new DataTable();
            dt = objAssesseeDAL.getBankMast(Name_ID).Copy();
            return dt;
        }
        public void DeleteFromBankmast(string NameID)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.DeleteBankMast(NameID);
        }

        public void DeleteBankMast(Int64 BankID)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.DeleteBankMast(BankID);
        }

        public void DeleteFromStoreTrans(string AssessId, string AY)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.DeleteStoreTrans(AssessId, AY);
        }

        //delete from StoreTrans
        public void DeleteStoreTrans(string AssessId)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.DeleteStoreTrans(AssessId);
        }

        public int GetID()
        {objAssesseeDAL = new dalAssessee();
        int BankID = objAssesseeDAL.BankID();
        return BankID;
        }

        public List<denAssesseeIndividual> Select(string username)
        {
            try
            {
                objAssesseeDAL = new dalAssessee();
                return objAssesseeDAL.Select(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectAll(string NameID)
        {
            try
            {
                objAssesseeDAL = new dalAssessee();
                return objAssesseeDAL.SelectAll(NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getPdfData(string NameID, int status)
        {
            try
            {
                objAssesseeDAL = new dalAssessee();
                return objAssesseeDAL.getPdfData(NameID, status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdateFunctions
        public int UpdateDataIndividual(denAssesseeIndividual objAssesseeIndividualDEN)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.UpdateDataIndividual(objAssesseeIndividualDEN);
            return 0;
        }

        public void addEmployerCategory(string NameID, int empCat)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.addEmployerCategory(NameID, empCat);
        }

        public int UpdateDataGeneral(denAssesseeMain objAssesseeMainDEN)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.UpdateDataGeneral(objAssesseeMainDEN);
            return 0;
        }

        public int UpdateDataPartner(denAssesseePartner objAssesseePartnerDEN)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.UpdateDataPartner(objAssesseePartnerDEN);
            return 0;
        }

        public int UpdateDataCompany(denAssesseeCompany objAssesseeCompanyDEN)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.UpdateDataCompany(objAssesseeCompanyDEN);
            return 0;
        }

        public DataTable Select(Int64 NameID)
        {
            objAssesseeDAL = new dalAssessee();
            return objAssesseeDAL.Select(NameID);
        }

        public DataTable SelectBusinessCategories()
        {
            objAssesseeDAL = new dalAssessee();
            return objAssesseeDAL.SelectBusinessCategories();
        }
        public void UpdateBankMast(string SID,string AID)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.UpdateBankMast(SID, AID);
        }
        //Update AccID according to VatasSolution.dbo.Accounts
        public void UpdateAccID(string AsseseeID, string PAN)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.UpdateAccID(AsseseeID, PAN);
        }
        public void UpdateBankMastData(string B_Name, string Add, string Account_Type, string Acc_No, string IFSC_Code, int Bank_ID)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.UpdateBankMastByID(B_Name, Add, Account_Type, Acc_No, IFSC_Code, Bank_ID);
        }
        #endregion

        //Update User of Assessee
        public void UpdateUser(string Super_User_Id, string NameID)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.UpdateUser(Super_User_Id,NameID);
        }

        //Function Added by Mudit on 19/08/2015 to Check the Existence of PAN in NameMast for BulkXMLUpload
        public string IsPANExists(string PAN)
        {
            objAssesseeDAL = new dalAssessee();
            return objAssesseeDAL.IsPANExists(PAN);
        }

        //Function Added by Ankush on 20/08/2015 to Check the Existence of 10+ Emails/Mobile for a an Assessee before creating it
        public void IsEmailExists(string Email, string Mobile, out int IsExists)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.IsEmailExists(Email, Mobile, out IsExists);
        }

        //Function to check whether this Assessee is associated with any AccID or not
        public int IsAccIDExists(string NameID)
        {
            objAssesseeDAL = new dalAssessee();
            return objAssesseeDAL.IsAccIDExists(NameID);
        }

        public void AddAssesseeLog(string AssesseeID)
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.AddAssesseeLog(AssesseeID);
        }

        //Add ITR for complete Assessee Session
        public void Add_AssesseeITR()
        {
            objAssesseeDAL = new dalAssessee();
            objAssesseeDAL.Add_AssesseeITR();
        }
    }
}