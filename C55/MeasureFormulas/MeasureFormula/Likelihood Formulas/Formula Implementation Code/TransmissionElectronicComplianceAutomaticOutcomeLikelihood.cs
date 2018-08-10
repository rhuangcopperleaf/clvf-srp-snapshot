using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionElectronicComplianceAutomaticOutcomeLikelihood : TransmissionElectronicComplianceAutomaticOutcomeLikelihoodBase
    {
        public override double?[] GetLikelihoodValues(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // In baseline Compliance likelihood is not provided, do not output Automatic Output
            var monthlyBaselineComplianceProbabilities = timeInvariantData.Transmission_32_Electronic_32_Asset_32_Risk_Transmission_32_Electronic_32__45__32_Compliance_ConsqUnitOutput_B;
            if (monthlyBaselineComplianceProbabilities == null)
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
