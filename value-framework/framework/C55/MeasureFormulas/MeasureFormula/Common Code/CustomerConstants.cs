using System.Collections.Generic;

namespace MeasureFormula.Common_Code
{
    
    public static class CustomerConstants
    {
        /// <summary>
        /// Condition score range -match these to the condition range configured using C55 system parameters
        /// </summary>
        public const int WorstConditionScore = 0;
        public const int BestConditionScore = 10;

        //Workaround for inability to access the value framework from the formulae.  This should be removed in the future.

        public const double consequence_Catastrophic = 20000;
        public const double consequence_Major = 6500;
        public const double consequence_Moderate = 2250;
        public const double consequence_Minor = 1000;
        public const double consequence_VeryMinor = 300;
        public const double consequence_None = 0;

        public const double probabilities_AlmostCertain = 0.975;
        public const double probabilities_VeryLikely = 0.625;
        public const double probabilities_Likely = 0.2;
        public const double probabilities_SomewhatLikely = 0.065;
        public const double probabilities_Unlikely = 0.02;
        public const double probabilities_Rare = 0.007;
        public const double probabilities_VeryRare = 0.002;
        public const double probabilities_None = 0;


        public const int genTechHydro = 1;  //Plant Type Config Field Dropdown
        public const int genTechCoal = 2;
        public const int genTechGas = 3;
        
        public const int LoadTypeResidential = 1;  //Load Type Config Field Dropdown
        public const int LoadTypeMixed = 2;
        public const int LoadTypeCommercial = 3;
        public const int LoadTypeTransmission = 5;
        public const int LoadTypeCritical = 4;
        
        public const double ReputationImpactPerBreakin = 10;
        

        /// <summary>
        /// Labour costs per hour used in multiple questionnaires
        /// </summary>
        public const double CAPEXLabourHour = 110d;
        public const double OPEXLabourHour = 110d;
        
        
        /// <summary>
        /// Business Continuity Risk Constants
        /// </summary>
        public const double BusinessContinuityImpactPerEmployee = 100000d;
        
        /// <summary>
        /// Customer Service Benefit Constants
        /// </summary>
        public const double AgentTimeCostPerHour = 110d;
        public const double SavingsPerLowEffortResolution = 20d;
        public const double SavingsPerSelfServiceResoultion = 20d;

        /// <summary>
        /// Generation Revenue Risk Constants
        /// </summary>
        public const double ValuePerMWGenerationRevenue = 40d;
        
        /// <summary>
        /// network Consequence Calculation Constants
        /// </summary>
        public const double CostPerMWhUnservedEnergyTransmission = 39000d;

        /// <summary>
        /// Change in Emissions Constants
        /// </summary>
        public const double ValuePerTonneNOX = 20d;
        public const double ValuePerTonneSO2 = 20d;
        public const double ValuePerTonneCO2 = 40d;

        /// <summary>
        /// Environmental Benefits Constants
        /// </summary>
        public const double ValuePerMWPowerSavings = 60d;
        public const double ValuePerKgSF6 = 200d;
        public const double RenewableEnergyValuePerMW = 200d;
        public const double RenewableEnergyCreditPerMWh = 0.7d;

        /// <summary>
        /// Transmission Line Safety Constants
        /// </summary>
        public const double BushFireSafetyFactor = 100000d;
        public const double TransmissionLineRoadCrossingSafetyFactor = 100000d;
        
        /// <summary>
        /// Constants Used in Productive Workplace benefit
        /// </summary>
        public const double ValuePerCandidateAttracted = 10000d;
        public const double EmployeeCostPerYear = 100000d;
        public const double EmployeeCostToReplace = 200000d;
        
        /// <summary>
        /// Constants Used in Employee Productivity benefit
        /// </summary>
        public const double HourlyEmpCostPerHour = 110d;
        public const double MPEmpCostPerHour = 200d;
        public const double ProbabilityOfRepurposing = 0.1d;
        
        /// <summary>
        /// The value of making a minor brand image improvement for all customers
        /// Used in the public perception benefit questionnaire
        /// </summary>
        public const double PublicPerceptionValueForAllCustomers = 500000d;
        
        /// <summary>
        /// Constants Used in Employee Wellness benefit
        /// </summary>
        public const double EmployeeWellnessFactor = 500000d;

        /// <summary>
        /// Account Types
        /// </summary>
        public const string CAPEXAccount = "Capital";
        public const string OMAAccount = "OMA";
        public const int CAPEXAccountNumber = 1;
        public const int OMAAccountNumber = 2;
        public const string CustomerContributionAccount = "CIAC";
        
        /// <summary>
        /// Resource Codes
        /// </summary>
        public const string PROJ_MGR = "12410";
        public const string	ENG_DESIGN = "14000";
        public const string internalLabourCode = "101000";
        public const string contractLabourCode = "102000";
        
        /// <summary>
        /// Avoided Impact Type Dropdown Values
        /// </summary>
        public const int UnitOutage = 1;
        public const int UnitDerate = 2;

