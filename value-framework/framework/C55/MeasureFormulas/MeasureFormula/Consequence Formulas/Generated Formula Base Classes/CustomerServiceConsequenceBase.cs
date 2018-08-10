// GENERATED CODE - DO NOT EDIT !!!
using System.Collections.Generic;
using CL.FormulaHelper;
using CL.FormulaHelper.Attributes;
using CL.FormulaHelper.DTOs;
using System.Runtime.Serialization;

namespace MeasureFormulas.Generated_Formula_Base_Classes
{
    [FormulaBase]
    public abstract class CustomerServiceConsequenceBase : FormulaConsequenceBase
    {
        [DataContract]
        public class TimeInvariantInputDTO
        {
            public TimeInvariantInputDTO(
                System.Double? p_SystemCall_32_Center_32_Cost,
                System.Double? p_SystemCall_32_Center_32_Cost_32_Per_32_Call,
                System.Int32? p_SystemContact_32_Center_32_Calls,
                System.Double? p_SystemLow_32_Effort_32_Customer_32_Value,
                System.Double? p_SystemSeconds_32_to_32_Close_32_Call)
            {
                SystemCall_32_Center_32_Cost = p_SystemCall_32_Center_32_Cost;
                SystemCall_32_Center_32_Cost_32_Per_32_Call = p_SystemCall_32_Center_32_Cost_32_Per_32_Call;
                SystemContact_32_Center_32_Calls = p_SystemContact_32_Center_32_Calls;
                SystemLow_32_Effort_32_Customer_32_Value = p_SystemLow_32_Effort_32_Customer_32_Value;
                SystemSeconds_32_to_32_Close_32_Call = p_SystemSeconds_32_to_32_Close_32_Call;
            }
            
            [CustomFieldInput("Call Center Cost", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemCall_32_Center_32_Cost  { get; private set; }
            
            [CustomFieldInput("Call Center Cost Per Call", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemCall_32_Center_32_Cost_32_Per_32_Call  { get; private set; }
            
            [CustomFieldInput("Contact Center Calls", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Int32? SystemContact_32_Center_32_Calls  { get; private set; }
            
            [CustomFieldInput("Low Effort Customer Value", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemLow_32_Effort_32_Customer_32_Value  { get; private set; }
            
            [CustomFieldInput("Seconds to Close Call", FormulaInputAssociatedEntity.System)]
            [DataMember]
            public System.Double? SystemSeconds_32_to_32_Close_32_Call  { get; private set; }
        }
        
        [DataContract]
        public class TimeVariantInputDTO : ITimeVariantInputDTO
        {
            public TimeVariantInputDTO(
                System.Double p_Agent_32_Time_32_Saved,
                System.Int32 p_Avoided_32_Inquiries,
                System.Int32 p_Low_32_Effort_32_Resolutions,
                System.Int32 p_Resolved_32_First_32_Contact,
                System.Int32 p_Self_32_Service_32_Resolutions,
                CL.FormulaHelper.DTOs.TimePeriodDTO p_TimePeriod)
            {
                Agent_32_Time_32_Saved = p_Agent_32_Time_32_Saved;
                Avoided_32_Inquiries = p_Avoided_32_Inquiries;
                Low_32_Effort_32_Resolutions = p_Low_32_Effort_32_Resolutions;
                Resolved_32_First_32_Contact = p_Resolved_32_First_32_Contact;
                Self_32_Service_32_Resolutions = p_Self_32_Service_32_Resolutions;
                TimePeriod = p_TimePeriod;
            }
            
            [PromptInput("Agent Time Saved")]
            [DataMember]
            public System.Double Agent_32_Time_32_Saved  { get; private set; }
            
            [PromptInput("Avoided Inquiries")]
            [DataMember]
            public System.Int32 Avoided_32_Inquiries  { get; private set; }
            
            [PromptInput("Low Effort Resolutions")]
            [DataMember]
            public System.Int32 Low_32_Effort_32_Resolutions  { get; private set; }
            
            [PromptInput("Resolved First Contact")]
            [DataMember]
            public System.Int32 Resolved_32_First_32_Contact  { get; private set; }
            
            [PromptInput("Self Service Resolutions")]
            [DataMember]
            public System.Int32 Self_32_Service_32_Resolutions  { get; private set; }
            
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
