using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
//using System.IO;

/// <summary>
/// Summary description for XMLService
/// </summary>
public class XMLService
{
    //XMLService objXMLService = new XMLService();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con_Poolable"].ConnectionString);
    public XMLService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable Master(string AY,string Form)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = "select * from T_XML where AY=@AY and ITRForm=@Form";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@AY", AY);
        cmd.Parameters.AddWithValue("@Form", Form);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable SelectByQuery(string strSQL, string[] arrParameters)
    {
        DataTable dt = new DataTable();
        try
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            for (int i = 0; i < arrParameters.Length; i++)
            {
                int index = strSQL.IndexOf("#");
                strSQL = strSQL.Remove(index, 1);
                strSQL = strSQL.Insert(index, arrParameters[i].ToString());
            }
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        return dt;
    }

    public DataTable SelectStoreTrans(Int64 AssesseeID, string AY)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = @"SELECT ENTRYID,NameID,VType,AY,MainID,ConstantID,GridIndex,GRowNo,KeyCheck,RecdAmount,ExemptedAmount,TempArray,DecisionArray,StaticAmount1,StaticAmount2,Section,WhichFormula,ExemptCol,IsEnterFDet,Col2,Col3 ,Col15,Col16,SubConstID,WhichDet,DispName,XMLTAG,ComboItemNo,XMLTAGID,Counter,0 as TaxPayments_Id,0 as TDSonSalaries_Id,0 as TDSonOthThanSals_Id,0 as ITR1_TaxComputation_Id,0 as TaxPaid_Id,0 as Refund_Id,0 as ITR1_IncomeDeductions_Id,0 as IncomeDeduction_Id FROM StoreTrans where nameid=@nameid and AY=@AY";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        cmd.Parameters.AddWithValue("@AY", AY);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable SelectStoreTransElg(Int64 AssesseeID, string AY)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = @"SELECT ENTRYID,NameID,VType,AY,MainID,ConstantID,GridIndex,GRowNo,KeyCheck,RecdAmount,ExemptedAmount,TempArray,DecisionArray,StaticAmount1,StaticAmount2,
                    Section,WhichFormula,ExemptCol,IsEnterFDet,Col2,Col3 ,Col15,Col16,SubConstID,WhichDet,DispName,XMLTAG,ComboItemNo,XMLTAGID,Counter,0 as TaxPayments_Id,0 as 
                    TDSonSalaries_Id,0 as TDSonOthThanSals_Id,0 as ITR1_TaxComputation_Id,0 as TaxPaid_Id,0 as Refund_Id,0 as ITR1_IncomeDeductions_Id,0 as IncomeDeduction_Id,
                    case when staticamount1=0 or cast(col3 as float)<=staticamount1 then col3 else staticamount1 end as eligibleAmt FROM StoreTrans where nameid=@nameid and AY=@AY and col3<>'L'";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        cmd.Parameters.AddWithValue("@AY", AY);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable SelectStoreFTrans(Int64 AssesseeID, string AY)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = @"SELECT NameID
      ,AY
      ,VType
      ,GOrder
      ,ConstantID
      ,iID
      ,HeaderID
      ,GridIndex
      ,Col2
      ,Col3
      ,Col4
      ,Col5
      ,Col6
      ,Col7 
      ,Col8
      ,Col9
      ,Col10
      ,Col11
      ,Col12
      ,Col13
      ,Col14
      ,Col15
      ,Col16
      ,Col17
      ,Col18
      ,Col19
      ,Col20
      ,Col21
      ,Col22
      ,Col23
      ,Col24
      ,Col25
      ,Col26
      ,Col27
      ,Col28
      ,Col29,0 as TDSonSalary_Id,0 as TDSonSalaries_Id,0 as TaxPayments_Id
  FROM StoreFTrans where nameid=@nameid";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        //cmd.Parameters.AddWithValue("@AY", AY);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable selectNameMaster(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = @"select Namemast.NameID,VType,Status,Salute,FirstName,MiddleName,LastName as SurNameOrOrgName,
                        0 as PersonalInfo_Id,FathersName as FatherName,convert(datetime,DateofBirth,105) as DOB,
                        WardCircle as DesigOfficerWardorCircle,PANNo as PAN,TanNo,(Case when Status=0 then 'I' End) as Status,
                        TypeofAss,email,PEOutsideIndia as AssetOutIndiaFlag ,PEInsideIndia,OldWardCircle,BusinessNature,ChangeinCompName,OldCompName,
                        CompStatus,CompNature,username,no_of_dependents,EmployerCategory,0 as TaxExmpIntInc,0 as ITR1_Id,
                        (Case when Salute = 0 then 'M' else 'F' End) as Gender,0 as PartA_GEN1_Id from namemast where nameid=@nameid";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable selectDoctrans(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = @"select DocID,doctrans.NameID,AccountNo as BankAccountNumber,Name as RepName,Address1+Address2+Address3+Address4+Address5+City as RepAddress,PAN as RepPAN,
                        AccountType as BankAccountType,IFSCCode,0 as Refund_Id,0 as FilingStatus_Id,MICRCode,NameofBank,0 as NameOfBranch,0 as TaxPayments_Id,Address1,City,
                        State,Pin,0 as EmployerOrDeductorOrCollectDetl_Id from DocTrans left outer JOIN states as State ON State.StateCode=DocTrans.State where nameid=(Select PanNo from namemast where nameid=@nameid)";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable SelectEmployeeMaster(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = @"select EmpID,VType,Name as NameOfEmployer,Address,PhoneNo,TypeOfEmployer,PSR,NameID,PAN as PANofEmployer,Designation,Flat,Road,Area,Premises,State,City,Pin,IsDeleted,0 as Salaries_Id,0 as ScheduleS_Id,0 as PropertyDetails_Id,0 as DoneeWithPan_Id from EmprMast where NameId=@nameid";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        //cmd.Parameters.AddWithValue("@AY", AY);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable SelectAssetTrans(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = @"select * from AssetTrans where NameId=(select PanNo from namemast where nameid=@nameid)";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        //cmd.Parameters.AddWithValue("@AY", AY);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable selectNameMaster1(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = @"select Namemast.NameID,VType,Status,Salute,FirstName,MiddleName,LastName as SurNameOrOrgName,
                        0 as PersonalInfo_Id,FathersName as FatherName,convert(datetime,DateofBirth,105) as DOB,
                        WardCircle as DesigOfficerWardorCircle,PANNo as PAN,TanNo,(Case when Status=0 then 'I' End) as Status,
                        TypeofAss,email,PEOutsideIndia,PEInsideIndia,OldWardCircle,BusinessNature,ChangeinCompName,OldCompName,
                        CompStatus,CompNature,username,no_of_dependents,EmployerCategory,
                        (Case when Salute = 0 then 'M' else 'F' End) as Gender,DocID,doctrans.NameID,
                        AccountNo as BankAccountNumber,AccountType as BankAccountType,IFSCCode,0 as Refund_Id from Namemast
                        INNER JOIN DocTrans as doctrans on doctrans.NameID=Namemast.PANNo where Namemast.nameid=@nameid";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable selectAdrsMaster(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = @"select FlatNo as ResidenceNo,NOPremises as ResidenceName,RoadStreet as RoadOrStreet,
                        Area as LocalityOrArea,City as CityOrTownOrDistrict,State as StateCode,91 as CountryCode,
                        PinCode,mobile1 as MobileNo,mobile2 as MobileNoSec,EmailID as EmailAddress,0 as Address_Id,
                        0 as PersonalInfo_Id,STDCode as STDcode,PhoneNo
                        from adrsmast where nameid=(Select PanNo from namemast where nameid=@nameid)";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable selectDataForPersonalInfo(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = "select PANNo as PAN,convert(datetime,DateofBirth,105) as DOB,(Case when EmployerCategory=0 then'Gov' when EmployerCategory=1 then 'PSW' when EmployerCategory=2 then 'Oth'  else 'NA' end )as EmployerCategory,(Case when Salute = 0 then 'M' else 'F' End) as Gender,(Case when Status=0 then 'I' End)as Status,0 as PersonalInfo_Id from namemast where nameid=@nameid";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;        
    }

    public DataTable selectDataForAssesseeName(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = "select FirstName,MiddleName,LastName as SurNameOrOrgName,0 as PersonalInfo_Id from namemast where nameid=@nameid";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable selectDataForDeclaration(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = "select FirstName+MiddleName+LastName as AssesseeVerName,FathersName as FatherName,PANNo as AssesseeVerPAN,0 as Verification_Id from namemast where nameid=@nameid";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable selectDataForAddress(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = "select FlatNo as ResidenceNo,NOPremises as ResidenceName,RoadStreet as RoadOrStreet,Area as LocalityOrArea,City as CityOrTownOrDistrict,State as StateCode,91 as CountryCode,PinCode,mobile1 as MobileNo,mobile2 as MobileNoSec,EmailID as EmailAddress,0 as Address_Id,0 as PersonalInfo_Id from adrsmast where nameid=(Select PanNo from namemast where nameid=@nameid)";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable SelectDataForVerification()
    {
        DataTable dtVerification = new DataTable();
        dtVerification.Columns.Add("Place",typeof(string));
        dtVerification.Columns.Add("Date", typeof(string));
        dtVerification.Columns.Add("Verification_Id", typeof(string));
        dtVerification.Rows.Add("Jalandhar", DateTime.Now.ToShortDateString(),0);
        return dtVerification;
    }

    public DataTable selectDataForPhone(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = "select STDCode as STDcode,PhoneNo,0 as Address_Id from adrsmast where nameid=(Select PanNo from namemast where nameid=@nameid)";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable selectDataForFillingStatus(Int64 AssesseeID)
    {
        con.Open();
        DataTable dt = new DataTable();
        string str = "select WardCircle as DesigOfficerWardorCircle,ReturnFiledUnderSection as ReturnFileSec,"+
                     " AckNo as AckNoOriginalReturn,0 as NoticeNo,FilingDate as DefRetOrigRetFileDate,ReturnType,RecieptNo as ReceiptNo,"+
                     " FilingDate as OrigRetFiledDate,ResidentialStatus as ResidentialStatus,0 as TaxStatus,0 as PortugeseCC5A,0 as PANOfSpouse,0 as NoticeDateUnder,0 as FillingStatus_Id,0 as PartA_GEN1_Id,Auth_Name as RepName,Address1 as RepAddress,PAN as RepPAN,0 as FilingStatus_Id from namemast as namemast,DocTrans,assessmentmast" +
                     " where doctrans.nameId='"+AssesseeID+"' and namemast.nameid='"+AssesseeID+ "' and assessmentmast.nameId='"+AssesseeID+"'";
        SqlCommand cmd = new SqlCommand(str, con);
        //cmd.Parameters.AddWithValue("@nameid", AssesseeID);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable GenerateTransposedTable(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();

        // Add columns by looping rows

        // Header row's first column is same as in inputTable
        outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

        // Header row's second column onwards, 'inputTable's first column taken
        foreach (DataRow inRow in inputTable.Rows)
        {
            string newColName = inRow[0].ToString();
            outputTable.Columns.Add(newColName);
        }

        // Add rows by looping columns        
        for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
        {
            DataRow newRow = outputTable.NewRow();

            // First column is inputTable's Header row's second column
            newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
            for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
            {
                string colValue = inputTable.Rows[cCount][rCount].ToString();
                newRow[cCount + 1] = colValue;
            }
            outputTable.Rows.Add(newRow);
        }
        outputTable.Columns.RemoveAt(0);
        //outputTable.Rows[0][0] = "0";
        //outputTable.Columns.a
        return outputTable;
    }

//    public void genXML(Int64 NameID,string AY,string ITR)
//    {
//        try
//        {
//            Int64 AssesseeID = NameID;
//            DataSet dsXML = new DataSet();//Datatset for XML
//            XmlReaderSettings settings = new XmlReaderSettings();
//            settings.DtdProcessing = DtdProcessing.Prohibit;
//            using (XmlReader reader = XmlReader.Create(@"E:\Ankush\XML\Final XSD Yearwise\2014-15\ITR-1\ITR-1_2014_Master(4).xsd", settings))
//            {
//                dsXML.ReadXmlSchema(reader);//Reading XML Schema

//                DataTable dtMaster = new DataTable();
//                DataTable dtStoreTrans = new DataTable();
//                DataTable dtStoreFtrans = new DataTable();
//                DataTable dtNameMast = new DataTable();
//                DataTable dtDeclaration = new DataTable();
//                DataTable dtDoctrans = new DataTable();
//                DataTable dtAddressMast = new DataTable();
//                DataTable dtAddressMast2 = new DataTable();
//                DataTable dtFillingStatus = new DataTable();
//                DataTable dtVerification = new DataTable();
//                DataTable dtEmprMast = new DataTable();
//                DataTable dtAssetTrans = new DataTable();
//                DataTable dtTemp = new DataTable();
//                DataSet dsAllTable = new DataSet(); //Dataset for above Datatable 

//                //Datatable for T_Xml table
//                dtMaster = objXMLService.Master(AY, "ITR-" + ITR);

//                //Datatable for StoreTrans
//                dtStoreTrans = objXMLService.SelectStoreTrans(AssesseeID, AY);

//                //Datatable for StoreFtrans
//                dtStoreFtrans = objXMLService.SelectStoreFTrans(AssesseeID, AY);

//                //Datatble for Personalinfo
//                dtNameMast = objXMLService.selectNameMaster(AssesseeID);

//                //Datatable for Address of Assessee
//                dtAddressMast = objXMLService.selectAdrsMaster(AssesseeID);

//                //Datatable for FilingStatus
//                dtFillingStatus = objXMLService.selectDataForFillingStatus(AssesseeID);

//                //Datatable for Doctrans
//                dtDoctrans = objXMLService.selectDoctrans(AssesseeID);

//                //Datatable for Declaration
//                dtDeclaration = objXMLService.selectDataForDeclaration(AssesseeID);

//                //Datatable for Verification
//                dtVerification = objXMLService.SelectDataForVerification();

//                //Datatable for EmployeeInfo
//                dtEmprMast = objXMLService.SelectEmployeeMaster(AssesseeID);

//                //Datatable for AssetInfo
//                dtAssetTrans = objXMLService.SelectAssetTrans(AssesseeID);

//                // Assigning name and Adding Datatables to Dataset dsAllTables
//                dtNameMast.TableName = "dtNameMast";
//                dsAllTable.Tables.Add(dtNameMast);

//                dtAddressMast.TableName = "dtAddressMast";
//                dsAllTable.Tables.Add(dtAddressMast);

//                dtFillingStatus.TableName = "dtFillingStatus";
//                dsAllTable.Tables.Add(dtFillingStatus);

//                dtStoreTrans.TableName = "dtStoreTrans";
//                dsAllTable.Tables.Add(dtStoreTrans);

//                dtStoreFtrans.TableName = "dtStoreFtrans";
//                dsAllTable.Tables.Add(dtStoreFtrans);

//                dtVerification.TableName = "dtVerification";
//                dsAllTable.Tables.Add(dtVerification);

//                dtDoctrans.TableName = "dtDocTrans";
//                dsAllTable.Tables.Add(dtDoctrans);

//                dtDeclaration.TableName = "dtDeclaration";
//                dsAllTable.Tables.Add(dtDeclaration);

//                dtEmprMast.TableName = "dtEmprMast";
//                dsAllTable.Tables.Add(dtEmprMast);

//                dtAssetTrans.TableName = "dtAssetTrans";
//                dsAllTable.Tables.Add(dtAssetTrans);

//                //Adding CreationInfo to Dataset dsXML
//                DataRow dr = dsXML.Tables[0].NewRow();
//                dr["SWVersionNO"] = "v1.1";
//                dr["SWCreatedBy"] = "VATAS.Tax";
//                dr["XMLCreatedBy"] = "VATAS.Tax";
//                dr["XMLCreationDate"] = DateTime.Now.ToShortDateString();
//                dr["IntermediaryCity"] = "Jalandhar";
//                //dr["ITR1_Id"] = 0;
//                dsXML.Tables[0].Rows.Add(dr);
//                dr = null;

//                //Adding FormInfo to Dataset dsXML
//                dr = dsXML.Tables[1].NewRow();
//                dr["FormName"] = "ITR-1";
//                dr["Description"] = "For Indls having Income from Salary, Pension, family pension and Interest";
//                dr["AssessmentYear"] = DateTime.Now.Year;
//                dr["SchemaVer"] = "Ver1.0";
//                dr["FormVer"] = "Ver1.0";
//                //dr["ITR1_Id"] = 0;
//                dsXML.Tables[1].Rows.Add(dr);
//                dr = null;


//                string[] arrParam = new string[] { AssesseeID.ToString() };
//                //arrParam[0] = AssesseeID.ToString();
//                string[] condition = new string[dtMaster.Rows.Count];
//                DataTable dt = new DataTable();
//                //Loop for filling Dataset dsXML 
//                for (int i = 0; i < dtMaster.Rows.Count; i++)
//                {
//                    string condition2 = dtMaster.Rows[i]["FilterCondition"].ToString();
//                    string[] serial = dtMaster.Rows[i]["ColNo"].ToString().Split(',');
//                    //Selecting Paricular Colums from Datatset dsAllTables based on conditions
//                    DataRow[] rows = dsAllTable.Tables[dtMaster.Rows[i][5].ToString()].DefaultView.ToTable(false, dtMaster.Rows[i]["SelectCondition"].ToString().Split(',')).Select(condition2);
//                    if (rows.Length > 0)
//                    {
//                        if (serial.Length > 1)
//                        {
//                            DataTable dtserial = new DataTable();
//                            DataTable dtS2 = new DataTable();

//                            dtserial.Columns.Add("Serial", typeof(string));
//                            for (int j = 0; j < serial.Length; j++)
//                            {
//                                dtserial.Rows.Add(serial[j]);
//                            }

//                            dt = rows.CopyToDataTable();
//                            dtS2 = rows.CopyToDataTable();

//                            if (dtMaster.Rows[i]["IsZero"].ToString() != "NULL")
//                            {
//                                string[] arrTemp = System.Text.RegularExpressions.Regex.Split(dtMaster.Rows[i]["IsZero"].ToString(), "~");
//                                System.Collections.ArrayList arrConstIDs = new System.Collections.ArrayList();
//                                for (int k = 0; k < arrTemp.Length; k++)
//                                {
//                                    arrConstIDs.Add(arrTemp[k]);
//                                }
//                                int cntt = 0;
//                                for (int r = 0; r < Convert.ToInt32(arrConstIDs.Count); r++)
//                                {
//                                    if (dtS2.Rows.Count > cntt)
//                                    {
//                                        if (dtS2.Rows[cntt][0] != null)
//                                        {
//                                            if (arrConstIDs[r].ToString() == dtS2.Rows[cntt][0].ToString())
//                                            {
//                                                arrConstIDs.RemoveAt(r);
//                                                cntt += 1;
//                                                if (arrConstIDs.Count > 1)
//                                                    r = 0;
//                                                else if (arrConstIDs.Count == 1)
//                                                    r = -1;
//                                            }
//                                        }
//                                    }
//                                }
//                                for (int kk = 0; kk < arrConstIDs.Count; kk++)
//                                {
//                                    DataRow row1 = dtS2.NewRow();
//                                    row1[0] = arrConstIDs[kk];
//                                    row1[1] = "0";
//                                    row1[2] = "0";
//                                    dtS2.Rows.Add(row1);
//                                }
//                            }
//                            dt.Clear();
//                            dt.Rows.Clear();
//                            foreach (DataRow roww in dtS2.Rows)
//                            {
//                                DataRow ro1 = dt.NewRow();
//                                ro1.ItemArray = roww.ItemArray;
//                                dt.Rows.Add(ro1);
//                            }
//                            for (int x = 0; x < dtserial.Rows.Count; x++)
//                            {
//                                dtS2.Rows[x].ItemArray = dt.Rows[Convert.ToInt32(dtserial.Rows[x][0])].ItemArray;
//                                //dtS2.Rows[x].ItemArray = dt.Rows[(dt.Rows.Count > Convert.ToInt32(dtserial.Rows[x]["Serial"]) ? Convert.ToInt32(dtserial.Rows[x]["Serial"]) : (dt.Rows.Count - 1))].ItemArray;
//                            }
//                        }
//                        else
//                        {
//                            dt = rows.CopyToDataTable();
//                        }
//                    }
//                    if (rows.Length > 1)
//                    {
//                        DataRow row22 = dsXML.Tables[dtMaster.Rows[i][4].ToString()].NewRow();
//                        row22[0] = "0";
//                        dsXML.Tables[dtMaster.Rows[i][4].ToString()].Rows.Add(row22);

//                        dt = objXMLService.GenerateTransposedTable(dt);//Function to Transpose Datatable dt
//                        DataRow row2 = dsXML.Tables[dtMaster.Rows[i][4].ToString()].NewRow();
//                        row2.ItemArray = dt.Rows[0].ItemArray;

//                        int cntt = 0;
//                        //for (int w = 0; w < dsXML.Tables["UsrDeductUndChapVIA"].Columns.Count; w++)
//                        //{
//                        //    dsXML.Tables["UsrDeductUndChapVIA"].Rows[0][w] = "0";
//                        //}
//                        dsXML.Tables[dtMaster.Rows[i][4].ToString()].Rows.Add(row2);
//                    }
//                    else
//                    {
//                        foreach (DataRow row in rows)
//                        {
//                            if (i > 0)
//                            {
//                                if (dsXML.Tables[dtMaster.Rows[i - 1][4].ToString()].Columns[dsXML.Tables[dtMaster.Rows[i - 1][4].ToString()].Columns.Count - 1].ColumnName == row.Table.Columns[row.Table.Columns.Count - 1].ColumnName)
//                                {
//                                    if (dsXML.Tables[dtMaster.Rows[i - 1][4].ToString()].Rows.Count > 0)
//                                        dsXML.Tables[dtMaster.Rows[i][4].ToString()].ImportRow(row);
//                                }
//                                else
//                                {
//                                    dsXML.Tables[dtMaster.Rows[i][4].ToString()].ImportRow(row);
//                                }
//                            }
//                            else
//                            {
//                                dsXML.Tables[dtMaster.Rows[i][4].ToString()].ImportRow(row);
//                            }
//                        }
//                    }
//                }

//                //Formatting XML
//                StreamWriter xmlDoc = new StreamWriter(@"e:\" + dtNameMast.Rows[0]["PAN"].ToString() + ".xml");
//                dsXML.WriteXml(xmlDoc);
//                xmlDoc.Close();
//                string sLine = "";

//                sLine = System.IO.File.ReadAllText(@"e:\" + dtNameMast.Rows[0]["PAN"].ToString() + ".xml");
//                string[] arrInfo = System.IO.File.ReadAllLines(@"e:\" + dtNameMast.Rows[0]["PAN"].ToString() + ".xml");
//                for (int i = 0; i < arrInfo.Length; i++)
//                {
//                    arrInfo[i] = arrInfo[i].Replace("</", "`");
//                    arrInfo[i] = arrInfo[i].Replace("<", "< ");
//                    arrInfo[i] = arrInfo[i].Replace("< ", "<ITRForm:");
//                    arrInfo[i] = arrInfo[i].Replace("`", "</ITRForm:");
//                    arrInfo[i] = arrInfo[i].Replace("<ITRForm:?", "<?");
//                }
//                arrInfo[0] = arrInfo[0].Remove(0);
//                arrInfo[0] = "<?xml version='1.0' encoding='ISO-8859-1'?>";
//                arrInfo[1] = "<ITRETURN:ITR xmlns:ITRETURN='http://incometaxindiaefiling.gov.in/main' xmlns:ITR1FORM='http://incometaxindiaefiling.gov.in/ITR1' xmlns:ITRForm='http://incometaxindiaefiling.gov.in/master' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>";
//                arrInfo[2] = @"<ITR1FORM:ITR1>
//  <ITRForm:CreationInfo>" +
//                 " " + arrInfo[2];
//                arrInfo[arrInfo.Length - 2] = arrInfo[arrInfo.Length - 2] + @"</ITR1FORM:ITR1>";
//                arrInfo[arrInfo.Length - 1] = "</ITRETURN:ITR>";
//                System.IO.File.WriteAllLines(@"e:\" + dtNameMast.Rows[0]["PAN"].ToString() + "2.xml", arrInfo);

//                //lblmsg.Visible = true;
//                //lblmsg.Text = @"XML of PAN:" + dtNameMast.Rows[0]["PAN"].ToString() + " is saved in e drive successfully..!";

//            }
//        }
//        catch (Exception ex)
//        {
//            throw ex;
//        }
//    }

    //public DataTable selectDataForITR_1IncomeDeduction()
    //{
    //    con.Open();
    //    DataTable dt = new DataTable();
    //    string str = " ";
    //    SqlCommand cmd = new SqlCommand(str, con);
    //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
    //    adp.Fill(dt);
    //    con.Close();
    //    return dt;
    //}

    //public DataTable selectDataForUsrDeductUndChapVIA()
    //{
    //    con.Open();
    //    DataTable dt = new DataTable();
    //    string str = "select S80C as Section80C,S80CCC as Section80CCC,S80CCD as Section80CCDEmployeeOrSE,"+
    //                 " S80CCD as Section80CCDEmployer,S80D as Section80D,S80DD as Section80DD,S80DDB as Section80DDB,"+
    //                 " S80E as Section80E,0 as Section80EE,S80G as Section80G,S80GG as Section80GG,S80GGA as Section80GGA,"+
    //                 " S80GGC as Section80GGC,S80U as Section80U,S80RRB as Section80RRB,S80QQB as Section80QQB,0 as Section80CCG,"+
    //                 " 0 as Section80TTA,(S80C+S80CCC+S80CCD+S80CCD+S80D+S80DD+S80DDB+S80E+0+S80G+S80GG+S80GGA+S80GGC+S80U+S80RRB+S80QQB+0+0)"+
    //                 " as TotalChapVIADeductions,0 as ITR1_IncomeDeductions_Id from tmp_deductions_sch10 where AssesseeID='1181299695' ";
    //    SqlCommand cmd = new SqlCommand(str, con);
    //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
    //    adp.Fill(dt);
    //    con.Close();
    //    return dt;
    //}

    //public DataTable selectDataForDeductUndChapVIA()
    //{
    //    con.Open();
    //    DataTable dt = new DataTable();
    //    string str = "select S80C as Section80C,S80CCC as Section80CCC,S80CCD as Section80CCDEmployeeOrSE," +
    //                 " S80CCD as Section80CCDEmployer,S80D as Section80D,S80DD as Section80DD,S80DDB as Section80DDB," +
    //                 " S80E as Section80E,0 as Section80EE,S80G as Section80G,S80GG as Section80GG,S80GGA as Section80GGA," +
    //                 " S80GGC as Section80GGC,S80U as Section80U,S80RRB as Section80RRB,S80QQB as Section80QQB,0 as Section80CCG," +
    //                 " 0 as Section80TTA,(S80C+S80CCC+S80CCD+S80CCD+S80D+S80DD+S80DDB+S80E+0+S80G+S80GG+S80GGA+S80GGC+S80U+S80RRB+S80QQB+0+0)" +
    //                 " as TotalChapVIADeductions,0 as ITR1_IncomeDeductions_Id from tmp_deductions_sch10 where AssesseeID='1181299695' ";
    //    SqlCommand cmd = new SqlCommand(str, con);
    //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
    //    adp.Fill(dt);
    //    con.Close();
    //    return dt;
    //}
}