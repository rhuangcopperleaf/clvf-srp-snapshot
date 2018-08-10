using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionStationReliabilityLikelihood : TransmissionStationReliabilityLikelihoodBase
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

            // Risk probability is the POF if it was entered in the questionnaire.
            // Otherwise, risk likelihood is calculated based on Condition and Design Life.

            if (answers != null && answers.POF != null)
            {
                return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months,
                                                                 (x => x.POF / 100d / CommonConstants.MonthsInYear));
            }
            else
            {
                var condition = timeInvariantData.Transmission_32_Station_32_Equipment_32_Risk_Transmission_32_Station_32__45__32_Condition_ConsqUnitOutput;
                if (condition == null)
                {
                    return null;
                }

                var eomConditionToFailureCurve = HelperFunctions.GenericEndOfLifeModel.constructGenericEndOfLifePofCurve();

                var monthlyProbabilities = ConvertConditionToMonthlyProbability(
                    condition, eomConditionToFailureCurve, treatProbabilityAsFrequency: true);

                return monthlyProbabilities;
            }
        }
    }
}
