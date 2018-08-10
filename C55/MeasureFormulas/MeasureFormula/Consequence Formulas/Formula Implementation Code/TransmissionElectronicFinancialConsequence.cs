using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionElectronicFinancialConsequence : TransmissionElectronicFinancialConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // Risk consequence is the COF if it was entered in the questionnaire
            // NOTE: Formula presumes that COF value, once entered, is consistently used accross all time-variant answers.
            var answers = timeVariantData.FirstOrDefault();
            if (answers != null && answers.COF != null)
            {
                return InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months, 
                                            (x => x.COF * CommonConstants.DollarToZynoConversionFactor)); // COF is in Dollars ($)
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
