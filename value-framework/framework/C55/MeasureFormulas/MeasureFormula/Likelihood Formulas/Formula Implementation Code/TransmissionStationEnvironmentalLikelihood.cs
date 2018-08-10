using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionStationEnvironmentalLikelihood : TransmissionStationEnvironmentalLikelihoodBase
    {
        public override double?[] GetLikelihoodValues(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // NOTE: Formula presumes that COF & POF values, if entered, are consistently used accross all time-variant answers.

            // When COF amount is used, we invalidate entire value measure
            var answers = timeVariantData.FirstOrDefault();
            if (answers != null && answers.COF != null)
            {
                return null;
            }

            var monthlyFailureProbabilities = timeInvariantData.Transmission_32_Station_32_Equipment_32_Risk_Transmission_32_Station_32__45__32_Reliability_LikelihoodUnitOutput;
            if (monthlyFailureProbabilities == null)
            {
                return null;
            }

            var environmentalRiskProbabilities = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months,
                                                                (x => (x.Probability_32_of_32_Environment_32_Risk ?? 0) / 100d));

            return HelperFunctions.MultiplySeries(months, monthlyFailureProbabilities, environmentalRiskProbabilities);
        }
    }
}
