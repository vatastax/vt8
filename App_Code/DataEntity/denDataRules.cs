using Taxation.Interface;

/// <summary>
/// Summary description for denDataRules
/// </summary>
namespace Taxation.DataEntity
{
    public class denDataRules:denStoreTrans
    {
        public denDataRules()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        

        #region DataRules Members
        public int ID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        public string Source_ID
        {
            get
            {
                return Source_ID;
            }
            set
            {
                Source_ID = value;
            }
        }

        public string Source_Value
        {
            get
            {
                return Source_Value;
            }
            set
            {
                Source_Value = value;
            }
        }

        public string Destination_ID
        {
            get
            {
                return Destination_ID;
            }
            set
            {
                Destination_ID = value;
            }
        }

        public int IsT00_T1000_T4
        {
            get
            {
                return IsT00_T1000_T4;
            }
            set
            {
                IsT00_T1000_T4 = value;
            }
        }

        public string T1000_Col
        {
            get
            {
                return T1000_Col;
            }
            set
            {
                T1000_Col = value;
            }
        }
        public string T1000_Col_Value
        {
            get
            {
                return T1000_Col_Value;
            }
            set
            {
                T1000_Col_Value = value;
            }
        }
        public string T4_SubConstID
        {
            get
            {
                return T4_SubConstID;
            }
            set
            {
                T4_SubConstID = value;
            }
        }
        public string T4_SubConstID_Value
        {
            get
            {
                return T4_SubConstID_Value;
            }
            set
            {
                T4_SubConstID_Value = value;
            }
        }

        #endregion
    }
}