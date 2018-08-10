using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class CostAvoidanceCapitalBaseline : CostAvoidanceCapitalBaselineBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            if (timeInvariantData.Account_32_Type.ValueAsInteger != CustomerConstants.CAPEXAccountNumber)
            {
                return null;
            }
            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                                                             startFiscalYear,
                                                             months, (x => x.Costs_32_incurred_32_if_32_this_32_investment_32_is_32_not_32_undertaken));
        }
        
        public override double?[] GetZynos(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData,
                                           IReadOnlyList<TimeVariantInputDTO> timeVariantData,
                                           double?[] unitOutput)
        {
            // We return negative value here because output value measure "Financial Benefits & Costs - Capital" 
            // is defined as "Positive Weighting" for Value Function Usage, and it is used as output measure by mulitple Value Models.

            return ConvertUnitsToZynos(HelperFunctions.scaleValues(months, unitOutput, -1d), CommonConstants.DollarToZynoConversionFactor);
        }
    }
}
