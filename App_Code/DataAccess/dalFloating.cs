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
using System.Collections.Generic;
using Taxation.DataEntity;

/// <summary>
/// Summary description for dalFloating
/// </summary>
/// 
namespace Taxation.DataAccess
{
    public class dalFloating:dalConnection
    {
        #region variables
        SqlCommand cmd;
        
        #endregion

        #region Constructors
        public dalFloating()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Functions

        #region Function GetFloatHeaders
        public List<denFloating> GetFloatHeaders(string strnameID,int intC16,int intconstID, string mainID)
        {
            try
            {
                string RP = (HttpContext.Current.Session["RP"] != null) ? HttpContext.Current.Session["RP"].ToString() : "";
                List<denFloating> genFloatingDEO = new List<denFloating>();
                int count;
                this.pConn();
                cmd = new SqlCommand("procgetfloatingheaders", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameID", strnameID);
                cmd.Parameters.AddWithValue("@headerID", intC16);
                cmd.Parameters.AddWithValue("@ConstID", intconstID);
                cmd.Parameters.AddWithValue("@mainID", mainID);
                
                cmd.Parameters.AddWithValue("@returnPeriod", RP);
                
                cmd.Parameters.Add("@Out", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                count = Convert.ToInt32(cmd.Parameters["@Out"].Value);
                //count=Convert.ToInt32(cmd.ExecuteScalar());

                //DataTable dt = new DataTable();
                //SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //adp.Fill(dt);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    denFloating objFloatingDEO = new denFloating();
                                        
                    objFloatingDEO.C1 = Convert.ToString(reader["C1"]);
                    objFloatingDEO.C2 = Convert.ToString(reader["C2"]);
                    objFloatingDEO.C3 = Convert.ToString(reader["C3"]);
                    objFloatingDEO.C4 = Convert.ToString(reader["C4"]);
                    objFloatingDEO.C5 = Convert.ToString(reader["C5"]);
                    objFloatingDEO.C6 = Convert.ToString(reader["C6"]);
                    objFloatingDEO.C7 = Convert.ToString(reader["C7"]);
                    objFloatingDEO.C8 = Convert.ToString(reader["C8"]);
                    objFloatingDEO.C9 = Convert.ToString(reader["C9"]);
                    objFloatingDEO.C10 = Convert.ToString(reader["C10"]);
                    objFloatingDEO.C11 = Convert.ToString(reader["C11"]);
                    objFloatingDEO.C12 = Convert.ToString(reader["C12"]);
                    objFloatingDEO.C13 = Convert.ToString(reader["C13"]);
                    objFloatingDEO.C14 = Convert.ToString(reader["C14"]);
                    objFloatingDEO.C15 = Convert.ToString(reader["C15"]);
                    objFloatingDEO.C16 = Convert.ToString(reader["C16"]);
                    objFloatingDEO.C17 = Convert.ToString(reader["C17"]);
                    objFloatingDEO.C18 = Convert.ToString(reader["C18"]);
                    objFloatingDEO.C19 = Convert.ToString(reader["C19"]);
                    objFloatingDEO.C20 = Convert.ToString(reader["C20"]);
                    objFloatingDEO.C21 = Convert.ToString(reader["C21"]);
                    objFloatingDEO.C22 = Convert.ToString(reader["C22"]);
                    objFloatingDEO.C23 = Convert.ToString(reader["C23"]);
                    objFloatingDEO.C24 = Convert.ToString(reader["C24"]);
                    objFloatingDEO.C25 = Convert.ToString(reader["C25"]);
                    objFloatingDEO.C26 = Convert.ToString(reader["C26"]);
                    objFloatingDEO.C27 = Convert.ToString(reader["C27"]);
                    objFloatingDEO.C28 = Convert.ToString(reader["C28"]);

                    if (count != 0)
                    {
                        if (reader["NameID"] == null)
                            objFloatingDEO.NameID = "0";
                        else
                            objFloatingDEO.NameID = Convert.ToString(reader["NameID"]);
                        if (reader["HeaderID"] == null)
                            objFloatingDEO.HeaderID = "0";
                        else
                            objFloatingDEO.HeaderID = Convert.ToString(reader["HeaderID"]);
                        if (reader["Vtype"] == null)
                            objFloatingDEO.Vtype = "0";
                        else
                            objFloatingDEO.Vtype = Convert.ToString(reader["Vtype"]);
                        if (reader["GOrder"] == null)
                            objFloatingDEO.Gorder = "0";
                        else
                            objFloatingDEO.Gorder = Convert.ToString(reader["GOrder"]);
                        if (reader["ConstantID"] == null)
                            objFloatingDEO.ConstID = "0";
                        else
                            objFloatingDEO.ConstID = Convert.ToString(reader["ConstantID"]);
                        if (reader["Col2"] == null)
                            objFloatingDEO.Col2 = "0";
                        else
                            objFloatingDEO.Col2 = Convert.ToString(reader["Col2"]);
                        if (reader["Col3"] == null)
                            objFloatingDEO.Col3 = "0";
                        else
                            objFloatingDEO.Col3 = Convert.ToString(reader["Col3"]);
                        if (reader["Col4"] == null)
                            objFloatingDEO.Col4 = "0";
                        else
                            objFloatingDEO.Col4 = Convert.ToString(reader["Col4"]);
                        if (reader["Col5"] == null)
                            objFloatingDEO.Col5 = "0";
                        else
                            objFloatingDEO.Col5 = Convert.ToString(reader["Col5"]);
                        if (reader["Col6"] == null)
                            objFloatingDEO.Col6 = "0";
                        else
                            objFloatingDEO.Col6 = Convert.ToString(reader["Col6"]);
                        if (reader["Col7"] == null)
                            objFloatingDEO.Col7 = "0";
                        else
                            objFloatingDEO.Col7 = Convert.ToString(reader["Col7"]);
                        if (reader["Col8"] == null)
                            objFloatingDEO.Col8 = "0";
                        else
                            objFloatingDEO.Col8 = Convert.ToString(reader["Col8"]);
                        if (reader["Col9"] == null)
                            objFloatingDEO.Col9 = "0";
                        else
                            objFloatingDEO.Col9 = Convert.ToString(reader["Col9"]);
                        if (reader["Col10"] == null)
                            objFloatingDEO.Col10 = "0";
                        else
                            objFloatingDEO.Col10 = Convert.ToString(reader["Col10"]);
                        if (reader["Col11"] == null)
                            objFloatingDEO.Col11 = "0";
                        else
                            objFloatingDEO.Col11 = Convert.ToString(reader["Col11"]);
                        if (reader["Col12"] == null)
                            objFloatingDEO.Col12 = "0";
                        else
                            objFloatingDEO.Col12 = Convert.ToString(reader["Col12"]);
                        if (reader["Col13"] == null)
                            objFloatingDEO.Col13 = "0";
                        else
                            objFloatingDEO.Col13 = Convert.ToString(reader["Col13"]);
                        if (reader["Col14"] == null)
                            objFloatingDEO.Col14 = "0";
                        else
                            objFloatingDEO.Col14 = Convert.ToString(reader["Col14"]);
                        if (reader["Col15"] == null)
                            objFloatingDEO.Col15 = "0";
                        else
                            objFloatingDEO.Col15 = Convert.ToString(reader["Col15"]);
                        if (reader["Col16"] == null)
                            objFloatingDEO.Col16 = "0";
                        else
                            objFloatingDEO.Col16 = Convert.ToString(reader["Col16"]);
                        if (reader["Col17"] == null)
                            objFloatingDEO.Col17 = "0";
                        else
                            objFloatingDEO.Col17 = Convert.ToString(reader["Col17"]);
                        if (reader["Col18"] == null)
                            objFloatingDEO.Col18 = "0";
                        else
                            objFloatingDEO.Col18 = Convert.ToString(reader["Col18"]);
                        if (reader["Col19"] == null)
                            objFloatingDEO.Col19 = "0";
                        else
                            objFloatingDEO.Col19 = Convert.ToString(reader["Col19"]);
                        if (reader["Col20"] == null)
                            objFloatingDEO.Col20 = "0";
                        else
                            objFloatingDEO.Col20 = Convert.ToString(reader["Col20"]);
                        if (reader["Col21"] == null)
                            objFloatingDEO.Col21 = "0";
                        else
                            objFloatingDEO.Col21 = Convert.ToString(reader["Col21"]);
                        if (reader["Col22"] == null)
                            objFloatingDEO.Col22 = "0";
                        else
                            objFloatingDEO.Col22 = Convert.ToString(reader["Col22"]);
                        if (reader["Col23"] == null)
                            objFloatingDEO.Col23 = "0";
                        else
                            objFloatingDEO.Col23 = Convert.ToString(reader["Col23"]);
                        if (reader["Col24"] == null)
                            objFloatingDEO.Col24 = "0";
                        else
                            objFloatingDEO.Col24 = Convert.ToString(reader["Col24"]);
                        if (reader["Col25"] == null)
                            objFloatingDEO.Col25 = "0";
                        else
                            objFloatingDEO.Col25 = Convert.ToString(reader["Col25"]);
                        if (reader["Col26"] == null)
                            objFloatingDEO.Col26 = "0";
                        else
                            objFloatingDEO.Col26 = Convert.ToString(reader["Col26"]);
                        if (reader["Col27"] == null)
                            objFloatingDEO.Col27 = "0";
                        else
                            objFloatingDEO.Col27 = Convert.ToString(reader["Col27"]);


                        //if (reader["DropDownColumns"] == null)
                        //    objFloatingDEO.DropDownColumns = "0";
                        //else
                        //    objFloatingDEO.DropDownColumns = Convert.ToString(reader["DropDownColumns"]);

                        //if (reader["DropdownQry"] == null)
                        //    objFloatingDEO.DropdownQry = "0";
                        //else
                        //    objFloatingDEO.DropdownQry = Convert.ToString(reader["DropdownQry"]);

                        //if (reader["ValidationColumns"] == null)
                        //    objFloatingDEO.ValidationColumns = "0";
                        //else
                        //    objFloatingDEO.ValidationColumns = Convert.ToString(reader["ValidationColumns"]);
                        //if (reader["Validation"] == null)
                        //    objFloatingDEO.Validation = "0";
                        //else
                        //    objFloatingDEO.Validation = Convert.ToString(reader["Validation"]);

                        //if (reader["ValidationString"] == null)
                        //    objFloatingDEO.ValidationString = "0";
                        //else
                        //    objFloatingDEO.ValidationString = Convert.ToString(reader["ValidationString"]);

                        //if (reader["ddText"] == null)
                        //    objFloatingDEO.ddText = "0";
                        //else
                        //    objFloatingDEO.ddText = Convert.ToString(reader["ddText"]);

                        //if (reader["ddVal"] == null)
                        //    objFloatingDEO.ddVal = "0";
                        //else
                        //    objFloatingDEO.ddVal = Convert.ToString(reader["ddVal"]);
                        //if (reader["status"] == null)
                        //    objFloatingDEO.status = false;
                        //else
                        //    objFloatingDEO.status = Convert.ToBoolean(reader["status"]);

                        objFloatingDEO.DropDownColumns = "0";
                        objFloatingDEO.DropdownQry = "0";
                        objFloatingDEO.ddVal = "0";
                        objFloatingDEO.ddText = "0";
                        objFloatingDEO.Validation = "0";
                        objFloatingDEO.ValidationColumns = "0";
                        objFloatingDEO.ValidationString = "0";
                        objFloatingDEO.status = false;
                    }
                    else
                    {
                        objFloatingDEO.NameID = "0";
                        objFloatingDEO.HeaderID = "0";
                        objFloatingDEO.Vtype = "0";
                        objFloatingDEO.Gorder = "0";
                        objFloatingDEO.ConstID = "0";
                        objFloatingDEO.Col2 = "0";
                        objFloatingDEO.Col3 = "0";
                        objFloatingDEO.Col4 = "0";
                        objFloatingDEO.Col5 = "0";
                        objFloatingDEO.Col6 = "0";
                        objFloatingDEO.Col7 = "0";
                        objFloatingDEO.Col8 = "0";
                        objFloatingDEO.Col9 = "0";
                        objFloatingDEO.Col10 = "0";
                        objFloatingDEO.Col11 = "0";
                        objFloatingDEO.Col12 = "0";
                        objFloatingDEO.Col13 = "0";
                        objFloatingDEO.Col14 = "0";
                        objFloatingDEO.Col15 = "0";
                        objFloatingDEO.Col16 = "0";
                        objFloatingDEO.Col17 = "0";
                        objFloatingDEO.Col18 = "0";
                        objFloatingDEO.Col19 = "0";
                        objFloatingDEO.Col20 = "0";
                        objFloatingDEO.Col21 = "0";
                        objFloatingDEO.Col22 = "0";
                        objFloatingDEO.Col23 = "0";
                        objFloatingDEO.Col24 = "0";
                        objFloatingDEO.Col25 = "0";
                        objFloatingDEO.Col26 = "0";
                        objFloatingDEO.Col27 = "0";

                        objFloatingDEO.DropDownColumns = "0";
                        objFloatingDEO.DropdownQry = "0";
                        objFloatingDEO.ddVal = "0";
                        objFloatingDEO.ddText = "0";
                        objFloatingDEO.Validation = "0";
                        objFloatingDEO.ValidationColumns = "0";
                        objFloatingDEO.ValidationString = "0";
                        objFloatingDEO.status = false;
                    }
                    genFloatingDEO.Add(objFloatingDEO);
                }
                return genFloatingDEO;
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

        #region Function InsertFloatGridData

        public int InsertFloatGridData(denFloating objFloatingDEO)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procinsertfloatgriddata", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objFloatingDEO.NameID);
                cmd.Parameters.AddWithValue("@Vtype", objFloatingDEO.Vtype);
                //cmd.Parameters.AddWithValue("@Gorder", objFloatingDEO.Gorder);
                cmd.Parameters.AddWithValue("@ConstantID", objFloatingDEO.ConstID);
                cmd.Parameters.AddWithValue("@HeaderID", objFloatingDEO.HeaderID);
                cmd.Parameters.AddWithValue("@AY", objFloatingDEO.AY);
                cmd.Parameters.AddWithValue("@MainId", objFloatingDEO.MainId);

                if (objFloatingDEO.Col2 == null)
                    cmd.Parameters.AddWithValue("@col2", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col2", objFloatingDEO.Col2);

                if (objFloatingDEO.Col3 == null)
                    cmd.Parameters.AddWithValue("@col3", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col3", objFloatingDEO.Col3);

                if (objFloatingDEO.Col4 == null)
                    cmd.Parameters.AddWithValue("@col4", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col4", objFloatingDEO.Col4);
                if (objFloatingDEO.Col5 == null)
                    cmd.Parameters.AddWithValue("@col5", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col5", objFloatingDEO.Col5);

                if (objFloatingDEO.Col6 == null)
                    cmd.Parameters.AddWithValue("@col6", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col6", objFloatingDEO.Col6);
                if (objFloatingDEO.Col7 == null)
                    cmd.Parameters.AddWithValue("@col7", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col7", objFloatingDEO.Col7);
                if (objFloatingDEO.Col8 == null)
                    cmd.Parameters.AddWithValue("@col8", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col8", objFloatingDEO.Col8);
                if (objFloatingDEO.Col9 == null)
                    cmd.Parameters.AddWithValue("@col9", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col9", objFloatingDEO.Col9);
                if (objFloatingDEO.Col10 == null)
                    cmd.Parameters.AddWithValue("@col10", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col10", objFloatingDEO.Col10);
                if (objFloatingDEO.Col11 == null)
                    cmd.Parameters.AddWithValue("@col11", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col11", objFloatingDEO.Col11);
                if (objFloatingDEO.Col12 == null)
                    cmd.Parameters.AddWithValue("@col12", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col12", objFloatingDEO.Col12);
                if (objFloatingDEO.Col13 == null)
                    cmd.Parameters.AddWithValue("@col13", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col13", objFloatingDEO.Col13);
                if (objFloatingDEO.Col14 == null)
                    cmd.Parameters.AddWithValue("@col14", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col14", objFloatingDEO.Col14);
                if (objFloatingDEO.Col15 == null)
                    cmd.Parameters.AddWithValue("@col15", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col15", objFloatingDEO.Col15);
                if (objFloatingDEO.Col16 == null)
                    cmd.Parameters.AddWithValue("@col16", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col16", objFloatingDEO.Col16);
                if (objFloatingDEO.Col17 == null)
                    cmd.Parameters.AddWithValue("@col17", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col17", objFloatingDEO.Col17);
                if (objFloatingDEO.Col18 == null)
                    cmd.Parameters.AddWithValue("@col18", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col18", objFloatingDEO.Col18);
                if (objFloatingDEO.Col19 == null)
                    cmd.Parameters.AddWithValue("@col19", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col19", objFloatingDEO.Col19);
                if (objFloatingDEO.Col20 == null)
                    cmd.Parameters.AddWithValue("@col20", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col20", objFloatingDEO.Col20);
                if (objFloatingDEO.Col21 == null)
                    cmd.Parameters.AddWithValue("@col21", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col21", objFloatingDEO.Col21);
                if (objFloatingDEO.Col22 == null)
                    cmd.Parameters.AddWithValue("@col22", "NIL");
                else
                    cmd.Parameters.AddWithValue("@col22", objFloatingDEO.Col22);

                if (objFloatingDEO.Col23 == null)
                    cmd.Parameters.AddWithValue("@col23", "NIL");
                else

                    cmd.Parameters.AddWithValue("@col23", objFloatingDEO.Col23);
                if (objFloatingDEO.Col24 == null)
                    cmd.Parameters.AddWithValue("@col24", "NIL");
                else

                    cmd.Parameters.AddWithValue("@col24", objFloatingDEO.Col24);
                if (objFloatingDEO.Col25 == null)
                    cmd.Parameters.AddWithValue("@col25", "NIL");
                else

                    cmd.Parameters.AddWithValue("@col25", objFloatingDEO.Col25);
                if (objFloatingDEO.Col26 == null)
                    cmd.Parameters.AddWithValue("@col26", "NIL");
                else

                    cmd.Parameters.AddWithValue("@col26", objFloatingDEO.Col26);
                if (objFloatingDEO.Col27 == null)
                    cmd.Parameters.AddWithValue("@col27", "NIL");
                else

                    cmd.Parameters.AddWithValue("@col27", objFloatingDEO.Col27);

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

        public void Delete(denFloating objFloatingDEO)
        {

            try
            {
                this.pConn();
                cmd = new SqlCommand("delete from storeftrans where NameID=@NameID and Vtype=@Vtype and ConstantID=@ConstantID and HeaderID=@HeaderID and GOrder=@GOrder", this.SqlCon);
                
                cmd.Parameters.AddWithValue("@NameID", objFloatingDEO.NameID);
                cmd.Parameters.AddWithValue("@Vtype", objFloatingDEO.Vtype);
                cmd.Parameters.AddWithValue("@Gorder", objFloatingDEO.Gorder);
                cmd.Parameters.AddWithValue("@ConstantID", objFloatingDEO.ConstID);
                cmd.Parameters.AddWithValue("@HeaderID", objFloatingDEO.HeaderID);

                if (objFloatingDEO.Col2 == null)
               

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

        public void InsertFloatManagedData(denFloating objFloatingDEO)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("proc_FloatDataManager", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objFloatingDEO.NameID);
                cmd.Parameters.AddWithValue("@HeaderID", objFloatingDEO.HeaderID);
                cmd.Parameters.AddWithValue("@AY", objFloatingDEO.AY);
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

        public int getTabCnt(string VType, string AY)
        {
            int cnt = 0;
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("select count(*) from Combo_Master_Values where vtype = @vtype and AY=@AY", this.SqlCon);
                cmd.Parameters.AddWithValue("@vtype", VType);
                cmd.Parameters.AddWithValue("@AY", AY);
                cnt = Convert.ToInt32(cmd.ExecuteScalar());
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

        public string IsFloatSec(int H1)
        {
            string IsSec = "";
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("select (case when Row_Count is NULL then 0 else Row_Count end) as Row_Count from t1000 where H1=@H1", this.SqlCon);
                cmd.Parameters.AddWithValue("@H1", H1);
                int cnt = Convert.ToInt32(cmd.ExecuteScalar());
                SqlCommand cmd2 = new SqlCommand("select count(*) from T1000_Sec where H1=@H1", this.SqlCon);
                cmd2.Parameters.AddWithValue("@H1", H1);
                int cnt2 = Convert.ToInt32(cmd2.ExecuteScalar());
                IsSec = cnt.ToString() + "~" + cnt2.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return IsSec;
        }

        public DataTable SelectT1000_Rules(int H1,string AY,string ITR)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConnMain();
                cmd = new SqlCommand("select ValidationColumns, Validation, ValidationString from T1000_rules where t1000_h1 = @H1 and AY=@AY and ITRType=@ITR order by ValidationColumns", this.SqlCon);
                
                cmd.Parameters.AddWithValue("@H1", H1);
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
        public DataTable SelectFloatData( string AY,string NameID,int CID)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand("select * from StoreFTrans where NameID=@NameID and ConstantID=@ConstantID and AY=@AY order by GOrder  ", this.SqlCon);

                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@ConstantID", CID);
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

        #region function CheckFloatGridData
        public int CheckFloatGridData(denFloating objFloatingDEO)
        {
            try
            {
                int i;
                this.pConn();
                cmd = new SqlCommand("proccheckfloatdata",this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objFloatingDEO.NameID);
                cmd.Parameters.AddWithValue("@HeaderID", objFloatingDEO.HeaderID);
                cmd.Parameters.AddWithValue("@Vtype", objFloatingDEO.Vtype);
                cmd.Parameters.AddWithValue("@Gorder", objFloatingDEO.Gorder);
                cmd.Parameters.AddWithValue("@ConstID", objFloatingDEO.ConstID);
                cmd.Parameters.AddWithValue("@mainID", objFloatingDEO.MainId);
                i = Convert.ToInt32(cmd.ExecuteScalar());
                return i;
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
        #region Function UpdateFloatGridData
        public int UpdateFloatGridData(denFloating objFloatingDEO)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procupdatefloatdata", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameID", objFloatingDEO.NameID);
                cmd.Parameters.AddWithValue("@Vtype", objFloatingDEO.Vtype);
                cmd.Parameters.AddWithValue("@Gorder", objFloatingDEO.Gorder);
                cmd.Parameters.AddWithValue("@ConstID", objFloatingDEO.ConstID);
                cmd.Parameters.AddWithValue("@HeaderID", objFloatingDEO.HeaderID);
                cmd.Parameters.AddWithValue("@Number", objFloatingDEO.Number);
                cmd.Parameters.AddWithValue("@Col_Main", objFloatingDEO.ColMain);
                cmd.Parameters.AddWithValue("@MainID", objFloatingDEO.MainId);

                //if (objFloatingDEO.Number == 2)
                //    cmd.Parameters.AddWithValue("@col2", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 3)
                //    cmd.Parameters.AddWithValue("@c1ol3", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 4)
                //    cmd.Parameters.AddWithValue("@col4", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 5)
                //    cmd.Parameters.AddWithValue("@col5", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 6)
                //    cmd.Parameters.AddWithValue("@col6", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 7)
                //    cmd.Parameters.AddWithValue("@col7", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 8)
                //    cmd.Parameters.AddWithValue("@col8", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 9)
                //    cmd.Parameters.AddWithValue("@col9", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 10)
                //    cmd.Parameters.AddWithValue("@col10", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 11)
                //    cmd.Parameters.AddWithValue("@col11", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 12)
                //    cmd.Parameters.AddWithValue("@col12", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 13)
                //    cmd.Parameters.AddWithValue("@col13", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 14)
                //    cmd.Parameters.AddWithValue("@col14", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 15)
                //    cmd.Parameters.AddWithValue("@col15", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 16)
                //    cmd.Parameters.AddWithValue("@col16", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 17)
                //    cmd.Parameters.AddWithValue("@col17", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 18)
                //    cmd.Parameters.AddWithValue("@col18", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 19)
                //    cmd.Parameters.AddWithValue("@col19", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 20)
                //    cmd.Parameters.AddWithValue("@col20", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 21)
                //    cmd.Parameters.AddWithValue("@col21", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 22)
                //    cmd.Parameters.AddWithValue("@col22", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 23)
                //    cmd.Parameters.AddWithValue("@col23", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 24)
                //    cmd.Parameters.AddWithValue("@col24", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 25)
                //    cmd.Parameters.AddWithValue("@col25", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 26)
                //    cmd.Parameters.AddWithValue("@col26", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 27)
                //    cmd.Parameters.AddWithValue("@col27", objFloatingDEO.ColMain);
                //else if (objFloatingDEO.Number == 28)
                //    cmd.Parameters.AddWithValue("@col28", objFloatingDEO.ColMain);


                //if (objFloatingDEO.Col2 == null)
                //    cmd.Parameters.AddWithValue("@col2", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col2", objFloatingDEO.Col2);

                //if (objFloatingDEO.Col3 == null)
                //    cmd.Parameters.AddWithValue("@col3", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col3", objFloatingDEO.Col3);

                //if (objFloatingDEO.Col4 == null)
                //    cmd.Parameters.AddWithValue("@col4", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col4", objFloatingDEO.Col4);
                //if (objFloatingDEO.Col5 == null)
                //    cmd.Parameters.AddWithValue("@col5", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col5", objFloatingDEO.Col5);

                //if (objFloatingDEO.Col6 == null)
                //    cmd.Parameters.AddWithValue("@col6", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col6", objFloatingDEO.Col6);
                //if (objFloatingDEO.Col7 == null)
                //    cmd.Parameters.AddWithValue("@col7", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col7", objFloatingDEO.Col7);
                //if (objFloatingDEO.Col8 == null)
                //    cmd.Parameters.AddWithValue("@col8", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col8", objFloatingDEO.Col8);
                //if (objFloatingDEO.Col9 == null)
                //    cmd.Parameters.AddWithValue("@col9", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col9", objFloatingDEO.Col9);
                //if (objFloatingDEO.Col10 == null)
                //    cmd.Parameters.AddWithValue("@col10", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col10", objFloatingDEO.Col10);
                //if (objFloatingDEO.Col11 == null)
                //    cmd.Parameters.AddWithValue("@col11", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col11", objFloatingDEO.Col11);
                //if (objFloatingDEO.Col12 == null)
                //    cmd.Parameters.AddWithValue("@col12", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col12", objFloatingDEO.Col12);
                //if (objFloatingDEO.Col13 == null)
                //    cmd.Parameters.AddWithValue("@col13", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col13", objFloatingDEO.Col13);
                //if (objFloatingDEO.Col14 == null)
                //    cmd.Parameters.AddWithValue("@col14", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col14", objFloatingDEO.Col14);
                //if (objFloatingDEO.Col15 == null)
                //    cmd.Parameters.AddWithValue("@col15", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col15", objFloatingDEO.Col15);
                //if (objFloatingDEO.Col16 == null)
                //    cmd.Parameters.AddWithValue("@col16", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col16", objFloatingDEO.Col16);
                //if (objFloatingDEO.Col17 == null)
                //    cmd.Parameters.AddWithValue("@col17", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col17", objFloatingDEO.Col17);
                //if (objFloatingDEO.Col18 == null)
                //    cmd.Parameters.AddWithValue("@col18", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col18", objFloatingDEO.Col18);
                //if (objFloatingDEO.Col19 == null)
                //    cmd.Parameters.AddWithValue("@col19", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col19", objFloatingDEO.Col19);
                //if (objFloatingDEO.Col20 == null)
                //    cmd.Parameters.AddWithValue("@col20", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col20", objFloatingDEO.Col20);
                //if (objFloatingDEO.Col21 == null)
                //    cmd.Parameters.AddWithValue("@col21", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col21", objFloatingDEO.Col21);
                //if (objFloatingDEO.Col22 == null)
                //    cmd.Parameters.AddWithValue("@col22", "NIL");
                //else
                //    cmd.Parameters.AddWithValue("@col22", objFloatingDEO.Col22);

                //if (objFloatingDEO.Col23 == null)
                //    cmd.Parameters.AddWithValue("@col23", "NIL");
                //else

                //    cmd.Parameters.AddWithValue("@col23", objFloatingDEO.Col23);
                //if (objFloatingDEO.Col24 == null)
                //    cmd.Parameters.AddWithValue("@col24", "NIL");
                //else

                //    cmd.Parameters.AddWithValue("@col24", objFloatingDEO.Col24);
                //if (objFloatingDEO.Col25 == null)
                //    cmd.Parameters.AddWithValue("@col25", "NIL");
                //else

                //    cmd.Parameters.AddWithValue("@col25", objFloatingDEO.Col25);
                //if (objFloatingDEO.Col26 == null)
                //    cmd.Parameters.AddWithValue("@col26", "NIL");
                //else

                //    cmd.Parameters.AddWithValue("@col26", objFloatingDEO.Col26);
                //if (objFloatingDEO.Col27 == null)
                //    cmd.Parameters.AddWithValue("@col27", "NIL");
                //else

                //    cmd.Parameters.AddWithValue("@col27", objFloatingDEO.Col27);

                cmd.ExecuteNonQuery();

                return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion
        #region Function InsertOrUpdate
        public int InsertOrUpdate(denFloating objFloatingDEO)
        {
            try
            {
                int i;
                i = CheckFloatGridData(objFloatingDEO);
                if (i > 0)
                    UpdateFloatGridData(objFloatingDEO);
                else
                    InsertFloatGridData(objFloatingDEO);
                return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #endregion
    }
}