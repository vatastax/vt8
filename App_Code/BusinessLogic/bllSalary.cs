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
    /// Summary description for bllSalary
    /// </summary>
    public class bllSalary
    {
        
        #region Variables
        dalSalary objdalSalary;
        #endregion

        #region Constructors
        public bllSalary()
        {
            //
            // TODO: Add constructor logic here
            //
            objdalSalary = new dalSalary();
        }
        #endregion

        #region Utilities
        public List<denSalary> getParticularsByIndex(int intIndex, int intGindex, string strAssesseeType, string strAY, string PAN, string ITR,string ReturnPeriod,string NameID)
        {  
            try
            {
                return objdalSalary.getParticularsByIndex(intIndex, intGindex, strAssesseeType, strAY, PAN, ITR, ReturnPeriod,NameID);
                //objListdenSalary = new denSalary();
                //objListdenSalary = objdalSalary.getParticularsByIndex(index);
                //return objListdenSalary;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<denSalary> getDataByAssetID(int SaleID, int GIndex, string AY)
        {
            try
            {
                return objdalSalary.getDataByAssetID(SaleID, GIndex, AY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<denSalary> GetHousePropertyData(int ComboParameter, int ChkBoxParameter, int SaleID, string AY)
        {
            try
            {
                return objdalSalary.GetHousePropertyData(ComboParameter, ChkBoxParameter, SaleID, AY);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetComboValues(string ConstID, string AY, string FormNo, string FY)
        {
            try
            {
                return objdalSalary.GetComboValues(ConstID, AY, FormNo, FY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<denSalary> GetAssetList(string NameID, string VType)
        {
            try
            {
                return objdalSalary.getAssetList(NameID, VType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getStatementHeaders()
        {
            try
            {
                return objdalSalary.getStatementHeaders();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getStatementData(string NameID, string AY)
        {
            try
            {
                return objdalSalary.getStatementData(NameID, AY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getStatementData(string NameID, string AY, int[] Vtype)
        {
            try
            {
                return objdalSalary.getStatementData(NameID, AY,Vtype);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getBusinessData(string NameID, string MainID, string AY, string vtype)
        {
            try
            {
                return objdalSalary.getBusinessData(NameID, MainID, AY,vtype);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getBusinessDataforCalculation(string NameID, string MainID, string AY, string vtype)
        {
            try
            {
                return objdalSalary.getBusinessDataforCalculation(NameID, MainID, AY, vtype);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void calcSal(string hwnd, string NameID, string AY, string duedate, out decimal gIFS, out decimal gIFHP, out decimal gIFBUS, out decimal gIFSTCG, out decimal gIFLTCG, out decimal gIFOS, out decimal gDED, out decimal gDED1, out decimal gICE, out decimal gAI, out decimal gTDS, out decimal gTCS, out decimal gSelfAss, out decimal gATP, out decimal gCasuInc, out decimal gCLUB, out decimal gRelief, out decimal gTI, out decimal gGIT, out decimal gNIT, out decimal gSum_234, out decimal gEduCess, out decimal gSur, out decimal Rebate87A)
        {
            objdalSalary.calcSal(hwnd, NameID, AY, duedate, out gIFS, out gIFHP, out gIFBUS, out gIFSTCG, out gIFLTCG, out gIFOS, out gDED, out gDED1, out gICE, out gAI, out gTDS, out gTCS, out gSelfAss, out gATP, out gCasuInc, out gCLUB, out gRelief, out gTI, out gGIT, out gNIT, out gSum_234, out gEduCess, out gSur, out Rebate87A);
        }

        public void calTaxNew(string NameID, string AY, decimal vtype, string duedate, int AssesseeType)
        {
            objdalSalary.calTaxNew(NameID, AY, vtype, duedate, AssesseeType);
        }

        public void SetAllZero(string nameid, int VType, string AY, string mainid, int SubConstID, int GridIndex, decimal ComboItemNo, int GRowNo, decimal IsEnterFDet, int RecdAmount)
        {
            objdalSalary.SetAllZero(nameid, VType, AY, mainid, SubConstID, GridIndex, ComboItemNo, GRowNo, IsEnterFDet, RecdAmount);
        }

        public void AddTaxDetails(string nameid, int VType, string AY, string mainid, string col3, decimal ConstantID, int SubConstID, int GridIndex, decimal ComboItemNo, int GRowNo, decimal IsEnterFDet, int RecdAmount)
        {
            objdalSalary.AddTaxDetails(nameid, VType, AY, mainid, col3, ConstantID, SubConstID, GridIndex, ComboItemNo, GRowNo, IsEnterFDet, RecdAmount);
        }

        public void AddLeftOvers(string nameid, string AY)
        {
            objdalSalary.AddLeftOvers(nameid, AY);
        }

        public DataTable Select(string strSQL)
        {
            return objdalSalary.Select(strSQL);
        }

        public List<T1000_rules> Select(int t1000_h1, string VType, string ITRType, string AY)
        {
            return objdalSalary.Select(t1000_h1, VType, ITRType, AY);
        }

        public List<t00_Rules> SelectT(string t00_c1)
        {
            return objdalSalary.SelectT(t00_c1);
        }

        public List<t00_Rules> SelectT(string t00_c1, string AY, string ITR)
        {
            return objdalSalary.SelectT(t00_c1, AY, ITR);
        }
        public List<t4_Rules> SelectT4_Rules(string t4_c1, string AY)
        {
            return objdalSalary.SelectT4_Rules(t4_c1, AY);
        }
        //This function is to load all Screen Rules for T00 Screen on page load (after filling up the grid)
        public DataTable loadRules(string AY, string ITR)
        {
            return objdalSalary.loadRules(AY, ITR);
        }

        public List<denSalary> GetComboItems(string ConstID, string AY, string FormNo, string FY)
        {
            try
            {
                return objdalSalary.GetComboItems(ConstID, AY, FormNo, FY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetComboItemsOther(string ConstID, string AY, string FormNo, string FY)
        {
            try
            {
                return objdalSalary.GetComboItemsOther(ConstID, AY, FormNo, FY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //functions for Mastre Pages for sending data to their corresponding master tables
        public int SendTransData(string Vtype,string NameID ,string AY, string UserName, int flag)
        {
            try
            {
                return objdalSalary.SendTransData(Vtype,NameID ,AY, UserName, flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         //functions for Saving the Assessee Data as XML into tbl_ITRXML without Validation

        public void SaveAssessee(int IsValidated, string NameID, string AY, string xmldata, string ITRType, string xmlData_total)
        {
            try
            {
                objdalSalary.SaveAssessee(IsValidated, NameID, AY, xmldata, ITRType, xmlData_total);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveAssessee_Main(string NameID, string AY)
        {
            try
            {
                objdalSalary.SaveAssessee_Main(NameID, AY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //functions for Mastre Pages for fetching data from their corresponding master tables into storetrans/storeftrans
        public void FetchTransData(string Vtype, string NameID, string AY, int IDD)
        {
            try
            {
                objdalSalary.FetchTransData(Vtype, NameID, AY, IDD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getConstIDByVType(string vtype, string indx, string AY)
        {
            try
            {
                return objdalSalary.getConstIDByVType(vtype, indx, AY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //function to fetch all constatIDs w.r.t. vtype and c5
        public DataTable getConstIDByVType(string vtype, string AY)
        {
            try
            {
                return objdalSalary.getConstIDByVType(vtype, AY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double getDataForConstID(string constID, string NameID)
        {
            try
            {
                return objdalSalary.getDataForConstID(constID, NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getDataForConstID_String(string constID, string NameID)
        {
            try
            {
                return objdalSalary.getDataForConstID_String(constID, NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public double getFloatDataForConstID(string constID, string NameID)
        {
            try
            {
                return objdalSalary.getFloatDataForConstID(constID, NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getComputationSheet(string NameID, string vtype, string AY, string ITR, string Assessee)
        {
            try
            {
                return objdalSalary.getComputationSheet(NameID,vtype,AY,ITR,Assessee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getBusinessData(string NameID, string AY, string vtype)
        {
            try
            {
                return objdalSalary.getBusinessData(NameID, AY, vtype);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void calcTax_TDS(string AYear, string NameID, int VType)
        {
            try
            {
                objdalSalary.calcTax_TDS(AYear, NameID, VType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}