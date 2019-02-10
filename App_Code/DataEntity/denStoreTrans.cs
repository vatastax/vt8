using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Taxation.Interface;
/// <summary>
/// Summary description for denStoreTrans
/// </summary>
/// 
namespace Taxation.DataEntity
{
    public class denStoreTrans:IStoreTrans
    {
        #region Constructor
        public denStoreTrans()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        
        int intAmount,  intMainID, intSubID,intVtype,intConstID,intSubConstID,intGindex,intRecdAmount,intXMLTAGID,
        intEntryID,intAssessmentID,intGRowNo,intKeyCheck,intExemptedAmount,intTempArray,intDecisionArray,intStaticAmount1,intStaticAmount2,
        intWhichFormula,intExemptCol,intIsEnterFDet,intcol15,intWhichDet,intComboItemNo,intcounter,intAssesseeType;
        
        string strNameID,strDispName,strXMLTAG,strSection,strcol2,strcol16,strAY,strCol3;
        
        #endregion

        #region Properties
        public int AssesseeType
        {
            get
            {
                return intAssesseeType;
            }
            set
            {
                intAssesseeType = value;
            }
        }

        public string Col3
        {
            get
            {
                return strCol3;
            }
            set
            {
                strCol3 = value;
            }
        }

        public string NameID
        {
            get
            {
                return strNameID;
            }
            set
            {
                strNameID = value;
            }
        }

        public int MainID
        {
            get
            {
                return intMainID;
            }
            set
            {
                intMainID = value;
            }
        }

        public int SubID
        {
            get
            {
                return intSubID;
            }
            set
            {
                intSubID = value;
            }
        }

       
        public int Vtype
        {
            get
            {
                return intVtype;
            }
            set
            {
                intVtype = value;
            }
        }

        public int ConstID
        {
            get
            {
                return intConstID;
            }
            set
            {
                intConstID = value;
            }
        }

        public int SubConstID
        {
            get
            {
                return intSubConstID;
            }
            set
            {
                intSubConstID = value;
            }
        }

        public int GIndex
        {
            get
            {
                return intGindex;
            }
            set
            {
                intGindex = value;
            }
        }


        //Added By Mudit For TDS
        public string TAN
        {
            get;
            set;
        }
        public string FY
        {
            get;
            set;
        }
        public string Quarter
        {
            get;
            set;
        }
        public string FormNo
        {
            get;
            set;
        }
        public string RegularCorrection
        {
            get;
            set;
        }
        public string PAN
        {
            get;
            set;
        }
        public string ChallanID
        {
            get;
            set;
        }

        public Int32 DeducteeID
        {
            get;
            set;
        }

        public Int32 RecordNo
        {
            get;
            set;
        }
        #endregion

        #region IStoreTrans Members


        public int EntryID
        {
            get
            {
                return intEntryID;
            }
            set
            {
                intEntryID = value;
            }
        }

        #endregion

        #region IStoreTrans Members


        public int RecdAmount
        {
            get
            {
                return intRecdAmount;
            }
            set
            {
                intRecdAmount=value;
            }
        }

        public string DispName
        {
            get
            {
                return strDispName;
            }
            set
            {
               strDispName=value;
            }
        }

        public string XMLTAG
        {
            get
            {
                return strXMLTAG;
            }
            set
            {
               strXMLTAG=value;
            }
        }

        public int XMLTAGID
        {
            get
            {
                return intXMLTAGID;
            }
            set
            {
                intXMLTAGID=value;
            }
        }

        #endregion

        #region IStoreTrans Members


        public string AY
        {
            get
            {
                return strAY;
            }
            set
            {
                strAY=value;
            }
        }

        public int GRowNo
        {
            get
            {
                return intGRowNo;
            }
            set
            {
                intGRowNo=value;
            }
        }

        public int KeyCheck
        {
            get
            {
                return intKeyCheck;
            }
            set
            {
                intKeyCheck=value;
            }
        }

        public int ExemptedAmount
        {
            get
            {
                return intExemptedAmount;
            }
            set
            {
                intExemptedAmount=value;
            }
        }

        public int TempArray
        {
            get
            {
                return intTempArray;
            }
            set
            {
                intTempArray =value;
            }
        }

        public int DecisionArray
        {
            get
            {
                return intDecisionArray;
            }
            set
            {
                intDecisionArray=value;
            }
        }

        public int StaticAmount1
        {
            get
            {
                return intStaticAmount1;
            }
            set
            {
                intStaticAmount1=value;
            }
        }

        public int StaticAmount2
        {
            get
            {
                return intStaticAmount2;
            }
            set
            {
                intStaticAmount2=value;
            }
        }

        public string Section
        {
            get
            {
                return strSection;
            }
            set
            {
                strSection=value;
            }
        }

        public int WhichFormula
        {
            get
            {
                return intWhichFormula;
            }
            set
            {
                intWhichFormula=value;
            }
        }

        public int ExemptCol
        {
            get
            {
                return intExemptCol;
            }
            set
            {
               intExemptCol=value;
            }
        }

        public int IsEnterFDet
        {
            get
            {
                return intIsEnterFDet;
            }
            set
            {
                intIsEnterFDet=value;
            }
        }

        public string col2
        {
            get
            {
                return strcol2;
            }
            set
            {
               strcol2=value;
            }
        }

        public int col15
        {
            get
            {
                return intcol15;
            }
            set
            {
               intcol15=value;
            }
        }

        public string col16
        {
            get
            {
                return strcol16;
            }
            set
            {
                strcol16=value;
            }
        }

        public int WhichDet
        {
            get
            {
                return intWhichDet;
            }
            set
            {
                intWhichDet=value;
            }
        }

        public int ComboItemNo
        {
            get
            {
                return intComboItemNo;
            }
            set
            {
                intComboItemNo=value;
            }
        }

        public int counter
        {
            get
            {
                return intcounter;
            }
            set
            {
                intcounter=value;
            }
        }

        // following property is for the purpose of using due date while computing gTI during calculations per cell

        public string DueDate
        { get; set; }


        #endregion

        #region TDS

        public Int16 BookEntry
        {
            get;
            set;
        }

        public Int32 Flag
        {
            get;
            set;
        }

        public Int32 SalaryID
        { get; set; }


        #endregion
    }
}
