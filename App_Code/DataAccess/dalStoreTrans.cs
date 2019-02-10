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
using System.Text;
/// <summary>
/// Summary description for dalStoreTrans
/// </summary>
/// 
namespace Taxation.DataAccess
{
    public class dalStoreTrans : dalConnection
    {
        #region Constructor
        public dalStoreTrans()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables

        SqlCommand cmd, cmd2;
        denStoreTrans objdenStoreTrans;
        #endregion

        #region Utilities
        public int UpdateMainGrid(denStoreTrans objSToreTrans1DEO, out string msg)
        {
            msg = "";
            try
            {
                this.pConn();
                if (objSToreTrans1DEO.Col3 == "")
                {
                    SqlCommand cmd4 = new SqlCommand("delete from storetrans where NameID = @NameID and MainID=@MainID and ConstantID = @ConstID and AY=@AY", this.SqlCon);
                    cmd4.Parameters.AddWithValue("@NameID", objSToreTrans1DEO.NameID);
                    cmd4.Parameters.AddWithValue("@MainID", objSToreTrans1DEO.MainID);
                    cmd4.Parameters.AddWithValue("@ConstID", objSToreTrans1DEO.ConstID);
                    cmd4.Parameters.AddWithValue("@AY", objSToreTrans1DEO.AY);
                    cmd4.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("procUpdateStoreTransMain", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NameID", objSToreTrans1DEO.NameID);
                    cmd.Parameters.AddWithValue("@Vtype", objSToreTrans1DEO.Vtype);
                    cmd.Parameters.AddWithValue("@MainID", objSToreTrans1DEO.MainID);
                    cmd.Parameters.AddWithValue("@ConstID", objSToreTrans1DEO.ConstID);
                    cmd.Parameters.AddWithValue("@Amount", objSToreTrans1DEO.Col3);
                    cmd.ExecuteNonQuery();
                }
                if (objSToreTrans1DEO.Vtype != 1066)
                {
                    SqlCommand cmd3 = new SqlCommand("procTempArray2", this.SqlCon);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@intC1", objSToreTrans1DEO.ConstID);
                    cmd3.Parameters.AddWithValue("@intIndex", objSToreTrans1DEO.GIndex);
                    cmd3.Parameters.AddWithValue("@AYear", objSToreTrans1DEO.AY);
                    cmd3.Parameters.AddWithValue("@MainID", objSToreTrans1DEO.MainID);
                    cmd3.Parameters.AddWithValue("@vtype", objSToreTrans1DEO.Vtype);
                    cmd3.Parameters.AddWithValue("@gioNameID", objSToreTrans1DEO.NameID);
                    cmd3.Parameters.AddWithValue("@purDate", "17-1-2015");
                    cmd3.Parameters.AddWithValue("@purCost", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@purExp", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@Nos", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@AssetID", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@gRowNo", objSToreTrans1DEO.GRowNo);
                    cmd3.Parameters.AddWithValue("@bolMethod1", true);
                    cmd3.Parameters.AddWithValue("@tblSelection", 0);
                    cmd3.Parameters.AddWithValue("@gTOA", 0);
                    cmd3.Parameters.AddWithValue("@gridIndex", objSToreTrans1DEO.GIndex);
                    cmd3.Parameters.AddWithValue("@DueDate", objSToreTrans1DEO.DueDate);
                    cmd3.Parameters.AddWithValue("@ITRType", HttpContext.Current.Session["ITR"].ToString());
                    cmd3.Parameters.Add("@OutputResult", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                    //cmd3.ExecuteNonQuery();

                    SqlDataAdapter adp = new SqlDataAdapter(cmd3);
                    DataTable dtST = new DataTable();
                    adp.Fill(dtST);
                    if (dtST.Rows.Count > 0)
                    {
                        if (dtST.Columns.Contains("msg"))
                            msg = dtST.Rows[0]["msg"].ToString();
                    }
                }

                //decimal OutputResult;
                //if (Convert.IsDBNull(cmd3.Parameters["@OutputResult"].Value))
                //    OutputResult = Convert.ToDecimal(cmd3.Parameters["@OutputResult"].Value);
                //else
                //    OutputResult = Convert.ToDecimal(cmd3.Parameters["@OutputResult"].Value);

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
        public int RunShowCalcOnOKButton(denStoreTrans objStoreTransDEN)
        {
            try
            {
                this.pConn();

                cmd2 = new SqlCommand("procShowcalculation", this.SqlCon);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@gioNameID", objStoreTransDEN.NameID);
                cmd2.Parameters.AddWithValue("@MainID", objStoreTransDEN.MainID);
                cmd2.Parameters.AddWithValue("@VType", objStoreTransDEN.Vtype);
                cmd2.Parameters.AddWithValue("@AYear", objStoreTransDEN.AY);
                cmd2.Parameters.AddWithValue("@ConstantID", objStoreTransDEN.ConstID);
                cmd2.Parameters.AddWithValue("@gIndex", objStoreTransDEN.GIndex);
                cmd2.Parameters.AddWithValue("@AssType", objStoreTransDEN.AssesseeType);
                cmd2.Parameters.AddWithValue("@expNext", "");
                cmd2.Parameters.AddWithValue("@ITRType", HttpContext.Current.Session["ITR"].ToString());
                cmd2.ExecuteNonQuery();
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
        public int UpdateMainGridBalanceSheet(denStoreTrans objStoreTransDEN,out string msg)
        {
            msg = "";
            try
            {
                this.pConn();
                cmd = new SqlCommand("procUpdateStoreTransMain", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objStoreTransDEN.NameID);
                cmd.Parameters.AddWithValue("@Vtype", objStoreTransDEN.Vtype);
                cmd.Parameters.AddWithValue("@MainID", objStoreTransDEN.MainID);
                cmd.Parameters.AddWithValue("@ConstID", objStoreTransDEN.ConstID);
                cmd.Parameters.AddWithValue("@Amount", objStoreTransDEN.Col3);
                cmd.ExecuteNonQuery();

                if (objStoreTransDEN.Vtype != 1066)
                {
                    SqlCommand cmd3 = new SqlCommand("procTempArray2", this.SqlCon);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@intC1", objStoreTransDEN.ConstID);
                    cmd3.Parameters.AddWithValue("@intIndex", objStoreTransDEN.GIndex);
                    cmd3.Parameters.AddWithValue("@AYear", objStoreTransDEN.AY);
                    cmd3.Parameters.AddWithValue("@MainID", objStoreTransDEN.MainID);
                    cmd3.Parameters.AddWithValue("@vtype", objStoreTransDEN.Vtype);
                    cmd3.Parameters.AddWithValue("@gioNameID", objStoreTransDEN.NameID);
                    cmd3.Parameters.AddWithValue("@purDate", "17-1-2015");
                    cmd3.Parameters.AddWithValue("@purCost", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@purExp", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@Nos", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@AssetID", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@gRowNo", objStoreTransDEN.GRowNo);
                    cmd3.Parameters.AddWithValue("@bolMethod1", true);
                    cmd3.Parameters.AddWithValue("@tblSelection", 0);
                    cmd3.Parameters.AddWithValue("@gTOA", 0);
                    cmd3.Parameters.AddWithValue("@gridIndex", objStoreTransDEN.GIndex);
                    cmd3.Parameters.AddWithValue("@DueDate", objStoreTransDEN.DueDate);
                    cmd3.Parameters.AddWithValue("@ITRType", HttpContext.Current.Session["ITR"].ToString());

                    cmd3.Parameters.Add("@OutputResult", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd3);
                    DataTable dtST = new DataTable();
                    adp.Fill(dtST);
                    if (dtST.Rows.Count > 0)
                    {
                        if (dtST.Columns.Contains("msg"))
                            msg = dtST.Rows[0]["msg"].ToString();
                    }
                    //cmd3.ExecuteNonQuery();

                    decimal OutputResult;
                    if (Convert.IsDBNull(cmd3.Parameters["@OutputResult"].Value))
                        OutputResult = 0;// Convert.ToDecimal(cmd3.Parameters["@OutputResult"].Value);
                    else
                        OutputResult = Convert.ToDecimal(cmd3.Parameters["@OutputResult"].Value);
                }
                if (HttpContext.Current.Session["Project"].ToString() == "tds")
                {
                    cmd2 = new SqlCommand("procShowcalculation", this.SqlCon);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@gioNameID", objStoreTransDEN.NameID);
                    cmd2.Parameters.AddWithValue("@MainID", objStoreTransDEN.NameID);
                    cmd2.Parameters.AddWithValue("@VType", objStoreTransDEN.Vtype);
                    cmd2.Parameters.AddWithValue("@AYear", objStoreTransDEN.AY);
                    cmd2.Parameters.AddWithValue("@ConstantID", objStoreTransDEN.ConstID);
                    cmd2.Parameters.AddWithValue("@gIndex", objStoreTransDEN.GIndex);
                    cmd2.Parameters.AddWithValue("@AssType", objStoreTransDEN.AssesseeType);
                    cmd2.Parameters.AddWithValue("@ITRType", HttpContext.Current.Session["ITR"].ToString());
                    cmd2.Parameters.AddWithValue("@expNext", " ");
                    cmd2.ExecuteNonQuery();
                    if (objStoreTransDEN.ConstID != 1524016 && objStoreTransDEN.ConstID != 1524017 && objStoreTransDEN.ConstID != 1524018)
                    {
                        Taxation.BusinessLogic.bllSalary objbllSalary = new BusinessLogic.bllSalary();
                        objbllSalary.calcTax_TDS(objStoreTransDEN.AY, objStoreTransDEN.NameID, objStoreTransDEN.Vtype);
                    }

                }
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
        public int UpdateDetailsGrid(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procUpdateStoreTransDetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objStoreTrans2DEO.NameID);
                cmd.Parameters.AddWithValue("@Vtype", objStoreTrans2DEO.Vtype);
                cmd.Parameters.AddWithValue("@MainID", objStoreTrans2DEO.MainID);
                cmd.Parameters.AddWithValue("@ConstID", objStoreTrans2DEO.ConstID);
                cmd.Parameters.AddWithValue("@SubConstID", objStoreTrans2DEO.SubConstID);
                cmd.Parameters.AddWithValue("@Amount", objStoreTrans2DEO.Col3);
                cmd.Parameters.AddWithValue("@AY", HttpContext.Current.Session["AY"].ToString());
                cmd.Parameters.AddWithValue("@ITRType", HttpContext.Current.Session["ITR"].ToString());

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

        // following code is to generate the XML:

        public void genXML(string NameID, string AY, string path, string ITR, string duedate, string strhashCode, string ReturnType, out string xmlfile, out string xmlfile_Extra)
        {
            xmlfile = "";
            xmlfile_Extra = "";
            try
            {
                //this.pConn();
                this.pConnMain();
                if (ITR == "3")
                {
                    cmd = new SqlCommand("Proc_ServiceTax_CombinedXML", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NameID", NameID);
                    cmd.Parameters.AddWithValue("@fnYear", AY);
                    cmd.Parameters.AddWithValue("@path", path);
                    cmd.Parameters.AddWithValue("@Xml", path);
                }
                else
                {
                    if (ITR == "1" || ITR == "8" || ITR == "4" || ITR == "9" || ITR == "50" || ITR == "51" || ITR == "55")
                    {
                        //cmd = new SqlCommand("Proc_ITR1XML", this.SqlCon);
                        //cmd = new SqlCommand("Proc_Generic_Xml_ITR1", this.SqlCon);
                        cmd = new SqlCommand("Proc_Call_Proc_Generic_Xml_ITR_New", this.SqlCon);
                        cmd.CommandTimeout = 1000;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ay", AY);
                        cmd.Parameters.AddWithValue("@ItrType", ITR);
                        cmd.Parameters.AddWithValue("@NameID", NameID);
                        cmd.Parameters.AddWithValue("@IsAssesseeCreate", 0);
                        cmd.Parameters.AddWithValue("@path", path);
                        cmd.Parameters.AddWithValue("@JobID", (HttpContext.Current.Session["Job_ID"] != null ? HttpContext.Current.Session["Job_ID"] : ""));
                        //cmd.Parameters.Add("@Result1", SqlDbType.NVarChar, 100000).Direction = ParameterDirection.Output;
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        //cmd.ExecuteNonQuery();
                        xmlfile = dt.Rows[0]["Result"].ToString();
                        xmlfile_Extra = dt.Rows[0]["Combine"].ToString();
                        //xmlfile = Convert.ToString(cmd.Parameters["@Result1"].Value);
                    }
                    //else if (ITR == "8")
                    //{
                    //    cmd = new SqlCommand("Proc_ITR4SXML", this.SqlCon);
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@fnYear", AY);
                    //    cmd.Parameters.AddWithValue("@path", path);
                    //    cmd.Parameters.AddWithValue("@duedate", duedate);
                    //    cmd.Parameters.AddWithValue("@HashCode", strhashCode);
                    //    cmd.Parameters.AddWithValue("@IsValidated", 0);
                    //    cmd.Parameters.AddWithValue("@NameID", NameID);
                    //    cmd.Parameters.AddWithValue("@ReturnType", ReturnType);
                    //}


                }

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

        public void validateXML(string xmlFile, string AY, int IsValidated, string NameID, string ITRType, string ReturnType, string IsUploaded, string xmlFile_Extra, out int flag)
        {
            flag = 0;
            try
            {
                //this.pConn();
                this.pConnMain();
                cmd = new SqlCommand("Proc_Validate_XML", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@xmlfile", xmlFile);
                cmd.Parameters.AddWithValue("@ay", AY);
                //cmd.Parameters.AddWithValue("@Isvalidated", IsValidated);
                cmd.Parameters.AddWithValue("@nameid", NameID);
                cmd.Parameters.AddWithValue("@ItrType", ITRType);
                cmd.Parameters.AddWithValue("@XML_Total", xmlFile_Extra);
                cmd.Parameters.AddWithValue("@JobId", (HttpContext.Current.Session["Job_ID"] != null ? Convert.ToInt32(HttpContext.Current.Session["Job_ID"]) : 0));

                //cmd.Parameters.AddWithValue("@ReturnType", ReturnType);
                //cmd.Parameters.AddWithValue("@Isuploaded", IsUploaded);

                cmd.Parameters.Add("@Isvalidated", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                flag = Convert.ToInt32(cmd.Parameters["@Isvalidated"].Value);

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


        public void genXML(string NameID, string AY, string path, string ITR, string duedate, int IsValidated)
        {
            try
            {
                this.pConn();
                if (ITR == "1")
                    cmd = new SqlCommand("Proc_ITR1XML", this.SqlCon);
                else if (ITR == "4s")
                    cmd = new SqlCommand("Proc_ITR4SXML", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@fnYear", AY);
                cmd.Parameters.AddWithValue("@path", path);
                cmd.Parameters.AddWithValue("@duedate", duedate);
                cmd.Parameters.AddWithValue("@IsValidated", IsValidated);
                cmd.Parameters.AddWithValue("@HashCode", "");
                cmd.Parameters.AddWithValue("@ReturnType", "1");
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

        // following code is to restore the XML:
        public void resXML(string xml, string Username, string AY, string path, string ITR, string NameID, out string PAN, int IsValidated)
        {
            try
            {
                this.pConn();
                //if (ITR == "1")
                cmd = new SqlCommand("ChkXmlBeforeUpload_Insert", this.SqlCon);
                //else if (ITR == "4s")
                //cmd = new SqlCommand("Proc_ITR4SXMLReverse", this.SqlCon);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@xml", xml);
                cmd.Parameters.AddWithValue("@ITRType", ITR);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@AY", AY);
                //cmd.Parameters.AddWithValue("@path", path);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.Add("@PAN", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@IsValidated", IsValidated);
                cmd.ExecuteNonQuery();
                PAN = Convert.ToString(cmd.Parameters["@PAN"].Value);
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

        // following code is to restore the XML:
        public void resXML_withMsg(string xml, string Username, string AY, string path, string ITR, string NameID, out string PAN, int IsValidated, out string msg)
        {
            PAN = "";
            msg = "";
            try
            {
                this.pConn();
                //if (ITR == "1")
                cmd = new SqlCommand("ChkXmlBeforeUpload_Insert", this.SqlCon);
                //else if (ITR == "4s")
                //cmd = new SqlCommand("Proc_ITR4SXMLReverse", this.SqlCon);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@xml", xml);
                cmd.Parameters.AddWithValue("@ITRType", ITR);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@AY", AY);
                //cmd.Parameters.AddWithValue("@path", path);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.Add("@PAN", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@IsValidated", IsValidated);
                cmd.ExecuteNonQuery();
                PAN = Convert.ToString(cmd.Parameters["@PAN"].Value);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                //throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }

        //Function Added by Mudit on 19/08/2015 to uplaod bulkxml without updating master data for BulkXMLUpload
        public void resXMLNoMasterUpdate(string xml, string Username, string AY, string path, string ITR, string NameID, out string PAN, int IsValidated)
        {
            try
            {
                this.pConn();
                //if (ITR == "1")
                cmd = new SqlCommand("ChkXmlBeforeUpload_InsertNoMasterUpdate", this.SqlCon);
                //else if (ITR == "4s")
                //cmd = new SqlCommand("Proc_ITR4SXMLReverse", this.SqlCon);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@xml", xml);
                cmd.Parameters.AddWithValue("@ITRType", ITR);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@AY", AY);
                //cmd.Parameters.AddWithValue("@path", path);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.Add("@PAN", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@IsValidated", IsValidated);
                cmd.ExecuteNonQuery();

                PAN = Convert.ToString(cmd.Parameters["@PAN"].Value);
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

        // following code is to restore the Invalid XML:
        public void resXMLInv(string AY, string Username, string ITR, Int64 ID, out string PAN)
        {
            try
            {
                this.pConn();
                if (ITR == "1")
                    cmd = new SqlCommand("Proc_ITR1XMLReverse", this.SqlCon);
                else if (ITR == "4s")
                    cmd = new SqlCommand("Proc_ITR4SXMLReverse", this.SqlCon);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@path", "");
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.Add("@PAN", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                PAN = Convert.ToString(cmd.Parameters["@PAN"].Value);
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

        // To Reverse Valid/Invalid XML using Sweeta Procedure
        public void resXMLInv(string NameID, string AY, out string PAN, int ITRType)
        {
            try
            {
                //this.pConn();
                this.pConnMain();
                //cmd = new SqlCommand("Proc_XML_Reverse", this.SqlCon);
                cmd = new SqlCommand("Proc_XML_Reverse_Bulk", this.SqlCon);
                cmd.CommandTimeout = 9999999;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@ITRType", ITRType);
                cmd.Parameters.AddWithValue("@xmlid", 0);//for testing 
                cmd.Parameters.AddWithValue("@UserName", "");
                cmd.Parameters.Add("@PAN", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                PAN = Convert.ToString(cmd.Parameters["@PAN"].Value);
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

        //public void resXML(string xml,string Username, string AY, string path, string ITR,string NameID)
        //{
        //    try
        //    {
        //        this.pConn();
        //        //if (ITR == "1")
        //        cmd = new SqlCommand("ChkXmlBeforeUpload_Insert", this.SqlCon);
        //        //else if (ITR == "4s")
        //        //cmd = new SqlCommand("Proc_ITR4SXMLReverse", this.SqlCon);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@xml", xml);
        //        cmd.Parameters.AddWithValue("@ITRType", ITR);
        //        cmd.Parameters.AddWithValue("@Username", Username);
        //        cmd.Parameters.AddWithValue("@AY", AY);
        //        //cmd.Parameters.AddWithValue("@path", path);
        //        cmd.Parameters.AddWithValue("@NameID", NameID);
        //        //cmd.Parameters.Add("@PAN", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
        //        cmd.ExecuteNonQuery();

        //        //PAN = Convert.ToString(cmd.Parameters["@PAN"].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        this.SqlCon.Close();
        //    }
        //}

        //Following Function is written by Ankush for Store Trans for the child values according to the main Parent Value
        public int UpdateDetailsGridByMain(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procUpdateStoreTransDetailsForMain", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objStoreTrans2DEO.NameID);
                cmd.Parameters.AddWithValue("@Vtype", objStoreTrans2DEO.Vtype);
                cmd.Parameters.AddWithValue("@MainID", objStoreTrans2DEO.MainID);
                cmd.Parameters.AddWithValue("@ConstID", objStoreTrans2DEO.ConstID);
                cmd.Parameters.AddWithValue("@GRowNo", objStoreTrans2DEO.GRowNo);
                cmd.Parameters.AddWithValue("@Amount", objStoreTrans2DEO.Col3);
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

        public int UpdateDetailsGridYesNo(denStoreTrans objStoreTransDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procupdatestoretransdetailsyesno", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objStoreTransDEN.NameID);
                cmd.Parameters.AddWithValue("@Vtype", objStoreTransDEN.Vtype);
                cmd.Parameters.AddWithValue("@MainID", objStoreTransDEN.MainID);
                cmd.Parameters.AddWithValue("@ConstID", objStoreTransDEN.ConstID);
                cmd.Parameters.AddWithValue("@SubConstID", objStoreTransDEN.SubConstID);
                cmd.Parameters.AddWithValue("@Col2", objStoreTransDEN.col2);
                cmd.Parameters.AddWithValue("@AY", objStoreTransDEN.AY);
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

        public int CheckDataMainGrid(denStoreTrans objStoreTransDEO)
        {

            try
            {
                int x;
                this.pConn();
                cmd = new SqlCommand("proccountermain", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objStoreTransDEO.NameID);
                cmd.Parameters.AddWithValue("@MainID", objStoreTransDEO.MainID);
                cmd.Parameters.AddWithValue("@Vtype", objStoreTransDEO.Vtype);
                cmd.Parameters.AddWithValue("@ConstID", objStoreTransDEO.ConstID);
                cmd.Parameters.AddWithValue("@AY", objStoreTransDEO.AY);
                // cmd.Parameters.Add("@ret", SqlDbType.Int).Direction = ParameterDirection.Output;
                x = Convert.ToInt32(cmd.ExecuteScalar());
                return x;
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

        public int CheckDataDetailsGrid(denStoreTrans objStoreTransDEO)
        {
            try
            {
                int x;
                this.pConn();
                cmd = new SqlCommand("proccounterdetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objStoreTransDEO.NameID);
                cmd.Parameters.AddWithValue("@MainID", objStoreTransDEO.MainID);
                cmd.Parameters.AddWithValue("@Vtype", objStoreTransDEO.Vtype);
                cmd.Parameters.AddWithValue("@ConstID", objStoreTransDEO.ConstID);
                cmd.Parameters.AddWithValue("@SubConstID", objStoreTransDEO.SubConstID);
                cmd.Parameters.AddWithValue("@AY", objStoreTransDEO.AY);
                //cmd.Parameters.Add("@ret", SqlDbType.Int).Direction = ParameterDirection.Output;
                x = Convert.ToInt16(cmd.ExecuteScalar());

                return x;

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

        public int InsertDataMainGrid(denStoreTrans objStoreTransDEN,out string msg)
        {
            msg = "";
            try
            {
                this.pConn();
                cmd = new SqlCommand("procInsertStoreTransMainNEW", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@entry", objdenStoreTrans.EntryID);
                cmd.Parameters.AddWithValue("@nameID", objStoreTransDEN.NameID);
                cmd.Parameters.AddWithValue("@Vtype", objStoreTransDEN.Vtype);
                cmd.Parameters.AddWithValue("@MainID", objStoreTransDEN.MainID);
                cmd.Parameters.AddWithValue("@ConstantID", objStoreTransDEN.ConstID);
                cmd.Parameters.AddWithValue("@SubConstID", objStoreTransDEN.SubConstID);
                cmd.Parameters.AddWithValue("@ComboItemNo", objStoreTransDEN.ComboItemNo);
                cmd.Parameters.AddWithValue("@GridIndex", objStoreTransDEN.GIndex);
                cmd.Parameters.AddWithValue("@Col3", objStoreTransDEN.Col3);
                cmd.Parameters.AddWithValue("@AY", objStoreTransDEN.AY);
                cmd.Parameters.AddWithValue("@GRowNo", objStoreTransDEN.GRowNo);
                cmd.Parameters.AddWithValue("@IsEnterFDet", objStoreTransDEN.IsEnterFDet);
                cmd.Parameters.AddWithValue("@RecdAmount", objStoreTransDEN.RecdAmount);
                cmd.ExecuteNonQuery();

                //following procedure mainly works for the calculations where a row cell value depends upon previous row cells (e.g.: 5(1,2,3) -> mean that Row 5 cell will automatically get sum of these 3 rows
                if (HttpContext.Current.Session["Project"].ToString() == "tds")
                {
                    cmd2 = new SqlCommand("procShowcalculation", this.SqlCon);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@gioNameID", objStoreTransDEN.NameID);
                    cmd2.Parameters.AddWithValue("@MainID", objStoreTransDEN.MainID);
                    cmd2.Parameters.AddWithValue("@VType", objStoreTransDEN.Vtype);
                    cmd2.Parameters.AddWithValue("@AYear", objStoreTransDEN.AY);
                    cmd2.Parameters.AddWithValue("@ConstantID", objStoreTransDEN.ConstID);
                    cmd2.Parameters.AddWithValue("@gIndex", objStoreTransDEN.GIndex);
                    cmd2.Parameters.AddWithValue("@AssType", objStoreTransDEN.AssesseeType);
                    cmd2.Parameters.AddWithValue("@ITRType", HttpContext.Current.Session["ITR"].ToString());
                    cmd2.Parameters.AddWithValue("@expNext", "");                    
                    cmd2.ExecuteNonQuery();
                    if (objStoreTransDEN.ConstID != 1524016 && objStoreTransDEN.ConstID != 1524017 && objStoreTransDEN.ConstID != 1524018)
                    {
                        Taxation.BusinessLogic.bllSalary objbllSalary = new BusinessLogic.bllSalary();
                        objbllSalary.calcTax_TDS(objStoreTransDEN.AY, objStoreTransDEN.NameID, objStoreTransDEN.Vtype);
                    }
                    
                }

                // Following procedure works for the specific hard code based coding for the specific conditions like Deductions for ConstantIDs (9070,982,983), other deductions for adding additional values
                if (objStoreTransDEN.Vtype != 1066)
                {
                    SqlCommand cmd3 = new SqlCommand("procTempArray2", this.SqlCon);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@intC1", objStoreTransDEN.ConstID);
                    cmd3.Parameters.AddWithValue("@intIndex", objStoreTransDEN.GIndex);
                    cmd3.Parameters.AddWithValue("@AYear", objStoreTransDEN.AY);
                    cmd3.Parameters.AddWithValue("@MainID", objStoreTransDEN.MainID);
                    cmd3.Parameters.AddWithValue("@vtype", objStoreTransDEN.Vtype);
                    cmd3.Parameters.AddWithValue("@gioNameID", objStoreTransDEN.NameID);
                    cmd3.Parameters.AddWithValue("@purDate", "17-1-2015");
                    cmd3.Parameters.AddWithValue("@purCost", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@purExp", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@Nos", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@AssetID", Convert.ToDecimal(0));
                    cmd3.Parameters.AddWithValue("@gRowNo", objStoreTransDEN.GRowNo);
                    cmd3.Parameters.AddWithValue("@bolMethod1", true);
                    cmd3.Parameters.AddWithValue("@tblSelection", 0);
                    cmd3.Parameters.AddWithValue("@gTOA", 0);
                    cmd3.Parameters.AddWithValue("@gridIndex", objStoreTransDEN.GIndex);
                    cmd3.Parameters.AddWithValue("@DueDate", objStoreTransDEN.DueDate);
                    cmd3.Parameters.AddWithValue("@ITRType", HttpContext.Current.Session["ITR"].ToString());

                    cmd3.Parameters.Add("@OutputResult", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd3);
                    DataTable dtST = new DataTable();
                    adp.Fill(dtST);
                    if (dtST.Rows.Count > 0)
                    {
                        if (dtST.Columns.Contains("msg"))
                            msg = dtST.Rows[0]["msg"].ToString();
                    }
                    //cmd3.ExecuteNonQuery();

                    decimal OutputResult;
                    if (Convert.IsDBNull(cmd3.Parameters["@OutputResult"].Value))
                        OutputResult = 0;// Convert.ToDecimal(cmd3.Parameters["@OutputResult"].Value);
                    else
                        OutputResult = Convert.ToDecimal(cmd3.Parameters["@OutputResult"].Value);
                }
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

        public void setLosses(decimal IFS, decimal IFHP, decimal IFBus, decimal IFSI, decimal IFSBus, decimal IFSTCG_15, decimal IFSTCG_30, decimal IFSTCG_app, decimal IFLTCG_10, decimal IFLTCG_20, decimal IFOS, decimal IFP_RH, string NameID, string AY, string ITR)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("A_Losses_New", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@IFS", IFS);
                //cmd.Parameters.AddWithValue("@IFHP", IFHP);
                //cmd.Parameters.AddWithValue("@IFBus", IFBus);
                //cmd.Parameters.AddWithValue("@IFSI", IFSI);
                //cmd.Parameters.AddWithValue("@IFSBus", IFSBus);
                //cmd.Parameters.AddWithValue("@IFSTCG_15", IFSTCG_15);
                //cmd.Parameters.AddWithValue("@IFSTCG_30", IFSTCG_30);
                //cmd.Parameters.AddWithValue("@IFSTCG_app", IFSTCG_app);
                //cmd.Parameters.AddWithValue("@IFLTCG_10", IFLTCG_10);
                //cmd.Parameters.AddWithValue("@IFLTCG_20", IFLTCG_20);
                //cmd.Parameters.AddWithValue("@IFOS", IFOS);
                //cmd.Parameters.AddWithValue("@IFP_RH", IFP_RH);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@ITR", ITR);
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

        public int InsertDataDetailsGrid(denStoreTrans objStoreTransDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procInsertStoreTransdetailscursor", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@entry", objdenStoreTrans.EntryID);
                cmd.Parameters.AddWithValue("@nameID", objStoreTransDEN.NameID);
                cmd.Parameters.AddWithValue("@Vtype", objStoreTransDEN.Vtype);
                cmd.Parameters.AddWithValue("@mainID", objStoreTransDEN.MainID);
                cmd.Parameters.AddWithValue("@ConstantID", objStoreTransDEN.ConstID);
                cmd.Parameters.AddWithValue("@GridIndex", objStoreTransDEN.GIndex);
                //cmd.Parameters.AddWithValue("@Col3", objStoreTransDEN.Col3);
                cmd.Parameters.AddWithValue("@AY", objStoreTransDEN.AY);
                //cmd.Parameters.AddWithValue("@GRowNo", objStoreTransDEN.GRowNo);

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

        public denStoreTrans GetMainGridData(string strNameID, int intVtype, int intConstID, string mainID, string AY)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("proc_mainGridData", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", strNameID);
                cmd.Parameters.AddWithValue("@vtype", intVtype);
                cmd.Parameters.AddWithValue("@ConstID", intConstID);
                cmd.Parameters.AddWithValue("@mainID", mainID);
                cmd.Parameters.AddWithValue("@AY", AY);

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                objdenStoreTrans = new denStoreTrans();

                if (reader.Read())
                {
                    objdenStoreTrans.Col3 = Convert.ToString(reader["col3"]);
                }
                else
                    objdenStoreTrans.Col3 = "";
                return objdenStoreTrans;
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

        //To get the MainID for Master Pages that checks if already exists then get the maximum+1 else 1
        public string getMainID(string NameID, string VType)
        {
            string strLastMainID = "";
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"select distinct(case when MainID is not null or MainID != '' then (select (max(MainID)+1) from StoreTrans where NameID = @NameID and VType = @VType) else 1 end) from StoreTrans 
where NameID = @NameID and VType = @VType", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@VType", VType);
                strLastMainID = Convert.ToString(cmd.ExecuteScalar());
                if (strLastMainID == "")
                    strLastMainID = "1";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return strLastMainID;
        }

        public DataTable Select(string strNameID, int intVtype, int intConstID)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from storetrans where NameID=@NameID and vType=@vType and constantid=@ConstID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", strNameID);
                cmd.Parameters.AddWithValue("@vtype", intVtype);
                cmd.Parameters.AddWithValue("@ConstID", intConstID);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
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

        //To fetch all Required Listing for those which 
        public DataTable SelectRequired(string strNameID, string ITRType)
        {
            DataTable dt = new DataTable();
            try
            {
                //this.pConn();
                this.pConnMain();
                cmd = new SqlCommand("Proc_Check_Requird", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", strNameID);
                //cmd.Parameters.AddWithValue("@Vtype", Vtype);
                cmd.Parameters.AddWithValue("@ITRType", ITRType);
                cmd.Parameters.AddWithValue("@AY", HttpContext.Current.Session["AY"].ToString());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
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

        //Select Data from StoreTrans w.r.t. VType
        public DataTable SelectData_Vtype(string strNameID, string VType)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from storetrans where NameID=@NameID and vType=@vType", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", strNameID);
                cmd.Parameters.AddWithValue("@vtype", VType);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
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

        //Select Data from StoreTrans w.r.t. VType and C5
        public DataTable SelectData_Vtype_C5(string strNameID, string VType, string ComboItemNo)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from storetrans where NameID=@NameID and vType=@vType and ComboItemNo=@ComboItemNo", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", strNameID);
                cmd.Parameters.AddWithValue("@vtype", VType);
                cmd.Parameters.AddWithValue("@ComboItemNo", ComboItemNo);
                
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
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

        //Select Data from StoreTrans w.r.t. ConstantID
        public string SelectData_ConstID(string strNameID, string constantID)
        {
            string strData = "";
            try
            {
                this.pConn();
                cmd = new SqlCommand("select Col3 from storetrans where NameID=@NameID and constantID=@constantID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", strNameID);
                cmd.Parameters.AddWithValue("@constantID", constantID);
                strData = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return strData;
        }

        //nishu 4/8/2015
        public DataTable Selectcol3(string strNameID)
        {
            DataTable dtcol3 = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select ConstantID,col3 from storetrans where NameID=@NameID ", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", strNameID);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dtcol3);
                return dtcol3;
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

        public int ProcCalculationDtlsGrid(denStoreTrans objStoreTransDEN, Int32 IsFloat, string VType, Int16 HeaderID)
        {
            try
            {
                this.pConn();
                //Int16 HeaderID = 0;107
                if (HttpContext.Current.Session["Project"].ToString() == "stax" && VType == "5001")
                {
                    if (HttpContext.Current.Session["Status"].ToString() == "1" || HttpContext.Current.Session["Status"].ToString() == "2" || HttpContext.Current.Session["Status"].ToString() == "7")
                    {
                        if (HttpContext.Current.Session["RP"].ToString() == "April-September")
                            HeaderID = 116;
                        else
                            HeaderID = 117;
                    }
                    else
                    {
                        if (HttpContext.Current.Session["RP"].ToString() == "October-March")
                            HeaderID = 114;
                        else
                            HeaderID = 115;
                    }
                }

                cmd = new SqlCommand("proccalculation", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConstantID", objStoreTransDEN.ConstID);
                cmd.Parameters.AddWithValue("@fnYear", objStoreTransDEN.AY);
                cmd.Parameters.AddWithValue("@mainid", objStoreTransDEN.MainID);
                cmd.Parameters.AddWithValue("@vtype", objStoreTransDEN.Vtype);
                cmd.Parameters.AddWithValue("@gioNameid", objStoreTransDEN.NameID);
                cmd.Parameters.AddWithValue("@gridIndex", objStoreTransDEN.GIndex);
                cmd.Parameters.AddWithValue("@comboItemNo", objStoreTransDEN.ComboItemNo);
                //if (objStoreTransDEN.Vtype == 62)// || HttpContext.Current.Session["IsMaster"].ToString() == "2")
                //{
                    cmd.Parameters.AddWithValue("@gRowNo", objStoreTransDEN.GRowNo);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@gRowNo", -1);
                //}
                cmd.Parameters.AddWithValue("@bolMethod1", 1);
                cmd.Parameters.AddWithValue("@IsFloat", IsFloat);
                cmd.Parameters.AddWithValue("@IsEnterFDet", objStoreTransDEN.IsEnterFDet);

                cmd.Parameters.AddWithValue("@DueDate", objStoreTransDEN.DueDate);
                cmd.Parameters.AddWithValue("@HeaderID", HeaderID);
                cmd.ExecuteNonQuery();

                if (HttpContext.Current.Session["Project"].ToString() == "tds")
                {
                    cmd2 = new SqlCommand("procShowcalculation", this.SqlCon);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@gioNameID", objStoreTransDEN.NameID);
                    cmd2.Parameters.AddWithValue("@MainID", objStoreTransDEN.NameID);
                    cmd2.Parameters.AddWithValue("@VType", objStoreTransDEN.Vtype);
                    cmd2.Parameters.AddWithValue("@AYear", objStoreTransDEN.AY);
                    cmd2.Parameters.AddWithValue("@ConstantID", objStoreTransDEN.ConstID);
                    cmd2.Parameters.AddWithValue("@gIndex", objStoreTransDEN.GIndex);
                    cmd2.Parameters.AddWithValue("@AssType", objStoreTransDEN.AssesseeType);
                    cmd2.Parameters.AddWithValue("@ITRType", HttpContext.Current.Session["ITR"].ToString());
                    cmd2.Parameters.AddWithValue("@expNext", " ");
                    cmd2.ExecuteNonQuery();
                }

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

        public denStoreTrans GetSubGridData(string strNameID, int intVtype, int intConstID, int intSubConstID, string AY)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("proc_subGridData", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", strNameID);
                cmd.Parameters.AddWithValue("@vtype", intVtype);
                cmd.Parameters.AddWithValue("@ConstID", intConstID);
                cmd.Parameters.AddWithValue("@subConstID", intSubConstID);
                cmd.Parameters.AddWithValue("@AY", AY);

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                objdenStoreTrans = new denStoreTrans();
                while (reader.Read())
                {
                    objdenStoreTrans.Col3 = Convert.ToString(reader["col3"]);
                    objdenStoreTrans.col2 = Convert.ToString(reader["col2"]);
                }
                //else
                //{
                //    objdenStoreTrans.Amount=0;
                //}
                return objdenStoreTrans;
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

        public DataTable getFormulaT00(int intVtype, string AY)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("select * from t00 where c21=@AY and C29!='0' and c6=(select gridindex from ScreenSettings where VType=@vtype)", this.SqlCon);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@vtype", intVtype);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
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

        public void deleteUser(string NameID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("delete from storetrans where NameID = @NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("delete from storeftrans where NameID = @NameID", this.SqlCon);
                cmd2.Parameters.AddWithValue("@NameID", NameID);
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

        public void deleteUser_VType(string NameID, string VType)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("delete from storetrans where NameID = @NameID and VType = @VType", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@VType", VType);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("delete from storeftrans where NameID = @NameID and VType=@VType", this.SqlCon);
                cmd2.Parameters.AddWithValue("@NameID", NameID);
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

        //Function to fetch the distinct assessee and AY details from StoreTrans w.r.t username
        public DataSet SelectUserData(string username)
        {
            DataSet dsMain = new DataSet();
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("select distinct AY from StoreTrans where NameID in (select nameid from NameMast where username=@username)", this.SqlCon);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                //DataSet ds = new DataSet();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SqlCommand cmd2 = new SqlCommand("select distinct NameID,AY from StoreTrans where NameID in (select nameid from NameMast where username=@username) and AY=@AY", this.SqlCon);
                    cmd2.Parameters.AddWithValue("@username", username);
                    cmd2.Parameters.AddWithValue("@AY", dt.Rows[0]["AY"].ToString());
                    DataTable dt2 = new DataTable();
                    adp = new SqlDataAdapter(cmd2);
                    adp.Fill(dt2);
                    dsMain.Tables.Add(dt2);
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
            return dsMain;
        }

        //To get count of number of StoreTrans Records w.r.t. Assessee (NameID)
        public Int64 getDataCount(string strNameID)
        {
            Int64 cnt = 0;
            try
            {
                this.pConn();
                cmd = new SqlCommand("select count(*) from storetrans where NameID=@NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", strNameID);
                cnt = Convert.ToInt64(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return cnt;
        }

        //To get XML Data w.r.t. Assessee (NameID) from tbl_ITRXML
        public string getXMLData(string strNameID, string AY, string ITR)
        {
            string xmlData = "";
            try
            {
                this.pConn();
                cmd = new SqlCommand("select XML_Data from Tbl_ITRXML where NameID=@NameID and AY = @AY and ITRType=@ITR", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", strNameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@ITR", ITR);

                xmlData = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return xmlData;
        }
        //get Computational data for itr4 nishu 1/15/2016
        public DataTable getVtypeData(int[] Vtype, string AY, string RetType, string NameID)
        {

            DataTable dt = new DataTable();
            string strVtype = "";
            for (int i = 0; i < Vtype.Length; i++)
            {
                strVtype += Convert.ToInt32(Vtype[i]) + ",";
            }
            strVtype = strVtype.Remove(strVtype.Length - 1);

            try
            {
                this.pConn();
                cmd = new SqlCommand("select tt.C4 as Detail,ss.col3 as Amount from dbMain.dbo.T00 tt inner join StoreTrans ss on ss.ConstantID = tt.C1 where NameID = '" + NameID + "' and tt.c21='" + AY + "' and tt.ReturnType = '" + RetType + "' and ss.SubConstID = 0 and ss.vtype in (" + strVtype + ") and ss.AY='" + AY + "' order by C1", this.SqlCon);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@AY", AY);
                //cmd.Parameters.AddWithValue("@Vtype",strVtype);
                //cmd.Parameters.AddWithValue("@RetType", RetType);
                //cmd.Parameters.AddWithValue("@NameID", NameID);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
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

        public string getIndexedCost_Improvement(string FY_Improvement, string amtImprovement, string NameID, string AY, string ConstantID)
        {
            string indxAmt = "0";
            try
            {
                string DateOfSale = "";
                this.pConn();
                cmd = new SqlCommand("select Col3 from StoreTrans where ConstantID=@ConstantID and NameID=@NameID and AY = @AY", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@ITR", "4");
                cmd.Parameters.AddWithValue("@ConstantID", ConstantID);
                DateOfSale = Convert.ToString(cmd.ExecuteScalar());

                string FY_Sale = "";

                string[] arrDate = System.Text.RegularExpressions.Regex.Split(DateOfSale, "/");
                if (Convert.ToInt32(arrDate[1]) > 3)
                {
                    FY_Sale = arrDate[2] + "-" + (Convert.ToInt32(arrDate[2]) + 1).ToString();
                }
                else
                {
                    FY_Sale = (Convert.ToInt32(arrDate[2]) - 1).ToString() + "-" + arrDate[2];
                }

                //code to find the index cost for the Sale and Improvement Dates
                Decimal costIndx_Sale = 0;
                Decimal costIndx_Improvement = 0;

                SqlCommand cmd2 = new SqlCommand("select C6 from dbMain.dbo.T0 where C5=@C5", this.SqlCon);
                cmd2.Parameters.AddWithValue("@C5", FY_Sale);
                costIndx_Sale = Convert.ToDecimal(cmd2.ExecuteScalar());

                SqlCommand cmd3 = new SqlCommand("select C6 from dbMain.dbo.T0 where C5=@C5", this.SqlCon);
                cmd3.Parameters.AddWithValue("@C5", FY_Improvement);
                costIndx_Improvement = Convert.ToDecimal(cmd3.ExecuteScalar());

                indxAmt = (Math.Round(Convert.ToDecimal(amtImprovement) * (costIndx_Sale / costIndx_Improvement))).ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return indxAmt;
        }

        //To call all deduction eligible cases together
        public void setEligibleDeductions(string NameID, string AY, string mainID, string ITRType)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("proc_DeductionsAll", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@gioNameID", NameID);
                cmd.Parameters.AddWithValue("@AYear", AY);
                cmd.Parameters.AddWithValue("@mainid", mainID);
                cmd.Parameters.AddWithValue("@ITRType", ITRType);
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

        //Added By Mudit For TDS
        public denStoreTrans InsertChalanDetails(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("InsertChallanDetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TAN", objStoreTrans2DEO.TAN);
                cmd.Parameters.AddWithValue("@AY", objStoreTrans2DEO.AY);
                cmd.Parameters.AddWithValue("@Quarter", objStoreTrans2DEO.Quarter);
                cmd.Parameters.AddWithValue("@FormNo", objStoreTrans2DEO.FormNo);
                cmd.Parameters.AddWithValue("@Regular_Correction", objStoreTrans2DEO.RegularCorrection);
                cmd.Parameters.AddWithValue("@FY", objStoreTrans2DEO.FY);
                cmd.Parameters.AddWithValue("@NameID", objStoreTrans2DEO.NameID);
                cmd.Parameters.AddWithValue("@BookEntry", objStoreTrans2DEO.BookEntry);
                cmd.Parameters.AddWithValue("@Flag", objStoreTrans2DEO.Flag);
                cmd.Parameters.AddWithValue("@CID", objStoreTrans2DEO.ChallanID);
                //cmd.Parameters.AddWithValue("@RecordNo", objStoreTrans2DEO.RecordNo);
                
                cmd.ExecuteNonQuery();
                return objdenStoreTrans;
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

        public denStoreTrans InsertDeducteeDetails(denStoreTrans objStoreTrans2DEO, string DeducteeID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("InsertDeducteeDetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TAN", objStoreTrans2DEO.TAN);
                cmd.Parameters.AddWithValue("@AY", objStoreTrans2DEO.AY);
                cmd.Parameters.AddWithValue("@Quarter", objStoreTrans2DEO.Quarter);
                cmd.Parameters.AddWithValue("@FormNo", objStoreTrans2DEO.FormNo);
                cmd.Parameters.AddWithValue("@Regular_Correction", objStoreTrans2DEO.RegularCorrection);
                cmd.Parameters.AddWithValue("@EmployeePAN", objStoreTrans2DEO.PAN);
                cmd.Parameters.AddWithValue("@ID", objStoreTrans2DEO.ChallanID);
                cmd.Parameters.AddWithValue("@FY", objStoreTrans2DEO.FY);
                cmd.Parameters.AddWithValue("@NameID", objStoreTrans2DEO.NameID);
                cmd.Parameters.AddWithValue("@FlagUpdate", objStoreTrans2DEO.Flag);
                cmd.Parameters.AddWithValue("@DID", DeducteeID);
                cmd.ExecuteNonQuery();
                return objdenStoreTrans;
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
        public denStoreTrans InsertSalaryDetails(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("InsertSalaryDetails", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TAN", objStoreTrans2DEO.TAN);
                cmd.Parameters.AddWithValue("@AY", objStoreTrans2DEO.AY);
                cmd.Parameters.AddWithValue("@Quarter", objStoreTrans2DEO.Quarter);
                cmd.Parameters.AddWithValue("@FormNo", objStoreTrans2DEO.FormNo);
                cmd.Parameters.AddWithValue("@Regular_Correction", objStoreTrans2DEO.RegularCorrection);
                cmd.Parameters.AddWithValue("@FY", objStoreTrans2DEO.FY);
                cmd.Parameters.AddWithValue("@NameID", objStoreTrans2DEO.NameID);
                cmd.Parameters.AddWithValue("@Flag", objStoreTrans2DEO.Flag);
                cmd.Parameters.AddWithValue("@SalaryID", (objStoreTrans2DEO.SalaryID == null ? 0 : objStoreTrans2DEO.SalaryID));
                cmd.ExecuteNonQuery();
                return objdenStoreTrans;
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
        //Following function is to fetch the data against a particular Challan on selection from the listing:
        public denStoreTrans InsertTransData(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("ProcSendTransData", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@TAN", objStoreTrans2DEO.TAN);
                cmd.Parameters.AddWithValue("@AY", objStoreTrans2DEO.AY);
                //cmd.Parameters.AddWithValue("@Quarter", objStoreTrans2DEO.Quarter);
                //cmd.Parameters.AddWithValue("@FormNo", objStoreTrans2DEO.FormNo);
                //cmd.Parameters.AddWithValue("@Regular_Correction", objStoreTrans2DEO.RegularCorrection);
                //cmd.Parameters.AddWithValue("@EmployeePAN", objStoreTrans2DEO.PAN);
                //cmd.Parameters.AddWithValue("@ID", objStoreTrans2DEO.ChallanID);
                cmd.Parameters.AddWithValue("@VType", objStoreTrans2DEO.Vtype);
                cmd.Parameters.AddWithValue("@NameID", objStoreTrans2DEO.NameID);
                //cmd.Parameters.AddWithValue("@FlagUpdate", objStoreTrans2DEO.Flag);
                //cmd.Parameters.AddWithValue("@DID", DeducteeID);
                cmd.ExecuteNonQuery();
                return objdenStoreTrans;
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
        public denStoreTrans ReverseChallanDetails(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                int BookEntry = 0;
                this.pConn();
                cmd = new SqlCommand("Proc_TDS_ChallanReverse", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TAN", objStoreTrans2DEO.TAN);
                cmd.Parameters.AddWithValue("@AY", objStoreTrans2DEO.AY);
                cmd.Parameters.AddWithValue("@Quarter", objStoreTrans2DEO.Quarter);
                cmd.Parameters.AddWithValue("@FormNo", objStoreTrans2DEO.FormNo);
                cmd.Parameters.AddWithValue("@Regular_Correction", objStoreTrans2DEO.RegularCorrection);
                cmd.Parameters.AddWithValue("@ChallanID", objStoreTrans2DEO.ChallanID);
                cmd.Parameters.AddWithValue("@FY", objStoreTrans2DEO.FY);
                cmd.Parameters.AddWithValue("@nameid", objStoreTrans2DEO.NameID);
                cmd.Parameters.Add("@Book", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                if (Convert.IsDBNull(cmd.Parameters["@Book"].Value))
                    BookEntry = 0;
                else
                    BookEntry = Convert.ToInt16(cmd.Parameters["@Book"].Value);
                HttpContext.Current.Session["BookEntry"] = BookEntry;
                return objdenStoreTrans;
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

        //Following function is to fetch the data against a particular Deductee on selection from the listing:
        public denStoreTrans ReverseDeducteeDetails(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("Proc_TDS_DeducteeReverse", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TAN", objStoreTrans2DEO.TAN);
                cmd.Parameters.AddWithValue("@AY", objStoreTrans2DEO.AY);
                cmd.Parameters.AddWithValue("@Quarter", objStoreTrans2DEO.Quarter);
                cmd.Parameters.AddWithValue("@FormNo", objStoreTrans2DEO.FormNo);
                cmd.Parameters.AddWithValue("@Regular_Correction", objStoreTrans2DEO.RegularCorrection);
                cmd.Parameters.AddWithValue("@ChallanID", objStoreTrans2DEO.ChallanID);
                cmd.Parameters.AddWithValue("@FY", objStoreTrans2DEO.FY);
                cmd.Parameters.AddWithValue("@nameid", objStoreTrans2DEO.NameID);
                cmd.Parameters.AddWithValue("@DeducteeID", (objStoreTrans2DEO.DeducteeID == null) ? 0 : objStoreTrans2DEO.DeducteeID);
                cmd.ExecuteNonQuery();
                return objdenStoreTrans;
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

        //Following function is to fetch the data against a particular Salary on selection from the listing:
        public denStoreTrans ReverseSalaryDetails(denStoreTrans objStoreTrans2DEO)
        {
            try
            {
                this.pConn();
                //cmd = new SqlCommand("Proc_TDS_SalaryReverse", this.SqlCon);
                cmd = new SqlCommand("Proc_TDS_SalaryReverse2", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TAN", objStoreTrans2DEO.TAN);
                cmd.Parameters.AddWithValue("@AY", objStoreTrans2DEO.AY);
                cmd.Parameters.AddWithValue("@Quarter", objStoreTrans2DEO.Quarter);
                cmd.Parameters.AddWithValue("@FormNo", objStoreTrans2DEO.FormNo);
                cmd.Parameters.AddWithValue("@Regular_Correction", objStoreTrans2DEO.RegularCorrection);
                cmd.Parameters.AddWithValue("@FY", objStoreTrans2DEO.FY);
                cmd.Parameters.AddWithValue("@nameid", objStoreTrans2DEO.NameID);
                cmd.Parameters.AddWithValue("@SalID", objStoreTrans2DEO.DeducteeID);
                cmd.ExecuteNonQuery();
                return objdenStoreTrans;
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


        public DataTable getComboListData(denStoreTrans objStoreTrans2DEO, string Project)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnAdmin();
                cmd = new SqlCommand("proc_getMainComboData", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@project", Project);
                cmd.Parameters.AddWithValue("@VType", objStoreTrans2DEO.Vtype);

                cmd.Parameters.AddWithValue("@TAN", objStoreTrans2DEO.TAN);
                cmd.Parameters.AddWithValue("@Qtr", objStoreTrans2DEO.Quarter);
                cmd.Parameters.AddWithValue("@FormNo", objStoreTrans2DEO.FormNo);
                cmd.Parameters.AddWithValue("@FY", objStoreTrans2DEO.FY);
                cmd.Parameters.AddWithValue("@RegularCorrection", objStoreTrans2DEO.RegularCorrection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
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

        public DataTable TDSCalculation(denStoreTrans objStoreTrans2DEO, string Project)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("ProcCalcTDS", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@project", Project);
                cmd.Parameters.AddWithValue("@NameID", objStoreTrans2DEO.NameID);

                cmd.Parameters.AddWithValue("@AY", objStoreTrans2DEO.AY);
                cmd.Parameters.AddWithValue("@FY", objStoreTrans2DEO.FY);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
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


        //Function to Get the ID From Master Table
        public int GetIDFromMaster(denStoreTrans objdenStoreTrans)
        {
            int ID = 0;
            try
            {
                this.pConn();
                cmd = new SqlCommand("Select ID From tbl_Master where TAN=@TAN and FY=@FY and Quarter=@Quarter and FormNo=@FormNo and Regular_Correction=@Regular_Correction", this.SqlCon);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TAN", objdenStoreTrans.TAN);
                cmd.Parameters.AddWithValue("@FY", objdenStoreTrans.FY.Replace("-20", ""));

                cmd.Parameters.AddWithValue("@Quarter", objdenStoreTrans.Quarter);
                cmd.Parameters.AddWithValue("@FormNo", objdenStoreTrans.FormNo);
                cmd.Parameters.AddWithValue("@Regular_Correction", objdenStoreTrans.RegularCorrection);
                //SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //adp.Fill(dt);
                ID = Convert.ToInt32(cmd.ExecuteScalar());
                return ID;
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
        //Function Added By Mudit on 24/08/2015 To fetch ChallansDetails based on ChallanID and MasterID
        public DataTable GetTDSChallanDetails(int MasterID, int ChallanID, denStoreTrans objdenstoretrans)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                if (objdenstoretrans.RegularCorrection == "Regular")
                    cmd = new SqlCommand("select Bank_Branch_Code,Cheque_DD_No,TotalDepositeAmount,(select Sum(Total_TaxDeposited) from tbl_DeducteeDetail_Record where MasterID=@MasterID and ID=@ChallanID) as ConsumedAmt from tbl_ChallanTransferVoucherDetail where ID=@MasterID and ChallanID=@ChallanID", this.SqlCon);
                else if (objdenstoretrans.RegularCorrection == "Correction")
                    cmd = new SqlCommand("select Bank_Branch_Code,Cheque_DD_No,TotalDepositeAmount from tbl_ChallanTransferVoucherDetail_Correction where ID=@MasterID and ChallanID=@ChallanID", this.SqlCon);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MasterID", MasterID);
                cmd.Parameters.AddWithValue("@ChallanID", ChallanID);

                //cmd.Parameters.AddWithValue("@Quarter", objdenStoreTrans.Quarter);
                //cmd.Parameters.AddWithValue("@FormNo", objdenStoreTrans.FormNo);
                //cmd.Parameters.AddWithValue("@Regular_Correction", objdenStoreTrans.RegularCorrection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                //ID = Convert.ToInt32(cmd.ExecuteScalar());
                return dt;
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

        //Function To insert Specific Rules For TDS
        public void InsertTDSSpecificRules(int Vtype, string AY, string NameID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procSpecificRulesForTDS", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vtype", Vtype);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@NameID", NameID);
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

        //To generate and add Unique Identification Number (In case of Form15G and Form15H)
        public void saveUniqueIndentificationNo(string NameID, string AY, string ITRType)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("Proc_Save_UniqueIdNumber", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nameid", NameID);
                cmd.Parameters.AddWithValue("@ay", AY);
                cmd.Parameters.AddWithValue("@itr", ITRType);
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
    }
}
