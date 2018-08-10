using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionElectronicFinancialAutomaticOutcomeConsequence : TransmissionElectronicFinancialAutomaticOutcomeConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // Do not produce any result unless there is a baseline calculated
            var baselineFinRiskConsequences = timeInvariantData.Transmission_32_Electronic_32_Asset_32_Risk_Transmission_32_Electronic_32__45__32_Financial_ConsqUnitOutput_B;
            if (baselineFinRiskConsequences == null)
            {
                return null;
            }

            // Return 0 values after the end of spend
            var result = new double?[months];
            FillWithValueAfterEndOfSpend(months, timeInvariantData.InvestmentSpendByAccountType, ref result, 0);

            return result;
        }

        public override double?[] GetZynos(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData,
            IReadOnlyList<TimeVariantInputDTO> timeVariantData,
            double?[] unitOutput)
        {
            return unitOutput; // risks consequence is already in value units        
        }
    }
}
