using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;

namespace CustomerFormulaCode
{
    [Formula]
    public class CostAvoidanceCapitalAutomaticOutcome : CostAvoidanceCapitalAutomaticOutcomeBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // We cannot use prompts in Automatic Outcome questionnaire, so we cannot check for the selected Account Type directly. 
            // Instead, we are checking if the Capital related measure has any output

            // This will return null if the Capital account type is not selected by user.
            var capitalSpends = timeInvariantData.Cost_32_Avoidance_Cost_32_Avoidance_32__32__45__32_Capital_ConsqUnitOutput_B;
            if (capitalSpends == null)
            {
                return null; // this eliminate measure output
            }

            // Return 0 values after the end of spend
            var result = new double?[months];
            FillWithValueAfterEndOfSpend(months, timeInvariantData.InvestmentSpendByAccountType, ref result, 0);

            return result; // this eliminate risk at the end of investment
        }

        public override double?[] GetZynos(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData,
            IReadOnlyList<TimeVariantInputDTO> timeVariantData,
            double?[] unitOutput)
        {
            return unitOutput; // always zero
        }
    }
}
