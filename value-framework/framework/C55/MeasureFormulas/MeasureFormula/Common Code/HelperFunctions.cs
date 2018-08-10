using MeasureFormula.Common_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.FormulaHelper.DTOs;
using MeasureFormulas.Generated_Formula_Base_Classes;
using CL.FormulaHelper;
using CL.FormulaHelper.Attributes;


namespace MeasureFormula.Common_Code
{
    public static class CommonConstants
    {
        /// <summary>
        /// Typical conversion factors used widely throughout the formulae
        /// </summary>
        public const double ZynoToDollarConversionFactor = 1000d;
        public const double DollarToZynoConversionFactor = 1d / 1000d;
        public const double HoursInYear = 8760d;
        public const double HoursInMonth = 365*24/12;
        public const double HoursInWeek = 7*24;
        public const double DaysInYear = 365d;
        public const double MonthsInYear = 12d;
        public const double HoursInDay = 24d;
        public const double MinutesInHour = 60d;
        public const double SecondsInHour = 3600d;
        public const double DollartoCents = 100d;
        public const double mWhtokWh = 1000d;
    }
    

    
    public static class HelperFunctions
    {
        

        
        /// <summary>
        ///This function returns a double vector of monthly values corresponding to the condition curve derived value based on the age of the asset.
        ///Since the condition curve is expressed in terms of age vs condition where age is in years the age is converted to months.
        ///The start fiscal year corresponds to month 0 of the output vector.  months is the number of months worth of data (starting at fiscal year)
        ///that are returned by the function.  The startOffsetMonth represents the number of months difference between the start year and the inservice date
        ///of the asset.
        /// <summary>
        
        public static double?[] computeConditionVectorfromOffset(int startFiscalYear,
                                                                 int months,
                                                                 int? conditionEntryOffsetMonths,
                                                                 int startOffsetMonth,
                                                                 CL.FormulaHelper.DTOs.XYCurveDTO conditionCurve,
                                                                 double offsetCondition,
                                                                 bool hasOffset,
                                                                 bool isBaseline)
        {
            double?[] conditionVector = new double?[months];
            int i, j;
            int lastMonth = Math.Min(months, months - startOffsetMonth);  //Upper limit of loop is the length of the vector (months) or months - start offset.
            int curDateOffset = CL.FormulaHelper.FormulaBase.ConvertDateTimeToOffset(System.DateTime.Now, startFiscalYear); //offset of current date from start fical year
            
            for (i = 0; i < lastMonth; i++)     //populate the output vector up to last month with condition scores
                if (i + startOffsetMonth >= 0)
                    conditionVector[i + startOffsetMonth] = conditionCurve.YFromX(i / 12);  //get the condition score per month for each year.
            
            //the following takes care of the condition where the ISD is far in the past such that the ISD plus maximum age of the asset may not even
            //overlap the start year plus start offset in months.  in this case the output vector must be populted with the condition score corresponding
            //to the maximum age of the asset.
            
            j = Math.Max(0, months + startOffsetMonth - 1);
            while (j < months) {      //  Populate all values past last month with the conditions derived from the curve
                if (conditionVector[j] == null)
                    conditionVector[j] = conditionCurve.YFromX((j - startOffsetMonth) / 12);
                j++;
            }

            if (!hasOffset)     //If the user is not specifying a condition override, return a vector that begins at 0 and follows the asset degradation curve starting from the ISD baseline)
                //or impact date (outcome)
                return conditionVector;
            
            //this code deals with the case where there is an override month spoecified,
            int overrideOffsetMonth;
            if (isBaseline) {
                overrideOffsetMonth = conditionEntryOffsetMonths ?? curDateOffset;
            } else {
                overrideOffsetMonth = startOffsetMonth;
            }
            var assetAge = Math.Max((overrideOffsetMonth - startOffsetMonth) / 12, 0);
            var effectiveAge = conditionCurve.XFromY(offsetCondition);
            int yearsOffset = Convert.ToInt32(effectiveAge - assetAge);
            double?[] overrideVector = conditionVector;
            int k = -1;      //index to keep track of (possible) null values in conditionVextor;
            for (i = 0; i < Math.Min(months, months - startOffsetMonth); i++) {
                overrideVector[i] = conditionVector[i];
                if (conditionVector[i] == null)
                    k = i;
            }
            if (isBaseline && (k >= 0))            //Thus there were null entries in the conditionVector and hence overrideVector[i]!
                while (k >= 0) {      //work backwards through the indices into overrideVector[i] and propagate first non-null value
                overrideVector[k] = overrideVector[k + 1];
                k--;
            }
            
            for (i = 0; i < Math.Min(months, months - overrideOffsetMonth); i++)
                overrideVector[Math.Max(0, i + overrideOffsetMonth)] = conditionCurve.YFromX(effectiveAge + (i / 12));
            return overrideVector;
        }


