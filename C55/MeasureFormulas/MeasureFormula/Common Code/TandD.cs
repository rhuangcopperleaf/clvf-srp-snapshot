using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureFormula.Common_Code
{
	public static class TandDHelperFunctions
	{
		
		
		/// <summary>
		/// Returns the frequency cost of an annual number of outages based on load.
		/// </summary>
		public static double getFrequencyCost(double? load, double? numOutages, double? frequencyCostPerKW)
		{
			return (load * numOutages * frequencyCostPerKW) ?? 0;
		}

		/// <summary>
		/// Returns the duration cost of an annual number of outages based on load and duration.
		/// </summary>
		public static double getDurationCost(double? load, double? numOutages, double? outageDuration, double? durationCostPerKWh)
		{
			return (load * numOutages * outageDuration * durationCostPerKWh) ?? 0;
		}
		
		public static double getCMICost(double? customers, double? numOutages, double? outageDuration, double? cmiCost)
		{
			return (customers * numOutages * outageDuration * cmiCost) ?? 0;
		}
		
		/// <summary>
		/// Based on the type of issue encountered, returns the societal cost of an outage, loss of redundancy or power quality issue
		/// </summary>
		/// 
		public static double? getReliabilityCost(int IssueSeverity, double? durationCostPerKWh,
		                                         double? frequencyCostPerKW, double? cmiCost, double? loadAtRisk,
		                                         double? numOutages, double? outageDuration, double? numCustomers)
		{
			switch (IssueSeverity) {
				case CustomerConstants.SeverityPowerQualityIssue:
					{
						return loadAtRisk * outageDuration *
							CustomerConstants.VoltageDeviationValuePerKWh;
					}


				case CustomerConstants.SeverityLostMultipleRedundancy:
					{
						double[] reliabilityCosts = {
							getDurationCost(loadAtRisk, numOutages, outageDuration, durationCostPerKWh),
							getFrequencyCost(loadAtRisk, numOutages, frequencyCostPerKW),
							getCMICost(numCustomers, numOutages, outageDuration * CommonConstants.MinutesInHour, cmiCost)};
						return Math.Pow(CustomerConstants.RedundancyFactor, 3)
							* reliabilityCosts.Max();
					}
					
				case CustomerConstants.SeverityLostNMinusOneMinusOneRedundancy:
					{
						double[] reliabilityCosts = {
							getDurationCost(loadAtRisk, numOutages, outageDuration, durationCostPerKWh),
							getFrequencyCost(loadAtRisk, numOutages, frequencyCostPerKW),
							getCMICost(numCustomers, numOutages, outageDuration * CommonConstants.MinutesInHour, cmiCost)};
						return Math.Pow(CustomerConstants.RedundancyFactor, 2)
							* reliabilityCosts.Max();
					}
				case CustomerConstants.SeverityLostRedundancy:
					{
						double[] reliabilityCosts = {
							getDurationCost(loadAtRisk, numOutages, outageDuration, durationCostPerKWh),
							getFrequencyCost(loadAtRisk, numOutages, frequencyCostPerKW),
							getCMICost(numCustomers, numOutages, outageDuration * CommonConstants.MinutesInHour, cmiCost)};
						return CustomerConstants.RedundancyFactor * reliabilityCosts.Max();
					}
				case CustomerConstants.SeverityUnableServeLoad:
					{
						double[] reliabilityCosts = {
							getDurationCost(loadAtRisk, numOutages, outageDuration, durationCostPerKWh),
							getFrequencyCost(loadAtRisk, numOutages, frequencyCostPerKW),
							getCMICost(numCustomers, numOutages, outageDuration * CommonConstants.MinutesInHour, cmiCost)};
						return reliabilityCosts.Max();
					}
					
				default:
					{
						return null;
					}
			}
		}
		
		
	}
}