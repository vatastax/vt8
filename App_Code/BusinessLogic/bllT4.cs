using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.DataEntity;
using Taxation.DataAccess;
using System.Collections.Generic;
namespace Taxation.BusinessLogic
{

    /// <summary>
    /// Summary description for bllT4
    /// </summary>
    public class bllT4
    {

        #region Constructors
        public bllT4()
        {
            //
            // TODO: Add constructor logic here
            //
            objdalT4 = new dalT4();
        }
        
#endregion

        #region Variables
        dalT4 objdalT4;        
#endregion

        #region Functions

        public List<denT4> GetParticulars(int intIndex,int yn,string AYear)
        {
            try
            {
                List<denT4> GenTest = new List<denT4>();
                int x;

                if (yn == 2)

                    return objdalT4.getParticulars(intIndex, AYear);
                //objListdenSalary = new denSalary();
                //objListdenSalary = objdalSalary.getParticularsByIndex(index);
                //return objListdenSalary;
                else


                    GenTest = objdalT4.GetYesNo(intIndex, yn, AYear);
                x = GenTest.Count;
                return GenTest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void getRowYesNo(int constID, string AYear, out string return_val)
        {
            try
            {
                objdalT4.getRowYesNo(constID, AYear, out return_val);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        #endregion


        
    }
}