        /// <summary>
        /// This function compares inputString to matchString.
        /// 
        /// </summary>
        /// <param name="inputString">First string to be compared</param>
        /// <param name="matchString">Second String to be compared</param>
        /// <param name="ucFlag">If this is set to true, a case insensitive comparison is performed.</param>
        /// <returns></returns>
        public static  bool checkStringEqual(System.String inputString, System.String matchString, bool ignoreCase)
        {
            if (!string.IsNullOrEmpty(inputString) && !string.IsNullOrEmpty(matchString))
            {
                return ignoreCase
                    ? string.Equals(inputString, matchString, StringComparison.OrdinalIgnoreCase)
                    : string.Equals(inputString, matchString);
            }
            return false;
        }
        
        
        /// <summary>
        /// This is a simple function that divides the input value by 12 to convert an annual value to its monthly equivalent.
        /// </summary>
        /// <param name="annualValue"></param>
        /// <returns></returns>
        public static double getMonthlyValue(double annualValue)
        {
            return annualValue / Common_Code.CommonConstants.MonthsInYear;
        }
        

        /// <summary>
        /// Checks that a string passed to this function exists and if so, if it is numeric.  If so return the value else 0.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        /// 
        
        public static double checkStringNumeric(System.String inputString)
        {
            double outVal = 0;

            if (!string.IsNullOrEmpty(inputString))
                try {
                outVal = Convert.ToDouble(inputString);
            } catch {
                outVal = 0;
            }
            return outVal;
        }
        
        /// <summary>
        /// Converts a vector containing annual probabilities to the corresponding monthly values.
        /// </summary>
        /// <param name="months"></param>
        /// <param name="annualProbabilities"></param>
        /// <returns></returns>
        public static double?[] getMonthlyProbabilityValue(int months, double?[] annualProbabilities)
        {
            if (annualProbabilities == null)
                return null;

            var result = new double?[months];
            for (var i = 0; i < months; i++)
            {
                result[i] = 1 - Math.Pow(1-(annualProbabilities[i]??0), 1/CommonConstants.MonthsInYear);
            }

            return result;
        }
        
        public static double?[] scaleValues(int months, double?[] inputValues, double? factor)
        {
            if (inputValues == null)
            {
                return null;
            }
            
            var result = new double?[months];
            for (int i=0;i<months;i++)
            {
                if (inputValues[i] == null)
                    continue;

                result[i] = (factor ?? 0) * inputValues[i];
            }
            return result;
        }

        public static double?[] scaleValues(int startFiscalYear, int months, double?[] inputValues, TimeSeriesDTO timeSeries)
        {
            if (inputValues == null || timeSeries == null)
            {
                return null;
            }

            var result = new double?[months];
            for (int i = 0; i < months; i++)
            {
                if (inputValues[i] == null)
                    continue;

                result[i] = timeSeries.GetMonthlyValue(startFiscalYear, i) * inputValues[i];
            }
            return result;
        }

        public static double?[] CalculateValueStream(int months, double?[] baselineConsequence, double?[] baselineLikelihood,
                                                     double?[] outcomeConsequence, double?[] outcomeLikelihood)
        {
            var result = new double?[months];
            if (outcomeConsequence == null )
            {
                return null;
            }
            if (outcomeLikelihood == null)
            {
                outcomeLikelihood = new double?[months];
                for (int i=0;i<months;i++)
                {
                    outcomeLikelihood[i]=1;
                }
            }
            if (baselineLikelihood == null)
            {
                baselineLikelihood = new double?[months];
                for (int i=0;i<months;i++)
                {
                    baselineLikelihood[i]=1;
                }
            }
            if (baselineConsequence == null)
            {
                for (int i=0;i<months;i++)
                {
                    result[i] = outcomeConsequence[i] * (outcomeLikelihood[i] ?? 1);
                }
            }
            else
            {
                for (int i=0;i<months;i++)
                {
                    result[i] = ((baselineConsequence[i] * (baselineLikelihood[i] ?? 1)) ?? 0) - ((outcomeConsequence[i] * (outcomeLikelihood[i] ?? 1)) ?? 0);
                }
            }
            return result;
        }
        
