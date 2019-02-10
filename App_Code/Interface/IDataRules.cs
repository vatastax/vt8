/// <summary>
/// Summary description for IDataRules
/// </summary>
namespace Taxation.Interface
{
    public class IDataRules
    {
        int ID
        {
            get;
            set;
        }
        string Source_ID
        {
            get;
            set;
        }
        string Source_Value
        {
            get;
            set;
        }
        string Destination_ID
        {
            get;
            set;
        }
        string Action
        {
            get;
            set;
        }
        int Is_T00_T1000_T4
        {
            get;
            set;
        }
        string T1000_Col
        {
            get;
            set;
        }
        string T1000_Col_Value
        {
            get;
            set;
        }
        string T4_SubConstID
        {
            get;
            set;
        }
        string T4_SubConstID_Value
        {
            get;
            set;
        }



    }
}