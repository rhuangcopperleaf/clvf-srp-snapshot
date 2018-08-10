// GENERATED CODE - DO NOT EDIT !!!
using System.Collections.Generic;
using CL.FormulaHelper;
using CL.FormulaHelper.Attributes;
using CL.FormulaHelper.DTOs;
using System.Runtime.Serialization;

namespace MeasureFormulas.Generated_Formula_Base_Classes
{
    [FormulaBase]
    public abstract class TransmissionElectronicReliabilityConsequenceBase : FormulaConsequenceBase
    {
        [DataContract]
        public class TimeInvariantInputDTO
        {
            public TimeInvariantInputDTO(
                CL.FormulaHelper.DTOs.TimeSeriesDTO p_SystemCost_32_of_32_Replacement_32_Energy,
                CL.FormulaHelper.DTOs.TimeSeriesDTO p_SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal,
                CL.FormulaHelper.DTOs.TimeSeriesDTO p_SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas,
                CL.FormulaHelper.DTOs.CustomFieldListItemDTO p_Type_32_of_32_Generation_32__40_Elec_32_Asset_41_)
            {
                SystemCost_32_of_32_Replacement_32_Energy = p_SystemCost_32_of_32_Replacement_32_Energy;
                SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal = p_SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal;
                SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas = p_SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas;
                Type_32_of_32_Generation_32__40_Elec_32_Asset_41_ = p_Type_32_of_32_Generation_32__40_Elec_32_Asset_41_;
            }
            
            [CustomFieldInput("Cost of Replacement Energy", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public CL.FormulaHelper.DTOs.TimeSeriesDTO SystemCost_32_of_32_Replacement_32_Energy  { get; private set; }
            
            [CustomFieldInput("Fuel Cost ($ / MWh) - Coal", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public CL.FormulaHelper.DTOs.TimeSeriesDTO SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal  { get; private set; }
            
            [CustomFieldInput("Fuel Cost ($ / MWh) - Natural Gas", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public CL.FormulaHelper.DTOs.TimeSeriesDTO SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas  { get; private set; }
            
            [PromptInput("Type of Generation (Elec Asset)")]
            [DataMember]
            public CL.FormulaHelper.DTOs.CustomFieldListItemDTO Type_32_of_32_Generation_32__40_Elec_32_Asset_41_  { get; private set; }
        }
        
        [DataContract]
        public class TimeVariantInputDTO : ITimeVariantInputDTO
        {
            public TimeVariantInputDTO(
                System.Double? p_COF,
                System.Double? p_Generation_32_Curtailment,
                System.Double? p_Time_32_to_32_Repair,
                CL.FormulaHelper.DTOs.TimePeriodDTO p_TimePeriod,
                System.Double? p_Transmission_32_Load_32_at_32_Risk)
            {
                COF = p_COF;
                Generation_32_Curtailment = p_Generation_32_Curtailment;
                Time_32_to_32_Repair = p_Time_32_to_32_Repair;
                TimePeriod = p_TimePeriod;
                Transmission_32_Load_32_at_32_Risk = p_Transmission_32_Load_32_at_32_Risk;
            }
            
            [PromptInput("COF")]
            [DataMember]
            public System.Double? COF  { get; private set; }
            
            [PromptInput("Generation Curtailment")]
            [DataMember]
            public System.Double? Generation_32_Curtailment  { get; private set; }
            
            [PromptInput("Time to Repair")]
            [DataMember]
            public System.Double? Time_32_to_32_Repair  { get; private set; }
            
            [CoreFieldInput(FormulaCoreFieldInputType.TimePeriod)]
            [DataMember]
            public CL.FormulaHelper.DTOs.TimePeriodDTO TimePeriod  { get; private set; }
            
            [PromptInput("Transmission Load at Risk")]
            [DataMember]
            public System.Double? Transmission_32_Load_32_at_32_Risk  { get; private set; }
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
