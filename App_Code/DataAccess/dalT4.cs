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
using Taxation.Interface;
using System.Collections.Generic;
using Taxation.DataEntity;
namespace Taxation.DataAccess
{

    /// <summary>
    /// Summary description for dalT4
    /// </summary>
    public class dalT4:dalConnection
    {
        public dalT4()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Variables
        SqlCommand cmd;        
        #endregion


        #region Utilities

        //Creating a Generic list to get records from T4 table when we click on LinkButton

        public List<denT4> getParticulars(int intIndex,string AYear)
        {
            denT4 objdenT4;
            try
            {
                List<denT4> GenT4 = new List<denT4>();
                this.pConnMain();
                //Now we are getting Details of ID 808 this is special case.
                //Another different case is 107.

                if (intIndex == 808 || intIndex == 844)
                {
                    cmd = new SqlCommand("procyesno808", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", intIndex);
                    cmd.Parameters.AddWithValue("@AY", AYear);
                }
                else
                {
                    cmd = new SqlCommand("SelectDataT4", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@intC1", intIndex);
                    cmd.Parameters.AddWithValue("@AY", AYear);
                    cmd.Parameters.AddWithValue("@ITR", HttpContext.Current.Session["ITR"].ToString());
                }
                    SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdenT4 = new denT4();

                    objdenT4.Serial = Convert.ToString(reader["C10"]);

                    objdenT4.Particular = Convert.ToString(reader["C4"]);
                    objdenT4.C11 = Convert.ToInt32(reader["C11"]);
                    objdenT4.SubConstID = Convert.ToInt32(reader["C1"]);
                    objdenT4.C12 = Convert.ToInt32(reader["C12"]);
                    objdenT4.C13 = Convert.ToInt32(reader["C13"]);
                    objdenT4.C14 = Convert.ToInt32(reader["C14"]);
                    objdenT4.C15 = Convert.ToInt32(reader["C15"]);
                    objdenT4.C35 = Convert.ToInt32(reader["C35"]);
                    objdenT4.C36 = Convert.ToInt32(reader["C36"]);
                    objdenT4.C37 = Convert.ToInt32(reader["C37"]);
                    objdenT4.C38 = Convert.ToInt32(reader["C38"]);
                    if (intIndex == 808 || intIndex == 844)
                    {
                        objdenT4.tooltip = "";
                    }
                    else
                    {
                        objdenT4.tooltip = (reader.IsDBNull(14)) ? "" : reader["tooltip"].ToString();
                    }
                    

                    //objdenT4.XMLNAME = Convert.ToString(reader["C44"]);


                    //objdenT4.C19 = Convert.ToInt32(reader["C19"]);

                    //objdenT4.C1 = Convert.ToInt32(reader["C1"]);

                    //objdenT4.C16 = Convert.ToInt32(reader["C16"]);

                    GenT4.Add(objdenT4);


                }
                reader.Close();
                //this.SqlCon.Close();
                return GenT4;
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

        public List<denT4> GetYesNo(int intIndex, int yn, string AY)
        {
            denT4 objdenT4;
            try
            {

                List<denT4> GenYesNo = new List<denT4>();
                this.pConnMain();

                //This is special case of 808 where we have to apply a new way.

                if (intIndex == 808 || intIndex == 844)
                {
                    cmd = new SqlCommand("procyesno808", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", intIndex);
                    cmd.Parameters.AddWithValue("@AY", AY);
                    
                }

                    //This is applicable to all other cases.
                if (intIndex == 803 || intIndex == 821 || intIndex == 829 || intIndex == 852 || intIndex == 869 || intIndex == 107 || intIndex == 126)
                {
                    cmd = new SqlCommand("procYesNo", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@yesno", yn);
                    cmd.Parameters.AddWithValue("@id", intIndex);
                    cmd.Parameters.AddWithValue("@year", AY);
                }
                else
                {
                    cmd = new SqlCommand("selectdatat4", this.SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@intC1", intIndex);
                    cmd.Parameters.AddWithValue("@AY", AY);
                    cmd.Parameters.AddWithValue("@ITR", HttpContext.Current.Session["ITR"].ToString());
                }
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdenT4 = new denT4();
                    objdenT4.Particular = Convert.ToString(reader["C4"]);
                    objdenT4.Serial = Convert.ToString(reader["C10"]);
                    objdenT4.SubConstID = Convert.ToInt32(reader["C1"]);
                    objdenT4.ConstID = Convert.ToInt32(reader["C2"]);
                    if (yn != 1 && intIndex != 803 && intIndex != 821 && intIndex != 829 && intIndex != 852 && intIndex != 869 && intIndex != 107 && intIndex != 126 && intIndex != 808 && intIndex != 844)
                        objdenT4.tooltip = reader["tooltip"].ToString();
                    else
                        objdenT4.tooltip = "";
                    //objdenYesNoGrid.AssessYear =Convert.ToInt16(reader[C40]);
                    //objdenYesNoGrid.RowID =Convert.ToInt16(reader[C2]); 
                    //objdenYesNoGrid.YESNO = yn;

                    GenYesNo.Add(objdenT4);

                }
                reader.Close();
                //this.SqlCon.Close();
                return GenYesNo;
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

        public void getRowYesNo(int constID, string AYear, out string return_val)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("ProcYesNoAll", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@constID", constID);
                cmd.Parameters.AddWithValue("@AY", AYear);
                cmd.Parameters.Add("@return_val", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                return_val = Convert.ToString(cmd.Parameters["@return_val"].Value);
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