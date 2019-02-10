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
namespace Taxation.DataAccess
{

    /// <summary>
    /// Summary description for daltbl_ProcessesHistoryofjob
    /// </summary>
    public class daltbl_ProcessesHistoryofjob : dalConnection
    {
        #region Constructor
        public daltbl_ProcessesHistoryofjob()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        SqlCommand cmd;
        dentbl_ProcessesHistoryofjob objtbl_ProcessesHistoryofjobDEN;
        #endregion

        #region Functions
        public void InsertDataMainGrid(dentbl_ProcessesHistoryofjob objdentbl_ProcessesHistoryofjob)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"INSERT INTO VatasSolution.dbo.tbl_ProcessesHistoryofjob
           (MasterID
           ,Next_UserID
           ,Previous_UserID
           ,Date_Time_Stamp
           ,Priority_of_Job
           ,Job_Status
           ,Reason_for_Delay
           ,Supervisor
           ,Is_Sent) values(@MasterID
           ,@Next_UserID
           ,@Previous_UserID
           ,@Date_Time_Stamp
           ,@Priority_of_Job
           ,@Job_Status
           ,@Reason_for_Delay
           ,@Supervisor
           ,@Is_Sent)", this.SqlCon);
                cmd.Parameters.AddWithValue("@MasterID", objdentbl_ProcessesHistoryofjob.MasterID);
                cmd.Parameters.AddWithValue("@Next_UserID", objdentbl_ProcessesHistoryofjob.Next_UserID);
                cmd.Parameters.AddWithValue("@Previous_UserID", objdentbl_ProcessesHistoryofjob.Previous_UserID);
                cmd.Parameters.AddWithValue("@Priority_of_Job", objdentbl_ProcessesHistoryofjob.Priority_of_Job);
                cmd.Parameters.AddWithValue("@Date_Time_Stamp", objdentbl_ProcessesHistoryofjob.Date_Time_Stamp);
                cmd.Parameters.AddWithValue("@Job_Status", objdentbl_ProcessesHistoryofjob.Job_Status);
                cmd.Parameters.AddWithValue("@Reason_for_Delay", objdentbl_ProcessesHistoryofjob.Reason_for_Delay);
                cmd.Parameters.AddWithValue("@Supervisor", objdentbl_ProcessesHistoryofjob.Supervisor);
                cmd.Parameters.AddWithValue("@Is_Sent", objdentbl_ProcessesHistoryofjob.Is_Sent);

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

        public void updateProcess(dentbl_ProcessesHistoryofjob objdentbl_ProcessesHistoryofjob)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"update VatasSolution.dbo.tbl_ProcessesHistoryofjob set Is_Sent = 'Y' where Next_UserID = @Next_UserID and MasterID = @MasterID", this.SqlCon);
                cmd.Parameters.AddWithValue("@MasterID", objdentbl_ProcessesHistoryofjob.MasterID);
                cmd.Parameters.AddWithValue("@Next_UserID", objdentbl_ProcessesHistoryofjob.Next_UserID);
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

        public void updateProcessDetail(dentbl_ProcessesHistoryofjob objdentbl_ProcessesHistoryofjob)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"update VatasSolution.dbo.tbl_ProcessesHistoryofjob set Is_Sent = @Is_Sent,Reason_for_Delay=@Reason_for_Delay where Next_UserID = @Next_UserID and MasterID = @MasterID", this.SqlCon);
                cmd.Parameters.AddWithValue("@MasterID", objdentbl_ProcessesHistoryofjob.MasterID);
                cmd.Parameters.AddWithValue("@Next_UserID", objdentbl_ProcessesHistoryofjob.Next_UserID);
                cmd.Parameters.AddWithValue("@Is_Sent", objdentbl_ProcessesHistoryofjob.Is_Sent);
                cmd.Parameters.AddWithValue("@Reason_for_Delay", objdentbl_ProcessesHistoryofjob.Reason_for_Delay);
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

        public DataTable Select(bool status)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"select am.id,nn.NameID,(nn.FirstName + ' ' + nn.LastName ) as Name, nn.PanNo, am.AY,am.ReturnType from NameMast nn
                                    inner join
                                    AssesseeMaster am on
                                    am.NameID=nn.NameID where am.status=@status and am.AY is not null and am.ReturnType is not null and am.Amount is not null", this.SqlCon);
                cmd.Parameters.AddWithValue("@status", status);
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
        #endregion
    }
}