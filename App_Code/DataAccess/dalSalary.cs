using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataEntity;
using System.Collections.Generic;

/// <summary>
/// Summary description for dalSalary
/// </summary>
/// 
namespace Taxation.DataAccess
{

    public class dalSalary : dalConnection
    {
        #region Variables

        SqlCommand cmd;
        #endregion

        #region Constructors
        public dalSalary()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Utilities

        public List<denSalary> getParticularsByIndex(int intIndex, int intGindex, string strAssesseeType, string strAY, string PAN,string ITR,string ReturnPeriod,string NameID)
        {
            denSalary objdenSalary;
            try
            {
                List<denSalary> GenSalary = new List<denSalary>();
                this.pConnMain();
                if (intGindex == 1003)
                {
                    cmd = new SqlCommand("usp_selectdata1003", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@index", intIndex);
                    cmd.Parameters.AddWithValue("@GridIndex", intGindex);
                    cmd.Parameters.AddWithValue("@AssesseeType", strAssesseeType);
                    cmd.Parameters.AddWithValue("@AY", strAY);
                    cmd.Parameters.AddWithValue("@PAN", PAN);
                }
                else if (intGindex == 11)
                {
                    cmd = new SqlCommand("usp_selectdatacapitalgains", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@index", intIndex);
                    cmd.Parameters.AddWithValue("@Gindex", intGindex);
                    cmd.Parameters.AddWithValue("@AssesseeType", strAssesseeType);
                    cmd.Parameters.AddWithValue("@AY", strAY);
                }
                else
                {
                    cmd = new SqlCommand("usp_selectdata", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@index", intIndex);
                    cmd.Parameters.AddWithValue("@Gindex", intGindex);
                    cmd.Parameters.AddWithValue("@AssesseeType", strAssesseeType);
                    cmd.Parameters.AddWithValue("@AY", strAY);
                    cmd.Parameters.AddWithValue("@PAN", PAN);
                    cmd.Parameters.AddWithValue("@ITR", ITR);
                    cmd.Parameters.AddWithValue("@ReturnPeriod", ReturnPeriod);
                    cmd.Parameters.AddWithValue("@NameID", NameID);
                }
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adp.Fill(dt);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdenSalary = new denSalary();

                    objdenSalary.Serial = Convert.ToString(reader["C7"]);
                    objdenSalary.Particulars = Convert.ToString(reader["C4"]);
                    objdenSalary.C19 = Convert.ToInt32(reader["C19"]);
                    objdenSalary.C1 = Convert.ToInt32(reader["C1"]);
                    objdenSalary.C16 = Convert.ToInt32(reader["C16"]);
                    objdenSalary.KeyCheck = Convert.ToInt32(reader["C10"]);
                    objdenSalary.C25 = Convert.ToInt32(reader["C25"]);
                    objdenSalary.GrowNo = Convert.ToInt32(reader["C2"]);
                    objdenSalary.C40 = Convert.ToInt32(reader["C40"]);
                    objdenSalary.C27 = Convert.ToInt32(reader["C27"]);
                    objdenSalary.C19 = Convert.ToInt32(reader["C19"]);
                    if (intGindex == 1003)
                    {
                        objdenSalary.tooltip = "";
                    }
                    else
                        objdenSalary.tooltip = reader["tooltip"].ToString();

                    //objdenSalary.XMLTAGID = Convert.ToInt32(reader["C41"]);
                    //objdenSalary.KeyCheck = Convert.ToInt32(reader["C10"]);
                    //objdenSalary.ExemptedAmount = Convert.ToInt32(reader["C14"]);
                    //objdenSalary.TempArray = Convert.ToInt32(reader["C12"]);
                    //objdenSalary.StaticAmount1 = Convert.ToInt32(reader["C11"]);
                    //objdenSalary.StaticAmount2=Convert.ToInt32(reader["C15"]);
                    //objdenSalary.Section = Convert.ToString(reader["C23"]);
                    //objdenSalary.WhichFormula = Convert.ToInt32(reader["C17"]);
                    //objdenSalary.ExemptCol = Convert.ToInt32(reader["C18"]);
                    //objdenSalary.WhichDet = Convert.ToInt32(reader["C20"]);
                    //objdenSalary.ComboItemNo = Convert.ToInt32(reader["C5"]);

                    GenSalary.Add(objdenSalary);
                }
                reader.Close();
                //this.SqlCon.Close();
                return GenSalary;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }
        public List<denSalary> GetHousePropertyData(int ComboParameter, int ChkBoxParameter, int SaleID, string AY)
        {
            try
            {
                denSalary objSalaryDEN;
                this.pConn();
                List<denSalary> genHousePropertyData = new List<denSalary>();
                //When Sale is Selected
                if (ComboParameter == 0 && ChkBoxParameter == 0)
                {
                    cmd = new SqlCommand("prochousepropertysale", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SaleID", SaleID);
                    cmd.Parameters.AddWithValue("@GridIndex", 11);
                    cmd.Parameters.AddWithValue("@AY", AY);


                }
                //when Compulsory acquisition is selected
                else if (ComboParameter == 1 && ChkBoxParameter == 0)
                {
                    cmd = new SqlCommand("prochousepropertyCA", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SaleID", SaleID);
                    cmd.Parameters.AddWithValue("@GridIndex", 11);
                    cmd.Parameters.AddWithValue("@AY", AY);
                }
                //when Enhanced acquisition is selected
                else if (ComboParameter == 1 && ChkBoxParameter == 1)
                {
                    cmd = new SqlCommand("prochousepropertyEC", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SaleID", SaleID);
                    cmd.Parameters.AddWithValue("@GridIndex", 11);
                    cmd.Parameters.AddWithValue("@AY", AY);
                }
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objSalaryDEN = new denSalary();
                    objSalaryDEN.C1 = Convert.ToInt32(reader["C1"]);
                    objSalaryDEN.Particulars = Convert.ToString(reader["C4"]);
                    objSalaryDEN.Serial = Convert.ToString(reader["C7"]);
                    objSalaryDEN.C19 = Convert.ToInt32(reader["C19"]);
                    objSalaryDEN.C16 = Convert.ToInt32(reader["C16"]);
                    objSalaryDEN.KeyCheck = Convert.ToInt32(reader["C10"]);
                    objSalaryDEN.C25 = Convert.ToInt32(reader["C25"]);
                    objSalaryDEN.C40 = Convert.ToInt32(reader["C40"]);

                    genHousePropertyData.Add(objSalaryDEN);
                }
                return genHousePropertyData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }
        public List<denSalary> getDataByAssetID(int SaleID, int GIndex, string AY)
        {
            try
            {
                denSalary objSalaryDEN;
                this.pConn();
                List<denSalary> genListByAssetID = new List<denSalary>();
                if (SaleID == 5)
                {
                    cmd = new SqlCommand("procHousePropertysale", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SaleID", SaleID);
                    cmd.Parameters.AddWithValue("@GridIndex", GIndex);
                    cmd.Parameters.AddWithValue("@AY", AY);
                }
                else
                {
                    cmd = new SqlCommand("usp_Selectdatabyassetid", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AssetID", SaleID);
                    cmd.Parameters.AddWithValue("@Gindex", GIndex);
                    cmd.Parameters.AddWithValue("@AY", AY);
                }
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objSalaryDEN = new denSalary();
                    objSalaryDEN.C1 = Convert.ToInt32(reader["C1"]);
                    objSalaryDEN.Particulars = Convert.ToString(reader["C4"]);
                    objSalaryDEN.Serial = Convert.ToString(reader["C7"]);
                    objSalaryDEN.C19 = Convert.ToInt32(reader["C19"]);
                    objSalaryDEN.C16 = Convert.ToInt32(reader["C16"]);
                    objSalaryDEN.KeyCheck = Convert.ToInt32(reader["C10"]);
                    objSalaryDEN.C25 = Convert.ToInt32(reader["C25"]);
                    objSalaryDEN.C40 = Convert.ToInt32(reader["C40"]);
                    genListByAssetID.Add(objSalaryDEN);
                }
                return genListByAssetID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }
        public DataTable GetComboItemsOther(string ConstID, string AY, string FormNo, string FY)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnAdmin();
                denSalary objSalaryDEN;
                List<denSalary> genComboItemList;
                genComboItemList = new List<denSalary>();
                cmd = new SqlCommand("procComboItemsOther", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConstantID", ConstID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@FormNo", FormNo);
                cmd.Parameters.AddWithValue("@FY", FY);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }

        public DataTable GetComboValues(string ConstID, string AY, string FormNo, string FY)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnMain();
                denSalary objSalaryDEN;
                List<denSalary> genComboItemList;
                genComboItemList = new List<denSalary>();
                cmd = new SqlCommand("proccomboitems", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConstID", ConstID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@FormNo", FormNo);
                cmd.Parameters.AddWithValue("@FY", FY);
                    //SqlDataReader reader;
                    //reader = cmd.ExecuteReader();
                    //while (reader.Read())
                    //{
                    //    objSalaryDEN = new denSalary();
                    //    objSalaryDEN.ComboText = Convert.ToString(reader["showtext"]);
                    //    objSalaryDEN.ComboTextID = Convert.ToInt32(reader["ID"]);
                    //    genComboItemList.Add(objSalaryDEN);
                    //}
                    //return genComboItemList;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }
        public List<denSalary> getAssetList(string NameID,string VType)
        {
            try
            {
                denSalary objSalaryDEN;
                List<denSalary> genAssetList = new List<denSalary>();
                this.pConn();
                cmd = new SqlCommand("procGetAssetList", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@VType", VType);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    objSalaryDEN = new denSalary();
                    objSalaryDEN.AssetName = Convert.ToString(reader["AssetName"]);
                    objSalaryDEN.PurchaseDate = Convert.ToString(reader["PurchaseDate"]);
                    if (VType != "46")
                    {
                        objSalaryDEN.PurchaseCost = Convert.ToInt32(reader["PurchaseCost"]);
                        objSalaryDEN.PurchaseExp = Convert.ToInt32(reader["PurchaseExp"]);
                        objSalaryDEN.AssetID = Convert.ToInt32(reader["assetid"]);
                        objSalaryDEN.SaleID = Convert.ToInt32(reader["SaleID"]);
                    }             
                    genAssetList.Add(objSalaryDEN);
                }
                return genAssetList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }
        public void AddTaxDetails(string nameid, int VType, string AY, string mainid, string col3, decimal ConstantID, int SubConstID, int GridIndex, decimal ComboItemNo, int GRowNo, decimal IsEnterFDet, int RecdAmount)
        {
            try
            {
                this.pConn();
                SqlCommand cmd = new SqlCommand("Proc_ProCalcTax", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameid", nameid);
                cmd.Parameters.AddWithValue("@VType", VType);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@mainid", mainid);
                cmd.Parameters.AddWithValue("@col3", col3);
                cmd.Parameters.AddWithValue("@ConstantID", ConstantID);
                cmd.Parameters.AddWithValue("@SubConstID", SubConstID);
                cmd.Parameters.AddWithValue("@GridIndex", GridIndex);
                cmd.Parameters.AddWithValue("@ComboItemNo", ComboItemNo);
                cmd.Parameters.AddWithValue("@GRowNo", GRowNo);
                cmd.Parameters.AddWithValue("@IsEnterFDet", IsEnterFDet);
                cmd.Parameters.AddWithValue("@RecdAmount", RecdAmount);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }

        public void AddLeftOvers(string nameid, string AY)
        {
            try
            {
                this.pConn();
                SqlCommand cmd = new SqlCommand("proc_Compute_LeftOvers", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@gioName", nameid);
                cmd.Parameters.AddWithValue("@AYear", AY);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }

        public void SetAllZero(string nameid, int VType, string AY, string mainid, int SubConstID, int GridIndex, decimal ComboItemNo, int GRowNo, decimal IsEnterFDet, int RecdAmount)
        {
            try
            {
                this.pConnMain();
                SqlCommand cmd = new SqlCommand("Proc_SetZeroValues", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameid", nameid);
                cmd.Parameters.AddWithValue("@VType", VType);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@mainid", mainid);
                cmd.Parameters.AddWithValue("@SubConstID", SubConstID);
                cmd.Parameters.AddWithValue("@GridIndex", GridIndex);
                cmd.Parameters.AddWithValue("@ComboItemNo", ComboItemNo);
                cmd.Parameters.AddWithValue("@GRowNo", GRowNo);
                cmd.Parameters.AddWithValue("@IsEnterFDet", IsEnterFDet);
                cmd.Parameters.AddWithValue("@RecdAmount", RecdAmount);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }

        public void calcSal(string hwnd, string NameID, string AY, string duedate, out decimal gIFS, out decimal gIFHP, out decimal gIFBUS, out decimal gIFSTCG, out decimal gIFLTCG, out decimal gIFOS, out decimal gDED, out decimal gDED1, out decimal gICE, out decimal gAI, out decimal gTDS, out decimal gTCS, out decimal gSelfAss, out decimal gATP, out decimal gCasuInc, out decimal gCLUB, out decimal gRelief, out decimal gTI, out decimal gGIT, out decimal gNIT, out decimal gSum_234, out decimal gEduCess, out decimal gSur, out decimal Rebate87A)
        {
            try
            {
                denSalary objSalaryDEN;
                List<denSalary> genAssetList = new List<denSalary>();
                this.pConn();

                cmd = new SqlCommand("procCompute1", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@hwnd", Convert.ToDecimal(0));
                cmd.Parameters.AddWithValue("@AYear", AY);
                cmd.Parameters.AddWithValue("@gioNameID", NameID);
                cmd.Parameters.AddWithValue("@duedate", duedate);

                cmd.Parameters.Add("@gIFS", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gIFHP", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gIFBUS", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gIFSTCG", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gIFLTCG", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gIFOS", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gDED", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gDED1", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gICE", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gAI", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gTDS", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gTCS", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gSelfAss", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gATP", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gCasuInc", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gCLUB", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gRelief", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gTI", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gGIT", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gNIT", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gSum_234", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gEducationCess", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gSURCHARGE", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Rebate87A", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                
                cmd.ExecuteNonQuery();

                gIFS = Convert.ToDecimal(cmd.Parameters["@gIFS"].Value);
                gIFHP = Convert.ToDecimal(cmd.Parameters["@gIFHP"].Value);
                gIFBUS = Convert.ToDecimal(cmd.Parameters["@gIFBUS"].Value);
                gIFSTCG = Convert.ToDecimal(cmd.Parameters["@gIFSTCG"].Value);
                gIFLTCG = Convert.ToDecimal(cmd.Parameters["@gIFLTCG"].Value);
                gIFOS = Convert.ToDecimal(cmd.Parameters["@gIFOS"].Value);
                gDED = Convert.ToDecimal(cmd.Parameters["@gDED"].Value);
                gDED1 = Convert.ToDecimal(cmd.Parameters["@gDED1"].Value);
                gICE = Convert.ToDecimal(cmd.Parameters["@gICE"].Value);
                gAI = Convert.ToDecimal(cmd.Parameters["@gAI"].Value);
                gTDS = Convert.ToDecimal(cmd.Parameters["@gTDS"].Value);
                gTCS = Convert.ToDecimal(cmd.Parameters["@gTCS"].Value);
                gSelfAss = Convert.ToDecimal(cmd.Parameters["@gSelfAss"].Value);
                gATP = Convert.ToDecimal(cmd.Parameters["@gATP"].Value);
                gCasuInc = Convert.ToDecimal(cmd.Parameters["@gCasuInc"].Value);
                gCLUB = Convert.ToDecimal(cmd.Parameters["@gCLUB"].Value);
                gRelief = Convert.ToDecimal(cmd.Parameters["@gRelief"].Value);
                gTI = Convert.ToDecimal(cmd.Parameters["@gTI"].Value);
                gGIT = Convert.ToDecimal(cmd.Parameters["@gGIT"].Value);
                gNIT = Convert.ToDecimal(cmd.Parameters["@gNIT"].Value);
                gSum_234 = Convert.ToDecimal(cmd.Parameters["@gSum_234"].Value);
                gEduCess = Convert.ToDecimal(cmd.Parameters["@gEducationCess"].Value);
                gSur = Convert.ToDecimal(cmd.Parameters["@gSURCHARGE"].Value);
                Rebate87A = Convert.ToDecimal(cmd.Parameters["@Rebate87A"].Value);
                //count = Convert.ToInt32(cmd.Parameters["@Out"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }           
            finally
            {
                this.SqlCon.Close();
            }
        }
        //By Ankush on 23-04-16
        public void calTaxNew(string NameID, string AY, decimal vtype, string duedate, int AssesseeType)
        {
            try
            {
                denSalary objSalaryDEN;
                List<denSalary> genAssetList = new List<denSalary>();
                this.pConn();

                cmd = new SqlCommand("procCalcTax2", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AYear",AY);
                cmd.Parameters.AddWithValue("@vtype",49);
                cmd.Parameters.AddWithValue("@gioNameID",NameID);
                cmd.Parameters.AddWithValue("@duedate",duedate);
                cmd.Parameters.AddWithValue("@AssesseType",AssesseeType);
                cmd.Parameters.AddWithValue("@gInTaxCalc",1);
                cmd.Parameters.AddWithValue("@CalculateCess",1);
                cmd.Parameters.AddWithValue("@Method1",1);
                cmd.Parameters.AddWithValue("@gComboYr",AY);
                //cmd.Parameters.AddWithValue("@gComboStatus",1);
                cmd.Parameters.AddWithValue("@gComboStatus", Convert.ToInt32(HttpContext.Current.Session["Status"]));
                //cmd.Parameters.AddWithValue("@ITRType", HttpContext.Current.Session["ITR"].ToString());
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                 throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }

        public DataTable getStatementHeaders()
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("procStatementIncome", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }

        public DataSet getStatementData(string NameID,string AY)
        {
            DataSet ds = new DataSet();
            try
            {
                this.pConn();
//                cmd = new SqlCommand("select * from storetrans where NameID=@NameID and Vtype=@Vtype and AY = @AY and NameID!=MainID", this.SqlCon);
//                SqlDataAdapter adp2 = new SqlDataAdapter(cmd);
//                DataTable dtTemp = new DataTable();
//                adp2.Fill(dtTemp);
//                if (dtTemp.Rows.Count > 0)
//                {
//                    cmd = new SqlCommand(@"select empr.EmpID,empr.Name,sum(cast(col3 as decimal)) as amt from storetrans ss
//                                    inner join
//                                    emprmast empr on
//                                    empr.EmpID = ss.mainID where ss.NameID = @NameID and AY = @AY and ss.VType= 40 and ss.SubConstID=0
//                                    group by empr.name,empr.EmpID ", this.SqlCon);
//                }
//                else
//                {
                cmd = new SqlCommand(@"select 0 as EmpID,'Default' as Name,sum(cast(col3 as decimal)) as amt from storetrans ss
                                            where ss.NameID = @NameID and AY = @AY and ss.VType= 40 and ss.SubConstID=0 and mainID=NameID 
                                            union 
                                            select empr.EmpID,empr.Name,sum(cast(col3 as decimal)) as amt from storetrans ss
                                            inner join
                                            emprmast empr on
                                            empr.EmpID = ss.mainID where ss.NameID = @NameID and AY = @AY and ss.VType= 40 and ss.SubConstID=0
                                            group by empr.name,empr.EmpID ", this.SqlCon);
                //}
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ds.Tables.Add(dt);

                SqlCommand cmd2 = new SqlCommand(@"select empr.EmpID,empr.Name,sum(cast(col3 as decimal)) as amt from storetrans ss
                                                inner join
                                                emprmast empr on
                                                empr.EmpID = ss.mainID where ss.NameID = @NameID and AY = @AY and ss.VType= 41 and ss.SubConstID=0
                                                group by empr.name,empr.EmpID
                                                union
                                                select 0,'Default Business',sum(cast(col3 as decimal)) as amt from storetrans ss
                                                where ss.NameID = @NameID and AY = @AY and ss.VType= 41 and ss.SubConstID=0 and NameID=MainID
                                                    ", this.SqlCon);
                cmd2.Parameters.AddWithValue("@NameID", NameID);
                cmd2.Parameters.AddWithValue("@AY", AY);

                adp = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                adp.Fill(dt);
                ds.Tables.Add(dt);

                SqlCommand cmd3 = new SqlCommand(@"select at.AssetID,at.CompanyName as Name,sum(cast(case when col3 not like '%[a-z]%' and Col3 is not null then Col3 else 0 end as decimal)) as amt from storetrans ss
                                                inner join
                                                assettrans at on
                                                at.AssetID = ss.mainID where ss.NameID = @NameID and AY = @AY and ss.VType= 42 and ss.SubConstID=0
                                                group by at.CompanyName,at.AssetID
                                                union
                                                select 0,'Default Property' as Name,sum(cast(col3 as decimal)) as amt from storetrans ss
                                                    where ss.NameID = @NameID and AY = @AY and ss.VType= 42 and ss.SubConstID=0 and NameID=MainID", this.SqlCon);
                cmd3.Parameters.AddWithValue("@NameID", NameID);
                cmd3.Parameters.AddWithValue("@AY", AY);

                adp = new SqlDataAdapter(cmd3);
                dt = new DataTable();
                adp.Fill(dt);

                ds.Tables.Add(dt);

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return ds;
        }
        public DataSet getStatementData(string NameID, string AY,int[]Vtype)
        {
            DataSet ds = new DataSet();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select 0 as EmpID,'Default' as Name,sum(cast(col3 as decimal)) as amt from storetrans ss where ss.NameID = '"+NameID+"' and AY='"+AY+"' and ss.VType= "+Vtype[0]+" and ss.SubConstID=0 and mainID=NameID union select empr.EmpID,empr.Name,sum(cast(col3 as decimal)) as amt from storetrans ss inner join emprmast empr on empr.EmpID = ss.mainID where ss.NameID = '"+NameID+"' and AY = '"+AY+"' and ss.VType= 40 and ss.SubConstID=0 group by empr.name,empr.EmpID ", this.SqlCon);
                //}
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ds.Tables.Add(dt);

                SqlCommand cmd2 = new SqlCommand("select empr.EmpID,empr.Name,sum(cast(col3 as decimal)) as amt from storetrans ss inner join emprmast empr on empr.EmpID = ss.mainID where ss.NameID = '"+NameID+"' and AY = '"+AY+"' and ss.VType= "+Vtype[1]+" and ss.SubConstID=0 group by empr.name,empr.EmpID union select 0,'Default Business',sum(cast(col3 as decimal)) as amt from storetrans ss where ss.NameID = '"+NameID+"' and AY = '"+AY+"' and ss.VType= "+Vtype[1]+" and ss.SubConstID=0 and NameID=MainID", this.SqlCon);
                cmd2.Parameters.AddWithValue("@NameID", NameID);
                cmd2.Parameters.AddWithValue("@AY", AY);

                adp = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                adp.Fill(dt);
                ds.Tables.Add(dt);

                SqlCommand cmd3 = new SqlCommand("select at.AssetID,at.CompanyName as Name,sum(cast(col3 as decimal)) as amt from storetrans ss inner join assettrans at on at.AssetID = ss.mainID where ss.NameID = '"+NameID+"' and AY = '"+AY+"' and ss.VType= 42 and ss.SubConstID=0 group by at.CompanyName,at.AssetID union select 0,'Default Property' as Name,sum(cast(col3 as decimal)) as amt from storetrans ss where ss.NameID = '"+NameID+"' and AY = '"+AY+"' and ss.VType= "+Vtype[2]+" and ss.SubConstID=0 and NameID=MainID", this.SqlCon);
                cmd3.Parameters.AddWithValue("@NameID", NameID);
                cmd3.Parameters.AddWithValue("@AY", AY);

                adp = new SqlDataAdapter(cmd3);
                dt = new DataTable();
                adp.Fill(dt);

                ds.Tables.Add(dt);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return ds;
        }
        public DataTable getBusinessData(string NameID, string MainID, string AY,string vtype)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                if (vtype == "46")
                {
//                    cmd = new SqlCommand(@"select tt.c4,ss.col3 from storetrans ss
//                                    inner join
//                                    dbMain.dbo.t00 tt on
//                                    tt.c1=ss.ConstantID
//                                    where VType=@VType and NameID = @NameID and MainID = @MainID and AY=@AY and c21=@AY and ss.col3!=0", this.SqlCon);
                                    //where VType=@VType and NameID = @NameID and MainID = @MainID and AY=@AY and c21=@AY and ss.col3!=0 and RecdAmount=15", this.SqlCon);
                    string strSQL = @"with cte(a,b)
                                        as
                                        (
                                        select tt.c4,ss.col3 from storetrans ss
	                                        inner join
	                                        dbMain.dbo.t00 tt on
	                                        tt.c1=ss.ConstantID
	                                        where VType=@VType and NameID = @NameID and MainID = @MainID and AY=@AY and c21=@AY and ss.col3!=0 and RecdAmount!=15
                                        ), cte2(x,y)
                                        as
                                        (
                                        select tt.c4,ss.col3 from storetrans ss
	                                        inner join
	                                        dbMain.dbo.t00 tt on
	                                        tt.c1=ss.ConstantID
	                                        where VType=@VType and NameID = @NameID and MainID = @MainID and AY=@AY and ss.col3!=0 and RecdAmount=15
                                        )
                                        ";
                     strSQL += @",cte3(c,d)
                                    as
                                    (
                                    select tt.c4,ss.col3 from storetrans ss
	                                    left outer join
	                                    dbMain.dbo.t00 tt on
	                                    tt.c1=ss.ConstantID
	                                    where VType=46 and NameID = @NameID and MainID = NameID and AY=@AY and ss.col3!=0 and RecdAmount!=15 and ConstantID=1042
                                    ), cte4(j,k)
                                    as
                                    (
                                    select tt.c4,ss.col3 from storetrans ss
	                                    inner join
	                                    dbMain.dbo.t00 tt on
	                                    tt.c1=ss.ConstantID
	                                    where VType=46 and NameID = @NameID and MainID = @NameID and AY=@AY and c21=@AY and ss.col3!=0 and RecdAmount=15 and ConstantID=189
                                    )
                                    select c1.a as c4,c1.b as col3,c2.y as elgAmt from cte c1
                                    inner join
                                    cte2 c2 on
                                    c1.a=c2.x union 
                                    select c3.c as c4,c3.d as col3,c4.k as elgAmt from cte3 c3
                                    inner join
                                    cte4 c4 on
                                    c3.c=c4.j
                                    ";
                    cmd = new SqlCommand(strSQL, this.SqlCon);
                }
                else if (vtype == "49")
                {
//                    cmd = new SqlCommand(@"select tt.c4,ss.col3 from storetrans ss
//                                    inner join
//                                    dbMain.dbo.t00 tt on
//                                    tt.c1=ss.ConstantID
//                                    where tt.c1 in(917,1015,1118,1119,1120,1121,1117,881,795,918,796,797,787,788,802) and c6 in(5003,5004) and NameID = @NameID and MainID = @MainID and AY=@AY and c21=@AY and col3!='0' order by tt.c2", this.SqlCon);

                    cmd = new SqlCommand(@"with cte(rowno,c4,col3) as
	                                (select ROW_NUMBER() over (order by tt.c1) as rowno,tt.c4,ss.col3 from storetrans ss
                                    inner join
                                    dbMain.dbo.t00 tt on
                                    tt.c1=ss.ConstantID
                                    where tt.c1 in(917,1015,1118,1119,1120,1121,1117,881,795,918,796,797,787,788,802) and c6 in(5004) and NameID = @NameID and MainID = @MainID and AY=@AY and c21=@AY and col3!='0'
                                    union
                                    select 8 as rowno,tt.c4,ss.col3 from storetrans ss
                                    inner join
                                    dbMain.dbo.t00 tt on
                                    tt.c1=ss.ConstantID
                                    where tt.c1 in(787,788,802) and c6 =5003 and NameID = @NameID and MainID = @MainID and AY=@AY and c21=@AY and col3!='0')select * from cte ", this.SqlCon);
                }

                else
                {
                    cmd = new SqlCommand(@"select tt.c4,ss.col3 from storetrans ss
                                    inner join
                                    dbMain.dbo.t00 tt on
                                    tt.c1=ss.ConstantID
                                    where VType=@VType and NameID = @NameID and MainID = @MainID and AY=@AY and c21=@AY and ss.col3!='0'", this.SqlCon);
                }
                
                cmd.Parameters.AddWithValue("@VType", vtype);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@MainID", MainID);
                cmd.Parameters.AddWithValue("@AY", AY);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                
                adp.Fill(dt);               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }

        public DataTable getBusinessData(string NameID, string AY, string vtype)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();

                string strSQL = @"select * from storetrans where VType=@VType and NameID = @NameID AY=@AY";
                cmd = new SqlCommand(strSQL, this.SqlCon);
                cmd.Parameters.AddWithValue("@VType", vtype);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }

        public DataTable getBusinessDataforCalculation(string NameID, string MainID, string AY, string vtype)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();                
                if (vtype == "49")
                {
                    cmd = new SqlCommand(@"select tt.c29,tt.c4,ss.col3 from storetrans ss
                                    inner join
                                    db_Admin.dbo.t00 tt on
                                    tt.c1=ss.ConstantID
                                    where tt.c1 in(917,1015,1118,1119,1120,1121,1117,881,795,918,796,797) and NameID = @NameID and MainID = @MainID and AY=@AY and c21=@AY order by tt.c2", this.SqlCon);
                }
                cmd.Parameters.AddWithValue("@VType", vtype);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@MainID", MainID);
                cmd.Parameters.AddWithValue("@AY", AY);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }
        
        public DataTable Select(string strSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                SqlCommand cmd2 = new SqlCommand("Proc_Select", this.SqlCon);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@qry", strSQL);
                SqlDataAdapter adp = new SqlDataAdapter(cmd2);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }

        public double getDataForConstID(string constID,string NameID)
        {
            double amt = 0;
            try
            {
                this.pConn();
                SqlCommand cmd2 = new SqlCommand("proc_getDataForConstID", this.SqlCon);
                cmd2.CommandType=CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@NameID", NameID);
                cmd2.Parameters.AddWithValue("@ConstID", constID);
                amt = Convert.ToDouble(cmd2.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return amt;
        }

        public string getDataForConstID_String(string constID, string NameID)
        {
            string Data = "";
            try
            {
                this.pConn();
                SqlCommand cmd2 = new SqlCommand("proc_getDataForConstID", this.SqlCon);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@NameID", NameID);
                cmd2.Parameters.AddWithValue("@ConstID", constID);
                Data = Convert.ToString(cmd2.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return Data;
        }

        public double getFloatDataForConstID(string constID, string NameID)
        {
            double amt = 0;
            try
            {
                this.pConn();
                SqlCommand cmd2 = new SqlCommand("select col9 from storeftrans where NameID=@NameID and ConstantID=@ConstantID", this.SqlCon);
                //cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@NameID", NameID);
                cmd2.Parameters.AddWithValue("@ConstantID", constID);
                amt = Convert.ToDouble(cmd2.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return amt;
        }

        public List<T1000_rules> Select(int t1000_h1, string VType, string ITRType, string AY)
        {
            List<T1000_rules> lst = new List<T1000_rules>();
            try
            {
                this.pConnMain();
                if (HttpContext.Current.Session["Project"].ToString() == "stax" && VType == "5001")
                {
                    if (HttpContext.Current.Session["Status"].ToString() == "1" || HttpContext.Current.Session["Status"].ToString() == "2" || HttpContext.Current.Session["Status"].ToString() == "7")
                    {
                        if (HttpContext.Current.Session["RP"].ToString() == "April-September")
                            t1000_h1 = 116;
                        else
                            t1000_h1 = 117;
                    }
                    else
                    {
                        if (HttpContext.Current.Session["RP"].ToString() == "October-March")
                            t1000_h1 = 114;
                        else
                            t1000_h1 = 115;
                    }
                }

                SqlCommand cmd2 = new SqlCommand("select * from T1000_rules where t1000_h1=@t1000_h1 and AY=@AY and ITRType = @ITRType", this.SqlCon);
                cmd2.Parameters.AddWithValue("@t1000_h1", t1000_h1);
                cmd2.Parameters.AddWithValue("@AY", AY);
                cmd2.Parameters.AddWithValue("@ITRType", ITRType);

                SqlDataReader reader;// = new SqlDataReader();
                reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    T1000_rules objT1000_rules = new T1000_rules();
                    objT1000_rules.ddText = reader.GetString(7);
                    objT1000_rules.ddVal = reader.GetString(8);
                    objT1000_rules.DropDownColumns = reader.GetString(2);
                    objT1000_rules.DropdownQry = reader.GetString(3);
                    objT1000_rules.status = reader.GetBoolean(9);
                    objT1000_rules.t1000_h1 = reader.GetInt32(1);
                    objT1000_rules.Validation = reader.GetString(5);
                    objT1000_rules.ValidationColumns = reader.GetString(4);
                    objT1000_rules.ValidationString = reader.GetString(6);
                    lst.Add(objT1000_rules);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return lst;
        }

        public List<t00_Rules> SelectT(string t00_c1)
        {
            List<t00_Rules> lst = new List<t00_Rules>();
            try
            {
                this.pConnMain();
                SqlCommand cmd2 = new SqlCommand("select * from t00_Rules where t00_c1=@t00_c1", this.SqlCon);
                cmd2.Parameters.AddWithValue("@t00_c1", t00_c1);
                SqlDataReader reader;// = new SqlDataReader();
                reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    t00_Rules objt00_Rules = new t00_Rules();
                    objt00_Rules.status = true;
                    objt00_Rules.t00_c1 = reader.GetString(1);
                    objt00_Rules.Validation = reader.GetString(3);
                    //objt00_Rules.ValidationColumn = reader.GetString(2);
                    objt00_Rules.ValidationString = reader.GetString(4);

                    lst.Add(objt00_Rules);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return lst;
        }

        public List<t00_Rules> SelectT(string t00_c1, string AY, string ITR)
        {
            List<t00_Rules> lst = new List<t00_Rules>();
            try
            {
                this.pConnMain();
                SqlCommand cmd2 = new SqlCommand("select * from t00_Rules where t00_c1=@t00_c1 and AY=@AY and RetType=@ITR", this.SqlCon);
                cmd2.Parameters.AddWithValue("@t00_c1", t00_c1);
                cmd2.Parameters.AddWithValue("@AY", AY);
                cmd2.Parameters.AddWithValue("@ITR", ITR);

                SqlDataReader reader;// = new SqlDataReader();
                reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    t00_Rules objt00_Rules = new t00_Rules();
                    objt00_Rules.status = true;
                    objt00_Rules.t00_c1 = reader.GetString(1);
                    objt00_Rules.Validation = reader.GetString(3);
                    //objt00_Rules.ValidationColumn = reader.GetString(2);
                    objt00_Rules.ValidationString = reader.GetString(4);
                    objt00_Rules.IsRow = (reader.IsDBNull(8)) ? 0 : 1;
                    lst.Add(objt00_Rules);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return lst;
        }

        public List<t4_Rules> SelectT4_Rules(string t4_c1, string AY)
        {
            List<t4_Rules> lst = new List<t4_Rules>();
            try
            {
                this.pConnMain();
                SqlCommand cmd2 = new SqlCommand("select * from t4_Rules where t4_c1 in (select C1 from T4 where c2 = @t4_c1) and AY=@AY", this.SqlCon);
                cmd2.Parameters.AddWithValue("@t4_c1", t4_c1);
                cmd2.Parameters.AddWithValue("@AY", AY);

                SqlDataReader reader;// = new SqlDataReader();
                reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    t4_Rules objt4_Rules = new t4_Rules();
                    objt4_Rules.status = true;
                    objt4_Rules.t4_c1 = reader.GetString(1);
                    objt4_Rules.Validation = reader.GetString(3);
                    objt4_Rules.ValidationString = reader.GetString(4);
                    objt4_Rules.DropdownQry = reader.GetString(7);
                    objt4_Rules.ddText = reader.GetString(8);
                    objt4_Rules.ddVal = reader.GetString(9);

                    lst.Add(objt4_Rules);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return lst;
        }

        //This function is to load all Screen Rules for T00 Screen on page load (after filling up the grid)
        public DataTable loadRules(string AY, string ITR)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnMain();
                SqlCommand cmd2 = new SqlCommand(@"select ReturnType, t00_c1,Validation,ValidationString,C10 from t00_Rules tr
                                                inner join
                                                T00 tt on
                                                cast(tt.C1 as nvarchar(50)) = tr.t00_c1
                                                where tt.C21=@AY and CHARINDEX(@ReturnType,tt.ReturnType)>0 and tr.AY=@AY and tr.RetType=@ReturnType and Validation ='onchange'", this.SqlCon);
                cmd2.Parameters.AddWithValue("@AY", AY);
                cmd2.Parameters.AddWithValue("@ReturnType", ITR);
                SqlDataAdapter adp = new SqlDataAdapter(cmd2);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }

        public List<denSalary> GetComboItems(string ConstID, string AY, string FormNo, string FY)
        {
            try
            {
                this.pConnAdmin();
                denSalary objSalaryDEN;
                List<denSalary> genComboItemList;
                genComboItemList = new List<denSalary>();
                cmd = new SqlCommand("procComboItemsOther", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConstantID", ConstID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@FormNo", FormNo);
                cmd.Parameters.AddWithValue("@FY", FY);              

                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    objSalaryDEN = new denSalary();
                    if (ConstID == "3042")
                    {
                        objSalaryDEN.Particular = Convert.ToString(reader["Particulars"]);
                        objSalaryDEN.TDS_TTACode = Convert.ToString(reader["Code"]);
                    }
                    else if (ConstID == "3043")
                    {
                        objSalaryDEN.Nature_Of_Remittances = Convert.ToString(reader["Nature_Of_Remittances"]);
                        objSalaryDEN.RemittancesCode = Convert.ToString(reader["Code"]);
                    }
                    else if (ConstID == "3044")
                    {
                        objSalaryDEN.Country = Convert.ToString(reader["Country_Name"]);
                        objSalaryDEN.CountryCode = Convert.ToInt32(reader["Country_Code"]);
                    }
                    else if (ConstID == "3031")
                    {
                        objSalaryDEN.SectionName = Convert.ToString(reader["SectionName"]);
                        objSalaryDEN.SectionCode = Convert.ToString(reader["SectionCode"]);
                    }
                    genComboItemList.Add(objSalaryDEN);
                }
                return genComboItemList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }

        //functions for Saving the Assessee Data as XML into tbl_ITRXML without Validation

        public void SaveAssessee(int IsValidated, string NameID, string AY, string xmldata, string ITRType, String xmlData_total)
        {
            DataTable dt = new DataTable();
            try
            {
                //this.pConn();
                this.pConnMain();
                cmd = new SqlCommand("Proc_Insert_Tbl_ITRXML", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@ItrType", ITRType);
                cmd.Parameters.AddWithValue("@xmldata", xmldata);
                cmd.Parameters.AddWithValue("@Isvalidated", IsValidated);
                cmd.Parameters.AddWithValue("@xmlData_total", xmlData_total);
                cmd.Parameters.AddWithValue("@JobId", (HttpContext.Current.Session["Job_ID"] != null ? Convert.ToInt32(HttpContext.Current.Session["Job_ID"]) : 0));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }

        //functions for Saving the Assessee Data into storetrans_main

        public void SaveAssessee_Main(string NameID, string AY)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                SqlCommand cmd2 = new SqlCommand("delete from storetrans_main where NameID=@NameID and AY=@AY", this.SqlCon);
                cmd2.Parameters.AddWithValue("@NameID", NameID);
                cmd2.Parameters.AddWithValue("@AY", AY);
                cmd2.ExecuteNonQuery();

                cmd = new SqlCommand("insert into storetrans_main select * from storetrans where NameID=@NameID and AY=@AY", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }

        //functions for Mastre Pages for sending data to their corresponding master tables

        public int SendTransData(string Vtype,string NameID ,string AY, string UserName, int flag)
        {
            int Success = 0;
            DataTable dt = new DataTable();
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("ProcSendTransData", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vtype", Vtype);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Flag", flag);
                cmd.Parameters.AddWithValue("@itrtype", HttpContext.Current.Session["ITR"].ToString());
                cmd.Parameters.AddWithValue("@IsImport", 0);
                Success = cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("select top(1)NameID from vatastax_dev.dbo.NameMast where username = @username order by NameID desc", this.SqlCon);
                cmd2.Parameters.AddWithValue("@username", HttpContext.Current.Session["userEmail"].ToString());
                Success = Convert.ToInt32(cmd2.ExecuteScalar());
                return Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }            
        }

        //functions for Mastre Pages for fetching data from their corresponding master tables into storetrans/storeftrans

        public void FetchTransData(string Vtype, string NameID, string AY, int IDD)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("ProcFetchTransData", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vtype", Vtype);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@ITR", HttpContext.Current.Session["ITR"].ToString());
                cmd.Parameters.AddWithValue("@IDD", IDD);
                
                //cmd.Parameters.AddWithValue("@Flag", 0);
                //cmd.Parameters.AddWithValue("@FY", FY);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }

        //function to fetch all constatIDs w.r.t. vtype and c5
        public DataTable getConstIDByVType(string vtype, string indx,string AY)
        {            
            DataTable dt = new DataTable();
            try
            {
                this.pConnMain();
                string AssesseeType = "0";
                if (System.Text.RegularExpressions.Regex.Matches(HttpContext.Current.Session["AssesseeType"].ToString(), @"[0-9]").Count < 1)
                {
                    SqlCommand cmd = new SqlCommand("select id from tbl_Status where Status = @Status and CHARINDEX(@ReturnType,ReturnType)>0", this.SqlCon);
                    cmd.Parameters.AddWithValue("@Status", HttpContext.Current.Session["AssesseeType"].ToString());
                    cmd.Parameters.AddWithValue("@ReturnType", HttpContext.Current.Session["ITR"].ToString());
                    AssesseeType = Convert.ToString(cmd.ExecuteScalar());
                }
                else
                    AssesseeType = HttpContext.Current.Session["AssesseeType"].ToString();

                SqlCommand cmd2 = new SqlCommand("select c1 from t00 where c6=(select gridindex from ScreenSettings where vtype = @vtype) and charindex(@ITR,ReturnType)>0 and c21=@AY and c5=@c5 and charindex(@AssesseeType,C31)>0 order by c2", this.SqlCon);
                cmd2.Parameters.AddWithValue("@vtype", vtype);
                cmd2.Parameters.AddWithValue("@c5", indx);
                cmd2.Parameters.AddWithValue("@AY", AY);
                cmd2.Parameters.AddWithValue("@ITR", HttpContext.Current.Session["ITR"].ToString());
                cmd2.Parameters.AddWithValue("@AssesseeType", AssesseeType);
                SqlDataAdapter adp = new SqlDataAdapter(cmd2);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }

        //function to fetch all constatIDs w.r.t. vtype and c5
        public DataTable getConstIDByVType(string vtype, string AY)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnMain();
                SqlCommand cmd2 = new SqlCommand("select c1 from t00 where c6=(select gridindex from ScreenSettings where vtype = @vtype) and ReturnType=@ITR and c21=@AY order by c2", this.SqlCon);
                cmd2.Parameters.AddWithValue("@vtype", vtype);
                cmd2.Parameters.AddWithValue("@AY", AY);
                cmd2.Parameters.AddWithValue("@ITR", HttpContext.Current.Session["ITR"].ToString());
                SqlDataAdapter adp = new SqlDataAdapter(cmd2);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return dt;
        }

        public DataSet getComputationSheet(string NameID,string vtype, string AY, string ITR, string Assessee)
        {
            DataSet ds = new DataSet();
            try
            {
                this.pConn();
                SqlCommand cmd2 = new SqlCommand("rptData_Statement", this.SqlCon);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@NameID", NameID);
                cmd2.Parameters.AddWithValue("@vtype", vtype);
                cmd2.Parameters.AddWithValue("@AY", AY);
                cmd2.Parameters.AddWithValue("@ITR", ITR);
                cmd2.Parameters.AddWithValue("@Assessee", Assessee);
                SqlDataAdapter adp = new SqlDataAdapter(cmd2);
                adp.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return ds;
        }

        public void calcTax_TDS(string AYear, string NameID, int VType)
        {
            try
            {
                this.pConn();
                SqlCommand cmd2 = new SqlCommand("proc_CalcTax", this.SqlCon);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@AYear", AYear);
                cmd2.Parameters.AddWithValue("@gioNameID", NameID);
                cmd2.Parameters.AddWithValue("@VType", VType);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }
        #endregion
    }
}