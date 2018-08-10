// GENERATED CODE - DO NOT EDIT !!!
using System.Collections.Generic;
using CL.FormulaHelper;
using CL.FormulaHelper.Attributes;
using CL.FormulaHelper.DTOs;
using System.Runtime.Serialization;

namespace MeasureFormulas.Generated_Formula_Base_Classes
{
    [FormulaBase]
    public abstract class LostGenerationConsequenceBase : FormulaConsequenceBase
    {
        [DataContract]
        public class TimeInvariantInputDTO
        {
            public TimeInvariantInputDTO(
                CL.FormulaHelper.DTOs.CustomFieldListItemDTO p_Plant_32_Type,
                CL.FormulaHelper.DTOs.TimeSeriesDTO p_SystemCost_32_of_32_Replacement_32_Energy,
                CL.FormulaHelper.DTOs.TimeSeriesDTO p_SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal,
                CL.FormulaHelper.DTOs.TimeSeriesDTO p_SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas)
            {
                Plant_32_Type = p_Plant_32_Type;
                SystemCost_32_of_32_Replacement_32_Energy = p_SystemCost_32_of_32_Replacement_32_Energy;
                SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal = p_SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal;
                SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas = p_SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas;
            }
            
            [PromptInput("Plant Type")]
            [DataMember]
            public CL.FormulaHelper.DTOs.CustomFieldListItemDTO Plant_32_Type  { get; private set; }
            
            [CustomFieldInput("Cost of Replacement Energy", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public CL.FormulaHelper.DTOs.TimeSeriesDTO SystemCost_32_of_32_Replacement_32_Energy  { get; private set; }
            
            [CustomFieldInput("Fuel Cost ($ / MWh) - Coal", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public CL.FormulaHelper.DTOs.TimeSeriesDTO SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal  { get; private set; }
            
            [CustomFieldInput("Fuel Cost ($ / MWh) - Natural Gas", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public CL.FormulaHelper.DTOs.TimeSeriesDTO SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas  { get; private set; }
        }
        
        [DataContract]
        public class TimeVariantInputDTO : ITimeVariantInputDTO
        {
            public TimeVariantInputDTO(
                System.Double p_Lost_32_Generation,
                CL.FormulaHelper.DTOs.TimePeriodDTO p_TimePeriod)
            {
                Lost_32_Generation = p_Lost_32_Generation;
                TimePeriod = p_TimePeriod;
            }
            
            [PromptInput("Lost Generation")]
            [DataMember]
            public System.Double Lost_32_Generation  { get; private set; }
            
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
