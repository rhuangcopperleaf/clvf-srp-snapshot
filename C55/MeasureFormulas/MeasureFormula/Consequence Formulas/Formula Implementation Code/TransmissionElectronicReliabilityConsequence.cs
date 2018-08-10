using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionElectronicReliabilityConsequence : TransmissionElectronicReliabilityConsequenceBase
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

            // Cannot calculate cosequence if system parameters are missing or have no values
            if (timeInvariantData.SystemCost_32_of_32_Replacement_32_Energy == null
                || timeInvariantData.SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal == null
                || timeInvariantData.SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas == null)
            {
                return null;
            }

            var costOfLostLoad = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months,
                                                                    (x => x.Transmission_32_Load_32_at_32_Risk
                                                                    * x.Time_32_to_32_Repair * CustomerConstants.transmissionLoadPrice));

            var costOfCurtailment = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear, months,
                                                                    (x => x.Generation_32_Curtailment ?? 0));

            var typeOfGeneration = timeInvariantData.Type_32_of_32_Generation_32__40_Elec_32_Asset_41_;

            // Invalid input, return zero values
            if (costOfLostLoad == null || costOfCurtailment == null || typeOfGeneration == null)
            {
                return PopulateOutputWithValue(months, 0);
            }

            var result = new double?[months];
            for (int i = 0; i < months; i++)
            {
                if (costOfCurtailment == null && costOfCurtailment[i] == null)
                {
                    continue;
                }

                switch (typeOfGeneration.ValueAsInteger)
                {
                    case (CustomerConstants.genTechHydro):
                        {
                            costOfCurtailment[i] = costOfCurtailment[i] *
                                timeInvariantData.SystemCost_32_of_32_Replacement_32_Energy.GetMonthlyValue(startFiscalYear, i);
                        }
                        break;
                    case (CustomerConstants.genTechCoal):
                        {
                            costOfCurtailment[i] = costOfCurtailment[i] *
                                (timeInvariantData.SystemCost_32_of_32_Replacement_32_Energy.GetMonthlyValue(startFiscalYear, i) -
                                    timeInvariantData.SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal.GetMonthlyValue(startFiscalYear, i));
                        }
                        break;
                    case (CustomerConstants.genTechGas):
                        {
                            costOfCurtailment[i] = costOfCurtailment[i] *
                                (timeInvariantData.SystemCost_32_of_32_Replacement_32_Energy.GetMonthlyValue(startFiscalYear, i) -
                                    timeInvariantData.SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas.GetMonthlyValue(startFiscalYear, i));
                        }
                        break;
                }

                result[i] = HelperFunctions.MaxNullable(costOfCurtailment[i], costOfLostLoad[i]);
                if (result[i].HasValue)
                {
                    result[i] = result[i].Value * CommonConstants.DollarToZynoConversionFactor;
                }
            }

            return result;
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
