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
    /// Summary description for bllStates
    /// </summary>
    public class bllStates
    {
        #region Constructors
        public bllStates()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        dalStates objStatesDAL;
        
        #endregion

        #region Functions
        public List<denStates> getStates()
        {
            try
            {
                objStatesDAL = new dalStates();
                return objStatesDAL.GetStateList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //nishu 6/8/2015
        public string SelectStateName(int StateCode)
        {
            try
            {
                objStatesDAL = new dalStates();
                return objStatesDAL.SelectStateName(StateCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}