        /// <summary>
        /// Account Type questionnaire Dropdown Values
        /// </summary>
        public const int CapitalAcctID = 1;
        public const int OMAAcctID = 2;
        
        /// <summary>
        /// Load Growth Severity Dropdown Values
        /// </summary>
        public const int SeverityPowerQualityIssue = 1;
        public const int SeverityLostMultipleRedundancy = 2;
        public const int SeverityLostNMinusOneMinusOneRedundancy = 3;
        public const int SeverityLostRedundancy = 4;
        public const int SeverityUnableServeLoad = 5;

        /// <summary>
        /// Inputs to Electrical Reliability and Delivery Capacity Calculations
        /// </summary>
        public const  int NumCustClasses = 4;
        
        public const double CMICost = 1.5d;
        public const double CMICostPerMinGas = 1.5d;
        public const double RedundancyFactor = 0.05d;
        public const double VoltageDeviationValuePerKWh = 0.01;

        public const double CostKWhUnservedEnergyResidential = 1.5d;
        public const double CostKWhUnservedEnergySmallCommercial = 50d;
        public const double CostKWhUnservedEnergyLargeCommercial = 100d;
        public const double CostEventUnservedEnergyResidential = 1.5d;
        public const double CostEventUnservedEnergySmallCommercial = 50d;
        public const double CostEventUnservedEnergyLargeCommercial = 100d;
        
        public const double MultiplerCritical = 1.33d;
        public const double WorstFeederFactor = 1.25;

        /// <summary>
        /// Transmission Fault Current Variables
        /// </summary>
        /// 
        public const int duration_2hours = 2;
        public const int duration_4hours = 4;
        public const double breakerOverloadRate = 0.95; // a breaker is considered overloaded if it is over 95% of its rating
        public const double probabilityOfCondition = 0.33; // NERC probability for an N-1 condition
        public const double annualBusFaultProbability = 0.04; // Annual fault probability at any specific substation 
        public const double annualExposurePercentage = 16.4; // Annual Exposure = ((Summer generation profile 120 days) * (0.5 daily duration))/365 = 16.4% annual exposure

        public const int line500kV = 0;
        public const int line230kV = 1;
        public const int line115kV = 2;
        public const int line69kV = 3;
        
        public const double faultCurrentSafetyProbability = 0.001;
        public const double faultCurrentFinancialProbability = 0.025;
        public const double faultCurrentReliabilityProbability = 0.025;

        // TODO: will change
        // Risk consequences are in value units, cost savings in dollars
        public static readonly double[] faultCurrentSafetyConsequences = {consequence_Catastrophic,consequence_Catastrophic,consequence_Catastrophic,consequence_Catastrophic};
        public static readonly double[] faultCurrentFinancialConsequences = {8e3, 4e3, 2e3, 1e3};
        public static readonly double[] faultCurrentReliabilityConsequences = {103.8e3, 27.7e3, 6.9e3, 3.5e3};
        public static readonly double[] faultCurrentCostConsequences = {1e6, 500e3, 250e3, 125e3};
        
        
        /// <summary>
        /// Transmission Power Flow Variables
        /// </summary>
        /// 
        public const int violationA = 1;
        public const int violationB = 2;
        public const int violationC = 3;
        public const int violationD = 4;
        public const double violationB_LikelihoodFactor = 0.33d;
        public const double violationC_LikelihoodFactor = 0.03d;
        public const double powerFlowConsequenceFactor = 20;  // Risk consequences are in value units
        public const double powerFlowConsequenceD = 0.8e3;
        public const double powerFlowLikelihoodD = 0.25;

        // Power factor - for conversion from MVA to MW:
        // - For general transmission calculation, we asume unity (value = 1)
        // - For industrial customer load the value = 0.85
        public const double powerFactor = 1.0;                  

        /// <summary>
        /// Variables used in multiple Transmission formulas
        /// </summary>
        /// 
        public const double transmissionLoadPrice = 20000d; // $/MWh

        /// <summary>
        /// Operational Flexibility Variables 
        /// </summary>
        /// 
        public const double sensitiveCustomerOutageCost = 100000d; // $/MW 
        public const double industrialCustomerOutageCost = 20000d; // $/MW 

        /// <summary>
        /// A probability that it will NOT be possible to schedule an outage for the given outage window.
        /// </summary>
        /// <Key>Outage Window</Key>
        /// <Value>Probability of outage not scheduled</Value>
        /// <remarks>
        /// As the Outage Window shrinks towards zero it becomes increasing difficulty to schedule an outage. 
        /// </remarks>
        public static readonly Dictionary<int, double> probabilityOutageNotScheduled = new Dictionary<int, double>{
            { 12, 0 },
            { 11, 0 },
            { 10, 0 },
            { 9, 0 },
            { 8, 0.01 },
            { 7, 0.02 },
            { 6, 0.03 },
            { 5, 0.05 },
            { 4, 0.1 },
            { 3, 0.2 },
            { 2, 0.4 },
            { 1, 0.75 },
            { 0, 1 }
        };
    }
}

