// GENERATED CODE - DO NOT EDIT !!!
using System.Collections.Generic;
using CL.FormulaHelper;
using CL.FormulaHelper.Attributes;
using CL.FormulaHelper.DTOs;
using System.Runtime.Serialization;

namespace MeasureFormulas.Generated_Formula_Base_Classes
{
    [FormulaBase]
    public abstract class TransmissionElectronicFinancialLikelihoodBase : FormulaLikelihoodBase
    {
        [DataContract]
        public class TimeInvariantInputDTO
        {
            public TimeInvariantInputDTO(
                System.Double?[] p_Transmission_32_Electronic_32_Asset_32_Risk_Transmission_32_Electronic_32__45__32_Condition_ConsqUnitOutput)
            {
                Transmission_32_Electronic_32_Asset_32_Risk_Transmission_32_Electronic_32__45__32_Condition_ConsqUnitOutput = p_Transmission_32_Electronic_32_Asset_32_Risk_Transmission_32_Electronic_32__45__32_Condition_ConsqUnitOutput;
            }
            
            [MeasureInput("Transmission Electronic Asset Risk", "Transmission Electronic - Condition", MeasureOutputType.ConsqUnitOutput, false)]
            [DataMember]
            public System.Double?[] Transmission_32_Electronic_32_Asset_32_Risk_Transmission_32_Electronic_32__45__32_Condition_ConsqUnitOutput  { get; private set; }
        }
        
        [DataContract]
        public class TimeVariantInputDTO : ITimeVariantInputDTO
        {
            public TimeVariantInputDTO(
                System.Boolean p_Manufacturer_32_Support,
                System.Int32? p_Number_32_of_32_Assets,
                System.Double? p_POF,
                System.Boolean p_Self_32_Monitored,
                System.Boolean p_Standard_32_OS,
                CL.FormulaHelper.DTOs.TimePeriodDTO p_TimePeriod)
            {
                Manufacturer_32_Support = p_Manufacturer_32_Support;
                Number_32_of_32_Assets = p_Number_32_of_32_Assets;
                POF = p_POF;
                Self_32_Monitored = p_Self_32_Monitored;
                Standard_32_OS = p_Standard_32_OS;
                TimePeriod = p_TimePeriod;
            }
            
            [PromptInput("Manufacturer Support")]
            [DataMember]
            public System.Boolean Manufacturer_32_Support  { get; private set; }
            
            [PromptInput("Number of Assets")]
            [DataMember]
            public System.Int32? Number_32_of_32_Assets  { get; private set; }
            
            [PromptInput("POF")]
            [DataMember]
            public System.Double? POF  { get; private set; }
            
            [PromptInput("Self Monitored")]
            [DataMember]
            public System.Boolean Self_32_Monitored  { get; private set; }
            
            [PromptInput("Standard OS")]
            [DataMember]
            public System.Boolean Standard_32_OS  { get; private set; }
            
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
