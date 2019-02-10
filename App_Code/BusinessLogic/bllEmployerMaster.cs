using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Taxation.DataEntity;
using Taxation.DataAccess;
namespace Taxation.BusinessLogic
{

    /// <summary>
    /// Summary description for bllEmployerMaster
    /// </summary>
    public class bllEmployerMaster
    {
        #region Constructor
        public bllEmployerMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        
#endregion
        

        #region Function
        public int InsertDataEmployerMaster(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                dalEmployerMaster objEmployerMasterDAL;
                objEmployerMasterDAL = new dalEmployerMaster();
                return objEmployerMasterDAL.InsertDataEmployerMaster(objEmployerMasterDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateDataEmployerMaster(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                dalEmployerMaster objEmployerMasterDAL;
                objEmployerMasterDAL = new dalEmployerMaster();
                objEmployerMasterDAL.UpdateDataEmployerMaster(objEmployerMasterDEN);
                return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //inserting data of BusinessMaster
        public int InsertDataBusinessMaster(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                dalEmployerMaster objEmployerMasterDAL;
                objEmployerMasterDAL = new dalEmployerMaster();
                objEmployerMasterDAL.InsertDataBusinessMaster(objEmployerMasterDEN);
                return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //updating data of Business MAster

        public int UpdateDataBusinessMaster(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                dalEmployerMaster objEmployerMasterDAL;
                objEmployerMasterDAL = new dalEmployerMaster();
                objEmployerMasterDAL.UpdateDataBusinessMaster(objEmployerMasterDEN);
                return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertDirectorDetails(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                dalEmployerMaster objEmployerMasterDAL;
                objEmployerMasterDAL = new dalEmployerMaster();
                objEmployerMasterDAL.InsertDirectorDetails(objEmployerMasterDEN);
                return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public int InsertBenefeciaryDetails(denEmployerMaster objEmployerMasterDEN)
        {
            try
            {
                dalEmployerMaster objEmployerMasterDAL;
                objEmployerMasterDAL = new dalEmployerMaster();
                objEmployerMasterDAL.InsertBeneficiaryDetails(objEmployerMasterDEN);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
        public denEmployerMaster GetDirectorDetails(string PAN)
        {
            try
            {
                dalEmployerMaster objEmployerMasterDAL = new dalEmployerMaster();
                denEmployerMaster objEmployerMasterDEN;
                objEmployerMasterDEN = objEmployerMasterDAL.GetDirectorDetails(PAN);
                return objEmployerMasterDEN;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<denEmployerMaster> GetDirectorList(string NameID)
        {
            try
            {
                dalEmployerMaster objEmployerMasterDAL = new dalEmployerMaster();
                return objEmployerMasterDAL.GetDirectorList(NameID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByAssessee(string aid, Int32 vtype)
        {
            dalEmployerMaster objEmployerMasterDAL = new dalEmployerMaster();
            return objEmployerMasterDAL.SelectByAssessee(aid, vtype);
        }

        public void Delete(Int64 EmpID)
        {
            dalEmployerMaster objEmployerMasterDAL = new dalEmployerMaster();
            objEmployerMasterDAL.Delete(EmpID);
        }

        public DataTable Select(Int64 id)
        {
            dalEmployerMaster objEmployerMasterDAL = new dalEmployerMaster();
            return objEmployerMasterDAL.Select(id);
        }
        #endregion

    }
}