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
    /// Summary description for dalAssessee
    /// </summary>
    public class dalAssessee : dalConnection
    {
        #region Constructor
        public dalAssessee()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variable
        SqlCommand cmd;
        #endregion

        #region Functions
        public int InsertDataIndividual(denAssesseeIndividual objAssesseeIndividualDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procInsertNameMastIndividual", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objAssesseeIndividualDEN.UserName);
                cmd.Parameters.AddWithValue("@Status", objAssesseeIndividualDEN.Status);
                cmd.Parameters.AddWithValue("@PANNO", objAssesseeIndividualDEN.PANNO);
                cmd.Parameters.AddWithValue("@Vtype", objAssesseeIndividualDEN.Vtype);
                cmd.Parameters.AddWithValue("@Salute", objAssesseeIndividualDEN.Salute);
                cmd.Parameters.AddWithValue("@FirstName", objAssesseeIndividualDEN.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objAssesseeIndividualDEN.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objAssesseeIndividualDEN.LastName);
                cmd.Parameters.AddWithValue("@FatherName", objAssesseeIndividualDEN.FatherName);
                cmd.Parameters.AddWithValue("@DateofBirth", objAssesseeIndividualDEN.DateofBirth);
                cmd.Parameters.AddWithValue("@WardCircle", objAssesseeIndividualDEN.WardCircle);
                cmd.Parameters.AddWithValue("@TANNO", objAssesseeIndividualDEN.TANNO);
                cmd.Parameters.AddWithValue("@ResidentialStatus", objAssesseeIndividualDEN.ResStatus);
                cmd.Parameters.AddWithValue("@Email", objAssesseeIndividualDEN.EMail);
                cmd.Parameters.AddWithValue("@PEOutsideIndia", objAssesseeIndividualDEN.PEOutIndia);
                cmd.Parameters.AddWithValue("@PEInsideIndia", objAssesseeIndividualDEN.PEInIndia);
                cmd.Parameters.AddWithValue("@BusinessNature", objAssesseeIndividualDEN.BussNature);
                cmd.Parameters.AddWithValue("@TypeofAss", objAssesseeIndividualDEN.TypeofAss);
                cmd.Parameters.AddWithValue("@no_of_dependents", objAssesseeIndividualDEN.no_of_dependents);
                cmd.Parameters.AddWithValue("@EmployerCategory", (objAssesseeIndividualDEN.EmployerCategory == null) ? "" : objAssesseeIndividualDEN.EmployerCategory);
                cmd.Parameters.AddWithValue("@ServiceTaxRegNo", (objAssesseeIndividualDEN.ServiceTaxRegNo == null) ? "" : objAssesseeIndividualDEN.ServiceTaxRegNo);

                cmd.Parameters.AddWithValue("@AdhaarNo", objAssesseeIndividualDEN.AdhaarNo);
                //cmd.ExecuteNonQuery();
                int lastNameID = Convert.ToInt32(cmd.ExecuteScalar());
                return lastNameID;

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

        public int InsertDataIndividualDirect(denAssesseeIndividual objAssesseeIndividualDEN)
        {
            int lastNameID = 0;
            try
            {
                this.pConn();
                SqlCommand cmd2 = new SqlCommand("select count(*) from namemast where PANNO=@PANNO and UserName = @UserName", this.SqlCon);
                cmd2.Parameters.AddWithValue("@PANNO", objAssesseeIndividualDEN.PANNO);
                cmd2.Parameters.AddWithValue("@UserName", objAssesseeIndividualDEN.UserName);
                int cnt = Convert.ToInt32(cmd2.ExecuteScalar());
                if (cnt == 0)
                {
                    cmd = new SqlCommand(@"insert into namemast (username,
			Vtype,
			Status,
			salute,
			firstname,
			middlename,
			LastName,
			fathersname,
			DateofBirth,
			wardcircle,
			PANNO,
			TANNO,
			ResidentialStatus,
			Email,
			PEOutsideIndia,
			PEInsideIndia,
			BusinessNature,
			typeofass,
			no_of_dependents,
			EmployerCategory,ServiceTaxRegNo,AdharCardNo
			)
		 values
		(	@UserName,
			@Vtype,
			@Status,
			@Salute,
			@FirstName,
			@MiddleName,
			@LastName,
			@FatherName,
			@DateofBirth,
			@WardCircle,
			@PANNO,
			@TANNO,
			@ResidentialStatus,
			@Email,
			@PEOutsideIndia,
			@PEInsideIndia,
			@BusinessNature,
			@TypeofAss,
			@no_of_dependents
			,@EmployerCategory,@ServiceTaxRegNo,@AdhaarNo); select @@identity", this.SqlCon);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", objAssesseeIndividualDEN.UserName);
                    cmd.Parameters.AddWithValue("@Status", objAssesseeIndividualDEN.Status);
                    cmd.Parameters.AddWithValue("@PANNO", objAssesseeIndividualDEN.PANNO);
                    cmd.Parameters.AddWithValue("@Vtype", objAssesseeIndividualDEN.Vtype);
                    cmd.Parameters.AddWithValue("@Salute", objAssesseeIndividualDEN.Salute);
                    cmd.Parameters.AddWithValue("@FirstName", objAssesseeIndividualDEN.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", objAssesseeIndividualDEN.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", objAssesseeIndividualDEN.LastName);
                    cmd.Parameters.AddWithValue("@FatherName", objAssesseeIndividualDEN.FatherName);
                    cmd.Parameters.AddWithValue("@DateofBirth", objAssesseeIndividualDEN.DateofBirth);
                    cmd.Parameters.AddWithValue("@WardCircle", objAssesseeIndividualDEN.WardCircle);
                    cmd.Parameters.AddWithValue("@TANNO", objAssesseeIndividualDEN.TANNO);
                    cmd.Parameters.AddWithValue("@ResidentialStatus", objAssesseeIndividualDEN.ResStatus);
                    cmd.Parameters.AddWithValue("@Email", objAssesseeIndividualDEN.EMail);
                    cmd.Parameters.AddWithValue("@PEOutsideIndia", objAssesseeIndividualDEN.PEOutIndia);
                    cmd.Parameters.AddWithValue("@PEInsideIndia", objAssesseeIndividualDEN.PEInIndia);
                    cmd.Parameters.AddWithValue("@BusinessNature", objAssesseeIndividualDEN.BussNature);
                    cmd.Parameters.AddWithValue("@TypeofAss", objAssesseeIndividualDEN.TypeofAss);
                    cmd.Parameters.AddWithValue("@no_of_dependents", objAssesseeIndividualDEN.no_of_dependents);
                    cmd.Parameters.AddWithValue("@EmployerCategory", (objAssesseeIndividualDEN.EmployerCategory == null) ? "" : objAssesseeIndividualDEN.EmployerCategory);
                    cmd.Parameters.AddWithValue("@ServiceTaxRegNo", (objAssesseeIndividualDEN.ServiceTaxRegNo == null) ? "" : objAssesseeIndividualDEN.ServiceTaxRegNo);

                    cmd.Parameters.AddWithValue("@AdhaarNo", objAssesseeIndividualDEN.AdhaarNo);
                    //cmd.ExecuteNonQuery();
                    lastNameID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return lastNameID;
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



        //Function to Select Data of AssesseeIndividual
        public denAssesseeIndividual GetDataIndividual(string PAN)
        {
            try
            {
                this.pConn();
                denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
                cmd = new SqlCommand("selectdataindividual", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PANNO", PAN);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable ddt = new DataTable();
                adp.Fill(ddt);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objAssesseeIndividual.PANNO = Convert.ToString(reader["panno"]);
                    objAssesseeIndividual.Status = (reader.IsDBNull(2)) ? 0 : Convert.ToInt16(reader["status"]);

                    objAssesseeIndividual.Salute = reader.IsDBNull(3) ? 0 : Convert.ToInt16(reader["salute"]);
                    objAssesseeIndividual.FirstName = Convert.ToString(reader["firstname"]);
                    objAssesseeIndividual.MiddleName = Convert.ToString(reader["middlename"]);
                    objAssesseeIndividual.LastName = Convert.ToString(reader["lastname"]);
                    objAssesseeIndividual.FatherName = Convert.ToString(reader["fathersname"]);
                    objAssesseeIndividual.DateofBirth = Convert.ToString(reader["dateofbirth"]);
                    objAssesseeIndividual.WardCircle = Convert.ToString(reader["wardcircle"]);
                    objAssesseeIndividual.TANNO = Convert.ToString(reader["tanno"]);
                    objAssesseeIndividual.ResStatus = reader.IsDBNull(11) ? 0 : Convert.ToInt16(reader["residentialstatus"]); // Convert.ToInt16(reader["residentialstatus"]);
                    objAssesseeIndividual.EMail = Convert.ToString(reader["email"]);
                    objAssesseeIndividual.BussNature = Convert.ToString(reader["businessnature"]);
                    //objAssesseeIndividual.STDCODE = Convert.ToString(reader["stdcode"]);
                    //objAssesseeIndividual.PhoneNo = Convert.ToString(reader["phoneno"]);
                    //objAssesseeIndividual.Address = Convert.ToString(reader["address"]);
                    objAssesseeIndividual.NameID = Convert.ToString(reader["NameID"]);

                }
                return objAssesseeIndividual;
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

        //Function to Select Data of AssesseeIndividual w.r.t. NameID
        public denAssesseeIndividual GetDataIndividualByNameID(string NameID)
        {
            try
            {
                this.pConn();
                denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
                cmd = new SqlCommand("select * from namemast where NameID=@NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objAssesseeIndividual.PANNO = Convert.ToString(reader["panno"]);
                    objAssesseeIndividual.Status = Convert.ToInt16(reader["status"]);

                    objAssesseeIndividual.Salute = reader.IsDBNull(3) ? 0 : Convert.ToInt16(reader["salute"]);
                    objAssesseeIndividual.FirstName = Convert.ToString(reader["firstname"]);
                    objAssesseeIndividual.MiddleName = Convert.ToString(reader["middlename"]);
                    objAssesseeIndividual.LastName = Convert.ToString(reader["lastname"]);
                    objAssesseeIndividual.FatherName = Convert.ToString(reader["fathersname"]);
                    objAssesseeIndividual.DateofBirth = Convert.ToString(reader["dateofbirth"]);
                    objAssesseeIndividual.WardCircle = Convert.ToString(reader["wardcircle"]);
                    objAssesseeIndividual.TANNO = Convert.ToString(reader["tanno"]);
                    objAssesseeIndividual.ResStatus = Convert.ToInt16(reader["residentialstatus"]);
                    objAssesseeIndividual.EMail = Convert.ToString(reader["email"]);
                    objAssesseeIndividual.BussNature = Convert.ToString(reader["businessnature"]);
                    objAssesseeIndividual.NameID = Convert.ToString(reader["NameID"]);
                }
                return objAssesseeIndividual;
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

        //Created to get Minimum Assessee Details like FirstName, MiddleName, LastName with PAN
        public denAssesseeIndividual getAssesseeMinDetail(string PAN)
        {
            try
            {
                this.pConn();
                denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
                cmd = new SqlCommand("select FirstName, MiddleName, LastName, PANNo from namemast where PanNo = @PANNO", this.SqlCon);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PANNO", PAN);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objAssesseeIndividual.PANNO = Convert.ToString(reader["panno"]);
                    objAssesseeIndividual.FirstName = Convert.ToString(reader["firstname"]);
                    objAssesseeIndividual.MiddleName = Convert.ToString(reader["middlename"]);
                    objAssesseeIndividual.LastName = Convert.ToString(reader["lastname"]);
                }
                return objAssesseeIndividual;
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

        //Function to Select Data of AssesseeIndividual w.r.t. User

        public denAssesseeIndividual GetDataIndividual(string PAN,string User)
        {
            try
            {
                this.pConn();
                denAssesseeIndividual objAssesseeIndividual = new denAssesseeIndividual();
                cmd = new SqlCommand("selectdataIndividual_User", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PANNO", PAN);
                cmd.Parameters.AddWithValue("@username", User);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objAssesseeIndividual.PANNO = Convert.ToString(reader["panno"]);
                    objAssesseeIndividual.Status = Convert.ToInt16(reader["status"]);

                    objAssesseeIndividual.Salute = reader.IsDBNull(2) ? 0 : Convert.ToInt16(reader["salute"]);
                    objAssesseeIndividual.FirstName = Convert.ToString(reader["firstname"]);
                    objAssesseeIndividual.MiddleName = Convert.ToString(reader["middlename"]);
                    objAssesseeIndividual.LastName = Convert.ToString(reader["lastname"]);
                    objAssesseeIndividual.FatherName = Convert.ToString(reader["fathersname"]);
                    objAssesseeIndividual.DateofBirth = Convert.ToString(reader["dateofbirth"]);
                    objAssesseeIndividual.WardCircle = Convert.ToString(reader["wardcircle"]);
                    objAssesseeIndividual.TANNO = Convert.ToString(reader["tanno"]);
                    objAssesseeIndividual.ResStatus = Convert.ToInt16(reader["residentialstatus"]);
                    objAssesseeIndividual.EMail = Convert.ToString(reader["email"]);
                    objAssesseeIndividual.BussNature = Convert.ToString(reader["businessnature"]);
                    objAssesseeIndividual.STDCODE = Convert.ToString(reader["stdcode"]);
                    objAssesseeIndividual.PhoneNo = Convert.ToString(reader["phoneno"]);
                    objAssesseeIndividual.Address = Convert.ToString(reader["address"]);
                    objAssesseeIndividual.NameID = Convert.ToString(reader["NameID"]);
                    objAssesseeIndividual.ServiceTaxRegNo = Convert.ToString(reader["ServiceTaxRegNo"]);
                    objAssesseeIndividual.AdhaarNo = Convert.ToString(reader["AdharCardNo"]);
                }
                return objAssesseeIndividual;
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

        //Function to select data of Partnership
        public denAssesseePartner GetDataPartner(string PAN)
        {
            try
            {
                this.pConn();
                denAssesseePartner objAssesseePartnerDEN = new denAssesseePartner();
                cmd = new SqlCommand("Selectdatapartner", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PANNO", PAN);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objAssesseePartnerDEN.PANNO = Convert.ToString(reader["panno"]);
                    objAssesseePartnerDEN.Status = Convert.ToInt16(reader["status"]);
                   
                    objAssesseePartnerDEN.LastName = Convert.ToString(reader["lastname"]);
                   
                    objAssesseePartnerDEN.DateofBirth = Convert.ToString(reader["dateofbirth"]);
                    objAssesseePartnerDEN.WardCircle = Convert.ToString(reader["wardcircle"]);
                    objAssesseePartnerDEN.TANNO = Convert.ToString(reader["tanno"]);
                    objAssesseePartnerDEN.ResStatus = Convert.ToInt16(reader["residentialstatus"]);
                    objAssesseePartnerDEN.EMail = Convert.ToString(reader["email"]);
                    objAssesseePartnerDEN.BussNature = Convert.ToString(reader["businessnature"]);
                    objAssesseePartnerDEN.STDCODE = Convert.ToString(reader["stdcode"]);
                    objAssesseePartnerDEN.PhoneNo = Convert.ToString(reader["phoneno"]);
                    objAssesseePartnerDEN.Address = Convert.ToString(reader["address"]);
                }
                return objAssesseePartnerDEN;
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
        //function to select data in case of company

        public denAssesseeCompany GetDataCompany(string PAN)
        {
            try
            {
                this.pConn();
                denAssesseeCompany objAssesseeCompanyDEN = new denAssesseeCompany();
                cmd = new SqlCommand("SelectdataCompany", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PANNO", PAN);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objAssesseeCompanyDEN.PANNO = Convert.ToString(reader["panno"]);
                    objAssesseeCompanyDEN.Status = Convert.ToInt16(reader["status"]);
                    objAssesseeCompanyDEN.LastName = Convert.ToString(reader["lastname"]);
                    objAssesseeCompanyDEN.DateofBirth = Convert.ToString(reader["dateofbirth"]);
                    objAssesseeCompanyDEN.WardCircle = Convert.ToString(reader["wardcircle"]);
                    objAssesseeCompanyDEN.TANNO = Convert.ToString(reader["tanno"]);
                    objAssesseeCompanyDEN.ResStatus = Convert.ToInt16(reader["residentialstatus"]);
                    objAssesseeCompanyDEN.EMail = Convert.ToString(reader["email"]);
                    objAssesseeCompanyDEN.BussNature = Convert.ToString(reader["businessnature"]);
                    objAssesseeCompanyDEN.CompNature = Convert.ToString(reader["compnature"]);
                    objAssesseeCompanyDEN.CompStatus = Convert.ToString(reader["compstatus"]);
                    objAssesseeCompanyDEN.STDCODE = Convert.ToString(reader["stdcode"]);
                    objAssesseeCompanyDEN.PhoneNo = Convert.ToString(reader["phoneno"]);
                    objAssesseeCompanyDEN.Address = Convert.ToString(reader["address"]);
                }
                return objAssesseeCompanyDEN;
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

        //Function to select data in other cases HUF,AOP,COOP
        public denAssesseeMain GetDataGeneral(string PAN)
        {
            try
            {
                this.pConn();
                denAssesseeMain objAssesseeMainDEN = new denAssesseeMain();
                cmd = new SqlCommand("Selectdatageneral", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PANNO", PAN);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objAssesseeMainDEN.PANNO = Convert.ToString(reader["panno"]);
                    objAssesseeMainDEN.Status = Convert.ToInt16(reader["status"]);
                    objAssesseeMainDEN.LastName = Convert.ToString(reader["lastname"]);
                    objAssesseeMainDEN.DateofBirth = Convert.ToString(reader["dateofbirth"]);
                    objAssesseeMainDEN.WardCircle = Convert.ToString(reader["wardcircle"]);
                    objAssesseeMainDEN.TANNO = Convert.ToString(reader["tanno"]);
                    objAssesseeMainDEN.ResStatus = Convert.ToInt16(reader["residentialstatus"]);
                    objAssesseeMainDEN.EMail = Convert.ToString(reader["email"]);
                    objAssesseeMainDEN.BussNature = Convert.ToString(reader["businessnature"]);
                    objAssesseeMainDEN.STDCODE = Convert.ToString(reader["stdcode"]);
                    objAssesseeMainDEN.PhoneNo = Convert.ToString(reader["phoneno"]);
                    objAssesseeMainDEN.Address = Convert.ToString(reader["address"]);
                }
                return objAssesseeMainDEN;
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
        public int InsertDataGeneral(denAssesseeMain objAssesseeMainDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procInsertNameMastGeneral", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objAssesseeMainDEN.UserName);
                cmd.Parameters.AddWithValue("@Vtype", objAssesseeMainDEN.Vtype);
                cmd.Parameters.AddWithValue("@Status", objAssesseeMainDEN.Status);
                cmd.Parameters.AddWithValue("@LastName", objAssesseeMainDEN.LastName);
                cmd.Parameters.AddWithValue("@DateofBirth", objAssesseeMainDEN.DateofBirth);
                cmd.Parameters.AddWithValue("@WardCircle", objAssesseeMainDEN.WardCircle);
                cmd.Parameters.AddWithValue("@PANNO", objAssesseeMainDEN.PANNO);
                cmd.Parameters.AddWithValue("@TANNO", objAssesseeMainDEN.TANNO);
                cmd.Parameters.AddWithValue("@ResidentialStatus", objAssesseeMainDEN.ResStatus);
                cmd.Parameters.AddWithValue("@Email", objAssesseeMainDEN.EMail);
                cmd.Parameters.AddWithValue("@PEOutsideIndia", objAssesseeMainDEN.PEOutIndia);
                cmd.Parameters.AddWithValue("@PEInsideIndia", objAssesseeMainDEN.PEInIndia);
                cmd.Parameters.AddWithValue("@BusinessNature", objAssesseeMainDEN.BussNature);
                cmd.Parameters.AddWithValue("@TypeofAss", objAssesseeMainDEN.TypeofAss);
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

        public int InsertDataCompany(denAssesseeCompany objAssesseeCompanyDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procInsertNameMastCompany", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objAssesseeCompanyDEN.UserName);
                cmd.Parameters.AddWithValue("@Vtype", objAssesseeCompanyDEN.Vtype);
                cmd.Parameters.AddWithValue("@Status", objAssesseeCompanyDEN.Status);
                cmd.Parameters.AddWithValue("@LastName", objAssesseeCompanyDEN.LastName);
                cmd.Parameters.AddWithValue("@DateofIncorp", objAssesseeCompanyDEN.DateofBirth);
                cmd.Parameters.AddWithValue("@WardCircle", objAssesseeCompanyDEN.WardCircle);
                cmd.Parameters.AddWithValue("@PANNO", objAssesseeCompanyDEN.PANNO);
                cmd.Parameters.AddWithValue("@TANNO", objAssesseeCompanyDEN.TANNO);
                cmd.Parameters.AddWithValue("@ResidentialStatus", objAssesseeCompanyDEN.ResStatus);
                cmd.Parameters.AddWithValue("@Email", objAssesseeCompanyDEN.EMail);
                cmd.Parameters.AddWithValue("@PEOutsideIndia", objAssesseeCompanyDEN.PEOutIndia);
                cmd.Parameters.AddWithValue("@PEInsideIndia", objAssesseeCompanyDEN.PEInIndia);
                cmd.Parameters.AddWithValue("@BusinessNature", objAssesseeCompanyDEN.BussNature);
                cmd.Parameters.AddWithValue("@CompStatus", objAssesseeCompanyDEN.CompStatus);
                cmd.Parameters.AddWithValue("@CompNature", objAssesseeCompanyDEN.CompNature);
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
        public int InsertDataPartner(denAssesseePartner objAssesseePartnerDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procInsertNameMastPartnership", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objAssesseePartnerDEN.UserName);
                cmd.Parameters.AddWithValue("@Vtype", objAssesseePartnerDEN.Vtype);
                cmd.Parameters.AddWithValue("@Status", objAssesseePartnerDEN.Status);
                cmd.Parameters.AddWithValue("@LastName", objAssesseePartnerDEN.LastName);
                cmd.Parameters.AddWithValue("@DateofBirth", objAssesseePartnerDEN.DateofBirth);
                cmd.Parameters.AddWithValue("@WardCircle", objAssesseePartnerDEN.WardCircle);
                cmd.Parameters.AddWithValue("@PANNO", objAssesseePartnerDEN.PANNO);
                cmd.Parameters.AddWithValue("@TANNO", objAssesseePartnerDEN.TANNO);
                cmd.Parameters.AddWithValue("@ResidentialStatus", objAssesseePartnerDEN.ResStatus);
                cmd.Parameters.AddWithValue("@Email", objAssesseePartnerDEN.EMail);
                cmd.Parameters.AddWithValue("@PEOutsideIndia", objAssesseePartnerDEN.PEOutIndia);
                cmd.Parameters.AddWithValue("@PEInsideIndia", objAssesseePartnerDEN.PEInIndia);
                cmd.Parameters.AddWithValue("@BusinessNature", objAssesseePartnerDEN.BussNature);
                cmd.Parameters.AddWithValue("@TypeofFirm", objAssesseePartnerDEN.TypeofFirm);
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

        public int UpdateDataIndividual(denAssesseeIndividual objAssesseeIndividualDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procUpdateNameMastIndividual", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", objAssesseeIndividualDEN.Status);
                cmd.Parameters.AddWithValue("@Salute", objAssesseeIndividualDEN.Salute);
                cmd.Parameters.AddWithValue("@FirstName", objAssesseeIndividualDEN.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objAssesseeIndividualDEN.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objAssesseeIndividualDEN.LastName);
                cmd.Parameters.AddWithValue("@FatherName", objAssesseeIndividualDEN.FatherName);
                cmd.Parameters.AddWithValue("@DateofBirth", objAssesseeIndividualDEN.DateofBirth);
                cmd.Parameters.AddWithValue("@WardCircle", objAssesseeIndividualDEN.WardCircle);
                cmd.Parameters.AddWithValue("@PANNO", objAssesseeIndividualDEN.PANNO);
                cmd.Parameters.AddWithValue("@TANNO", objAssesseeIndividualDEN.TANNO);
                cmd.Parameters.AddWithValue("@ResidentialStatus", objAssesseeIndividualDEN.ResStatus);
                cmd.Parameters.AddWithValue("@Email", objAssesseeIndividualDEN.EMail);
                cmd.Parameters.AddWithValue("@PEOutsideIndia", objAssesseeIndividualDEN.PEOutIndia);
                cmd.Parameters.AddWithValue("@PEInsideIndia", objAssesseeIndividualDEN.PEInIndia);
                cmd.Parameters.AddWithValue("@BusinessNature", objAssesseeIndividualDEN.BussNature);
                cmd.Parameters.AddWithValue("@TypeofAss", objAssesseeIndividualDEN.TypeofAss);
                cmd.Parameters.AddWithValue("@no_of_dependents", objAssesseeIndividualDEN.no_of_dependents);
                cmd.Parameters.AddWithValue("@ServiceTaxRegNo", (objAssesseeIndividualDEN.ServiceTaxRegNo == null) ? "" : objAssesseeIndividualDEN.ServiceTaxRegNo);

                cmd.Parameters.AddWithValue("@AdhaarNo", objAssesseeIndividualDEN.AdhaarNo);
                cmd.ExecuteNonQuery();
                return 0;

                

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
        }

        public int UpdateDataGeneral(denAssesseeMain objAssesseeMainDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procUpdateNameMastGeneral", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Status", objAssesseeMainDEN.Status);
                cmd.Parameters.AddWithValue("@LastName", objAssesseeMainDEN.LastName);
                cmd.Parameters.AddWithValue("@DateofBirth", objAssesseeMainDEN.DateofBirth);
                cmd.Parameters.AddWithValue("@WardCircle", objAssesseeMainDEN.WardCircle);
                cmd.Parameters.AddWithValue("@PANNO", objAssesseeMainDEN.PANNO);
                cmd.Parameters.AddWithValue("@TANNO", objAssesseeMainDEN.TANNO);
                cmd.Parameters.AddWithValue("@ResidentialStatus", objAssesseeMainDEN.ResStatus);
                cmd.Parameters.AddWithValue("@Email", objAssesseeMainDEN.EMail);
                cmd.Parameters.AddWithValue("@PEOutsideIndia", objAssesseeMainDEN.PEOutIndia);
                cmd.Parameters.AddWithValue("@PEInsideIndia", objAssesseeMainDEN.PEInIndia);
                cmd.Parameters.AddWithValue("@BusinessNature", objAssesseeMainDEN.BussNature);
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

        // following function is specific to the ITR-1 XML only as we need to provide the EmployerCategory in there

        public void addEmployerCategory(string NameID,int empCat)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("update namemast set EmployerCategory = @empcat where NameID = @NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                cmd.Parameters.AddWithValue("@empcat", Convert.ToInt16(empCat));
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

        public int UpdateDataCompany(denAssesseeCompany objAssesseeCompanyDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procUpdateNameMastCompany", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Status", objAssesseeCompanyDEN.Status);
                cmd.Parameters.AddWithValue("@LastName", objAssesseeCompanyDEN.LastName);
                cmd.Parameters.AddWithValue("@DateofIncorp", objAssesseeCompanyDEN.DateofBirth);
                cmd.Parameters.AddWithValue("@WardCircle", objAssesseeCompanyDEN.WardCircle);
                cmd.Parameters.AddWithValue("@PANNO", objAssesseeCompanyDEN.PANNO);
                cmd.Parameters.AddWithValue("@TANNO", objAssesseeCompanyDEN.TANNO);
                cmd.Parameters.AddWithValue("@ResidentialStatus", objAssesseeCompanyDEN.ResStatus);
                cmd.Parameters.AddWithValue("@Email", objAssesseeCompanyDEN.EMail);
                cmd.Parameters.AddWithValue("@PEOutsideIndia", objAssesseeCompanyDEN.PEOutIndia);
                cmd.Parameters.AddWithValue("@PEInsideIndia", objAssesseeCompanyDEN.PEInIndia);
                cmd.Parameters.AddWithValue("@BusinessNature", objAssesseeCompanyDEN.BussNature);
                cmd.Parameters.AddWithValue("@CompStatus", objAssesseeCompanyDEN.CompStatus);
                cmd.Parameters.AddWithValue("@CompNature", objAssesseeCompanyDEN.CompNature);
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

        public int UpdateDataPartner(denAssesseePartner objAssesseePartnerDEN)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procUpdateNameMastPartnership", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Status", objAssesseePartnerDEN.Status);
                cmd.Parameters.AddWithValue("@LastName", objAssesseePartnerDEN.LastName);
                cmd.Parameters.AddWithValue("@DateofBirth", objAssesseePartnerDEN.DateofBirth);
                cmd.Parameters.AddWithValue("@WardCircle", objAssesseePartnerDEN.WardCircle);
                cmd.Parameters.AddWithValue("@PANNO", objAssesseePartnerDEN.PANNO);
                cmd.Parameters.AddWithValue("@TANNO", objAssesseePartnerDEN.TANNO);
                cmd.Parameters.AddWithValue("@ResidentialStatus", objAssesseePartnerDEN.ResStatus);
                cmd.Parameters.AddWithValue("@Email", objAssesseePartnerDEN.EMail);
                cmd.Parameters.AddWithValue("@PEOutsideIndia", objAssesseePartnerDEN.PEOutIndia);
                cmd.Parameters.AddWithValue("@PEInsideIndia", objAssesseePartnerDEN.PEInIndia);
                cmd.Parameters.AddWithValue("@BusinessNature", objAssesseePartnerDEN.BussNature);
                cmd.Parameters.AddWithValue("@TypeofFirm", objAssesseePartnerDEN.TypeofFirm);
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

        public DataTable Select(Int64 NameID)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"select (ISNULL(FirstName,'') + ' ' + (case MiddleName when '' then '' else (MiddleName + ' ') end) + LastName) as name,PanNo,FathersName,DateofBirth from namemast where 
                                        NameID=@NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
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

        public DataTable SelectAll(string NameID)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"select * from namemast where NameID=@NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
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

        public List<denAssesseeIndividual> Select(string username)
        {
            List<denAssesseeIndividual> LstAssessees = new List<denAssesseeIndividual>();
            denAssesseeIndividual objdenAssesseeIndividual;
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"select NameID from namemast where 
                                        username=@username", this.SqlCon);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objdenAssesseeIndividual = new denAssesseeIndividual();                    
                    objdenAssesseeIndividual.NameID = reader.GetString(0);
                    LstAssessees.Add(objdenAssesseeIndividual);
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
            return LstAssessees;
        }

        public DataTable SelectBusinessCategories()
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"select * from BusinessCategories", this.SqlCon);
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

        //public denAssesseeIndividual GetIndividualData(string PAN)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //    }
        //}
        //Add ITR for complete Assessee Session
        public void Add_AssesseeITR()
        {
            try
            {
                this.pConn();
                SqlCommand cmd2 = new SqlCommand("delete from tbl_Assessee_ITR where NameID= @NameID", this.SqlCon);
                cmd2.Parameters.AddWithValue("@NameID", HttpContext.Current.Session["NameID"].ToString());
                cmd2.ExecuteNonQuery();

                cmd = new SqlCommand("insert into tbl_Assessee_ITR values(@NameID,@ITRType,@AY)", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", HttpContext.Current.Session["NameID"].ToString());
                cmd.Parameters.AddWithValue("@ITRType", HttpContext.Current.Session["ITR"].ToString());
                cmd.Parameters.AddWithValue("@AY", HttpContext.Current.Session["AY"].ToString());
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


        //insert data into bankmast table
        public void AddBankMast(string AssessId,string BankName,string Address,string AccountType,string AccountNo,string IFSCCode)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("insert into BankMast (AssesseeID,BankName,Address,AccountType,AccountNo,IFSCCode)values(@AId,@Bname,@Add,@Atype,@AccNo,@IFSCCode)", this.SqlCon);
                cmd.Parameters.AddWithValue("@AID", AssessId);
                cmd.Parameters.AddWithValue("@Bname", BankName);
                cmd.Parameters.AddWithValue("@Add", Address);
                cmd.Parameters.AddWithValue("@AType", AccountType);
                cmd.Parameters.AddWithValue("@AccNo", AccountNo);
                cmd.Parameters.AddWithValue("@IFSCCode", IFSCCode);
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
        //select data from bankmast
        public DataTable getBankMast(string NameId)
        {
            try
            {
                this.pConn();

                cmd = new SqlCommand("select BankID,BankName,Address,case when AccountType='2' then 'Savings' when AccountType='3' then 'Current' end as AccountType,AccountNo,IFSCCode from BankMast where AssesseeID=@AId", this.SqlCon);
                cmd.Parameters.AddWithValue("@AId", NameId);
                DataTable dt = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
                else
                {   
                    DataColumn col1 = new DataColumn("BankID", Type.GetType("System.Int32"));
                    DataColumn col2 = new DataColumn("BankName", Type.GetType("System.String"));
                    DataColumn col3 = new DataColumn("Address", Type.GetType("System.String"));
                    DataColumn col4 = new DataColumn("AccountNo", Type.GetType("System.String"));
                    DataColumn col5 = new DataColumn("AccountType", Type.GetType("System.String"));
                    DataColumn col6 = new DataColumn("IFSCCode", Type.GetType("System.String"));
                    
                    dt.Columns.Add(col1);
                    dt.Columns.Add(col2);
                    dt.Columns.Add(col3);
                    dt.Columns.Add(col4);
                    dt.Columns.Add(col5);
                    dt.Columns.Add(col6);
                }
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
      //Update bank mast assessee id
        public void UpdateBankMast(string SessionID, string AsseseeID)
        {
            try
            {
                this.pConn();

                cmd = new SqlCommand("Update BankMast set AssesseeID=@aid where AssesseeID=@Oldaid", this.SqlCon);
               
                cmd.Parameters.AddWithValue("@aid", AsseseeID);
                cmd.Parameters.AddWithValue("@oldaid",SessionID);
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
        //Update AccID according to VatasSolution.dbo.Accounts
        public void UpdateAccID(string AsseseeID, string PAN)
        {
            try
            {
                this.pConn();

                cmd = new SqlCommand("update NameMast set AccID = (select top(1) AccID from VatasSolution.dbo.Accounts where PAN = @PAN order by AccID desc) where NameID = @NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", AsseseeID);
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
        //update bankmast by bankid
        public void UpdateBankMastByID(string BName,string Address,string AccountType,string AccNo,string IFSCCode,int BankID)
        {
            try
            {
                this.pConn();

                cmd = new SqlCommand("Update BankMast set BankName=@Bn,Address=@Add,AccountType=@At,AccountNo=@An,IFSCCode=@IC where BankID=@BID", this.SqlCon);

                cmd.Parameters.AddWithValue("@Bn", BName);
                cmd.Parameters.AddWithValue("@Add", Address);
                cmd.Parameters.AddWithValue("@At", AccountType);
                cmd.Parameters.AddWithValue("@IC", IFSCCode);
                cmd.Parameters.AddWithValue("@An", AccNo);
                cmd.Parameters.AddWithValue("@BID",BankID);
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
        //delete from bankmast
        public void DeleteBankMast(string AssessId)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("delete from bankmast where AssesseeID=@AID", this.SqlCon);
                cmd.Parameters.AddWithValue("@AID", AssessId);

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

        //delete from bankmast w.r.t. Bank ID
        public void DeleteBankMast(Int64 BankID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("delete from bankmast where BankID=@BankID", this.SqlCon);
                cmd.Parameters.AddWithValue("@BankID", BankID);
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

        //delete from StoreTrans
        public void DeleteStoreTrans(string AssessId, string AY)
        {
            try
            {
                this.pConn();
                //cmd = new SqlCommand("proc_ChkSTandSFT", this.SqlCon);
                cmd = new SqlCommand("delete from storetrans where NameID=@NameID and AY=@AY", this.SqlCon);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameId", AssessId);
                cmd.Parameters.AddWithValue("@AY", AY);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("delete from storeftrans where NameID=@NameID and AY=@AY", this.SqlCon);
                cmd2.Parameters.AddWithValue("@NameId", AssessId);
                cmd2.Parameters.AddWithValue("@AY", AY);
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

        //delete from StoreTrans
        public void DeleteStoreTrans(string AssessId)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("delete from storetrans where NameID=@NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameId", AssessId);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("delete from storeftrans where NameID=@NameID", this.SqlCon);
                cmd2.Parameters.AddWithValue("@NameId", AssessId);
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

        //select max banid from bankmast
        public int BankID()
        {
            int ID = 0;
            try
            {
                this.pConn();
                SqlCommand cmd2 = new SqlCommand("select count(*) from bankmast", this.SqlCon);
                int cnt = Convert.ToInt32(cmd2.ExecuteScalar());
                if (cnt != 0)
                {
                    cmd = new SqlCommand("select max(BankID) from bankmast ", this.SqlCon);
                    ID = Convert.ToInt32(cmd.ExecuteScalar());
                }
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
        //select data from namemast and addmast by nameid and status condition
        public DataTable getPdfData(string NameID,int status)
        {
            DataTable dt = new DataTable();
            try
            {
                this.pConn();
                //cmd = new SqlCommand(@"select * from NameMast left outer join AdrsMast on NameMast.PANNo=AdrsMast.NameID  where NameMast.PANNo=@NameID and NameMast.Status=@Status", this.SqlCon);
                cmd = new SqlCommand(@"select * from NameMast where PANNo=@NameID and Status=@Status", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID",NameID);

                cmd.Parameters.AddWithValue("@Status", status);
                SqlDataAdapter adppdf = new SqlDataAdapter(cmd);
                adppdf.Fill(dt);
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

        //Update User of Assessee
        public void UpdateUser(string Super_User_Id, string NameID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("Update namemast set username=(select emailID from db_Admin.dbo.tbl_UserGroup_Registration where Super_User_Id=@Super_User_Id) where NameID=@NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@Super_User_Id", Super_User_Id);
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

        //Function Added by Mudit on 19/08/2015 to Check the Existence of PAN in NameMast for BulkXMLUpload
        public string IsPANExists(string PAN)
        {
            int IsExists = 0;
            string IsPANExists = "";
            int count = 0;
            //string PANreturn = "";
            try
            {
                this.pConn();
                SqlCommand cmd2 = new SqlCommand("select NameID from namemast where PanNo='" + PAN + "'", this.SqlCon);
                IsPANExists = (cmd2.ExecuteScalar() != null) ? cmd2.ExecuteScalar().ToString() : "";
                cmd = new SqlCommand(@"select count(PANNo) from NameMast where PANNo='" + PAN + "'", this.SqlCon);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    IsExists = 1;
                }
                else
                {
                    IsExists = 0;
                }
                IsPANExists = IsExists.ToString() + "~" + IsPANExists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlCon.Close();
            }
            return IsPANExists;
        }

        //Function Added by Ankush on 20/08/2015 to Check the Existence of 10+ Emails/Mobile for a an Assessee before creating it
        public void IsEmailExists(string Email, string Mobile, out int IsExists)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"procChkEmail", this.SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@mobile", Mobile);


                cmd.Parameters.Add("@IsExists", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                IsExists = Convert.ToInt32(cmd.Parameters["@IsExists"].Value);
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

        //Function to check whether this Assessee is associated with any AccID or not
        public int IsAccIDExists(string NameID)
        {
            int IsExists = 0;
            try
            {
                this.pConn();
                cmd = new SqlCommand(@"select ISNULL(AccID,0) from NameMast where NameID = @NameID", this.SqlCon);
                cmd.Parameters.AddWithValue("@NameID", NameID);
                IsExists = Convert.ToInt32(cmd.ExecuteScalar());
                return IsExists;
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

        public void AddAssesseeLog(string AssesseeID)
        {
            try
            {
                this.pConn();
                cmd = new SqlCommand("procAssesseeLog", this.SqlCon);
                cmd.Parameters.AddWithValue("@AssesseeID", AssesseeID);
                cmd.Parameters.AddWithValue("@Status_Challan_Deposit_Later", 3);
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
    }
}