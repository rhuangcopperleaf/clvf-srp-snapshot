using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class AdditionalCostsOMAOutcome : AdditionalCostsOMAOutcomeBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            if (timeInvariantData.Additional_32_Costs_Additional_32_Costs_32__32__45__32_OMA_ConsqUnitOutput_B == null)
            {
                return null;
            }
            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                                                             startFiscalYear,
                                                             months, (x => -1d * x.Additional_32_Costs));
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
