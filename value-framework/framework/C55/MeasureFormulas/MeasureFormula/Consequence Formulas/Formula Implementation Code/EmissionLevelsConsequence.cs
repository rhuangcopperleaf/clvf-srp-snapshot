using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class EmissionLevelsConsequence : EmissionLevelsConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            var cO2Prices = timeInvariantData.SystemCO2_32_Credits_32_Value_32__40__36__32__47__32_MWh_41__32_TimeSeries;
            var tonsCO2Avoided = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                                                                          startFiscalYear,
                                                                          months, (x => x.CO2_32_Reduction));
            if (cO2Prices == null || tonsCO2Avoided == null)
            {
                return null;
            }

            var result = HelperFunctions.scaleValues(startFiscalYear, months, tonsCO2Avoided, cO2Prices);
            return result;
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
