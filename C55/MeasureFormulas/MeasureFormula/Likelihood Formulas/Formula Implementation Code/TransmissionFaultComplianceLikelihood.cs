using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionFaultComplianceLikelihood : TransmissionFaultComplianceLikelihoodBase
    {
        public override double?[] GetLikelihoodValues(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // NOTE: Formula assumes that "BESS Risk Issue" is used consistently accross the all time-variant answers (i.e. once true - always true).

            // Measure is calculated only if "BESS Risk Issue" is true
            if (timeVariantData.Any(answer => answer.BES_32_Risk_32_Issue == true))
            {
                return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                            startFiscalYear,
                            months, (x => x.BES_32_Risk_32_Issue
                                            ? (CustomerConstants.probabilities_AlmostCertain / CommonConstants.MonthsInYear)
                                            : CustomerConstants.probabilities_None));
            }

            return null;
        }
    }
}
