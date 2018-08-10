using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    /// <summary>
    /// Returns the maximum of frequency of duration cost for avoided electricity outages.
    /// </summary>
    public class ElectricDistributionReliabilityConsequence : ElectricDistributionReliabilityConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // Cannot calculate cosequence if system parameters are missing or have no values
            if (!timeInvariantData.SystemCMI_32_cost_32__40__36__41_.HasValue
                || !timeInvariantData.SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Residential.HasValue
                || !timeInvariantData.SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Residential.HasValue
                || !timeInvariantData.SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial.HasValue
                || !timeInvariantData.SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial.HasValue
                || !timeInvariantData.SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Purely_32_Commercial.HasValue
                || !timeInvariantData.SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Purely_32_Commercial.HasValue
                || !timeInvariantData.SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_System_32_Average_32__47__32_Transmission.HasValue
                || !timeInvariantData.SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_System_32_Average_32__47__32_Transmission.HasValue)
            {
                return null;
            }

            double? CMICost = timeInvariantData.SystemCMI_32_cost_32__40__36__41_.Value;
            double? durationCost;
            double? frequencyCost;

            var loadType = timeInvariantData.Type_32_of_32_Load.ValueAsInteger;
            switch (loadType)
            {
                case (CustomerConstants.LoadTypeResidential):
                    {
                        durationCost = timeInvariantData.SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Residential.Value;
                        frequencyCost = timeInvariantData.SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Residential.Value;
                        break;
                    }
                case (CustomerConstants.LoadTypeMixed):
                    {
                        durationCost = timeInvariantData.SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial.Value;
                        frequencyCost = timeInvariantData.SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial.Value;
                        break;
                    }
                case (CustomerConstants.LoadTypeCommercial):
                    {
                        durationCost = timeInvariantData.SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Purely_32_Commercial.Value;
                        frequencyCost = timeInvariantData.SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Purely_32_Commercial.Value;
                        break;
                    }

                case (CustomerConstants.LoadTypeCritical):
                    {
                        durationCost = CustomerConstants.MultiplerCritical * timeInvariantData.SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Purely_32_Commercial.Value;
                        frequencyCost = CustomerConstants.MultiplerCritical * timeInvariantData.SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Purely_32_Commercial.Value;
                        break;
                    }
                    
                case (CustomerConstants.LoadTypeTransmission):
                    {
                        durationCost = timeInvariantData.SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_System_32_Average_32__47__32_Transmission.Value;
                        frequencyCost = timeInvariantData.SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_System_32_Average_32__47__32_Transmission.Value;
                        break;
                    }
                default:
                    {
                        return null;
                    }
            }

            var result = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                                                    startFiscalYear,
                                                    months, (x =>
                                                    (
                                                        TandDHelperFunctions.getReliabilityCost(CustomerConstants.SeverityUnableServeLoad,
                                                            durationCost, frequencyCost, CMICost, (x.Peak_32_Lost_32_Load ?? 0),
                                                            x.Annual_32_Failure_32_Frequency, x.Outage_32_Duration, x.Number_32_of_32_Customers_32_Impacted)
                                                    + 
                                                        TandDHelperFunctions.getReliabilityCost(CustomerConstants.SeverityLostRedundancy,
                                                            durationCost, frequencyCost, CMICost, (x.Peak_32_Lost_32_Load ?? 0),
                                                            x.Annual_32_Failure_32_Frequency, x.Lost_32_Redundancy_32_Duration, x.Number_32_of_32_Customers_32_Impacted)
                                                    ) ?? 0));
            return result;
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
