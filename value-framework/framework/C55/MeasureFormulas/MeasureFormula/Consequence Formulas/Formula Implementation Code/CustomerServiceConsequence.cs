using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class CustomerServiceConsequence : CustomerServiceConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // Cannot calculate cosequence if system parameters are missing or have no values
            if (!timeInvariantData.SystemCall_32_Center_32_Cost.HasValue
                || !timeInvariantData.SystemCall_32_Center_32_Cost_32_Per_32_Call.HasValue
                || !timeInvariantData.SystemContact_32_Center_32_Calls.HasValue
                || !timeInvariantData.SystemSeconds_32_to_32_Close_32_Call.HasValue
                || !timeInvariantData.SystemLow_32_Effort_32_Customer_32_Value.HasValue)
            {
                return null;
            }

            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                                                             startFiscalYear,
                                                             months, (x => ((x.Avoided_32_Inquiries * timeInvariantData.SystemSeconds_32_to_32_Close_32_Call.Value
                                                                                + timeInvariantData.SystemContact_32_Center_32_Calls.Value * x.Agent_32_Time_32_Saved) 
                                                                                * timeInvariantData.SystemCall_32_Center_32_Cost.Value / CommonConstants.SecondsInHour
                                                                            + 
                                                                            (x.Self_32_Service_32_Resolutions 
                                                                                * timeInvariantData.SystemCall_32_Center_32_Cost_32_Per_32_Call.Value)
                                                                            +
                                                                            ((x.Resolved_32_First_32_Contact + x.Low_32_Effort_32_Resolutions)
                                                                                * timeInvariantData.SystemLow_32_Effort_32_Customer_32_Value.Value))));
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
