// GENERATED CODE - DO NOT EDIT !!!
using System.Collections.Generic;
using CL.FormulaHelper;
using CL.FormulaHelper.Attributes;
using CL.FormulaHelper.DTOs;
using System.Runtime.Serialization;

namespace MeasureFormulas.Generated_Formula_Base_Classes
{
    [FormulaBase]
    public abstract class EmployeeEngagementAttractionRetentionConsequenceBase : FormulaConsequenceBase
    {
        [DataContract]
        public class TimeInvariantInputDTO
        {
            public TimeInvariantInputDTO(
                System.Int32? p_SystemEmployee_32_Cost_32_to_32_Replace,
                System.Int32? p_SystemEmployee_32_Productivity_32_Value,
                System.Double? p_SystemLabour_32_Cost_32_Per_32_hour,
                System.Int32? p_SystemValue_32_per_32_Candidate_32_Attracted)
            {
                SystemEmployee_32_Cost_32_to_32_Replace = p_SystemEmployee_32_Cost_32_to_32_Replace;
                SystemEmployee_32_Productivity_32_Value = p_SystemEmployee_32_Productivity_32_Value;
                SystemLabour_32_Cost_32_Per_32_hour = p_SystemLabour_32_Cost_32_Per_32_hour;
                SystemValue_32_per_32_Candidate_32_Attracted = p_SystemValue_32_per_32_Candidate_32_Attracted;
            }
            
            [CustomFieldInput("Employee Cost to Replace", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Int32? SystemEmployee_32_Cost_32_to_32_Replace  { get; private set; }
            
            [CustomFieldInput("Employee Productivity Value", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Int32? SystemEmployee_32_Productivity_32_Value  { get; private set; }
            
            [CustomFieldInput("Labour Cost Per hour", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemLabour_32_Cost_32_Per_32_hour  { get; private set; }
            
            [CustomFieldInput("Value per Candidate Attracted", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Int32? SystemValue_32_per_32_Candidate_32_Attracted  { get; private set; }
        }
        
        [DataContract]
        public class TimeVariantInputDTO : ITimeVariantInputDTO
        {
            public TimeVariantInputDTO(
                System.Double p_Number_32_of_32_Candidates_32_Attracted,
                System.Double p_Number_32_of_32_Employees_32_Affected,
                System.Double p_Number_32_of_32_Employees_32_At_32_Risk_32_Of_32_Leaving,
                CL.FormulaHelper.DTOs.TimePeriodDTO p_TimePeriod,
                CL.FormulaHelper.DTOs.CustomFieldListItemDTO p_Workplace_32_Impact_32_On_32_Attractiveness,
                CL.FormulaHelper.DTOs.CustomFieldListItemDTO p_Workplace_32_Impact_32_On_32_Productivity)
            {
                Number_32_of_32_Candidates_32_Attracted = p_Number_32_of_32_Candidates_32_Attracted;
                Number_32_of_32_Employees_32_Affected = p_Number_32_of_32_Employees_32_Affected;
                Number_32_of_32_Employees_32_At_32_Risk_32_Of_32_Leaving = p_Number_32_of_32_Employees_32_At_32_Risk_32_Of_32_Leaving;
                TimePeriod = p_TimePeriod;
                Workplace_32_Impact_32_On_32_Attractiveness = p_Workplace_32_Impact_32_On_32_Attractiveness;
                Workplace_32_Impact_32_On_32_Productivity = p_Workplace_32_Impact_32_On_32_Productivity;
            }
            
            [PromptInput("Number of Candidates Attracted")]
            [DataMember]
            public System.Double Number_32_of_32_Candidates_32_Attracted  { get; private set; }
            
            [PromptInput("Number of Employees Affected")]
            [DataMember]
            public System.Double Number_32_of_32_Employees_32_Affected  { get; private set; }
            
            [PromptInput("Number of Employees At Risk Of Leaving")]
            [DataMember]
            public System.Double Number_32_of_32_Employees_32_At_32_Risk_32_Of_32_Leaving  { get; private set; }
            
            [CoreFieldInput(FormulaCoreFieldInputType.TimePeriod)]
            [DataMember]
            public CL.FormulaHelper.DTOs.TimePeriodDTO TimePeriod  { get; private set; }
            
            [PromptInput("Workplace Impact On Attractiveness")]
            [DataMember]
            public CL.FormulaHelper.DTOs.CustomFieldListItemDTO Workplace_32_Impact_32_On_32_Attractiveness  { get; private set; }
            
            [PromptInput("Workplace Impact On Productivity")]
            [DataMember]
            public CL.FormulaHelper.DTOs.CustomFieldListItemDTO Workplace_32_Impact_32_On_32_Productivity  { get; private set; }
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
