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
    /// Summary description for bllSTax
    /// </summary>
    public class bllSTax
    {

        #region Constructors
        public bllSTax()
        {
            //
            // TODO: Add constructor logic here
            //
            objdalSTax = new dalSTax();
        }

        #endregion

        #region Variables
        dalSTax objdalSTax;
        #endregion

        #region Functions

        public List<denSTax> GetParticulars()
        {
            try
            {
                List<denSTax> GenTest = new List<denSTax>();
                int x;

                GenTest = objdalSTax.getParticulars();
                x = GenTest.Count;
                return GenTest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<denAbatementNotifications> getAbatementNotifications()
        {
            try
            {
                
                List<denAbatementNotifications> GenTest = new List<denAbatementNotifications>();
                int x;

                GenTest = objdalSTax.getAbatementNotifications();
                x = GenTest.Count;
                return GenTest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<denAbatementNotifications> getAbatementNotifications(Int64 serviceID)
        {
            try
            {

                List<denAbatementNotifications> GenTest = new List<denAbatementNotifications>();
                int x;

                GenTest = objdalSTax.getAbatementNotifications(serviceID);
                x = GenTest.Count;
                return GenTest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<denExemptionSerials> getExemptionSerials(Int64 serviceID)
        {
            try
            {
                List<denExemptionSerials> GenTest = new List<denExemptionSerials>();
                int x;

                GenTest = objdalSTax.getExemptionSerials(serviceID);
                x = GenTest.Count;
                return GenTest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Changed by Mudit on 24-04-2015 as new fields are added in the table
        public Int64 AddService(Int64 ServiceID, string NameID, int ServiceProvider, int SP_PartialReverseCharge, string SP_STPayable, int ServiceReceiver, int SR_PartialReverseCharge, string SR_STPayable, int BenefitOfExemptions, int AbatementClaimed, int ProvisionallyAssessed)
        {
            Int64 lastID = 0;
            try
            {
                lastID= objdalSTax.AddService(ServiceID, NameID,ServiceProvider,SP_PartialReverseCharge,SP_STPayable,ServiceReceiver,SR_PartialReverseCharge,SR_STPayable,BenefitOfExemptions,AbatementClaimed,ProvisionallyAssessed);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastID;
        }

        //Added by Mudit on 24-04-2015 for maintaining Abatement Records
        public void AddAbtService(Int64 ServID, string NotificationNo, Int64 SI_No)
        {
            try
            {
                objdalSTax.AddAbtService(ServID, NotificationNo, SI_No);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Added by Mudit on 24-04-2015 for maintaining Exemption Records
        public void AddExmptService(Int64 ServID, string NotificationNo, Int64 SI_No)
        {
            try
            {
                objdalSTax.AddExmptService(ServID, NotificationNo,SI_No);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Added by Mudit on 24-04-2015 for maintaining Provisional Records
        public void AddProService(Int64 ServID, string ProOrderNo, string Date)
        {
            try
            {
                objdalSTax.AddProService(ServID, ProOrderNo, Date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Added by Mudit on 25-04-2015 for Fetching Records From SelectedService Table
        public DataTable getSelectedServices(String NameID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt=objdalSTax.getSelectedServices(NameID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //Added by Mudit on 25-04-2015 for Fetching Records From Selected Abatement Service Table
        public DataTable getSelectedAbtServices(string SelServID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = objdalSTax.getSelectedAbtServices(SelServID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        //Added by Mudit on 25-04-2015 for Fetching Records From Selected Exempted Service Table
        public DataTable getSelectedExmptServices(string SelServID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = objdalSTax.getSelectedExmptServices(SelServID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion




    }
}