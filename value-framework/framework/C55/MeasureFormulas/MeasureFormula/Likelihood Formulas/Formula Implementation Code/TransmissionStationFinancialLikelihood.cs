using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionStationFinancialLikelihood : TransmissionStationFinancialLikelihoodBase
    {
        public override double?[] GetLikelihoodValues(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            double?[] monthlyFailureProbabilities = null;

            // Risk probability is the POF if it was entered in the questionnaire;
            // otherwise, risk likelihood is calculated using Condition and Design Life 

            // NOTE: Formula presumes that POF value, if entered, is consistently used accross all time-variant answers.
            var answers = timeVariantData.FirstOrDefault();
            if (answers != null && answers.POF != null)
            {
                monthlyFailureProbabilities = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months,
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

                monthlyFailureProbabilities = ConvertConditionToMonthlyProbability(
                                        condition, eomConditionToFailureCurve, treatProbabilityAsFrequency: true);
            }

            // Probability of Collateral Damage is mandatory input variable
            var collateralDamageProbabilities = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months,
                                                                (x => (x.Probability_32_of_32_Collateral_32_Damage / 100d)));

            return HelperFunctions.MultiplySeries(months, monthlyFailureProbabilities, collateralDamageProbabilities);
        }
    }
}
