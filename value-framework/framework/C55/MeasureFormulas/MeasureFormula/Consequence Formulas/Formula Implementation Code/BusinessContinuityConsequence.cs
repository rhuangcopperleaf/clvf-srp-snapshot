using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    /// <summary>
    /// Business Continuity Questionnaire formula calculates the consequence of an event that impacts the ability of employees to carry out the business of the compnay
    /// This formula uses constants specified in CustomerConstants.cs
    /// Returns Annual Consequence values.  Expected to be used in conjunction with a likelihood formula that returns monthly values
    /// </summary>
    public class BusinessContinuityConsequence : BusinessContinuityConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // Cannot calculate cosequence if system parameters are missing or have no values
            if (!timeInvariantData.SystemEmployee_32_Productivity_32_Cost_32_Per_32_Year.HasValue
                || !timeInvariantData.SystemImpact_32_to_32_Critical_32_Process.HasValue)
            {
                    return null;
            }

            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months, 
                                                            (x => (x.Business_32_Continuity_32_Employees_32_Affected 
                                                                    * x.Productivity_32_Impact.Value 
                                                                    * timeInvariantData.SystemEmployee_32_Productivity_32_Cost_32_Per_32_Year.Value)
                                                                  + ((timeInvariantData.BIA_32_Critical ? 1 : 0) 
                                                                    * (timeInvariantData.Interruption_32_Exceeds_32_RTO ? 1 : 0)
                                                                    * timeInvariantData.SystemImpact_32_to_32_Critical_32_Process)
                                                                  ));
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
