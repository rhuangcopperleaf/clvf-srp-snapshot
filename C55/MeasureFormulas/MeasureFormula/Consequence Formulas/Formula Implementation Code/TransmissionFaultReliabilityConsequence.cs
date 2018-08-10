using System.Collections.Generic;
using System.Linq;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionFaultReliabilityConsequence : TransmissionFaultReliabilityConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // NOTE: Formula assumes that "BESS Risk Issue" is used consistently accross the all time-variant answers (i.e. once true - always true).

            // Measure ouptut is eliminated if "BESS Risk Issue" is true
            if (timeVariantData.Any(answer => answer.BES_32_Risk_32_Issue == true))
            {
                return null;
            }

            // Cannot calculate cosequence if system parameters are missing or have no values
            if (timeInvariantData.SystemCost_32_of_32_Replacement_32_Energy == null
            || timeInvariantData.SystemDamaging_32_Fault_32_Repair_32_Cost_32__40__36__41_ == null
            || timeInvariantData.SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal == null
            || timeInvariantData.SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas == null)
            {
                return null;
            }

            var costOfCurtailment = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                                                                    startFiscalYear,
                                                                    months, (x => (((1 + (x.Overload_32_Amount / (CustomerConstants.breakerOverloadRate * x.Fault_32_Current_32_Rating))) // (% Overload)
                                                                                    * CommonConstants.DaysInYear * CommonConstants.HoursInDay) * (x.Required_32_Generation_32_Curtailment ?? 0))
                                                                            ));

            var costOfLostLoad = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                                                                    startFiscalYear,
                                                                    months, (x => ((1 + (x.Overload_32_Amount / (CustomerConstants.breakerOverloadRate * x.Fault_32_Current_32_Rating))) // (1 + % Overload) 
                                                                                    * CustomerConstants.annualBusFaultProbability
                                                                                    * (x.Transmission_32_Load_32_at_32_Risk.HasValue ?
                                                                                       (x.Transmission_32_Load_32_at_32_Risk.Value * CustomerConstants.duration_2hours * CustomerConstants.transmissionLoadPrice
                                                                                       + timeInvariantData.SystemDamaging_32_Fault_32_Repair_32_Cost_32__40__36__41_.Value)
                                                                                    : 0))
                                                                            ));

            var typeOfGeneration = timeInvariantData.Type_32_of_32_Generation_32__40_Fault_32_Current_41_;

            // Invalid input, return zero values
            if (costOfLostLoad == null || costOfCurtailment == null || typeOfGeneration == null)
            {
                return PopulateOutputWithValue(months, 0);
            }

            var result = new double?[months];
            for (int i = 0; i < months; i++)
            {
                if (costOfCurtailment[i] == null)
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
