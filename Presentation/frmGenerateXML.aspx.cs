using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;
public partial class frmGenerateXML : System.Web.UI.Page
{
    XMLService objXMLService = new XMLService();
    Int64 AssesseeID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Auto Redirect on Session Out
        int reason = 0;
        if (!common.IsLoggedIn(out reason))
        {
            if (reason == 1)
            {
                Session["reason_logout"] = "suspecious_attempt";
            }
            Response.Redirect("Logout.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            AssesseeID = 1981850416;
            DataSet dsXML = new DataSet();//Datatset for XML
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Prohibit;
            using (XmlReader reader = XmlReader.Create(@"E:\Ankush\XML\Final XSD Yearwise\2014-15\ITR-1\ITR-1_2014_Master(4).xsd", settings))
            {
                dsXML.ReadXmlSchema(reader);//Reading XML Schema

                DataTable dtMaster = new DataTable();
                DataTable dtStoreTrans = new DataTable();
                DataTable dtStoreFtrans = new DataTable();
                DataTable dtNameMast = new DataTable();
                DataTable dtDeclaration = new DataTable();
                DataTable dtDoctrans = new DataTable();
                DataTable dtAddressMast = new DataTable();
                DataTable dtAddressMast2 = new DataTable();
                DataTable dtFillingStatus = new DataTable();
                DataTable dtVerification = new DataTable();
                DataTable dtEmprMast = new DataTable();
                DataTable dtAssetTrans = new DataTable();
                DataTable dtTemp = new DataTable();
                DataSet dsAllTable = new DataSet(); //Dataset for above Datatable 

                //Datatable for T_Xml table
                dtMaster = objXMLService.Master(Session["AY"].ToString(), "ITR-" + Session["ITR"].ToString());

                //Datatable for StoreTrans
                dtStoreTrans = objXMLService.SelectStoreTrans(AssesseeID, Session["AY"].ToString());

                //Datatable for StoreFtrans
                dtStoreFtrans = objXMLService.SelectStoreFTrans(AssesseeID, Session["AY"].ToString());

                //Datatble for Personalinfo
                dtNameMast = objXMLService.selectNameMaster(AssesseeID);

                //Datatable for Address of Assessee
                dtAddressMast = objXMLService.selectAdrsMaster(AssesseeID);

                //Datatable for FilingStatus
                dtFillingStatus = objXMLService.selectDataForFillingStatus(AssesseeID);

                //Datatable for Doctrans
                dtDoctrans = objXMLService.selectDoctrans(AssesseeID);

                //Datatable for Declaration
                dtDeclaration = objXMLService.selectDataForDeclaration(AssesseeID);

                //Datatable for Verification
                dtVerification = objXMLService.SelectDataForVerification();

                //Datatable for EmployeeInfo
                dtEmprMast = objXMLService.SelectEmployeeMaster(AssesseeID);

                //Datatable for AssetInfo
                dtAssetTrans = objXMLService.SelectAssetTrans(AssesseeID);

                // Assigning name and Adding Datatables to Dataset dsAllTables
                dtNameMast.TableName = "dtNameMast";
                dsAllTable.Tables.Add(dtNameMast);

                dtAddressMast.TableName = "dtAddressMast";
                dsAllTable.Tables.Add(dtAddressMast);

                dtFillingStatus.TableName = "dtFillingStatus";
                dsAllTable.Tables.Add(dtFillingStatus);

                dtStoreTrans.TableName = "dtStoreTrans";
                dsAllTable.Tables.Add(dtStoreTrans);

                dtStoreFtrans.TableName = "dtStoreFtrans";
                dsAllTable.Tables.Add(dtStoreFtrans);

                dtVerification.TableName = "dtVerification";
                dsAllTable.Tables.Add(dtVerification);

                dtDoctrans.TableName = "dtDocTrans";
                dsAllTable.Tables.Add(dtDoctrans);

                dtDeclaration.TableName = "dtDeclaration";
                dsAllTable.Tables.Add(dtDeclaration);

                dtEmprMast.TableName = "dtEmprMast";
                dsAllTable.Tables.Add(dtEmprMast);

                dtAssetTrans.TableName = "dtAssetTrans";
                dsAllTable.Tables.Add(dtAssetTrans);

                //Adding CreationInfo to Dataset dsXML
                DataRow dr = dsXML.Tables[0].NewRow();
                dr["SWVersionNO"] = "v1.1";
                dr["SWCreatedBy"] = "VATAS.Tax";
                dr["XMLCreatedBy"] = "VATAS.Tax";
                dr["XMLCreationDate"] = DateTime.Now.ToShortDateString();
                dr["IntermediaryCity"] = "Jalandhar";
                //dr["ITR1_Id"] = 0;
                dsXML.Tables[0].Rows.Add(dr);
                dr = null;

                //Adding FormInfo to Dataset dsXML
                dr = dsXML.Tables[1].NewRow();
                dr["FormName"] = "ITR-1";
                dr["Description"] = "For Indls having Income from Salary, Pension, family pension and Interest";
                dr["AssessmentYear"] = DateTime.Now.Year;
                dr["SchemaVer"] = "Ver1.0";
                dr["FormVer"] = "Ver1.0";
                //dr["ITR1_Id"] = 0;
                dsXML.Tables[1].Rows.Add(dr);
                dr = null;


                string[] arrParam = new string[] { AssesseeID.ToString() };
                //arrParam[0] = AssesseeID.ToString();
                string[] condition = new string[dtMaster.Rows.Count];
                DataTable dt = new DataTable();
                //Loop for filling Dataset dsXML 
                for (int i = 0; i < dtMaster.Rows.Count; i++)
                {
                    string condition2 = dtMaster.Rows[i]["FilterCondition"].ToString();
                    string[] serial = dtMaster.Rows[i]["ColNo"].ToString().Split(',');
                    //Selecting Paricular Colums from Datatset dsAllTables based on conditions
                    DataRow[] rows = dsAllTable.Tables[dtMaster.Rows[i][5].ToString()].DefaultView.ToTable(false, dtMaster.Rows[i]["SelectCondition"].ToString().Split(',')).Select(condition2);
                    if (rows.Length > 0)
                    {
                        if (serial.Length > 1)
                        {
                            DataTable dtserial = new DataTable();
                            DataTable dtS2 = new DataTable();

                            dtserial.Columns.Add("Serial", typeof(string));
                            for (int j = 0; j < serial.Length; j++)
                            {
                                dtserial.Rows.Add(serial[j]);
                            }

                            dt = rows.CopyToDataTable();
                            dtS2 = rows.CopyToDataTable();

                            for (int x = 0; x < dtserial.Rows.Count; x++)
                            {
                                dtS2.Rows[x].ItemArray = dt.Rows[Convert.ToInt32(dtserial.Rows[x]["Serial"])].ItemArray;
                            }

                            dt.Clear();
                            dt.Rows.Clear();
                            dt = dtS2;
                        }
                        else
                        {
                            dt = rows.CopyToDataTable();
                        }
                    }
                    if (rows.Length > 1)
                    {
                        dt = objXMLService.GenerateTransposedTable(dt);//Function to Transpose Datatable dt
                        DataRow row2 = dsXML.Tables[dtMaster.Rows[i][4].ToString()].NewRow();
                        row2.ItemArray = dt.Rows[0].ItemArray;
                        dsXML.Tables[dtMaster.Rows[i][4].ToString()].Rows.Add(row2);
                    }
                    else
                    {
                        foreach (DataRow row in rows)
                        {
                            if (i > 0)
                            {
                                if (dsXML.Tables[dtMaster.Rows[i - 1][4].ToString()].Columns[dsXML.Tables[dtMaster.Rows[i - 1][4].ToString()].Columns.Count - 1].ColumnName == row.Table.Columns[row.Table.Columns.Count - 1].ColumnName)
                                {
                                    if (dsXML.Tables[dtMaster.Rows[i - 1][4].ToString()].Rows.Count > 0)
                                        dsXML.Tables[dtMaster.Rows[i][4].ToString()].ImportRow(row);
                                }
                                else
                                {
                                    dsXML.Tables[dtMaster.Rows[i][4].ToString()].ImportRow(row);
                                }
                            }
                            else
                            {
                                dsXML.Tables[dtMaster.Rows[i][4].ToString()].ImportRow(row);
                            }
                        }
                    }
                }

                //Formatting XML
                StreamWriter xmlDoc = new StreamWriter(@"e:\" + dtNameMast.Rows[0]["PAN"].ToString() + ".xml");
                dsXML.WriteXml(xmlDoc);
                xmlDoc.Close();
                string sLine = "";

                sLine = System.IO.File.ReadAllText(@"e:\" + dtNameMast.Rows[0]["PAN"].ToString() + ".xml");
                string[] arrInfo = System.IO.File.ReadAllLines(@"e:\" + dtNameMast.Rows[0]["PAN"].ToString() + ".xml");
                for (int i = 0; i < arrInfo.Length; i++)
                {
                    arrInfo[i] = arrInfo[i].Replace("</", "`");
                    arrInfo[i] = arrInfo[i].Replace("<", "< ");
                    arrInfo[i] = arrInfo[i].Replace("< ", "<ITRForm:");
                    arrInfo[i] = arrInfo[i].Replace("`", "</ITRForm:");
                    arrInfo[i] = arrInfo[i].Replace("<ITRForm:?", "<?");
                }
                arrInfo[0] = arrInfo[0].Remove(0);
                arrInfo[0] = "<?xml version='1.0' encoding='ISO-8859-1'?>";
                arrInfo[1] = "<ITRETURN:ITR xmlns:ITRETURN='http://incometaxindiaefiling.gov.in/main' xmlns:ITR1FORM='http://incometaxindiaefiling.gov.in/ITR1' xmlns:ITRForm='http://incometaxindiaefiling.gov.in/master' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>";
                arrInfo[2] = @"<ITR1FORM:ITR1>
  <ITRForm:CreationInfo>" +
                 " " + arrInfo[2];
                arrInfo[arrInfo.Length - 2] = arrInfo[arrInfo.Length - 2] + @"</ITR1FORM:ITR1>";
                arrInfo[arrInfo.Length - 1] = "</ITRETURN:ITR>";
                System.IO.File.WriteAllLines(@"e:\" + dtNameMast.Rows[0]["PAN"].ToString() + ".xml", arrInfo);

                lblmsg.Visible = true;
                lblmsg.Text = @"XML of PAN:" + dtNameMast.Rows[0]["PAN"].ToString() + " is saved in e drive successfully..!";

            }
        }
        catch (Exception ex)
        {
            lblmsg.Visible = true;
            lblmsg.Text = ex.Message;
        }
    }
}