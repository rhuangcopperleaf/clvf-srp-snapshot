using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionStabilityRiskLikelihood : TransmissionStabilityRiskLikelihoodBase
    {
        public override double?[] GetLikelihoodValues(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                startFiscalYear,
                months, (x => x.Event_32_Type.Value / CommonConstants.MonthsInYear));
        }
    }
}
