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
using System.Data.SqlClient;
using System.Collections.Generic;
using DALVatasETDS;
using BALVatasETDS;


namespace Taxation.DataAccess
{

    /// <summary>
    /// Summary description for dalMain
    /// </summary>
    public class dalMain:dalConnection
    {
        #region Constructor
        public dalMain()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        SqlCommand cmd;
        int i;
        #endregion

        #region Functions
        public List<denMain> GetAssYear()
        {
            
            try
            {
                this.pConnMain();
                List<denMain> genListAY = new List<denMain>();
                string strSql;
                //strSql = "select distinct c2 from db_Admin.dbo.t6 where c2 not in('2002-2003','2003-2004','2004-2005','2005-2006','2006-2007','2007-2008','2008-2009','2009-2010','2010-2011') order by c2 desc";
                //strSql = "select distinct c2 from db_Admin.dbo.t6 where c2 in('2014-2015') order by c2 desc";
                strSql = "select distinct c2 from t6 where c2 in('2014-2015','2015-2016') order by c2 desc";
                //strSql = "select distinct c2 from t6 order by c2 desc";
                cmd = new SqlCommand(strSql, this.SqlCon);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    denMain objMainDEN = new denMain();
                    objMainDEN.AssYear = Convert.ToString(reader["c2"]);
                    genListAY.Add(objMainDEN);
                }
                return genListAY;
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

        public List<denMain> GetFinYear()
        {

            try
            {
                this.pConn();
                List<denMain> genListAY = new List<denMain>();
                string strSql;
                //strSql = "select distinct c2 from db_Admin.dbo.t6 where c2 not in('2002-2003','2003-2004','2004-2005','2005-2006','2006-2007','2007-2008','2008-2009','2009-2010','2010-2011') order by c2 desc";
                strSql = "select distinct c2 from dbMain.dbo.t6 where c2 in('2014-2015','2015-2016') order by c2 desc";
                //strSql = "select distinct c2 from t6 order by c2 desc";
                cmd = new SqlCommand(strSql, this.SqlCon);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    denMain objMainDEN = new denMain();
                    objMainDEN.AssYear = Convert.ToString(reader["c2"]);
                    genListAY.Add(objMainDEN);
                }
                return genListAY;
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

        public List<denMain> GetAuditor()
        {
            try
            {
                this.pConn();
                List<denMain> genListAuditor = new List<denMain>();
                string strSql;
                strSql = "Select firmname from consultantmast";
                cmd = new SqlCommand(strSql, this.SqlCon);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    denMain objMainDEN = new denMain();
                    objMainDEN.AuditorName = Convert.ToString(reader["firmname"]);
                    genListAuditor.Add(objMainDEN);
                }
                return genListAuditor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public denMain GetDueDate(string AY,int Status,int Audited, int StateID)
        {
            try
            {
                this.pConnMain();
                denMain objMainDEN = new denMain();
                cmd = new SqlCommand("getduedate", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@Audited", Audited);
                cmd.Parameters.AddWithValue("@StateID", StateID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    if (Audited == 0)
                        objMainDEN.DueDate = Convert.ToString(reader["c5"]);
                    else if (Audited == 1)
                        objMainDEN.DueDate = Convert.ToString(reader["c4"]);
                                        
                }
                return objMainDEN;
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

        public int CountNames(string UserName)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("proccountnames", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", UserName);
               return Convert.ToInt32(cmd.ExecuteScalar());
               
                
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
        public List<denMain> GetAssesseeList(string UserName, string TypeOfAss)
        {
            try
            {
                this.pConn();
                List<denMain> genListMain = new List<denMain>();
                cmd = new SqlCommand("getdatanamemast", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName",UserName);
                cmd.Parameters.AddWithValue("@TypeOfAss", TypeOfAss);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                string ss = reader.FieldCount.ToString();
                
                while (reader.Read())
                {
                    //ss = reader.GetString(6);
                    denMain objMainDEN = new denMain();
                    objMainDEN.FirstName = Convert.ToString(reader["FirstName"]);
                    objMainDEN.MiddleName = Convert.ToString(reader["MiddleName"]);
                    if (objMainDEN.MiddleName == null)
                        objMainDEN.MiddleName = "";

                    objMainDEN.LastName = Convert.ToString(reader["LastName"]);

                    if (objMainDEN.LastName == null)
                        objMainDEN.LastName = "";
                   
                    objMainDEN.CombinedName = objMainDEN.FirstName + " " + objMainDEN.MiddleName + " " + objMainDEN.LastName;
                    
                    objMainDEN.PAN = Convert.ToString(reader["PANNo"]);
                    objMainDEN.Status = Convert.ToInt16(reader["Status"]);
                    if (objMainDEN.Status == 1 || objMainDEN.Status == 0)
                        objMainDEN.DispStatus = "Individual";
                    else if (objMainDEN.Status == 2)
                        objMainDEN.DispStatus = "Hindu Undivided Family";
                    else if (objMainDEN.Status == 3)
                        objMainDEN.DispStatus = "Partnership";
                    else if (objMainDEN.Status == 4)
                        objMainDEN.DispStatus = "Company";
                    else if (objMainDEN.Status == 5)
                        objMainDEN.DispStatus = "Association of Persons";
                    else if (objMainDEN.Status == 6)
                        objMainDEN.DispStatus = "Cooperative Society";

                    objMainDEN.DateofBirth = reader["DateofBirth"].ToString();
                    objMainDEN.NameID = reader["NameID"].ToString();
                    genListMain.Add(objMainDEN);
                }
                return genListMain;
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

        public List<BALVatasETDS.TANMaster.tbl_TANMaster> GetTANList(string UserName)
        {
            List<BALVatasETDS.TANMaster.tbl_TANMaster> genListMain = new List<BALVatasETDS.TANMaster.tbl_TANMaster>();
            
            try
            {
                this.pConn();
                //List<denMain> genListMain = new List<denMain>();
                cmd = new SqlCommand("proc_getTAN", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@UserName", UserName);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                string ss = reader.FieldCount.ToString();
                
                while (reader.Read())
                {
                    BALVatasETDS.TANMaster.tbl_TANMaster objTAN = new BALVatasETDS.TANMaster.tbl_TANMaster();            
                    objTAN.TAN = Convert.ToString(reader["TAN"]);
                    objTAN.PAN = Convert.ToString(reader["PAN"]);
                    objTAN.AName = Convert.ToString(reader["AName"]);
                    objTAN.ID = Convert.ToInt32(reader["ID"]);
                    genListMain.Add(objTAN);
                }
                return genListMain;
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

        public DataTable getMenu(string AY, string ITR, string Assessee,string Project,Int64 userID)
        {
            DataTable dt = new DataTable();
            try
            {
                //this.pConnMain();
                this.pConnAdmin();
                cmd = new SqlCommand("proc_GetMenu", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ITR", ITR);
                cmd.Parameters.AddWithValue("@Assessee", Assessee);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@project", Project);
                cmd.Parameters.AddWithValue("@userID", userID);
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

        //following function is for global menu from admin DB:

        public DataTable getMenuGlobal(string project, string AY)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("proc_GetMenuGlobal", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProjectName", project);
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
        //This function is used get activated menu link nishu 11/6/2015
        public int getMenuLink(string ProjectName, string AY, string MenuLink)
        {
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("select (case when Parent_Menu<>0 then Parent_Menu else Menu_id end) as mid from tbl_Menu where Project_Name=@pn and Menu_Link=@ml and AY=@ay", this.SqlCon);
                cmd.Parameters.AddWithValue("@pn", ProjectName);
                cmd.Parameters.AddWithValue("@ay", AY);
                cmd.Parameters.AddWithValue("@ml", MenuLink);
                int Menu_ID = Convert.ToInt32(cmd.ExecuteScalar());
                return Menu_ID;
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
        //Following Function will return a table For filling Main Page Details
        public DataTable GetDetails(string NameID)
        {
            DataTable dt = new DataTable();
            try
            {
                //this.pConnMain();
                this.pConn();
                cmd = new SqlCommand("Proc_GetMainDetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
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

        //To get mainID w.r.t. NameID and Employer TAN:
        public string getMainID(string NameID, string Col3)
        {
            string MainID = "";
            try
            {
                //this.pConnMain();
                this.pConn();
                cmd = new SqlCommand("select MainID from storetrans where VType = 13011 and Col3 = @Col3 and NameID = @NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@Col3", Col3);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                MainID = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return MainID;
        }

        public DataTable getT00_Details(int C1, string AY, string ITR)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("select * from T00 where C1=@C1 and C21=@AY and ReturnType=@ITR", this.SqlCon);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@C1", C1);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@ITR", ITR);
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

        //To set Main Page Data w.r.t. NameID, AY and MainID
        public void SetMainPageData(string NameID, string AY, string MainID, string EmployerCategory, string TaxStatus, string ReturnFiledUnderSection, string AreYouGovByPortugeseCivilCode, string PANOfSpouse, string WhetherOriginalOrRevisedReturn, string OrgAckNo, string DateOfFilingOrgReturn, string DateofFilingOriginalReturn, string OriginalAcknowledgementNo, string NoticeNo, string DateOfNotice, string TRPPIN, string NameofTRP, string AmtToBePaidToTRP)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("proc_MainData_Assignment", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);

                cmd.Parameters.AddWithValue("@MainID", MainID);
                cmd.Parameters.AddWithValue("@EmployerCategory", EmployerCategory);
                cmd.Parameters.AddWithValue("@TaxStatus", TaxStatus);
                cmd.Parameters.AddWithValue("@ReturnFiledUnderSection", ReturnFiledUnderSection);
                cmd.Parameters.AddWithValue("@AreYouGovByPortugeseCivilCode", AreYouGovByPortugeseCivilCode);
                cmd.Parameters.AddWithValue("@PANOfSpouse", PANOfSpouse);
                cmd.Parameters.AddWithValue("@WhetherOriginalOrRevisedReturn", WhetherOriginalOrRevisedReturn);
                cmd.Parameters.AddWithValue("@OrgAckNo", OrgAckNo);
                cmd.Parameters.AddWithValue("@DateOfFilingOrgReturn", DateOfFilingOrgReturn);
                cmd.Parameters.AddWithValue("@DateofFilingOriginalReturn", DateofFilingOriginalReturn);
                cmd.Parameters.AddWithValue("@OriginalAcknowledgementNo", OriginalAcknowledgementNo);
                cmd.Parameters.AddWithValue("@NoticeNo", NoticeNo);
                cmd.Parameters.AddWithValue("@DateOfNotice", DateOfNotice);

                cmd.Parameters.AddWithValue("@TRPPIN", TRPPIN);
                cmd.Parameters.AddWithValue("@NameofTRP", NameofTRP);
                cmd.Parameters.AddWithValue("@AmtToBePaidToTRP", AmtToBePaidToTRP);
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

        //To set Signatory Page Data w.r.t. NameID, AY and MainID
        public void SetSignPageData(string NameID, string AY, string MainID, string NameOfAssessee, string PANOfAssessee, string FatherName, string PlaceOfAssessee, string Date)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("proc_SignatoryData_Assignment", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);

                cmd.Parameters.AddWithValue("@MainID", MainID);
                cmd.Parameters.AddWithValue("@NameOfAssessee", NameOfAssessee);
                cmd.Parameters.AddWithValue("@PANOfAssessee", PANOfAssessee);
                cmd.Parameters.AddWithValue("@FatherName", FatherName);
                cmd.Parameters.AddWithValue("@PlaceOfAssessee", PlaceOfAssessee);
                cmd.Parameters.AddWithValue("@Date", Date);
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

        #endregion

        
        #region TDS
        //MADE BY MUDIT ON 03-04-2015
        public void TDSMasterDetails(string TAN, string FY, string RegularCorrection, string Quarter, string FormNo, string AY)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("proc_tblMaster", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TAN", TAN);
                cmd.Parameters.AddWithValue("@Quarter", Quarter);
                cmd.Parameters.AddWithValue("@FormNo", FormNo);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@FY", FY);
                cmd.Parameters.AddWithValue("@RegularCorrection", RegularCorrection);
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

        //Made by mudit On 10-04-2015 For managing TDS Menus
        public DataTable FormQuaeterMapping(string FormNo, string Quarter,string Type)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("proc_GetFormAndQuarter", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FormNo", FormNo);
                cmd.Parameters.AddWithValue("@Quarter", Quarter);
                cmd.Parameters.AddWithValue("@Type", Type);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    this.SqlCon.Close();
                    this.pConnMain();
                    dt.Clear();
                    cmd = new SqlCommand("select * from tbl_ITRTypes where detail = @detail", this.SqlCon);
                    cmd.Parameters.AddWithValue("@detail", FormNo);
                    SqlDataAdapter adp2 = new SqlDataAdapter(cmd);
                    adp2.Fill(dt);
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
            return dt;
        }

        public int IsDataExists(string TAN,string FY,string FormNo, string Quarter, string Type, string Vtype )
        {
            int IsExist = 0;
            try
            {
                this.pConn();
                if (Type == "Regular")
                {
                    if (Vtype == "3001")
                    {
                        cmd = new SqlCommand(@"select Count(*) from mydatabase1.dbo.tbl_ChallanTransferVoucherDetail
                                       where id in(select id from mydatabase1.dbo.tbl_Master 
                                       where TAN = @TAN and FormNo=@FormNo and Quarter=@Quarter and FY=Replace(@FY,'-20','') and Regular_Correction=@Type) ", this.SqlCon);
                    }
                    else if (Vtype == "3002")
                    {
                        cmd = new SqlCommand(@"select Count(*) from mydatabase1.dbo.tbl_DeducteeDetail_Record
                                       where MasterID in(select id from mydatabase1.dbo.tbl_Master 
                                       where TAN = @TAN and FormNo=@FormNo and Quarter=@Quarter and FY=Replace(@FY,'-20','') and Regular_Correction=@Type) ", this.SqlCon);
                    }
                    else if (Vtype == "3003")
                    {
                        cmd = new SqlCommand(@"select Count(*) from mydatabase1.dbo.tbl_SalaryDetailsRecords
                                       where id in(select id from mydatabase1.dbo.tbl_Master 
                                       where TAN = @TAN and FormNo=@FormNo and Quarter=@Quarter and FY=Replace(@FY,'-20','') and Regular_Correction=@Type) ", this.SqlCon);
                    }
                }
                else
                {
                    if (Vtype == "3001")
                    {
                        cmd = new SqlCommand(@"select Count(*) from mydatabase1.dbo.tbl_ChallanTransferVoucherDetail_Correction
                                       where id in(select id from mydatabase1.dbo.tbl_Master 
                                       where TAN = @TAN and FormNo=@FormNo and Quarter=@Quarter and FY=Replace(@FY,'-20','') and Regular_Correction=@Type) ", this.SqlCon);
                    }
                    else if (Vtype == "3002")
                    {
                        cmd = new SqlCommand(@"select Count(*) from mydatabase1.dbo.tbl_DeducteeDetail_Record_Correction
                                       where MasterID in(select id from mydatabase1.dbo.tbl_Master 
                                       where TAN = @TAN and FormNo=@FormNo and Quarter=@Quarter and FY=Replace(@FY,'-20','') and Regular_Correction=@Type) ", this.SqlCon);
                    }
                    else if (Vtype == "3003")
                    {
                        cmd = new SqlCommand(@"select Count(*) from mydatabase1.dbo.tbl_SalaryDetailsRecords_Correction
                                       where id in(select id from mydatabase1.dbo.tbl_Master 
                                       where TAN = @TAN and FormNo=@FormNo and Quarter=@Quarter and FY=Replace(@FY,'-20','') and Regular_Correction=@Type) ", this.SqlCon);
                    }
                }
                cmd.Parameters.AddWithValue("@TAN", TAN);
                cmd.Parameters.AddWithValue("@FormNo", FormNo);
                cmd.Parameters.AddWithValue("@Quarter", Quarter);
                cmd.Parameters.AddWithValue("@FY", FY);
                cmd.Parameters.AddWithValue("@Type", Type);

                IsExist = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return IsExist;
        }

        //By Ankush on 10/10/2016:
        public bool IsProject_XML(string ReturnType)
        {
            bool IsXML = false;
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"select * from dbmain.dbo.ScreenSettings where ISNULL(IsMaster,'0') = '2' and GridIndex in (select C6 from dbmain.dbo.t00 where CHARINDEX(@ReturnType,ReturnType)>0)", this.SqlCon);
                cmd.Parameters.AddWithValue("@ReturnType", ReturnType);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                    IsXML = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return IsXML;
        }

        #endregion


    }
}
