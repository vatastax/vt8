using Taxation.Interface;

/// <summary>
/// This Class is to design the properties and here we define private variables to be accessed 
/// by the properties
/// </summary>
/// 
namespace Taxation.DataEntity
{
    public class denSalary:Isalary
    {
        #region "Constructors"
        public denSalary()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region "Variables"
     int intGIndex,intC19,intC1,intC16,intRecdAmount,intXMLTAGID,intAssessmentID,intGRowNo,intKeyCheck,intSaleID;
        int intExemptedAmount, intTempArray, intDecisionArray, intStaticAmount1, intStaticAmount2, intWhichFormula, intExemptCol,intC40;
        int intIsEnterFDet, intcol15, intWhichDet, intComboItemNo, intcounter,intC25,intComboTextID,intPurchaseCost,intPurchaseExp,intAssetID;
        string strParticulars,strSerial,strDispName,strXMLTAG,strXMLTAGNAME,
            strSection,strcol2,strcol16,strAssesseeType,strCombotext,strAssetName,strPurchaseDate,strAY;


        #endregion





        #region Isalary Members "Properties"
        public int C40
        {
            get
            {
                return intC40;
            }
            set
            {
                intC40 = value;
            }
        }
        public int SaleID
        {
            get
            {
                return intSaleID;
            }
            set
            {
                intSaleID = value;
            }
        }
        public string AY
        {
            get
            {
                return strAY;
            }
            set
            {
                strAY = value;
            }
        }
        public int AssetID
        {
            get
            {
                return intAssetID;
            }
            set
            {
                intAssetID = value;
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
                strSerial=value;
            }
        }

        public string Particulars
        {
            get
            {
                return strParticulars;
            }
            set
            {
                strParticulars=value;
            }
        }
        public int GIndex
        {
            get
            {

                return intGIndex;
            }
            set
            {
                intGIndex = value;
            }
        }

        public string AssesseeType
        {
            get
            {
                return strAssesseeType;
            }
            set
            {
                strAssesseeType = value;
            }
        }
        public int C19
        {
            get
            {
                return intC19;
            }
            set
            {
                intC19 = value;
            }

        }
        public int C1
        {
            get
            {
                return intC1;
            }
            set
            {
                intC1 = value;
            }

        }
        public int C16
        {
            get
            {
                return intC16;
            }
            set
            {
                intC16 = value;
            }

        }

        public int C27
        { get; set; }

        #endregion

        #region Isalary Members


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
        public string XMLTAGNAME
        {
            get
            {
                return strXMLTAGNAME;
            }
            set
            {
                strXMLTAGNAME = value;
            }
        }

        #endregion

        #region Isalary Members


        public int AssessmentID
        {
            get
            {
                return intAssessmentID;
            }
            set
            {
                intAssessmentID=value;
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
                intTempArray=value;
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
        public int C25
        {
            get
            {
                return intC25;
            }
            set
            {
                intC25 = value;
            }
        }
        public int ComboTextID
        {
            get
            {
                return intComboTextID;
            }
            set
            {
                intComboTextID = value;
            }
        }
        public string ComboText
        {
            get
            {
                return strCombotext;
            }
            set
            {
                strCombotext = value;
            }
        }
        public string tooltip
        {
            get;
            set;
        }

        #endregion

        #region Isalary Members

        public string AssetName
        {
            get
            {
                return strAssetName;
            }
            set
            {
               strAssetName=value;
            }
        }

        public string PurchaseDate
        {
            get
            {
               return strPurchaseDate;
            }
            set
            {
                strPurchaseDate=value;
            }
        }

        public int PurchaseCost
        {
            get
            {
               return intPurchaseCost;
            }
            set
            {
                intPurchaseCost=value;
            }
        }

        public int PurchaseExp
        {
            get
            {
                return intPurchaseExp;
            }
            set
            {
                intPurchaseExp=value;
            }
        }

        #endregion

        #region Isalary Members

        public int GrowNo
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

        public string SectionName
        {
            get;
            set;
        }
        public string SectionCode
        {
            get;
            set;
        }

        public string Particular
        {
            get;set;
        }
        public string TDS_TTACode
        { get; set; }

        public string Nature_Of_Remittances
        {
            get;set;
        }
        public string RemittancesCode
        {
            get;set;
        }

        public string Country
        {
            get;set;
        }
        public int CountryCode
        {get;set;}

        public string Data_Text_Field
        { get; set; }

        public string DataValueField
        { get; set; }



        #endregion
    }
}
