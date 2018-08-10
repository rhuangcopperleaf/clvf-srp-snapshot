// GENERATED CODE - DO NOT EDIT !!!
using System.Collections.Generic;
using CL.FormulaHelper;
using CL.FormulaHelper.Attributes;
using CL.FormulaHelper.DTOs;
using System.Runtime.Serialization;

namespace MeasureFormulas.Generated_Formula_Base_Classes
{
    [FormulaBase]
    public abstract class TransmissionStationSafetyLikelihoodBase : FormulaLikelihoodBase
    {
        [DataContract]
        public class TimeInvariantInputDTO
        {
            public TimeInvariantInputDTO(
                System.Double?[] p_Transmission_32_Station_32_Equipment_32_Risk_Transmission_32_Station_32__45__32_Reliability_LikelihoodUnitOutput)
            {
                Transmission_32_Station_32_Equipment_32_Risk_Transmission_32_Station_32__45__32_Reliability_LikelihoodUnitOutput = p_Transmission_32_Station_32_Equipment_32_Risk_Transmission_32_Station_32__45__32_Reliability_LikelihoodUnitOutput;
            }
            
            [MeasureInput("Transmission Station Equipment Risk", "Transmission Station - Reliability", MeasureOutputType.LikelihoodUnitOutput, false)]
            [DataMember]
            public System.Double?[] Transmission_32_Station_32_Equipment_32_Risk_Transmission_32_Station_32__45__32_Reliability_LikelihoodUnitOutput  { get; private set; }
        }
        
        [DataContract]
        public class TimeVariantInputDTO : ITimeVariantInputDTO
        {
            public TimeVariantInputDTO(
                System.Double? p_COF,
                System.Double? p_Probability_32_of_32_Danger,
                System.Double? p_Probability_32_of_32_Injury,
                System.Double? p_Probability_32_of_32_Person_32_in_32_Danger,
                CL.FormulaHelper.DTOs.TimePeriodDTO p_TimePeriod)
            {
                COF = p_COF;
                Probability_32_of_32_Danger = p_Probability_32_of_32_Danger;
                Probability_32_of_32_Injury = p_Probability_32_of_32_Injury;
                Probability_32_of_32_Person_32_in_32_Danger = p_Probability_32_of_32_Person_32_in_32_Danger;
                TimePeriod = p_TimePeriod;
            }
            
            [PromptInput("COF")]
            [DataMember]
            public System.Double? COF  { get; private set; }
            
            [PromptInput("Probability of Danger")]
            [DataMember]
            public System.Double? Probability_32_of_32_Danger  { get; private set; }
            
            [PromptInput("Probability of Injury")]
            [DataMember]
            public System.Double? Probability_32_of_32_Injury  { get; private set; }
            
            [PromptInput("Probability of Person in Danger")]
            [DataMember]
            public System.Double? Probability_32_of_32_Person_32_in_32_Danger  { get; private set; }
            
            [CoreFieldInput(FormulaCoreFieldInputType.TimePeriod)]
            [DataMember]
            public CL.FormulaHelper.DTOs.TimePeriodDTO TimePeriod  { get; private set; }
        }
        
        public abstract double?[] GetLikelihoodValues(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData);
            
        
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
