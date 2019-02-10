using System;
using Taxation.Interface;

/// <summary>
/// Summary description for denFloating
/// </summary>
/// 
namespace Taxation.DataEntity
{
    public class denFloating : IFloating
    {
        #region Constructors

        public denFloating()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        private string strC1, strC2, strC3, strC4, strC5, strC6, strC7, strC8, strC9, strC10, strC11;
        private string strC12, strC13, strC14, strC15, strC16, strC17, strC18, strC19, strC20, strC21;
        private string strC22, strC23, strC24, strC25, strC26, strC27, strC28, strDropDownColumns, strDropdownQry, strValidation, strValidationString;

        string strNameID, strCol1, strCol3, strCol4, strCol6, strCol7, strCol8, strCol9, strCol10, strCol21, strCol22;
        string strCol23, strCol24, strCol25, strCol26;

        string intVtype, intGorder, intConstID, intHeaderID, intCol2, intCol5, intCol11, intCol12,
                    intCol13, intCol14, intCol15, intCol16, intCol17, intCol18, intCol19, intCol20, intCol27;



        int intNumber;

        #endregion

        #region DataEntities
        public int Number
        {
            get
            {
                return intNumber;
            }
            set
            {
                intNumber = value;
            }
        }

        public string @AY
        {
            get;
            set;
        }

        public string C1
        {
            get
            {
                return strC1;
            }
            set
            {
                strC1 = value;
            }
        }

        public string C2
        {
            get
            {
                return strC2;
            }
            set
            {
                strC2 = value;
            }
        }

        public string C3
        {
            get
            {
                return strC3;
            }
            set
            {
                strC3 = value;
            }
        }

        public string C4
        {
            get
            {
                return strC4;
            }
            set
            {
                strC4 = value;
            }
        }

        public string C5
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

        public string C6
        {
            get
            {
                return strC6;
            }
            set
            {
                strC6 = value;
            }
        }

        public string C7
        {
            get
            {
                return strC7;
            }
            set
            {
                strC7 = value;
            }
        }

        public string C8
        {
            get
            {
                return strC8;
            }
            set
            {
                strC8 = value;
            }
        }

        public string C9
        {
            get
            {
                return strC9;
            }
            set
            {
                strC9 = value;
            }
        }

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

        public string C11
        {
            get
            {
                return strC11;
            }
            set
            {
                strC11 = value;
            }
        }

        public string C12
        {
            get
            {
                return strC12;
            }
            set
            {
                strC12 = value;
            }
        }

        public string C13
        {
            get
            {
                return strC13;
            }
            set
            {
                strC13 = value;
            }
        }

        public string C14
        {
            get
            {
                return strC14;
            }
            set
            {
                strC14 = value;
            }
        }

        public string C15
        {
            get
            {
                return strC15;
            }
            set
            {
                strC15 = value;
            }
        }

        public string C16
        {
            get
            {
                return strC16;
            }
            set
            {
                strC16 = value;
            }
        }

        public string C17
        {
            get
            {
                return strC17;
            }
            set
            {
                strC17 = value;
            }
        }

        public string C18
        {
            get
            {
                return strC18;
            }
            set
            {
                strC18 = value;
            }
        }

        public string C19
        {
            get
            {
                return strC19;
            }
            set
            {
                strC19 = value;
            }
        }

        public string C20
        {
            get
            {
                return strC20;
            }
            set
            {
                strC20 = value;
            }
        }

        public string C21
        {
            get
            {
                return strC21;
            }
            set
            {
                strC21 = value;
            }
        }

        public string C22
        {
            get
            {
                return strC22;
            }
            set
            {
                strC22 = value;
            }
        }

        public string C23
        {
            get
            {
                return strC23;
            }
            set
            {
                strC23 = value;
            }
        }

        public string C24
        {
            get
            {
                return strC24;
            }
            set
            {
                strC24 = value;
            }
        }

        public string C25
        {
            get
            {
                return strC25;
            }
            set
            {
                strC25 = value;
            }
        }

        public string C26
        {
            get
            {
                return strC26;
            }
            set
            {
                strC26 = value;
            }
        }

        public string C27
        {
            get
            {
                return strC27;
            }
            set
            {
                strC27 = value;
            }
        }

        public string C28
        {
            get
            {
                return strC28;
            }
            set
            {
                strC28 = value;
            }
        }

        public string MainId
        { get; set; }

        //public string DropDownColumns
        //{
        //    get
        //    {
        //        return strDropDownColumns;
        //    }
        //    set
        //    {
        //        strDropDownColumns = value;
        //    }
        //}

        //public string DropdownQry
        //{
        //    get
        //    {
        //        return strDropdownQry;
        //    }
        //    set
        //    {
        //        strDropdownQry = value;
        //    }
        //}

        //public string ValidationColumns
        //{
        //    get;
        //    set;
        //}

        //public string Validation
        //{
        //    get
        //    {
        //        return strValidation;
        //    }
        //    set
        //    {
        //        strValidation = value;
        //    }
        //}

        //public string ValidationString
        //{
        //    get
        //    {
        //        return strValidationString;
        //    }
        //    set
        //    {
        //        strValidationString = value;
        //    }
        //}

        //public string ddText
        //{
        //    get;
        //    set;
        //}
        //public string ddVal
        //{
        //    get;
        //    set;
        //}

        //Properties Regarding Storeftrans Table


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

        public string Vtype
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

