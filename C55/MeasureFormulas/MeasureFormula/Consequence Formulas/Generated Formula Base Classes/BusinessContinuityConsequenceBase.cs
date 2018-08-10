// GENERATED CODE - DO NOT EDIT !!!
using System.Collections.Generic;
using CL.FormulaHelper;
using CL.FormulaHelper.Attributes;
using CL.FormulaHelper.DTOs;
using System.Runtime.Serialization;

namespace MeasureFormulas.Generated_Formula_Base_Classes
{
    [FormulaBase]
    public abstract class BusinessContinuityConsequenceBase : FormulaConsequenceBase
    {
        [DataContract]
        public class TimeInvariantInputDTO
        {
            public TimeInvariantInputDTO(
                System.Boolean p_BIA_32_Critical,
                System.Boolean p_Interruption_32_Exceeds_32_RTO,
                System.Double? p_SystemEmployee_32_Productivity_32_Cost_32_Per_32_Year,
                System.Double? p_SystemImpact_32_to_32_Critical_32_Process)
            {
                BIA_32_Critical = p_BIA_32_Critical;
                Interruption_32_Exceeds_32_RTO = p_Interruption_32_Exceeds_32_RTO;
                SystemEmployee_32_Productivity_32_Cost_32_Per_32_Year = p_SystemEmployee_32_Productivity_32_Cost_32_Per_32_Year;
                SystemImpact_32_to_32_Critical_32_Process = p_SystemImpact_32_to_32_Critical_32_Process;
            }
            
            [PromptInput("BIA Critical")]
            [DataMember]
            public System.Boolean BIA_32_Critical  { get; private set; }
            
            [PromptInput("Interruption Exceeds RTO")]
            [DataMember]
            public System.Boolean Interruption_32_Exceeds_32_RTO  { get; private set; }
            
            [CustomFieldInput("Employee Productivity Cost Per Year", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemEmployee_32_Productivity_32_Cost_32_Per_32_Year  { get; private set; }
            
            [CustomFieldInput("Impact to Critical Process", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemImpact_32_to_32_Critical_32_Process  { get; private set; }
        }
        
        [DataContract]
        public class TimeVariantInputDTO : ITimeVariantInputDTO
        {
            public TimeVariantInputDTO(
                System.Int32 p_Business_32_Continuity_32_Employees_32_Affected,
                CL.FormulaHelper.DTOs.CustomFieldListItemDTO p_Productivity_32_Impact,
                CL.FormulaHelper.DTOs.TimePeriodDTO p_TimePeriod)
            {
                Business_32_Continuity_32_Employees_32_Affected = p_Business_32_Continuity_32_Employees_32_Affected;
                Productivity_32_Impact = p_Productivity_32_Impact;
                TimePeriod = p_TimePeriod;
            }
            
            [PromptInput("Business Continuity Employees Affected")]
            [DataMember]
            public System.Int32 Business_32_Continuity_32_Employees_32_Affected  { get; private set; }
            
            [PromptInput("Productivity Impact")]
            [DataMember]
            public CL.FormulaHelper.DTOs.CustomFieldListItemDTO Productivity_32_Impact  { get; private set; }
            
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
