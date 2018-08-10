using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionFaultComplianceConsequence : TransmissionFaultComplianceConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // NOTE: Formula assumes that "BESS Risk Issue" is used consistently accross the all time-variant answers (i.e. once true - always true).

            // Measure is calculated only if "BESS Risk Issue" is true
            if (timeVariantData.Any(answer => answer.BES_32_Risk_32_Issue == true))
            {
                return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                                startFiscalYear,
                                months, (x => x.BES_32_Risk_32_Issue
                                                ? (CustomerConstants.consequence_Catastrophic)
                                                : CustomerConstants.consequence_None));
            }

            return null;
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
