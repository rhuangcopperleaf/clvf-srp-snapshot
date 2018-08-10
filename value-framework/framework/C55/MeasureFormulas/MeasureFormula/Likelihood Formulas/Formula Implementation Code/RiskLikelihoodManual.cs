using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class RiskLikelihoodManual : RiskLikelihoodManualBase
    {
        public override double?[] GetLikelihoodValues(int startFiscalYear, int months,
                                                      TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                startFiscalYear,
                months, (x => x.Manual_32_Risk_32_Probability.AvgValue / CommonConstants.MonthsInYear));
        }
    }
}
