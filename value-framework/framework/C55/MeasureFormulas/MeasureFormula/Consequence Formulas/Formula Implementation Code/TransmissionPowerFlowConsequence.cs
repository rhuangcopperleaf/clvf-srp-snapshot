using System;
using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class TransmissionPowerFlowConsequence : TransmissionPowerFlowConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
            TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // We have to calculate and sum up two different risks in a single model.
            // Therefore, the entire Risk is calculated in the consequence formula, 
            // and the likelihood formula returns default 100% probability.

            var violationTypes = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear,
                                                               months, (x => x.Violation_32_Type.ValueAsInteger));

            var peakLoads = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear,
                                                                     months, (x => x.Peak_32_Load));

            var continuousRatings = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear,
                                                                             months, (x => x.Continuous_32_Rating));

            var transformersCapacities = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear,
                                                                             months, (x => x.Transformers_32_Capacity));

            var voltageViolations = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData, startFiscalYear,
                                                                     months, (x => x.Voltage_32_Violation));

            var powerFlowRisk = new double?[months];
            for (int i = 0; i < months; i++)
            {
                powerFlowRisk[i] = null;

                if (violationTypes[i] == null)
                {
                    continue;
                }

                var violationType = Convert.ToInt32(violationTypes[i].Value);
                switch (violationType)
                {
                    case (CustomerConstants.violationA):
                        {
                            powerFlowRisk[i] = CustomerConstants.consequence_Catastrophic;
                        }
                        break;
                    case (CustomerConstants.violationB):
                        {
                            double? overloadViolationRisk = 0d;
                            double? voltageViolationRisk = 0d;

                            // Overload Violation risk
                            if (peakLoads != null && continuousRatings != null 
                                && peakLoads[i].HasValue && continuousRatings[i].HasValue)
                            {
                                var consequence = (peakLoads[i].Value - continuousRatings[i].Value) * CustomerConstants.powerFlowConsequenceFactor;
                                var likelihood = ((peakLoads[i].Value / continuousRatings[i].Value) - 1) * 100d * CustomerConstants.violationB_LikelihoodFactor;
                                overloadViolationRisk = consequence * likelihood;
                            }
                            // Voltage Violation risk
                            if (transformersCapacities != null && voltageViolations != null
                                && transformersCapacities[i].HasValue && voltageViolations[i].HasValue)
                            {
                                // transformersCapacity is MVA, voltageViolation is %
                                var consequence = transformersCapacities[i].Value * CustomerConstants.powerFactor * CustomerConstants.powerFlowConsequenceFactor;
                                var likelihood = voltageViolations[i].Value * CustomerConstants.violationB_LikelihoodFactor;
                                voltageViolationRisk = consequence * likelihood;
                            }
                            if (overloadViolationRisk.HasValue || voltageViolationRisk.HasValue)
                            {
                                powerFlowRisk[i] = (overloadViolationRisk ?? 0) + (voltageViolationRisk ?? 0);
                            }
                        }
                        break;
                    case (CustomerConstants.violationC):
                        {
                            double? overloadViolationRisk = 0d;
                            double? voltageViolationRisk = 0d;

                            // Overload Violation risk
                            if (peakLoads != null && continuousRatings != null
                                && peakLoads[i].HasValue && continuousRatings[i].HasValue)
                            {
                                var consequence = (peakLoads[i].Value - continuousRatings[i].Value) * CustomerConstants.powerFlowConsequenceFactor;
                                var likelihood = ((peakLoads[i].Value / continuousRatings[i].Value) - 1) * 100d * CustomerConstants.violationC_LikelihoodFactor;
                                overloadViolationRisk = consequence * likelihood;
                            }
                            // Voltage Violation risk
                            if (transformersCapacities != null && voltageViolations != null
                                && transformersCapacities[i].HasValue && voltageViolations[i].HasValue)
                            {
                                // transformersCapacity is MVA, voltageViolation is %
                                var consequence = transformersCapacities[i].Value * CustomerConstants.powerFactor * CustomerConstants.powerFlowConsequenceFactor;
                                var likelihood = voltageViolations[i].Value * CustomerConstants.violationC_LikelihoodFactor;
                                voltageViolationRisk = consequence * likelihood;
                            }
                            if (overloadViolationRisk.HasValue || voltageViolationRisk.HasValue)
                            {
                                powerFlowRisk[i] = (overloadViolationRisk ?? 0) + (voltageViolationRisk ?? 0);
                            }
                        }
                        break;
                    case (CustomerConstants.violationD):
                        {
                            powerFlowRisk[i] = CustomerConstants.powerFlowConsequenceD * CustomerConstants.powerFlowLikelihoodD;
                        }
                        break;
                    default:
                        break;
                }
            }
            return powerFlowRisk;
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
