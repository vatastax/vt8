using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IBankBranches
/// </summary>
namespace Taxation.Interface
{

    /// <summary>
    /// Summary description for IAssetMast
    /// </summary>
    interface IBankBranches
    {
        string BankCode
        { get; set; }

        string BankType
        { get; set; }

        string BankName
        { get; set; }

        string Branch
        { get; set; }

        string BankAddress
        { get; set; }

        string BankCity
        { get; set; }

        string BankState
        { get; set; }

        string BankRegion
        { get; set; }

    }
}