using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    /// <summary>
    /// Investment Capital costs in dollars.
    /// No likelihood formula expected to be used.
    /// Typically applied as a constraint.
    /// Uses the capital account code (CAPEXAccount) specified in CustomerConstants.cs
    /// </summary>
    public class CapitalCost : CapitalCostBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            var values = GetSpendForAccountType(months, timeInvariantData.InvestmentSpendByAccountType,
                                                CustomerConstants.CAPEXAccount );

            return values;

        }
        
        public override double?[] GetZynos(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData,
                                           IReadOnlyList<TimeVariantInputDTO> timeVariantData,
                                           double?[] unitOutput)
        {
            return ConvertUnitsToZynos(unitOutput, CommonConstants.DollarToZynoConversionFactor);
        }
    }
}