        public static double GetTotalCost(int months, DistributionByAccountTypeDTO capitalCosts)
        {
            var endOfSpendMonth = (FormulaBase.FindEndOfSpendMonth(months, capitalCosts) ?? 0) + 1;
            var spendByMonth = FormulaBase.GetSpendForAccountType(months, capitalCosts, CustomerConstants.CAPEXAccount);
            double totalInvestmentCost = 0;
            if (spendByMonth == null)
            {
                return 0;
            }
            for (int i=0; i<months;i++)
            {
                totalInvestmentCost += (spendByMonth[i]??0);
            }
            return totalInvestmentCost;
        }
        
        public static double?[] CalculateRequiredReturn(int months, double? capitalCosts, int ISDOffset, double?[] omaCosts, double depreciationLife, double rateOfReturn)
        {
            var annualDepreciation = capitalCosts * (1d / depreciationLife);
            var depreciatedValues = new double?[months];
            depreciatedValues[ISDOffset] = capitalCosts;
            for (int i = ISDOffset+1;i<months;i++)
            {
                depreciatedValues[i] = Math.Max(0, (capitalCosts - (((i-ISDOffset) / 12) * annualDepreciation)) ?? 0);
            }
            var result = new double?[months];
            
            if (omaCosts == null)
            {
                for (int i=0; i<months; i++)
                    
                {
                    result[i] = HelperFunctions.getMonthlyValue((depreciatedValues[i]??0) * rateOfReturn + ((depreciatedValues[Math.Max(0,i - 1)]??0) - (depreciatedValues[i]??0)));
                }
            }
            else
            {
                for (int i=0; i<months; i++)
                    
                {
                    result[i] = HelperFunctions.getMonthlyValue((omaCosts[i]??0) +
                                                                ((depreciatedValues[i]??0) * rateOfReturn));
                }
            }
            return result;
        }
        
        public static double?[] GetResourceCurrencyUnitsFromForecast(int months, string resCode, CL.FormulaHelper.DTOs.DistributionByResourceDTO forecast)
        {
            var result = new double?[months];

            if (forecast.ResourceValues == null)
            {
                return null;
            }

            var resourceSupplyValue = forecast.ResourceValues
                .FirstOrDefault(x => x.ResourceCode.Equals(resCode, StringComparison.OrdinalIgnoreCase));

            if (resourceSupplyValue != null)
            {
                foreach (var kvp in resourceSupplyValue.SpendValues)
                {
                    if (kvp.Key >= 0 && kvp.Key < months)
                    {
                        result[kvp.Key] = kvp.Value.CurrencyValue;
                    }
                }
            }

            return result;
        }
        
        public static double?[] CombineSeries(int months, double?[]series1, double?[]series2)
        {
            if (series1 == null)
            {
                return series2;
            }

            if (series2 == null)
            {
                return series1;
            }

            var result = new double?[months];
            for (int i = 0; i < months; i++)
            {
                result[i] = (series1[i] ?? 0) + (series2[i] ?? 0);
            }
            return result;
        }

        public static double?[] MultiplySeries(int months, double?[] series1, double?[] series2)
        {
            if (series1 == null)
            {
                return series2;
            }

            if (series2 == null)
            {
                return series1;
            }

            var result = new double?[months];
            for (int i = 0; i < months; i++)
            {
                result[i] = (series1[i] ?? 0) * (series2[i] ?? 0);
            }
            return result;
        }

        public static double? MaxNullable(double? value1, double? value2)
        {
            if (value1.HasValue && value2.HasValue)
            {
                return Math.Max(value1.Value, value2.Value);
            }
            else if (value1.HasValue)
            {
                return value1.Value;
            }
            else if (value2.HasValue)
            {
                return value2.Value;
            }
            else
            {
                return null;
            }
        }

