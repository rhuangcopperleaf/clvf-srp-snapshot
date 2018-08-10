using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionElectronicSafetyLikelihood : TransmissionElectronicSafetyLikelihoodBase
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

            // Risk likelihood is the POF value if it was entered in the questionnaire.
            // Otherwise, risk likelihood is calculated using Condition and Design Life.
            // The likelihood is then being modified by the probability modifying values.

            var probabilityModifyingValues = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear,
                                                months, (x => (x.Number_32_of_32_Assets ?? 1)
                                                            * (x.Self_32_Monitored ? 0.33 : 1)
                                                            * ((x.Manufacturer_32_Support && x.Standard_32_OS) ? 1 : 3)
                                                            * ((x.Probability_32_of_32_Danger ?? 0) / 100d)));

            if (answers != null && answers.POF != null)
            {
                var pofMonthlyProbabilities = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months,
                                                                 (x => x.POF / 100d / CommonConstants.MonthsInYear));

                return HelperFunctions.MultiplySeries(months, pofMonthlyProbabilities, probabilityModifyingValues);
            }
            else
            {
                var condition = timeInvariantData.Transmission_32_Electronic_32_Asset_32_Risk_Transmission_32_Electronic_32__45__32_Condition_ConsqUnitOutput;
                if (condition == null)
                {
                    return null;
                }

                var eomConditionToFailureCurve = HelperFunctions.GenericEndOfLifeModel.constructGenericEndOfLifePofCurve();

                var monthlyProbabilities = ConvertConditionToMonthlyProbability(
                    condition, eomConditionToFailureCurve, treatProbabilityAsFrequency: true);

                return HelperFunctions.MultiplySeries(months, monthlyProbabilities, probabilityModifyingValues);
            }
        }
    }
}
