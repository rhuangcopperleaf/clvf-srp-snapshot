// GENERATED CODE - DO NOT EDIT !!!
using System.Collections.Generic;
using CL.FormulaHelper;
using CL.FormulaHelper.Attributes;
using CL.FormulaHelper.DTOs;
using System.Runtime.Serialization;

namespace MeasureFormulas.Generated_Formula_Base_Classes
{
    [FormulaBase]
    public abstract class ElectricDistributionReliabilityConsequenceBase : FormulaConsequenceBase
    {
        [DataContract]
        public class TimeInvariantInputDTO
        {
            public TimeInvariantInputDTO(
                System.Double? p_SystemCMI_32_cost_32__40__36__41_,
                System.Double? p_SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial,
                System.Double? p_SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Purely_32_Commercial,
                System.Double? p_SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Residential,
                System.Double? p_SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_System_32_Average_32__47__32_Transmission,
                System.Double? p_SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial,
                System.Double? p_SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Purely_32_Commercial,
                System.Double? p_SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Residential,
                System.Double? p_SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_System_32_Average_32__47__32_Transmission,
                CL.FormulaHelper.DTOs.CustomFieldListItemDTO p_Type_32_of_32_Load)
            {
                SystemCMI_32_cost_32__40__36__41_ = p_SystemCMI_32_cost_32__40__36__41_;
                SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial = p_SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial;
                SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Purely_32_Commercial = p_SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Purely_32_Commercial;
                SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Residential = p_SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Residential;
                SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_System_32_Average_32__47__32_Transmission = p_SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_System_32_Average_32__47__32_Transmission;
                SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial = p_SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial;
                SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Purely_32_Commercial = p_SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Purely_32_Commercial;
                SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Residential = p_SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Residential;
                SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_System_32_Average_32__47__32_Transmission = p_SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_System_32_Average_32__47__32_Transmission;
                Type_32_of_32_Load = p_Type_32_of_32_Load;
            }
            