        public string Gorder
        {
            get
            {
                return intGorder;
            }
            set
            {
                intGorder = value;
            }
        }

        public string ConstID
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

        public string HeaderID
        {
            get
            {
                return intHeaderID;
            }
            set
            {
                intHeaderID = value;
            }
        }

        public string Col1
        {
            get
            {
                return strCol1;
            }
            set
            {
                strCol1 = value;
            }
        }

        public string Col2
        {
            get
            {
                return intCol12;
            }
            set
            {
                intCol12 = value;
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

        public string Col4
        {
            get
            {
                return strCol4;
            }
            set
            {
                strCol4 = value;
            }
        }

        public string Col5
        {
            get
            {
                return intCol5;
            }
            set
            {
                intCol5 = value;
            }
        }

        public string Col6
        {
            get
            {
                return strCol6;
            }
            set
            {
                strCol6 = value;
            }
        }

        public string Col7
        {
            get
            {
                return strCol7;
            }
            set
            {
                strCol7 = value;
            }
        }

        public string Col8
        {
            get
            {
                return strCol8;
            }
            set
            {
                strCol8 = value;
            }
        }

        public string Col9
        {
            get
            {
                return strCol9;
            }
            set
            {
                strCol9 = value;
            }
        }

        public string Col10
        {
            get
            {
                return strCol10;
            }
            set
            {
                strCol10 = value;
            }
        }

        public string Col11
        {
            get
            {
                return intCol11;
            }
            set
            {
                intCol11 = value;
            }
        }

        public string Col12
        {
            get
            {
                return intCol12;
            }
            set
            {
                intCol12 = value;
            }
        }

        public string Col13
        {
            get
            {
                return intCol13;
            }
            set
            {
                intCol13 = value;
            }
        }

        public string Col14
        {
            get
            {
                return intCol14;
            }
            set
            {
                intCol14 = value;
            }
        }

        public string Col15
        {
            get
            {
                return intCol15;
            }
            set
            {
                intCol15 = value;
            }
        }

        public string Col16
        {
            get
            {
                return intCol16;
            }
            set
            {
                intCol16 = value;
            }
        }

        public string Col17
        {
            get
            {
                return intCol17;
            }
            set
            {
                intCol17 = value;
            }
        }

        public string Col18
        {
            get
            {
                return intCol18;
            }
            set
            {
                intCol18 = value;
            }
        }

        public string Col19
        {
            get
            {
                return intCol19;
            }
            set
            {
                intCol19 = value;
            }
        }

        public string Col20
        {
            get
            {
                return intCol20;
            }
            set
            {
                intCol20 = value;
            }
        }

        public string Col21
        {
            get
            {
                return strCol21;
            }
            set
            {
                strCol21 = value;
            }
        }

        public string Col22
        {
            get
            {
                return strCol22;
            }
            set
            {
                strCol22 = value;
            }
        }

        public string Col23
        {
            get
            {
                return strCol23;
            }
            set
            {
                strCol23 = value;
            }
        }

        public string Col24
        {
            get
            {
                return strCol24;
            }
            set
            {
                strCol24 = value;
            }
        }

        public string Col25
        {
            get
            {
                return strCol25;
            }
            set
            {
                strCol25 = value;
            }
        }

        public string Col26
        {
            get
            {
                return strCol26;
            }
            set
            {
                strCol26 = value;
            }
        }

        public string Col27
        {
            get
            {
                return intCol27;
            }
            set
            {
                intCol27 = value;
            }
        }

        public string ColMain
        {
            get;
            set;
        }


        //Properties Regarding T1000_Rules Table

        public Int64 id
        {
            get;
            set;
        }
        public int t1000_h1
        {
            get;
            set;
        }
        public string DropDownColumns
        { get; set; }

        public string DropdownQry
        { get; set; }
        public string ValidationColumns
        { get; set; }
        public string Validation
        { get; set; }
        public string ValidationString
        { get; set; }
        public string ddText
        { get; set; }
        public string ddVal
        { get; set; }
        public bool status
        { get; set; }

        #endregion
    }

    public class T1000_rules
    {
        public Int64 id
        { get; set; }

        public int t1000_h1
        { get; set; }

        public string DropDownColumns
        {
            get;
            set;
        }

        public string DropdownQry
        { get; set; }

        public string ValidationColumns
        { get; set; }

        public string Validation
        {
            get;
            set;
        }
        public string ValidationString
        { get; set; }

        public string ddText
        { get; set; }
        public string ddVal
        {
            get;
            set;
        }

        public bool status
        { get; set; }

    }

    public class t00_Rules
    {
        public Int64 id
        { get; set; }

        public string t00_c1
        { get; set; }      

        public string ValidationColumn
        { get; set; }

        public string Validation
        {
            get;
            set;
        }
        public string ValidationString
        { get; set; }       

        public bool status
        { get; set; }

        public int IsRow
        {
            get;
            set;
        }

    }

    public class t4_Rules
    {
        public Int64 id
        { get; set; }

        public string t4_c1
        { get; set; }

        public string ValidationColumn
        { get; set; }

        public string Validation
        {
            get;
            set;
        }
        public string ValidationString
        { get; set; }

        public bool status
        { get; set; }

        public string AY
        {
            get;
            set;
        }

        public string DropdownQry
        { get; set; }

        public string ddText
        { get; set; }

        public string ddVal
        { get; set; }


    }
}
