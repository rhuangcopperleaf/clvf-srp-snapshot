using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    /// <summary>
    /// Productive Workplace Questionnaire formula calculates the consequence of an investment that improves employees recruitment, engagement or productivity.
    /// This formula uses constants specified in CustomerConstants.cs
    /// Returns Annual Consequence values.  Expected to be used in conjunction with a likelihood formula that returns monthly values
    /// </summary>
    public class EmployeeEngagementAttractionRetentionConsequence : EmployeeEngagementAttractionRetentionConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // Cannot calculate cosequence if system parameters are missing or have no values
            if (!timeInvariantData.SystemValue_32_per_32_Candidate_32_Attracted.HasValue
                || !timeInvariantData.SystemEmployee_32_Productivity_32_Value.HasValue
                || !timeInvariantData.SystemEmployee_32_Cost_32_to_32_Replace.HasValue)
            {
                return null;
            }

            return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                                                             startFiscalYear,
                                                             months, (x => 
                                                                (x.Number_32_of_32_Candidates_32_Attracted * x.Workplace_32_Impact_32_On_32_Attractiveness.Value
                                                                    * timeInvariantData.SystemValue_32_per_32_Candidate_32_Attracted.Value) +
                                                                (x.Number_32_of_32_Employees_32_Affected * x.Workplace_32_Impact_32_On_32_Productivity.Value
                                                                    * timeInvariantData.SystemEmployee_32_Productivity_32_Value.Value) +
                                                                (x.Number_32_of_32_Employees_32_At_32_Risk_32_Of_32_Leaving * x.Workplace_32_Impact_32_On_32_Productivity.Value
                                                                    * timeInvariantData.SystemEmployee_32_Cost_32_to_32_Replace.Value)
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
