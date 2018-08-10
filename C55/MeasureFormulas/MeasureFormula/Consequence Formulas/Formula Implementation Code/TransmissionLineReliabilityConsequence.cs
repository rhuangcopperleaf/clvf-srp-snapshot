using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionLineReliabilityConsequence : TransmissionLineReliabilityConsequenceBase
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

            // The LineVoltage is in USD/Day (in zynos), and the TimeToRepair is ih Hours
            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months,
                                        (x => (x.Line_32_Voltage != null ? 
                                              (x.Line_32_Voltage.Value / CommonConstants.HoursInDay) : 0)
                                            * (x.Time_32_to_32_Repair ?? 0)));
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
