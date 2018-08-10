using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class PublicPerceptionConsequence : PublicPerceptionConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // Cannot calculate cosequence if system parameters are missing or have no values
            if (!timeInvariantData.SystemValue_32_of_32_Improvement_32_Affecting_32_All_32_Public.HasValue)
            {
                return null;
            }

            var publicPerceptionValue = timeInvariantData.SystemValue_32_of_32_Improvement_32_Affecting_32_All_32_Public.Value *
                timeInvariantData.Percentage_32_Public / 100d;
            return PopulateOutputWithValue(months, publicPerceptionValue);
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
