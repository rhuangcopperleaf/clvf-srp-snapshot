using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TotalLabour : TotalLabourBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            if (timeInvariantData.InvestmentSpendByResource == null)
            {
                return null;
            }
            var internalLabourHours = HelperFunctions.GetResourceCurrencyUnitsFromForecast(months, CustomerConstants.internalLabourCode, timeInvariantData.InvestmentSpendByResource);
            var contractLabourHours = HelperFunctions.GetResourceCurrencyUnitsFromForecast(months, CustomerConstants.contractLabourCode, timeInvariantData.InvestmentSpendByResource);
            return HelperFunctions.CombineSeries(months, internalLabourHours, contractLabourHours);
        }
        
        public override double?[] GetZynos(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData,
            IReadOnlyList<TimeVariantInputDTO> timeVariantData,
            double?[] unitOutput)
        {
            return null; // no reasonable conversion
        }
    }
}
