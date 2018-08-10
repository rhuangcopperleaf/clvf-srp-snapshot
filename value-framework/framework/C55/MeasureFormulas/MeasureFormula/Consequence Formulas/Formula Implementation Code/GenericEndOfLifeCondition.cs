using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using System.Linq;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;
using CL.FormulaHelper.DTOs;

namespace CustomerFormulaCode
{
    [Formula]
    public class GenericEndOfLifeCondition : GenericEndOfLifeConditionBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            var answers = timeVariantData.FirstOrDefault();
            double estimatedDesignLife = timeInvariantData.Design_32_Life;
           
            TimeVariantLocalConditionDTO localTimeInvariantData =
                new TimeVariantLocalConditionDTO (answers.Condition, answers.TimePeriod);
            
            /*IReadOnly*/List<TimeVariantLocalConditionDTO>  localTimeInvariantDataList
                = new List<TimeVariantLocalConditionDTO>();
            localTimeInvariantDataList.Add (localTimeInvariantData);

            // A generic end of life condition decay curve, generated based on the design life entered by user.
            XYCurveDTO conditionDecayCurve = HelperFunctions.GenericEndOfLifeModel.constructConditionDecayCurve(estimatedDesignLife);

            // From Zeus v18
            var monthlyConditionScores = MonthlyConditionScores<TimeVariantLocalConditionDTO>(
                startFiscalYear,
                months,
                null, // assetInServiceDate
                localTimeInvariantDataList,
                conditionDecayCurve,
                x => x.ConditionScoreLocal);

            return monthlyConditionScores;
        }
        
        public override double?[] GetZynos(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData,
            IReadOnlyList<TimeVariantInputDTO> timeVariantData,
            double?[] unitOutput)
        {
            return null;
        }
    }
}
