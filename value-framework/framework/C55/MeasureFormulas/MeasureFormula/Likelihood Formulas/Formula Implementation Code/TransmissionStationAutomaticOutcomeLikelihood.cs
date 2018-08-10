using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionStationAutomaticOutcomeLikelihood : TransmissionStationAutomaticOutcomeLikelihoodBase
    {
        public override double?[] GetLikelihoodValues(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // In case COF is provided, we invalidate the entire measure calculation based on the Reliability Risk output
            var monthlyReliabilityProbabilities = timeInvariantData.Transmission_32_Station_32_Equipment_32_Risk_Transmission_32_Station_32__45__32_Reliability_LikelihoodUnitOutput_B;
            if (monthlyReliabilityProbabilities == null)
            {
                return null;
            }

            // Return 0 values after the end of spend
            var result = new double?[months];
            FillWithValueAfterEndOfSpend(months, timeInvariantData.InvestmentSpendByAccountType, ref result, 0);

            return result;
        }
    }
}
