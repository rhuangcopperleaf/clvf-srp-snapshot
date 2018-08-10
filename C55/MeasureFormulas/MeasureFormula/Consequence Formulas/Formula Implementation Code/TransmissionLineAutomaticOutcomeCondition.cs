using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using CL.FormulaHelper.DTOs;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionLineAutomaticOutcomeCondition : TransmissionLineAutomaticOutcomeConditionBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            var estimatedDesignLifeMeasure = timeInvariantData.Transmission_32_Line_32_Risk_Transmission_32_Line_32__45__32_Design_32_Life_ConsqUnitOutput_B;
            if (estimatedDesignLifeMeasure == null)
            {
                return null;
            }

            double estimatedDesignLife = estimatedDesignLifeMeasure[0].Value;
            double defaultOutcomeCondition = 10.0;

            TimePeriodDTO timePeriod = new TimePeriodDTO();
            var endOfSpendMonthOffset = FindEndOfSpendMonth(timeInvariantData.InvestmentSpendByAccountType);
            if (!endOfSpendMonthOffset.HasValue)
            {
                return null;
            }
            timePeriod.StartTime = GetCalendarDateTime(startFiscalYear, fiscalPeriod: 1)
                                    .AddMonths(endOfSpendMonthOffset.Value + 1); // + 1 because the benefit starts in the first month after end of spend. 

            TimeVariantLocalConditionDTO localTimeInvariantData =
                new TimeVariantLocalConditionDTO(defaultOutcomeCondition, timePeriod);

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
            return unitOutput; // risks consequence is already in value units
        }
    }
}
