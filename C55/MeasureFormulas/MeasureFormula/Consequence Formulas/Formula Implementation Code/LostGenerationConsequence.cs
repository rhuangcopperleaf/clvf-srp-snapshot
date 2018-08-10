using System.Collections.Generic;
using CL.FormulaHelper.Attributes;
using MeasureFormulas.Generated_Formula_Base_Classes;
using MeasureFormula.Common_Code;

namespace CustomerFormulaCode
{
    [Formula]
    public class LostGenerationConsequence : LostGenerationConsequenceBase
    {
        public override double?[] GetUnits(int startFiscalYear, int months,
                                           TimeInvariantInputDTO timeInvariantData, IReadOnlyList<TimeVariantInputDTO> timeVariantData)
        {
            // Cannot calculate cosequence if system parameters are missing or have no values
            if (timeInvariantData.SystemCost_32_of_32_Replacement_32_Energy == null
                || timeInvariantData.SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal == null
                || timeInvariantData.SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas == null)
            {
                return null;
            }


            var lostMWh = InterpolatePropagate<TimeVariantInputDTO>(timeVariantData,
                                                                    startFiscalYear,
                                                                    months, (x => x.Lost_32_Generation));

            var revenueLost = new double?[months];
            switch (timeInvariantData.Plant_32_Type.ValueAsInteger)
            {

                case (CustomerConstants.genTechHydro):
                    {
                        for (int i = 0; i < months; i++)
                        {
                            revenueLost[i] = lostMWh[i] *
                                timeInvariantData.SystemCost_32_of_32_Replacement_32_Energy.GetMonthlyValue(startFiscalYear, i);
                        }
                    }
                    break;
                case (CustomerConstants.genTechCoal):
                    {
                        for (int i = 0; i < months; i++)
                        {
                            revenueLost[i] = lostMWh[i] *
                                (timeInvariantData.SystemCost_32_of_32_Replacement_32_Energy.GetMonthlyValue(startFiscalYear, i) -
                                 timeInvariantData.SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Coal.GetMonthlyValue(startFiscalYear, i));
                        }
                    }
                    break;
                case (CustomerConstants.genTechGas):
                    {
                        for (int i = 0; i < months; i++)
                        {
                            revenueLost[i] = lostMWh[i] *
                                (timeInvariantData.SystemCost_32_of_32_Replacement_32_Energy.GetMonthlyValue(startFiscalYear, i) -
                                 timeInvariantData.SystemFuel_32_Cost_32__40__36__32__47__32_MWh_41__32__45__32_Natural_32_Gas.GetMonthlyValue(startFiscalYear, i));
                        }
                    }
                    break;
                default:
                    {
                        return null;
                    }
            }

            return revenueLost;
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
