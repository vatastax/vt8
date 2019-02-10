using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Taxation.DataEntity;
namespace Taxation.DataAccess
{

    /// <summary>
    /// Summary description for dalDoctrans
    /// </summary>
    public class dalDoctrans:dalConnection
    {
        #region Constructors
        public dalDoctrans()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        SqlCommand cmd;
        #endregion

        #region Functions
        public int InsertMiscDetails(denDocTrans objDocTransDEN, out Int32 IsExists)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("insertmiscinfo_docTrans", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objDocTransDEN.NameID);
                cmd.Parameters.AddWithValue("@IncomeFileSection", objDocTransDEN.IncomeFileSection);
                cmd.Parameters.AddWithValue("@FBTFileSection", objDocTransDEN.FBTFileSection);
                cmd.Parameters.AddWithValue("@ReturnType", objDocTransDEN.ReturnType);
                cmd.Parameters.AddWithValue("@RecieptNo", objDocTransDEN.RecieptNo);
                cmd.Parameters.AddWithValue("@FilingDate", objDocTransDEN.FilingDate);
                cmd.Parameters.AddWithValue("@ReturnFiledUnderSection", objDocTransDEN.ReturnFiledUS);
                cmd.Parameters.AddWithValue("@FirstReturn", objDocTransDEN.FirstReturn);
                cmd.Parameters.AddWithValue("@username", objDocTransDEN.username);
                cmd.Parameters.AddWithValue("@SpouseName", (objDocTransDEN.SpouseName == null) ? "" : objDocTransDEN.SpouseName);
                cmd.Parameters.AddWithValue("@STC_CodeNumber", objDocTransDEN.STC_CodeNumber);
                cmd.Parameters.AddWithValue("@State", (objDocTransDEN.State == null) ? 26 : objDocTransDEN.State);
                //cmd.Parameters.AddWithValue("@SpousePAN", objDocTransDEN.SpousePAN);
                cmd.Parameters.Add("@IsExists", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                IsExists = Convert.ToInt32(cmd.Parameters["@IsExists"].Value);

                return 0;
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

        public int updateMiscDetails(denDocTrans objDocTransDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("update_Doctrans_Initial", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objDocTransDEN.NameID);
                cmd.Parameters.AddWithValue("@IncomeFileSection", objDocTransDEN.IncomeFileSection);
                cmd.Parameters.AddWithValue("@FBTFileSection", objDocTransDEN.FBTFileSection);
                cmd.Parameters.AddWithValue("@ReturnType", objDocTransDEN.ReturnType);
                cmd.Parameters.AddWithValue("@RecieptNo", objDocTransDEN.RecieptNo);
                cmd.Parameters.AddWithValue("@FilingDate", objDocTransDEN.FilingDate);
                cmd.Parameters.AddWithValue("@ReturnFiledUnderSection", objDocTransDEN.ReturnFiledUS);
                cmd.Parameters.AddWithValue("@FirstReturn", objDocTransDEN.FirstReturn);
                cmd.Parameters.AddWithValue("@IsGovernedByPortugeseCivilCodeunder5A", objDocTransDEN.IsGovernedByPortugeseCivilCodeunder5A);

                cmd.Parameters.AddWithValue("@IsReturnByTRP", objDocTransDEN.IsReturnByTRP);
                cmd.Parameters.AddWithValue("@TRP_PIN", objDocTransDEN.TRP_PIN);
                cmd.Parameters.AddWithValue("@TRP_Name", objDocTransDEN.TRP_Name);
                cmd.Parameters.AddWithValue("@TRP_AmtToBePaid", objDocTransDEN.TRP_AmtToBePaid);
                cmd.ExecuteNonQuery();
                return 0;
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

        public int UpdateBankDetails(denDocTrans objDocTransDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("updatebankdetails_doctrans", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objDocTransDEN.NameID);
                cmd.Parameters.AddWithValue("@BankName", objDocTransDEN.BankNAme);
                cmd.Parameters.AddWithValue("@AccountType", objDocTransDEN.AccountType);
                cmd.Parameters.AddWithValue("@MICRCode", objDocTransDEN.MICRCode);
                cmd.Parameters.AddWithValue("@AccountNumber", objDocTransDEN.AccountNumber);
                cmd.Parameters.AddWithValue("@AddressofBranch", objDocTransDEN.AddressofBranch);
                cmd.Parameters.AddWithValue("@ECS", objDocTransDEN.ECS);
                cmd.Parameters.AddWithValue("@RefundType", objDocTransDEN.RefundMethod);

                cmd.Parameters.AddWithValue("@Business_Nature1", objDocTransDEN.Business_Nature1);
                cmd.Parameters.AddWithValue("@Business_Nature2", objDocTransDEN.Business_Nature2);
                cmd.Parameters.AddWithValue("@Business_Nature3", objDocTransDEN.Business_Nature3);

                cmd.Parameters.AddWithValue("@Business1_Trade1", objDocTransDEN.Business1_Trade1);
                cmd.Parameters.AddWithValue("@Business1_Trade2", objDocTransDEN.Business1_Trade2);
                cmd.Parameters.AddWithValue("@Business1_Trade3", objDocTransDEN.Business1_Trade3);

                cmd.Parameters.AddWithValue("@Business2_Trade1", objDocTransDEN.Business2_Trade1);
                cmd.Parameters.AddWithValue("@Business2_Trade2", objDocTransDEN.Business2_Trade2);
                cmd.Parameters.AddWithValue("@Business2_Trade3", objDocTransDEN.Business2_Trade3);
                
                cmd.Parameters.AddWithValue("@Business3_Trade1", objDocTransDEN.Business3_Trade1);
                cmd.Parameters.AddWithValue("@Business3_Trade2", objDocTransDEN.Business3_Trade2);
                cmd.Parameters.AddWithValue("@Business3_Trade3", objDocTransDEN.Business3_Trade3);

                cmd.ExecuteNonQuery();

                return 0;
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

        public int UpdateRepresentativeDetails(denDocTrans objDocTransDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("updatedatarepresentative_doctrans", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID",objDocTransDEN.NameID);
			    cmd.Parameters.AddWithValue("@Name",objDocTransDEN.Name);
                cmd.Parameters.AddWithValue("@Place",objDocTransDEN.Place);
			    cmd.Parameters.AddWithValue("@Designation",objDocTransDEN.Designation);
               
                cmd.Parameters.AddWithValue("@Flat",objDocTransDEN.Flat);
			    cmd.Parameters.AddWithValue("@Premises",objDocTransDEN.Premises);
                cmd.Parameters.AddWithValue("@Road",objDocTransDEN.Road);
                cmd.Parameters.AddWithValue("@Area" ,objDocTransDEN.Area);
			    cmd.Parameters.AddWithValue("@State",objDocTransDEN.State);
                cmd.Parameters.AddWithValue("@City",objDocTransDEN.City);
                cmd.Parameters.AddWithValue("@PIN",objDocTransDEN.PIN);
                cmd.Parameters.AddWithValue("@PAN", objDocTransDEN.PAN);
                cmd.Parameters.AddWithValue("@Auth_Father_Name", objDocTransDEN.Auth_Father_Name);
                cmd.Parameters.AddWithValue("@FilingDate", objDocTransDEN.FilingDate);

                cmd.ExecuteNonQuery();
                return 0;
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

        public int UpdateAuthorisedSignatory(denDocTrans objDocTransDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("updatedataself_doctrans", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID",objDocTransDEN.NameID);
                 cmd.Parameters.AddWithValue("@Auth_Name",objDocTransDEN.Auth_Name);
                 cmd.Parameters.AddWithValue("@Auth_Father", objDocTransDEN.Auth_Father_Name);
                 //'@Auth_Father', 
				cmd.Parameters.AddWithValue("@Auth_Desig",objDocTransDEN.Auth_Desig);
                cmd.Parameters.AddWithValue("@Auth_Place",objDocTransDEN.Auth_Place);
                cmd.Parameters.AddWithValue("@Ward",objDocTransDEN.WardCircle);
                cmd.Parameters.AddWithValue("@FilingDate", objDocTransDEN.FilingDate);

                cmd.ExecuteNonQuery();
                return 0;
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

        public int UpdateField(string field, string val,string NameID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("update doctrans set " + field + " = @Val where nameid=@NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@Val", val);
                cmd.ExecuteNonQuery();
                return 0;
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

        public denDocTrans GetRepresentativeDetails(string NameID)
        {
            try
            {
                denDocTrans objDocTransDEN = new denDocTrans();
                this.pConn();
                cmd = new SqlCommand("procselectrepresentativedata", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objDocTransDEN.RepAssessee = Convert.ToInt32(reader["isrepassessee"]);
                    if (objDocTransDEN.RepAssessee == 1)
                    {
                        objDocTransDEN.Name = Convert.ToString(reader["name"]);
                        objDocTransDEN.PAN = Convert.ToString(reader["pan"]);
                        objDocTransDEN.Designation = Convert.ToString(reader["designation"]);
                        objDocTransDEN.Place = Convert.ToString(reader["place"]);
                        objDocTransDEN.Flat = Convert.ToString(reader["address1"]);
                        objDocTransDEN.Premises = Convert.ToString(reader["address2"]);
                        objDocTransDEN.Road = Convert.ToString(reader["address3"]);
                        objDocTransDEN.Area = Convert.ToString(reader["address4"]);
                        objDocTransDEN.City = Convert.ToString(reader["city"]);
                        objDocTransDEN.PIN = Convert.ToString(reader["pin"]);
                        objDocTransDEN.State = Convert.ToInt32(reader["state"]);
                        objDocTransDEN.Auth_Father_Name = Convert.ToString(reader["Auth_Father_Name"]);
                    }
                    else if (objDocTransDEN.RepAssessee == 0)
                    {
                        objDocTransDEN.Auth_Name = Convert.ToString(reader["Auth_Name"]);
                        objDocTransDEN.Auth_Desig = Convert.ToString(reader["auth_desig"]);
                        objDocTransDEN.Auth_Father_Name = Convert.ToString(reader["auth_father_name"]);
                        objDocTransDEN.Auth_Place = Convert.ToString(reader["auth_place"]);
                        objDocTransDEN.FilingDate = Convert.ToString(reader["filingdate"]);
                        objDocTransDEN.WardCircle = Convert.ToString(reader["circlepplrname"]);
                        objDocTransDEN.Auth_Father_Name = Convert.ToString(reader["Auth_Father_Name"]);
                    }

                }
                return objDocTransDEN;
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

        public int IsExists(string PANNo)
        {
            int IExists = 0;
            try
            {
                denDocTrans objDocTransDEN = new denDocTrans();
                this.pConn();
                cmd = new SqlCommand("select count(*) from NameMast where PANNo=@PANNo", this.SqlCon);
                cmd.Parameters.AddWithValue("@PANNo", PANNo);
                IExists = Convert.ToInt32(cmd.ExecuteScalar());
                return IExists;
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

        public int getState(string NameID)
        {
            int stateID = 0;
            try
            {
                denDocTrans objDocTransDEN = new denDocTrans();
                this.pConn();
                cmd = new SqlCommand("select State from DocTrans where NameID=@NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                stateID = Convert.ToInt32(cmd.ExecuteScalar());
                return stateID;
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

        public denDocTrans GetBankDetails(string NameID)
        {
            try
            {
                denDocTrans objDocTransDEN = new denDocTrans();
                this.pConn();
                cmd = new SqlCommand("procgetbankdetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objDocTransDEN.BankNAme = Convert.ToString(reader["nameofbank"]);
                    objDocTransDEN.AddressofBranch = Convert.ToString(reader["address"]);
                    objDocTransDEN.AccountNumber = Convert.ToString(reader["accountno"]);
                    objDocTransDEN.MICRCode = Convert.ToString(reader["micrcode"]);
                    objDocTransDEN.AccountType = Convert.ToString(reader["accounttype"]);
                    objDocTransDEN.ECS = Convert.ToString(reader["esc"]);
                    objDocTransDEN.RefundMethod = Convert.ToString(reader["refundtype"]);


                    objDocTransDEN.Business_Nature1 = Convert.ToInt64(Convert.IsDBNull(reader["Business_Nature1"]) ? 0 : reader["Business_Nature1"]);
                    objDocTransDEN.Business_Nature2 = Convert.ToInt64(Convert.IsDBNull(reader["Business_Nature2"]) ? 0 : reader["Business_Nature2"]);
                    objDocTransDEN.Business_Nature3 = Convert.ToInt64(Convert.IsDBNull(reader["Business_Nature3"]) ? 0 : reader["Business_Nature3"]);

                    objDocTransDEN.Business1_Trade1 = reader["Business1_Trade1"].ToString();
                    objDocTransDEN.Business1_Trade2 = reader["Business1_Trade2"].ToString();
                    objDocTransDEN.Business1_Trade3 = reader["Business1_Trade3"].ToString();

                    objDocTransDEN.Business2_Trade1 = reader["Business2_Trade1"].ToString();
                    objDocTransDEN.Business2_Trade2 = reader["Business2_Trade2"].ToString();
                    objDocTransDEN.Business2_Trade3 = reader["Business2_Trade3"].ToString();

                    objDocTransDEN.Business3_Trade1 = reader["Business3_Trade1"].ToString();
                    objDocTransDEN.Business3_Trade2 = reader["Business3_Trade2"].ToString();
                    objDocTransDEN.Business3_Trade3 = reader["Business3_Trade3"].ToString();

                    //objDocTransDEN.bus

                }
                return objDocTransDEN;

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

        //Function Added by Mudit on 01/09/2015 to enter main page data in storetrans
        public int InsertMainDataInStoreTrans(denDocTrans objDocTransDEN,string AY,string ITRType,string EmpCategory,string DueDate,int FlagPri)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procInsertDocTransInStoreTrans", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@NameID", objDocTransDEN.NameID);
                cmd.Parameters.AddWithValue("@AY",AY );
                cmd.Parameters.AddWithValue("@ITRType", ITRType);
                if (FlagPri == 0)
                {
                    cmd.Parameters.AddWithValue("@IncomeFileSection", objDocTransDEN.IncomeFileSection);

                    cmd.Parameters.AddWithValue("@ReturnType", objDocTransDEN.ReturnType);
                    cmd.Parameters.AddWithValue("@FilingDate", objDocTransDEN.FilingDate);
                    cmd.Parameters.AddWithValue("@ReturnFiledUnderSection", objDocTransDEN.ReturnFiledUS);
                    cmd.Parameters.AddWithValue("@IsGovernedByPortugeseCivilCodeunder5A", objDocTransDEN.IsGovernedByPortugeseCivilCodeunder5A);

                    cmd.Parameters.AddWithValue("@IsReturnByTRP", objDocTransDEN.IsReturnByTRP);
                    cmd.Parameters.AddWithValue("@TRP_AmtToBePaid", objDocTransDEN.TRP_AmtToBePaid);
                    cmd.Parameters.AddWithValue("@TRP_Name", objDocTransDEN.TRP_Name);
                    cmd.Parameters.AddWithValue("@TRP_PIN", objDocTransDEN.TRP_PIN);

                    cmd.Parameters.AddWithValue("@EmpCategory", EmpCategory);
                    cmd.Parameters.AddWithValue("@DueDate", DueDate);
                    cmd.Parameters.AddWithValue("@AckNo", "");
                    cmd.Parameters.AddWithValue("@SpouseName", objDocTransDEN.SpouseName);

                    cmd.Parameters.AddWithValue("@SpousePAN", objDocTransDEN.SpousePAN);
                    cmd.Parameters.AddWithValue("@NoticeNo", "");
                    cmd.Parameters.AddWithValue("@AuthName", objDocTransDEN.Auth_Name);

                    cmd.Parameters.AddWithValue("@AuthPAN", objDocTransDEN.PAN);
                    cmd.Parameters.AddWithValue("@Place", objDocTransDEN.Place);
                    cmd.Parameters.AddWithValue("@Date", objDocTransDEN.FilingDate);
                    cmd.Parameters.AddWithValue("@FlagPri", FlagPri);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IncomeFileSection", "");

                    cmd.Parameters.AddWithValue("@ReturnType", "");
                    cmd.Parameters.AddWithValue("@FilingDate", "");
                    cmd.Parameters.AddWithValue("@ReturnFiledUnderSection","");
                    cmd.Parameters.AddWithValue("@IsGovernedByPortugeseCivilCodeunder5A", "");

                    cmd.Parameters.AddWithValue("@IsReturnByTRP", "");
                    cmd.Parameters.AddWithValue("@TRP_AmtToBePaid", "");
                    cmd.Parameters.AddWithValue("@TRP_Name","");
                    cmd.Parameters.AddWithValue("@TRP_PIN", "");

                    cmd.Parameters.AddWithValue("@EmpCategory", "");
                    cmd.Parameters.AddWithValue("@DueDate", "");
                    cmd.Parameters.AddWithValue("@AckNo", "");
                    cmd.Parameters.AddWithValue("@SpouseName", "");

                    cmd.Parameters.AddWithValue("@SpousePAN", "");
                    cmd.Parameters.AddWithValue("@NoticeNo", "");
                    cmd.Parameters.AddWithValue("@AuthName", objDocTransDEN.Name);

                    cmd.Parameters.AddWithValue("@AuthPAN", objDocTransDEN.PAN);
                    cmd.Parameters.AddWithValue("@Place", objDocTransDEN.Place);
                    cmd.Parameters.AddWithValue("@Date", objDocTransDEN.FilingDate);
                    cmd.Parameters.AddWithValue("@FlagPri", FlagPri);
                }
                cmd.ExecuteNonQuery();
                
                return 0;
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