        public static double?[] CalculateRequiredReturnOngoingCapital(int months, double?[] capitalCosts, double?[] omaCosts, double depreciationLife, double rateOfReturn)
        {
            if (capitalCosts== null)
            {
                return omaCosts;
            }
            var recoveries = new double?[months];
            var pastISAs = new double?[months];
            recoveries[0] = 0;
            for (int i = 0;i<months;i++)
            {
                pastISAs[i] = 0;
                for (int j=0;j<i;j++)
                {
                    pastISAs[i]+= (capitalCosts[j] ?? 0) * (1 - Math.Min(1, (Math.Max(0, (i-j) / 12)/ depreciationLife)));
                }
                recoveries[i] = ((capitalCosts[i] + pastISAs[i]) * rateOfReturn) + ((pastISAs[Math.Max(0,i-1)] ?? 0) -  (pastISAs[i] ?? 0));
                //Recoveries on rate base plus depreciateion costs
            }
            
            var result = new double?[months];
            
            if (omaCosts == null)
            {
                for (int i=0; i<months; i++)
                {
                    result[i] = HelperFunctions.getMonthlyValue(recoveries[i] ?? 0);
                }
            }
            else
            {
                for (int i=0; i<months; i++)
                    
                {
                    result[i] = HelperFunctions.getMonthlyValue((omaCosts[i] ?? 0) + (recoveries[i] ?? 0));
                }
            }
            return result;
        }

        public static class GenericEndOfLifeModel
        {
            /// <summary>
            /// // Construct a generic end of life condition decay curve, based on the design life entered by the user.
            /// </summary>
            /// <param name="estimatedDesignLife">Asset's estimated design life in years</param>
            /// <returns>Generated condition decay curve</returns>
            public static XYCurveDTO constructConditionDecayCurve(double estimatedDesignLife)
            {
                XYCurveDTO conditionDecayCurve = new XYCurveDTO();
                CurvePointDTO[] points = new CurvePointDTO[3];
                points[0] = new CurvePointDTO();
                points[0].X = 0;
                points[0].Y = 10.0;   // - - - - - - - - - - -> When brand new, the asset is in perfect condition
                points[1] = new CurvePointDTO();
                points[1].X = estimatedDesignLife;  // - - - -> When at its design life, the asset has a condition of 3
                points[1].Y = 3.0;
                points[2] = new CurvePointDTO();
                points[2].X = estimatedDesignLife / 0.7;  // -> When past its design life (assuming linear degradation), Design Life/0.7 corresponds to a condition of 0
                points[2].Y = 0.0;
                conditionDecayCurve.Points = points;

                return conditionDecayCurve;
            }

            public static XYCurveDTO constructGenericEndOfLifePofCurve()
            {
                // Construct a generic end of life condition to failure curve.
                
                int numPoints = 11;
                double mAHI =
                    (CustomerConstants.BestConditionScore + CustomerConstants.WorstConditionScore) / 2.0;
                // Midpoint Of AHI Scale, aka mAHI, aka m
                double theta   = 0.463; // Convexity Of Curve
                double curveBias = 0.22; //  (s)
                
                XYCurveDTO eomConditionToFailureCurve = new XYCurveDTO();
                // eomConditionToFailureCurve.Id
                // eomConditionToFailureCurve.Name
                // eomConditionToFailureCurve.CurveType
                CurvePointDTO[] points = new CurvePointDTO[numPoints];
                for (int i = 0; i < numPoints; i ++)
                {
                    points[i] = new CurvePointDTO();
                    points[i].X = // Condition
                        CustomerConstants.WorstConditionScore +
                        i * (CustomerConstants.BestConditionScore - CustomerConstants.WorstConditionScore) / (numPoints-1);
                    
                    points[i].Y =  // PoF
                        Math.Exp(mAHI) /
                        (1+Math.Exp(mAHI+curveBias+theta*points[i].X));
                }
                eomConditionToFailureCurve.Points = points;
                
                return eomConditionToFailureCurve;
            }
        }
    }
    class TimeVariantLocalConditionDTO : ITimeVariantInputDTO
    {
        public TimeVariantLocalConditionDTO(
            System.Double? p_ConditionScoreLocal,
            CL.FormulaHelper.DTOs.TimePeriodDTO p_TimePeriod)
        {
            ConditionScoreLocal = p_ConditionScoreLocal;
            TimePeriod = p_TimePeriod;
        }

        public CL.FormulaHelper.DTOs.TimePeriodDTO TimePeriod  { get; private set; }

        public System.Double? ConditionScoreLocal  { get; private set; }

    }
}

