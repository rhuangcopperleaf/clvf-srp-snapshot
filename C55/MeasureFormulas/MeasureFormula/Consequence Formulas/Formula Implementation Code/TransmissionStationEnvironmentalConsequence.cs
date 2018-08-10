using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionStationEnvironmentalConsequence : TransmissionStationEnvironmentalConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // NOTE: Formula presumes that COF & POF values, if entered, are consistently used accross all time-variant answers.

            // When COF amount is used, we invalidate entire value measure
            var answers = timeVariantData.FirstOrDefault();
            if (answers != null && answers.COF != null)
            {
                return null;
            }

            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months,
                                                (x => x.Consequence_32_of_32_Environment_32_Risk != null
                                                    ? x.Consequence_32_of_32_Environment_32_Risk.Value
                                                    : 0));
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
