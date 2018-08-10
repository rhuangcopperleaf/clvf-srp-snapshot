using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using System.Linq;
using CL.FormulaHelper;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;
using CL.FormulaHelper.DTOs;

namespace CustomerFormulaCode
{
    [Formula]
    public class GenericEndOfLifeConditionOutcome : GenericEndOfLifeConditionOutcomeBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // TODO: Pass this as a value measure
            var answers = timeVariantData.FirstOrDefault();
            double estimatedDesignLife = timeInvariantData.Design_32_Life;


            CL.FormulaHelper.DTOs.TimePeriodDTO timePeriod = new CL.FormulaHelper.DTOs.TimePeriodDTO();
            var endOfSpendMonthOffset = FormulaBase.FindEndOfSpendMonth(timeInvariantData.InvestmentSpendByAccountType);
            if (!endOfSpendMonthOffset.HasValue)
            {
                return null;
            }
            timePeriod.StartTime = FormulaBase.GetCalendarDateTime(startFiscalYear, fiscalPeriod: 1)
                               .AddMonths(endOfSpendMonthOffset.Value + 1); // + 1 because the benefit starts in the first month after end of spend. 

            TimeVariantLocalConditionDTO localTimeInvariantData =
                new TimeVariantLocalConditionDTO(answers.Condition, timePeriod);

            List<TimeVariantLocalConditionDTO> localTimeInvariantDataList
                = new List<TimeVariantLocalConditionDTO>();
            localTimeInvariantDataList.Add(localTimeInvariantData);

            // A generic end of life condition decay curve, generated based on the design life entered by user.
            XYCurveDTO conditionDecayCurve = HelperFunctions.GenericEndOfLifeModel.constructConditionDecayCurve(estimatedDesignLife);

            return InterpolateCurve<TimeVariantLocalConditionDTO>(localTimeInvariantDataList,
                startFiscalYear,
                months,
                conditionDecayCurve,
                x => x.ConditionScoreLocal);
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
