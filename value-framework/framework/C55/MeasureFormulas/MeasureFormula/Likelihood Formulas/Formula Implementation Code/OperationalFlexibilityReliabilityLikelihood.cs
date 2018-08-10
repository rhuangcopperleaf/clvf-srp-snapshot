using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using System.Linq;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class OperationalFlexibilityReliabilityLikelihood : OperationalFlexibilityReliabilityLikelihoodBase
    {
        public override double?[] GetLikelihoodValues(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear,
                                                             months, (x => (((x.Planned_32_Outage_32_Days / CommonConstants.DaysInYear) * 0.33 
                                                                            * x.Number_32_of_32_Outages_32_Radial_32_Load)
                                                                            + CustomerConstants.probabilityOutageNotScheduled.First(e => e.Key <= x.Outage_32_Window).Value)
                                                                            / CommonConstants.MonthsInYear));
        }
    }
}
