using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class OperationalFlexibilityReliabilityConsequence : OperationalFlexibilityReliabilityConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear,
                                                             months, (x => (x.Radial_32_Load * CustomerConstants.industrialCustomerOutageCost 
                                                                            + x.Number_32_of_32_Sensitive_32_Customers * CustomerConstants.sensitiveCustomerOutageCost)
                                                                            * CommonConstants.DollarToZynoConversionFactor));
        }

        public override double?[] GetZynos(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData,
            IReadOnlyList<TimeVariantInputDTO> timeVariantData,
            double?[] unitOutput)
        {
            return unitOutput;
        }
    }
}
