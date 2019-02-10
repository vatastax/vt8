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
/// <summary>
/// Summary description for bllStoreTrans
/// </summary>
/// 

namespace Taxation.BusinessLogic
{
    public class bllStoreTrans
    {
        #region Constructor
        public bllStoreTrans()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Functions
        public int InsertDataMainGrid(denStoreTrans objStoreTransDEN, out string msg)
        {
            try
            {
                dalStoreTrans objStoreTransDAL;
                objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.InsertDataMainGrid(objStoreTransDEN, out msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int InsertDataDetailsGrid(denStoreTrans objStoreTransDEN)
        {
            try
            {
                dalStoreTrans objDalStoreTrans = new dalStoreTrans();
                return objDalStoreTrans.InsertDataDetailsGrid(objStoreTransDEN);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public int UpdateDetailsGrid(denStoreTrans objStoreTransDEO)
        {
            try
            {
                dalStoreTrans objStoreTransDAO = new dalStoreTrans();
                return objStoreTransDAO.UpdateDetailsGrid(objStoreTransDEO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateDetailsGridByMain(denStoreTrans objStoreTransDEO)
        {
            try
            {
                dalStoreTrans objStoreTransDAO = new dalStoreTrans();
                return objStoreTransDAO.UpdateDetailsGridByMain(objStoreTransDEO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateDetailsGridYesNo(denStoreTrans objStoreTransDEN)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.UpdateDetailsGridYesNo(objStoreTransDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateMainGrid(denStoreTrans objStoreTransDEO, out string msg)
        {
            try
            {
                dalStoreTrans objStoreTransDAO = new dalStoreTrans();
                return objStoreTransDAO.UpdateMainGrid(objStoreTransDEO, out msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int RunShowCalcOnOKButton(denStoreTrans objStoreTransDEN)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.RunShowCalcOnOKButton(objStoreTransDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         //To get the MainID for Master Pages that checks if already exists then get the maximum+1 else 1
        public string getMainID(string NameID, string VType)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.getMainID(NameID, VType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateMainGridBalanceSheet(denStoreTrans objStoreTransDEN, out string msg)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.UpdateMainGridBalanceSheet(objStoreTransDEN, out msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CheckMainGrid(denStoreTrans objStoreTransDEO)
        {
            try
            {
                dalStoreTrans objStoreTransDAO = new dalStoreTrans();
                return objStoreTransDAO.CheckDataMainGrid(objStoreTransDEO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public int CheckDetailGrid(denStoreTrans objStoreTransDEO)
        {
            try
            {
                dalStoreTrans objStoreTransDAO = new dalStoreTrans();
                return objStoreTransDAO.CheckDataDetailsGrid(objStoreTransDEO);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public denStoreTrans GetMainGridData(string strNameID, int intVtype, int intConstID, string mainID, string AY)
        {
            denStoreTrans objdenStoreTrans;
            dalStoreTrans objdalStoreTrans;
            try
            {
                objdenStoreTrans = new denStoreTrans();
                objdalStoreTrans = new dalStoreTrans();

                objdenStoreTrans = objdalStoreTrans.GetMainGridData(strNameID, intVtype, intConstID, mainID, AY);

                return objdenStoreTrans;

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public int ProcCalculationDtlsGrid(denStoreTrans objStoreTransDEN, Int32 IsFloat, string VType, Int16 HeaderID)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.ProcCalculationDtlsGrid(objStoreTransDEN, IsFloat, VType, HeaderID);
            }
            catch (Exception ex)
            {
                return 1;
                //throw ex;
            }
        }
        public denStoreTrans GetSubGridData(string strNameID, int intVtype, int intConstID, int intSubConstID,string AY)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                denStoreTrans objStoreTransDEN;
                objStoreTransDEN= objStoreTransDAL.GetSubGridData(strNameID, intVtype, intConstID, intSubConstID,AY);
                return objStoreTransDEN;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Select(string strNameID, int intVtype, int intConstID)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            return objStoreTransDAL.Select(strNameID, intVtype, intConstID);
        }
        //nishu 4/8/2015
        public DataTable Selectcol3(string strNameID)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            return objStoreTransDAL.Selectcol3(strNameID);
        }
        public void genXML(string NameID, string AY, string path, string ITR, string duedate, string strhashCode, string ReturnType, out string xmlfile, out string xmlfile_Extra)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            objStoreTransDAL.genXML(NameID, AY, path, ITR, duedate, strhashCode, ReturnType, out xmlfile, out xmlfile_Extra);
        }

        public void validateXML(string xmlFile, string AY, int IsValidated, string NameID, string ITRType, string ReturnType, string IsUploaded, string xmlFile_Extra, out int flag)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            objStoreTransDAL.validateXML(xmlFile, AY, IsValidated, NameID, ITRType, ReturnType, IsUploaded, xmlFile_Extra, out flag);
        }
        public void genXML(string NameID, string AY, string path, string ITR, string duedate, int IsValidated)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            objStoreTransDAL.genXML(NameID, AY, path, ITR, duedate, IsValidated);
        }

        //public void resXML(string xml, string Username, string AY, string path,  string ITR, string NameID)
        //{
        //    dalStoreTrans objStoreTransDAL = new dalStoreTrans();
        //    objStoreTransDAL.resXML(xml,Username,AY,path,ITR,NameID);
        //}

        //To fetch all Required Listing for those which 
        public DataTable SelectRequired(string strNameID, string ITRType)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            return objStoreTransDAL.SelectRequired(strNameID, ITRType);
        }

        public void resXML(string xml, string Username, string AY, string path, string ITR, string NameID, out string PAN, int IsValidated)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            objStoreTransDAL.resXML(xml, Username, AY, path, ITR, NameID, out PAN, IsValidated);
        }

        // following code is to restore the XML:
        public void resXML_withMsg(string xml, string Username, string AY, string path, string ITR, string NameID, out string PAN, int IsValidated, out string msg)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            objStoreTransDAL.resXML_withMsg(xml, Username, AY, path, ITR, NameID, out PAN, IsValidated, out msg);
        }

        public void resXMLInv(string AY, string Username, string ITR, Int64 ID, out string PAN)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            objStoreTransDAL.resXMLInv(AY, Username, ITR, ID, out PAN);
        }

         // To Reverse Valid/Invalid XML using Sweeta Procedure
        public void resXMLInv(string NameID, string AY, out string PAN, int ITRType)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            objStoreTransDAL.resXMLInv(NameID, AY, out PAN, ITRType);
        }

        //To call all deduction eligible cases together
        public void setEligibleDeductions(string NameID, string AY, string mainID, string ITRType)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            objStoreTransDAL.setEligibleDeductions(NameID, AY, mainID, ITRType);
        }


        public void deleteUser(string NameID)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            objStoreTransDAL.deleteUser(NameID);
        }

        public void deleteUser_VType(string NameID, string VType)
        {
            dalStoreTrans objdalStoreTrans = new dalStoreTrans();
            objdalStoreTrans.deleteUser_VType(NameID, VType);
        }

        public DataTable getFormulaT00(int intVtype, string AY)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.getFormulaT00(intVtype, AY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getVtypeData(int[] Vtype, string AY, string RetType, string NameID)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.getVtypeData(Vtype, AY, RetType, NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectUserData(string username)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.SelectUserData(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 getDataCount(string strNameID)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.getDataCount(strNameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getXMLData(string strNameID, string AY, string ITR)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.getXMLData(strNameID, AY, ITR);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Function Added by Mudit on 19/08/2015 to uplaod bulkxml without updating master data for BulkXMLUpload
        public void resXMLNoMasterUpdate(string xml, string Username, string AY, string path, string ITR, string NameID, out string PAN, int IsValidated)
        {
            dalStoreTrans objStoreTransDAL = new dalStoreTrans();
            objStoreTransDAL.resXMLNoMasterUpdate(xml, Username, AY, path, ITR, NameID, out PAN, IsValidated);
        }

        public void setLosses(decimal IFS, decimal IFHP, decimal IFBus, decimal IFSI, decimal IFSBus, decimal IFSTCG_15, decimal IFSTCG_30, decimal IFSTCG_app, decimal IFLTCG_10, decimal IFLTCG_20, decimal IFOS, decimal IFP_RH, string NameID, string AY, string ITR)
        {
            dalStoreTrans objdalStoreTrans = new dalStoreTrans();
            objdalStoreTrans.setLosses(IFS, IFHP, IFBus, IFSI, IFSBus, IFSTCG_15, IFSTCG_30, IFSTCG_app, IFLTCG_10, IFLTCG_20, IFOS, IFP_RH, NameID, AY, ITR);
        }

         //Select Data from StoreTrans w.r.t. VType
        public DataTable SelectData_Vtype(string strNameID, string VType)
        {
            dalStoreTrans objdalStoreTrans = new dalStoreTrans();
            return objdalStoreTrans.SelectData_Vtype(strNameID, VType);
        }

         //Select Data from StoreTrans w.r.t. VType and C5
        public DataTable SelectData_Vtype_C5(string strNameID, string VType, string ComboItemNo)
        {
            dalStoreTrans objdalStoreTrans = new dalStoreTrans();
            return objdalStoreTrans.SelectData_Vtype_C5(strNameID, VType, ComboItemNo);
        }

          //Select Data from StoreTrans w.r.t. ConstantID
        public string SelectData_ConstID(string strNameID, string constantID)
        {
            dalStoreTrans objdalStoreTrans = new dalStoreTrans();
            return objdalStoreTrans.SelectData_ConstID(strNameID, constantID);
        }
        #endregion

        #region TDS
        //Added by Mudit For TDS
        public denStoreTrans InsertChalanDetails(denStoreTrans objdenStoreTrans)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();

                return objStoreTransDAL.InsertChalanDetails(objdenStoreTrans);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public denStoreTrans InsertDeducteeDetails(denStoreTrans objdenStoreTrans, string DeducteeID)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();

                return objStoreTransDAL.InsertDeducteeDetails(objdenStoreTrans, DeducteeID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denStoreTrans InsertSalaryDetails(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();

                return objStoreTransDAL.InsertSalaryDetails(objStoreTrans2DEO);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denStoreTrans InsertTransData(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();

                return objStoreTransDAL.InsertTransData(objStoreTrans2DEO);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denStoreTrans ReverseChallanDetails(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.ReverseChallanDetails(objStoreTrans2DEO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denStoreTrans ReverseDeducteeDetails(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.ReverseDeducteeDetails(objStoreTrans2DEO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public denStoreTrans ReverseSalaryDetails(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.ReverseSalaryDetails(objStoreTrans2DEO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getComboListData(denStoreTrans objStoreTrans2DEO, string Project)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.getComboListData(objStoreTrans2DEO, Project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable TDSCalculation(denStoreTrans objStoreTrans2DEO, string Project)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.TDSCalculation(objStoreTrans2DEO, Project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Function to Get the ID From Master Table
        public int GetIDFromMaster(denStoreTrans objdenStoreTrans)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.GetIDFromMaster(objdenStoreTrans);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Function Added By Mudit on 24/08/2015 To fetch ChallansDetails based on ChallanID and MasterID
        public DataTable GetTDSChallanDetails(int MasterID, int ChallanID, denStoreTrans objdenStoretrans)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                return objStoreTransDAL.GetTDSChallanDetails(MasterID, ChallanID, objdenStoretrans);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Function To insert Specific Rules For TDS
        public void InsertTDSSpecificRules(int Vtype, string AY, string NameID)
        {
            try
            {
                dalStoreTrans objStoreTransDAL = new dalStoreTrans();
                objStoreTransDAL.InsertTDSSpecificRules(Vtype, AY, NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To generate and add Unique Identification Number (In case of Form15G and Form15H)
        public void saveUniqueIndentificationNo(string NameID, string AY, string ITRType)
        {
            dalStoreTrans objdalStoreTrans = new dalStoreTrans();
            objdalStoreTrans.saveUniqueIndentificationNo(NameID, AY, ITRType);
        }

        #endregion

    }
    
}
