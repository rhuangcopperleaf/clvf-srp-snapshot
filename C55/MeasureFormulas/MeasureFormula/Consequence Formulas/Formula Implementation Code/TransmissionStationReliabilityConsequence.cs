using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionStationReliabilityConsequence : TransmissionStationReliabilityConsequenceBase
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


            // The StationVoltage is in USD/Day (in zynos), and the TimeToRepair is ih Hours
            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months, 
                                        (x => (x.Equipment_32_Type != null ? x.Equipment_32_Type.Value : 0)
                                        * (x.Station_32_Voltage != null ? (x.Station_32_Voltage.Value / CommonConstants.HoursInDay) : 0) 
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
