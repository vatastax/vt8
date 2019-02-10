using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxation.DataAccess;
using System.Data;
using Taxation.DataEntity;
/// <summary>
/// Summary description for bllDataRules
/// </summary>
namespace Taxation.BusinessLogic
{

    public class bllDataRules
    {
        public bllDataRules()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region variables
        dalDataRules objdalDataRules;
        #endregion

        #region function


        public DataTable Select()
        {
            try
            {
                objdalDataRules = new dalDataRules();
                return objdalDataRules.Select();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Fun To select records based on SourceID
        public DataSet SelectRules(denDataRules objdenDataRules,string ITR)
        {
            DataSet ds = new DataSet();
            try
            {
                objdalDataRules = new dalDataRules();
                ds = objdalDataRules.SelectRules(objdenDataRules,ITR);
                ds.Tables[0].TableName = "DataRules_T00";
                ds.Tables[1].TableName = "DataRules_T1000";
                ds.Tables[2].TableName = "DataRules_T4";
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}