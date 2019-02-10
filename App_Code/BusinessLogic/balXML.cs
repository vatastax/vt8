using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for balXML
/// </summary>
public class balXML
{
    dalXML objdalxml = new dalXML();
	public balXML()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string ExecuteCommandSync(string command)
    {
        return objdalxml.ExecuteCommandSync(command);
    }

    //Added By mudit on 31/08/2015 to fetch the xpath from the XML
    public DataTable GetXPath(string xml)
    {
        return objdalxml.GetXPath(xml);
    }
    public string GetXML(Int64 NameID, string Itrtype, string Ay)
    {
        return objdalxml.GetXML(NameID,Itrtype,Ay);
    }
    public int Get_IsValidated(Int64 NameID, string Itrtype, string Ay)
    {
        return objdalxml.Get_IsValidated(NameID, Itrtype, Ay);
    }
    public string getXML_Last_ID(string NameID)
    {
        return objdalxml.getXML_Last_ID(NameID);
    }

    public string getXML_JobID(Int64 ID)
    {
        return objdalxml.getXML_JobID(ID);
    }

    public DataTable GetValidationErrors(string NameID, string Ay, string ITRType)
    {
        return objdalxml.GetValidationErrors(NameID, Ay, ITRType);
    }

    public void DeleteErrors(string NameID)
    {
        objdalxml.DeleteErrors(NameID);
    }

    public void Update_JobID(string ITRXML_ID, string PAN)
    {
        objdalxml.Update_JobID(ITRXML_ID, PAN);
    }

    public void Update_Status(string ITRXML_ID, int IsSubmitUploaded)
    {
        objdalxml.Update_Status(ITRXML_ID, IsSubmitUploaded);
    }

    public void Update_JobID_ByNameID(string NameID)
    {
        objdalxml.Update_JobID_ByNameID(NameID);
    }

    public Int64 AddXMLData(string NameID, string ITRType, string AY, string ReturnType)
    {
        return objdalxml.AddXMLData(NameID, ITRType, AY, ReturnType);
    }
    public string getTag_Value(string TagName, string XML)
    {
        return objdalxml.getTag_Value(TagName, XML);
    }
}