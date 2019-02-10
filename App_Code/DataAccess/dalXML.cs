using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for dalXML
/// </summary>
public class dalXML:dalConnection
{
    SqlCommand cmd;
	public dalXML()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string ExecuteCommandSync(string command)
    {
        string result = "";
        try
        {
            // create the ProcessStartInfo using "cmd" as the program to be run,
            // and "/c " as the parameters.
            // Incidentally, /c tells cmd that we want it to execute the command that follows,
            // and then exit.
            System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

            // The following commands are needed to redirect the standard output.
            // This means that it will be redirected to the Process.StandardOutput StreamReader.
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = true;
            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            
            // Get the output into a string
            result = proc.StandardOutput.ReadToEnd();
            // Display the command output.
            //Label1.Text = result;
            //Console.WriteLine(result);
            
        }
        catch (Exception objException)
        {
            throw objException;
            // Log the exception
        }
        return result;
    }

    //Added By mudit on 31/08/2015 to fetch the xpath from the XML
    public DataTable GetXPath(string xml)
    {
        DataTable dt = new DataTable();
        try
        {
            this.pConn();
            cmd = new SqlCommand("select * from dbo.XmlTable(@xml)", this.SqlCon);
            cmd.Parameters.AddWithValue("@xml", xml);
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

    public string GetXML(Int64 NameID, string Itrtype, string Ay)
    {
        string Xml = "";
        try
        {
            this.pConn();
            cmd = new SqlCommand("select xml_data from dbo.tbl_ITRXML where NameID=@NameID and itrtype=@itrtype and ay=@ay", this.SqlCon);
            cmd.Parameters.AddWithValue("@NameID", NameID);
            cmd.Parameters.AddWithValue("@itrtype", Itrtype);
            cmd.Parameters.AddWithValue("@ay", Ay);
            object xmlobj = cmd.ExecuteScalar();
            if (xmlobj != null)
            {
                Xml = cmd.ExecuteScalar().ToString();
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
        return Xml;
    }
    public int Get_IsValidated(Int64 NameID, string Itrtype, string Ay)
    {
        int Xml =0;
        try
        {
            this.pConn();
            cmd = new SqlCommand("select IsValidated from dbo.tbl_ITRXML where NameID=@NameID and itrtype=@itrtype and ay=@ay", this.SqlCon);
            cmd.Parameters.AddWithValue("@NameID", NameID);
            cmd.Parameters.AddWithValue("@itrtype", Itrtype);
            cmd.Parameters.AddWithValue("@ay", Ay);
            object xmlobj = cmd.ExecuteScalar();
            if (xmlobj != null)
            {
                Xml = Convert.ToInt32(cmd.ExecuteScalar());
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
        return Xml;
    }
    public string getXML_JobID(Int64 ID)
    {
        string Job_ID = "0";
        try
        {
            this.pConn();
            cmd = new SqlCommand("select ISNULL(Job_ID,0) from dbo.tbl_ITRXML where ID=@ID", this.SqlCon);
            cmd.Parameters.AddWithValue("@ID", ID);
            object xmlobj = cmd.ExecuteScalar();
            if (xmlobj != null)
            {
                Job_ID = cmd.ExecuteScalar().ToString();
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
        return Job_ID;
    }

    public string getXML_Last_ID(string NameID)
    {
        string XML_ID = "";
        try
        {
            this.pConn();
            cmd = new SqlCommand("SELECT TOP (1) ID FROM Tbl_ITRXML WHERE (NameID = @NameID) ORDER BY ID DESC", this.SqlCon);
            cmd.Parameters.AddWithValue("@NameID", NameID);
            object xmlobj = cmd.ExecuteScalar();
            if (xmlobj != null)
            {
                XML_ID = cmd.ExecuteScalar().ToString();
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
        return XML_ID;
    }

    public DataTable GetValidationErrors(string NameID, string Ay, string ITRType)
    {
        DataTable dt = new DataTable();
        try
        {
            //this.pConn();
            this.pConnMain();
            cmd = new SqlCommand("Proc_Check_XML_Error", this.SqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NameID", NameID);
            cmd.Parameters.AddWithValue("@Ay", Ay);
            cmd.Parameters.AddWithValue("@ItrType", ITRType);
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

    public void DeleteErrors(string NameID)
    {
        try
        {
            this.pConn();
            cmd = new SqlCommand("delete from tbl_Error where NameID = @NameID", this.SqlCon);
            //cmd.CommandType = CommandType.StoredProcedure;
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

    public void Update_JobID(string ITRXML_ID, string PAN)
    {
        try
        {
            this.pConn();
            cmd = new SqlCommand("update Tbl_ITRXML set Job_ID = (select top(1) Job_ID from VatasSolution.dbo.Returns_Copy where PAN = @PAN order by Job_ID desc) where ID=@ID", this.SqlCon);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ITRXML_ID);
            cmd.Parameters.AddWithValue("@PAN", PAN);
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

    public void Update_Status(string ITRXML_ID, int IsSubmitUploaded)
    {
        try
        {
            this.pConn();
            cmd = new SqlCommand("update Tbl_ITRXML set IsSubmitUploaded = @IsSubmitUploaded where ID=@ID", this.SqlCon);            
            cmd.Parameters.AddWithValue("@ID", ITRXML_ID);
            cmd.Parameters.AddWithValue("@IsSubmitUploaded", IsSubmitUploaded);
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

    public void Update_JobID_ByNameID(string NameID)
    {
        try
        {
            this.pConn();
            cmd = new SqlCommand("update Tbl_ITRXML set Job_ID = (select top(1) Job_ID from VatasSolution.dbo.Returns_Copy where PAN = (select PANNo from NameMast where NameID = @NameID) order by Job_ID desc) where NameID=@NameID and ID =(select top(1) ID from Tbl_ITRXML where NameID = @NameID order by ID desc)", this.SqlCon);
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

    public string getTag_Value(string TagName, string XML)
    {
        string strTagVal = "";
        try
        {
            this.pConn();
            cmd = new SqlCommand("Proc_Search_TagValue_from_XML", this.SqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@XML", XML);
            cmd.Parameters.AddWithValue("@search", TagName);

            cmd.Parameters.Add("@result", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            strTagVal = Convert.ToString(cmd.Parameters["@result"].Value);
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
        return strTagVal;
    }

    public Int64 AddXMLData(string NameID, string ITRType, string AY, string ReturnType)
    {
        Int64 XMLID = 0;
        try
        {
            this.pConn();
            cmd = new SqlCommand("select * from Tbl_ITRXML where NameID = @NameID and ITRType = @ITRType and AY = @AY and ReturnType = @ReturnType", this.SqlCon);
            cmd.Parameters.AddWithValue("@NameID", NameID);
            cmd.Parameters.AddWithValue("@ITRType", ITRType);
            cmd.Parameters.AddWithValue("@AY", AY);
            cmd.Parameters.AddWithValue("@ReturnType", ReturnType);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count < 1 || ReturnType == "R")
            {
                DataTable dt2 = new DataTable();
                if (ReturnType == "O")
                {
                    SqlCommand cmd3 = new SqlCommand("select * from Tbl_ITRXML where NameID = @NameID and AY = @AY", this.SqlCon);
                    cmd3.Parameters.AddWithValue("@NameID", NameID);
                    cmd3.Parameters.AddWithValue("@ITRType", ITRType);
                    cmd3.Parameters.AddWithValue("@AY", AY);
                    cmd3.Parameters.AddWithValue("@ReturnType", ReturnType);
                    SqlDataAdapter adp2 = new SqlDataAdapter(cmd3);
                    adp2.Fill(dt2);
                }
                if (dt2.Rows.Count < 1)
                {
                    SqlCommand cmd2 = new SqlCommand("insert into Tbl_ITRXML(NameID,AY,ITRType,AddedOn,IsValidated,ReturnType) values(@NameID,@AY,@ITRType,@AddedOn,@IsValidated,@ReturnType); select @@identity", this.SqlCon);
                    cmd2.Parameters.AddWithValue("@NameID", NameID);
                    cmd2.Parameters.AddWithValue("@ITRType", ITRType);
                    cmd2.Parameters.AddWithValue("@AY", AY);
                    cmd2.Parameters.AddWithValue("@ReturnType", ReturnType);
                    cmd2.Parameters.AddWithValue("@AddedOn", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@IsValidated", 0);
                    XMLID = Convert.ToInt64(cmd2.ExecuteScalar());
                }
                //cmd2.ExecuteNonQuery();
            }
            return XMLID;
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

}