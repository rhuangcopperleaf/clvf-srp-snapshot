using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionElectronicComplianceLikelihood : TransmissionElectronicComplianceLikelihoodBase
    {
        public override double?[] GetLikelihoodValues(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            if (timeInvariantData.NERC_32_Dollars.HasValue && timeInvariantData.NERC_32_Dollars.Value > 0)
            {
                return PopulateOutputWithValue(months, CustomerConstants.probabilities_AlmostCertain / CommonConstants.MonthsInYear);
            }

            return null;
        }
    }
}
