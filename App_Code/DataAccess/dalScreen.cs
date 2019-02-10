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
using System.Collections.Generic;

namespace Taxation.DataAccess
{
    /// <summary>
    /// Summary description for dalScreen
    /// </summary>
    public class dalScreen:dalConnection
    {
        #region Constructors
        public dalScreen()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        SqlCommand cmd;        
         #endregion        

        #region Utilities
        
        public List<denScreen> getComboData(int intVtype, string ITR,string AY)
        {
            denScreen objdenScreen;
            try
            {                
                List<denScreen> GenScreen = new List<denScreen>();
                this.pConnMain();
                cmd = new SqlCommand("procScreenSettings", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vtype", intVtype);
                cmd.Parameters.AddWithValue("@ITR", ITR);
                cmd.Parameters.AddWithValue("@AY", AY);                
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdenScreen = new denScreen();                    
                    objdenScreen.ComboItems = Convert.ToString(reader["Description"]);
                    objdenScreen.ID = Convert.ToInt16(reader["ID"]);
                    GenScreen.Add(objdenScreen);
                }
                reader.Close();                
                return GenScreen;
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
        
        public denScreen getSettings(int intVType)
        {            
            try
            {
                denScreen objdenScreen;
                
                this.pConnMain();
                cmd = new SqlCommand("HideUnhide", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@info", intVType);
                //SqlDataAdapter adp = new SqlDataAdapter();
                //DataTable dt = new DataTable();
                //adp = new SqlDataAdapter(cmd);
                //adp.Fill(dt);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                objdenScreen = new denScreen();
                if (reader.Read())
                {
                    objdenScreen.Voucher = Convert.ToString(reader["VType"]);
                    objdenScreen.AssessYear = Convert.ToString(reader["AY"]);
                    
                    objdenScreen.IsComboAttach = Convert.ToString(reader["IsComboAttached"]);
                    objdenScreen.LabelText = Convert.ToString(reader["LabelText"]);
                    objdenScreen.RadioVisible = Convert.ToString(reader["RadioScreen"]);
                    objdenScreen.GridIndex = Convert.ToString(reader["GridIndex"]);
                    
                    objdenScreen.ScreenTitle = Convert.ToString(reader["ScreenTitle"]);
                    objdenScreen.Theme = Convert.ToString(reader["Theme"]);

                    objdenScreen.GridName = Convert.ToString(reader["GridName"]);
                    objdenScreen.Page_ID = Convert.ToString(reader["Page_ID"]);
                    objdenScreen.Page_SubModule_ID = Convert.ToString(reader["Page_SubModule_ID"]);
                    objdenScreen.IsMaster = Convert.ToString(reader["IsMaster"]);
                    objdenScreen.GridHeader =  (!reader.IsDBNull(14)) ? Convert.ToString(reader["GridHeader"]) : "";
                    objdenScreen.popupID = (!reader.IsDBNull(7)) ? Convert.ToInt32(reader["popupID"]) : 0;
                    objdenScreen.ScreenListing = (!reader.IsDBNull(17)) ? reader["ScreenListing"].ToString() : "";
                    objdenScreen.dbtnID = (!reader.IsDBNull(18)) ? reader["dbtnID"].ToString() : "";
                    
                }
                reader.Close();                
                return objdenScreen;
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

        public string getVTypeByScreenTitle(string screenTitle)
        {
            string VType = "";
            try
            {
                denScreen objdenScreen;

                this.pConnMain();
                cmd = new SqlCommand("select VType from ScreenSettings where ScreenTitle=@ScreenTitle", this.SqlCon);
                cmd.Parameters.AddWithValue("@ScreenTitle", screenTitle);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                objdenScreen = new denScreen();
                if (reader.Read())
                {
                    VType = (!reader.IsDBNull(0)) ? Convert.ToString(reader["VType"]) : "";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return VType;
        }

        // Below functions are for TDS by Mudit:

        public List<denScreen> getOtherComboData(int intVtype, string ITR, string AY, string TAN, string FormNo, string Regular_Correction, string FY, string Quarter)
        {
            denScreen objdenScreen;
            try
            {

                List<denScreen> GenScreen = new List<denScreen>();
                this.pConnAdmin();
                cmd = new SqlCommand("procComboOtherThanScreenSetting", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vtype", intVtype);
                cmd.Parameters.AddWithValue("@ITR", ITR);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@TAN", TAN);
                cmd.Parameters.AddWithValue("@FormNo", FormNo);
                cmd.Parameters.AddWithValue("@FY", FY);
                cmd.Parameters.AddWithValue("@Regular_Correction", Regular_Correction);
                cmd.Parameters.AddWithValue("@Quarter", Quarter);
                SqlDataReader reader;   
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdenScreen = new denScreen();



                    objdenScreen.ChallanID = Convert.ToInt32(reader["ChallanID"]);

                    objdenScreen.ID = Convert.ToInt16(reader["ChallanID"]);

                    GenScreen.Add(objdenScreen);

                }
                reader.Close();

                return GenScreen;
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

        public string getNextPrevVType(string VType,string IsNextCont,string AY,string ITRType,string Tab)
        {
            string strVType = "";
            try
            {  
                this.pConnMain();
                if (IsNextCont == "next")
                    cmd = new SqlCommand("select Cont,Title,TitleBack from tbl_ScreenNavigation where VType=@VType and ITRType=@ITRType and AY = @AY and Tab=@Tab", this.SqlCon);
                else
                    cmd = new SqlCommand("select Back,Title,TitleBack from tbl_ScreenNavigation where VType=@VType and ITRType=@ITRType and AY = @AY and Tab=@Tab", this.SqlCon);

                cmd.Parameters.AddWithValue("@VType", VType);
                cmd.Parameters.AddWithValue("@ITRType", ITRType);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.Parameters.AddWithValue("@Tab", (Tab == "") ? "0" : Tab);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        strVType += reader.GetString(0);
                        strVType += "~" + reader.GetString(1);
                        strVType += "~" + reader.GetString(2);
                    }
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
            return strVType;
        }

        public int getFirstLast(string VType, string AY, string ITRType)
        {
            int IsFirstLast = 1;
            try
            {
                this.pConnMain();

                cmd = new SqlCommand("select IsNothingFirstLast from tbl_ScreenNavigation where VType=@VType and ITRType=@ITRType and AY = @AY", this.SqlCon);

                cmd.Parameters.AddWithValue("@VType", VType);
                cmd.Parameters.AddWithValue("@ITRType", ITRType);
                cmd.Parameters.AddWithValue("@AY", AY);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IsFirstLast = reader.GetInt32(0);
                    }
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
            return IsFirstLast;
        }

        #endregion




    }

}