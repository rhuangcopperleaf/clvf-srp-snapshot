using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    /// <summary>
    /// Values an increas in renewable capacity through additional generation or transmission investments to enable the connection of that generation.
    /// This formula uses constants specified in CustomerConstants.cs
    /// Returns Annual Consequence values.  Expected to be used in conjunction with a likelihood formula that returns monthly values
    /// </summary>
    public class RenewableCapacityConsequence : RenewableCapacityConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            var renewableCapacityValues = timeInvariantData.SystemRenewable_32_Capacity_32_Value_32__40__36__47_MW_41__32_TimeSeries;
            var renewableCapacityAdded = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                                                             startFiscalYear,
                                                             months, (x => x.Renewable_32_Capacity_32_Added));

            if (renewableCapacityValues == null || renewableCapacityAdded == null)
            {
                return null;
            }

            var result = HelperFunctions.scaleValues(startFiscalYear, months, renewableCapacityAdded, renewableCapacityValues);
            return result;
        }

        public override double?[] GetZynos(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData,
                                           IReadOnlyList<TimeVariantInputDTO> timeVariantData,
                                           double?[] unitOutput)
        {
            return ConvertUnitsToZynos(unitOutput, CommonConstants.DollarToZynoConversionFactor);
        }
    }
}
