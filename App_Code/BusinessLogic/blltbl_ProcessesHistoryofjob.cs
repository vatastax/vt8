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
    /// Summary description for blltbl_ProcessesHistoryofjob
    /// </summary>
    public class blltbl_ProcessesHistoryofjob
    {
        #region Constructors
        public blltbl_ProcessesHistoryofjob()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        daltbl_ProcessesHistoryofjob objtbl_ProcessesHistoryofjobDAL;
        
        #endregion

        #region Functions
        public void InsertDataMainGrid(dentbl_ProcessesHistoryofjob objdentbl_ProcessesHistoryofjob)
        {
            daltbl_ProcessesHistoryofjob objdaltbl_ProcessesHistoryofjob = new daltbl_ProcessesHistoryofjob();
            objdaltbl_ProcessesHistoryofjob.InsertDataMainGrid(objdentbl_ProcessesHistoryofjob);
        }

        public void updateProcess(dentbl_ProcessesHistoryofjob objdentbl_ProcessesHistoryofjob)
        {
            daltbl_ProcessesHistoryofjob objdaltbl_ProcessesHistoryofjob = new daltbl_ProcessesHistoryofjob();
            objdaltbl_ProcessesHistoryofjob.updateProcess(objdentbl_ProcessesHistoryofjob);
        }

        public void updateProcessDetail(dentbl_ProcessesHistoryofjob objdentbl_ProcessesHistoryofjob)
        {
            daltbl_ProcessesHistoryofjob objdaltbl_ProcessesHistoryofjob = new daltbl_ProcessesHistoryofjob();
            objdaltbl_ProcessesHistoryofjob.updateProcessDetail(objdentbl_ProcessesHistoryofjob);
        }


        public DataTable Select(bool status)
        {
            daltbl_ProcessesHistoryofjob objdaltbl_ProcessesHistoryofjob = new daltbl_ProcessesHistoryofjob();
            return objdaltbl_ProcessesHistoryofjob.Select(status);
        }

        #endregion

    }
}