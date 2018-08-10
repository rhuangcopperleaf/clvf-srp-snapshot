using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionElectronicComplianceConsequence : TransmissionElectronicComplianceConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            if (timeInvariantData.NERC_32_Dollars.HasValue && timeInvariantData.NERC_32_Dollars.Value > 0)
            {
                return PopulateOutputWithValue(months, 
                    (2 * timeInvariantData.NERC_32_Dollars * CommonConstants.DollarToZynoConversionFactor));
            }

            return null;
        }

        public override double?[] GetZynos(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData,
            IReadOnlyList<TimeVariantInputDTO> timeVariantData,
            double?[] unitOutput)
        {
            return unitOutput;
        }
    }
}
