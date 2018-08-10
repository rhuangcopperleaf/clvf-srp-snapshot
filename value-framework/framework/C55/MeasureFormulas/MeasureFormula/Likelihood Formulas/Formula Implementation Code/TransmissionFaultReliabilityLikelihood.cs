using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionFaultReliabilityLikelihood : TransmissionFaultReliabilityLikelihoodBase
    {
        public override double?[] GetLikelihoodValues(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // NOTE: Formula assumes that "BESS Risk Issue" is used consistently accross the all time-variant answers (i.e. once true - always true).

            // Measure ouptut is eliminated if "BESS Risk Issue" is true
            if (timeVariantData.Any(answer => answer.BES_32_Risk_32_Issue == true))
            {
                return null;
            }

            return PopulateOutputWithValue(months, CustomerConstants.annualExposurePercentage / 100d 
                                                    / CommonConstants.MonthsInYear);
        }
    }
}
