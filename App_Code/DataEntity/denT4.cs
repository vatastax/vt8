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
/// Summary description for denT4
/// </summary>
/// 
namespace Taxation.DataEntity
{

    public class denT4 : IT4
    {
        public denT4()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Variables
        int intYesNo, intC11, intSubConstID, intConstID, intAssessmentID, intGridIndex, intGRowNo,
            intKeyCheck, intExemptedAmount, intTempArray, intDecisionArray, intStaticAmount1, intStaticAmount2, intWhichFormula, intExemptCol, intIsEnterFDet,
            intcol15, intWhichDet, intComboItemNo, intcounter, intXMLTAGID;
        string strC5, strC10, strParticular, strSerial, strAssessYear, strXMLNAME, strSection, strcol16, strcol2;
        #endregion



        #region IT4 Members

        public string C10
        {
            get
            {
                return strC10;
            }
            set
            {
                strC10 = value;
            }
        }

        public Int32 C12
        {
            get;
            set;
        }

        public Int32 C13
        {
            get;
            set;
        }

        public Int32 C14
        {
            get;
            set;
        }

        public Int32 C15
        {
            get;
            set;
        }

        public Int32 C35
        {
            get;
            set;
        }

        public Int32 C36
        {
            get;
            set;
        }

        public Int32 C37
        {
            get;
            set;
        }

        public Int32 C38
        {
            get;
            set;
        }

        public string C4
        {
            get
            {
                return strC5;
            }
            set
            {
                strC5 = value;
            }
        }
        public int C11
        {
            get
            {
                return intC11;
            }
            set
            {
                intC11 = value;
            }
        }

        public string Particular
        {
            get
            {
                return strParticular;
            }

            set
            {
                strParticular = value;
            }
        }
        public string Serial
        {
            get
            {
                return strSerial;
            }
            set
            {
                strSerial = value;
            }
        }
        public int YESNO
        {
            get
            {
                return intYesNo;
            }
            set
            {
                intYesNo = value;
            }
        }
        public string AssessYear
        {
            get
            {
                return strAssessYear;
            }
            set
            {
                strAssessYear = value;
            }
        }

        #endregion



        #region IT4 Members


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
        public string XMLNAME
        {
            get
            {
                return strXMLNAME;
            }
            set
            {
                strXMLNAME = value;
            }

        }

        public string tooltip
        {
            get;
            set;
        }

        #endregion

        #region IT4 Members


        public int AssessmentID
        {
            get
            {
                return intAssessmentID;
            }
            set
            {
                intAssessmentID = value;
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
                intGRowNo = value;
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
                intKeyCheck = value;
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
                intExemptedAmount = value;
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
                intTempArray = value;
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
                intDecisionArray = value;
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
                intStaticAmount1 = value;
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
                intStaticAmount2 = value;
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
                strSection = value;
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
                intWhichFormula = value;
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
                intExemptCol = value;
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
                intIsEnterFDet = value;
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
                strcol2 = value;
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
                intcol15 = value;
            }
        }

        public int WhichDet
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int ComboItemNo
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int counter
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