            [CustomFieldInput("CMI cost ($)", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemCMI_32_cost_32__40__36__41_  { get; private set; }
            
            [CustomFieldInput("Duration Cost ($/kWh) - Mixed Residential, Commercial and Industrial", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial  { get; private set; }
            
            [CustomFieldInput("Duration Cost ($/kWh) - Purely Commercial", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Purely_32_Commercial  { get; private set; }
            
            [CustomFieldInput("Duration Cost ($/kWh) - Residential", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_Residential  { get; private set; }
            
            [CustomFieldInput("Duration Cost ($/kWh) - System Average / Transmission", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemDuration_32_Cost_32__40__36__47_kWh_41__32__45__32_System_32_Average_32__47__32_Transmission  { get; private set; }
            
            [CustomFieldInput("Frequency Cost ($/kW) - Mixed Residential, Commercial and Industrial", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Mixed_32_Residential_44__32_Commercial_32_and_32_Industrial  { get; private set; }
            
            [CustomFieldInput("Frequency Cost ($/kW) - Purely Commercial", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Purely_32_Commercial  { get; private set; }
            
            [CustomFieldInput("Frequency Cost ($/kW) - Residential", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_Residential  { get; private set; }
            
            [CustomFieldInput("Frequency Cost ($/kW) - System Average / Transmission", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemFrequency_32_Cost_32__40__36__47_kW_41__32__45__32_System_32_Average_32__47__32_Transmission  { get; private set; }
            
            [PromptInput("Type of Load")]
            [DataMember]
            public CL.FormulaHelper.DTOs.CustomFieldListItemDTO Type_32_of_32_Load  { get; private set; }
        }
        
        [DataContract]
        public class TimeVariantInputDTO : ITimeVariantInputDTO
        {
            public TimeVariantInputDTO(
                System.Double p_Annual_32_Failure_32_Frequency,
                System.Double p_Lost_32_Redundancy_32_Duration,
                System.Int32 p_Number_32_of_32_Customers_32_Impacted,
                System.Double p_Outage_32_Duration,
                System.Double? p_Peak_32_Lost_32_Load,
                CL.FormulaHelper.DTOs.TimePeriodDTO p_TimePeriod)
            {
                Annual_32_Failure_32_Frequency = p_Annual_32_Failure_32_Frequency;
                Lost_32_Redundancy_32_Duration = p_Lost_32_Redundancy_32_Duration;
                Number_32_of_32_Customers_32_Impacted = p_Number_32_of_32_Customers_32_Impacted;
                Outage_32_Duration = p_Outage_32_Duration;
                Peak_32_Lost_32_Load = p_Peak_32_Lost_32_Load;
                TimePeriod = p_TimePeriod;
            }
            
            [PromptInput("Annual Failure Frequency")]
            [DataMember]
            public System.Double Annual_32_Failure_32_Frequency  { get; private set; }
            
            [PromptInput("Lost Redundancy Duration")]
            [DataMember]
            public System.Double Lost_32_Redundancy_32_Duration  { get; private set; }
            
            [PromptInput("Number of Customers Impacted")]
            [DataMember]
            public System.Int32 Number_32_of_32_Customers_32_Impacted  { get; private set; }
            
            [PromptInput("Outage Duration")]
            [DataMember]
            public System.Double Outage_32_Duration  { get; private set; }
            
            [PromptInput("Peak Lost Load")]
            [DataMember]
            public System.Double? Peak_32_Lost_32_Load  { get; private set; }
            
            [CoreFieldInput(FormulaCoreFieldInputType.TimePeriod)]
            [DataMember]
            public CL.FormulaHelper.DTOs.TimePeriodDTO TimePeriod  { get; private set; }
        }
        
        public abstract double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData);
            
        public abstract double?[] GetZynos(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData,
            IReadOnlyList<TimeVariantInputDTO> timeVariantData,
            double?[] unitOutput);
        
        ///
        /// Class to enable formula debugging
        ///
        [DataContract]
        public class FormulaParams : IFormulaParams
        {
            public FormulaParams(CL.FormulaHelper.MeasureOutputType measureOutputType,
                string measureName,
                long alternativeId,
                string formulaImplClassName,
                bool isProbabilityFormula,
                int fiscalYearEndMonth,
                int startFiscalYear,
                int months,
                TimeInvariantInputDTO timeInvariantData,
                IReadOnlyList<TimeVariantInputDTO> timeVariantData,
                double?[] unitOutput,
                double?[] formulaOutput,
                string exceptionMessage)
            {
                MeasureOutputType = measureOutputType;
                MeasureName = measureName;
                AlternativeId = alternativeId;
                FormulaImplClassName = formulaImplClassName;
                IsProbabilityFormula = isProbabilityFormula;
                FiscalYearEndMonth = fiscalYearEndMonth;
                StartFiscalYear = startFiscalYear;
                Months = months;
                TimeInvariantData = timeInvariantData;
                TimeVariantData = timeVariantData;
                UnitOutput = unitOutput;
                FormulaOutput = formulaOutput;
                ExceptionMessage = exceptionMessage;
            }
            [DataMember(Order = 0)]
            public CL.FormulaHelper.MeasureOutputType MeasureOutputType { get; set; }
            [DataMember(Order = 1)]
            public string MeasureName { get; set; }
            [DataMember(Order = 2)]
            public long AlternativeId { get; set; }
            [DataMember(Order = 3)]
            public string FormulaImplClassName { get; set; }
            [DataMember(Order = 4)]
            public bool IsProbabilityFormula { get; set; }
            [DataMember(Order = 5)]
            public int FiscalYearEndMonth { get; set; }
            [DataMember(Order = 6)]
            public int StartFiscalYear { get; set; }
            [DataMember(Order = 7)]
            public int Months { get; set; }
            [DataMember(Order = 8)]
            public TimeInvariantInputDTO TimeInvariantData { get; set; }
            [DataMember(Order = 9)]
            public IReadOnlyList<TimeVariantInputDTO> TimeVariantData { get; set; }
            [DataMember(Order = 10)]
            public double?[] UnitOutput { get; set; }
            [DataMember(Order = 11)]
            public double?[] FormulaOutput { get; set; }
            [DataMember(Order = 12)]
            public string ExceptionMessage { get; set; }
        }
    }
}
// GENERATED CODE - DO NOT EDIT !!!
