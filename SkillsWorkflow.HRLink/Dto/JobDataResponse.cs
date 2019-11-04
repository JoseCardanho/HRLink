using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsWorkflow.HrLink.Dto
{
    public class JobSoapenvEnvelopeDefinition
    {
        [JsonProperty("soapenv")]
        public string Soapenv { get; set; }

        [JsonProperty("soapenc")]
        public string Soapenc { get; set; }

        [JsonProperty("xsd")]
        public string Xsd { get; set; }

        [JsonProperty("xsi")]
        public string Xsi { get; set; }
    }


    public class JobDataWithComp
    {
        [JsonProperty("JOB")]
        public Job Job { get; set; }

        [JsonProperty("SETID_DEPT")]
        public SetidDept SetidDept { get; set; }

        [JsonProperty("DEPARTMENT")]
        public Department Department { get; set; }

        [JsonProperty("DEPT_HR_REP")]
        public DeptHrRep DeptHrRep { get; set; }

        [JsonProperty("SETID_JOBCODE")]
        public SetidJobcode SetidJobcode { get; set; }

        [JsonProperty("JOBCODE")]
        public Jobcode Jobcode { get; set; }

        [JsonProperty("JOB_FUNCTION")]
        public JobFunction JobFunction { get; set; }

        [JsonProperty("MANAGER_LEVEL")]
        public ManagerLevel ManagerLevel { get; set; }

        [JsonProperty("JOB_FAMILY")]
        public JobFamily JobFamily { get; set; }

        [JsonProperty("JOB_SUB_FUNC")]
        public JobSubFunc JobSubFunc { get; set; }

        [JsonProperty("SUPERVISOR_ID")]
        public SupervisorId SupervisorId { get; set; }

        [JsonProperty("ACTION_REASON")]
        public ActionReason ActionReason { get; set; }

        [JsonProperty("SETID_LOCATION")]
        public SetidLocation SetidLocation { get; set; }

        [JsonProperty("LOCATION")]
        public Location Location { get; set; }

        [JsonProperty("LOC_COUNTRY")]
        public LocCountry LocCountry { get; set; }

        [JsonProperty("LOC_STATE")]
        public LocState LocState { get; set; }

        [JsonProperty("COMPANY")]
        public Company Company { get; set; }

        [JsonProperty("EMPL_CLASS")]
        public EmplClass EmplClass { get; set; }

        [JsonProperty("BUSINESS_UNIT")]
        public BusinessUnit BusinessUnit { get; set; }

        [JsonProperty("SETID_BU")]
        public SetidBu SetidBu { get; set; }

        [JsonProperty("BUS_UNIT_HR")]
        public BusUnitHr BusUnitHr { get; set; }

        [JsonProperty("AGENCY_GROUP")]
        public AgencyGroup AgencyGroup { get; set; }

        [JsonProperty("AGENCY_SUB_GROUP")]
        public AgencySubGroup AgencySubGroup { get; set; }

        [JsonProperty("IPG_EMPLOYMENT")]
        public IpgEmployment IpgEmployment { get; set; }

        [JsonProperty("PER_ORG_ASGN")]
        public PerOrgAsgn PerOrgAsgn { get; set; }

        [JsonProperty("PER_ORG_INST")]
        public PerOrgInst PerOrgInst { get; set; }

        [JsonProperty("COMP_RATECD_TBL")]
        public CompRatecdTbl CompRatecdTbl { get; set; }

        [JsonProperty("COMPENSATION")]
        public Compensation Compensation { get; set; }

        [JsonProperty("IPGAUD_COMPENS")]
        public IpgaudCompens IpgaudCompens { get; set; }

        [JsonProperty("IPG_COMP_RATECD")]
        public IpgCompRatecd IpgCompRatecd { get; set; }

        [JsonProperty("ADDITIONAL_DETAILS")]
        public AdditionalDetails AdditionalDetails { get; set; }
    }

    public class ApiVersionJobs
    {
        [JsonProperty("")]
        public DataResponseVersion Version { get; set; }

        [JsonProperty("JOB_DATA_WITH_COMP")]
        public JobDataWithComp[] JobDataWithCompList { get; set; }
    }

    public class JobSoapenvBody
    {
        [JsonProperty("IPG_API_JOBD_WITHC_RESP_P_COLL")]
        public ApiVersionJobs ApiVersionJobs { get; set; }
    }

    public class JobSoapenvEnvelope
    {
        [JsonProperty("")]
        public JobSoapenvEnvelopeDefinition Definition { get; set; }

        [JsonProperty("soapenvBody")]
        public JobSoapenvBody Body { get; set; }
    }

    public class JobDataResponse
    {
        [JsonProperty("soapenvEnvelope")]
        public JobSoapenvEnvelope SoapenvEnvelope { get; set; }
    }



    

    

   

    

    

    

    

    public partial class ActionReason
    {
        [JsonProperty("ACTION")]
        public StringText Action { get; set; }

        [JsonProperty("ACTION_REASON")]
        public StringText ActionReasonActionReason { get; set; }

        [JsonProperty("ACTION_REASON_DESCR")]
        public StringText ActionReasonDescr { get; set; }
    }

    
    public partial class AdditionalDetails
    {
        [JsonProperty("IPG_DESIGNATION_CD")]
        public StringText IpgDesignationCd { get; set; }

        [JsonProperty("IPG_REPLACE")]
        public StringText IpgReplace { get; set; }

        [JsonProperty("GRADE")]
        public StringText Grade { get; set; }

        [JsonProperty("IPG_EMPLOYEE_GROUP")]
        public StringText IpgEmployeeGroup { get; set; }

        [JsonProperty("LAST_DATE_WORKED")]
        public StringText LastDateWorked { get; set; }

        [JsonProperty("LAST_INCREASE_DT")]
        public StringText LastIncreaseDt { get; set; }

        [JsonProperty("REHIRE_DT")]
        public StringText RehireDt { get; set; }

        [JsonProperty("BUSINESS_TITLE")]
        public StringText BusinessTitle { get; set; }

        [JsonProperty("IPG_COST_CENTER")]
        public StringText IpgCostCenter { get; set; }
    }

    
    public partial class AgencyGroup
    {
        [JsonProperty("AGENCY_GROUP_DESCR")]
        public StringText AgencyGroupDescr { get; set; }

        [JsonProperty("AGENCY_GROUP_DESCRSHORT")]
        public StringText AgencyGroupDescrshort { get; set; }
    }

    public partial class AgencySubGroup
    {
        [JsonProperty("AGENCY_SUB_GROUP_DESCR")]
        public StringText AgencySubGroupDescr { get; set; }

        [JsonProperty("AGENCY_SUB_GROUP_DESCRSHORT")]
        public StringText AgencySubGroupDescrshort { get; set; }
    }

    public partial class BusUnitHr
    {
        [JsonProperty("IPG_BU_RPT1")]
        public StringText IpgBuRpt1 { get; set; }

        [JsonProperty("IPG_BU_RPT3")]
        public StringText IpgBuRpt3 { get; set; }

        [JsonProperty("IPG_BU_RPT4")]
        public StringText IpgBuRpt4 { get; set; }

        [JsonProperty("IPG_BU_RPT5")]
        public StringText IpgBuRpt5 { get; set; }

        [JsonProperty("IPG_BU_RPT6")]
        public StringText IpgBuRpt6 { get; set; }
    }

    public partial class BusinessUnit
    {
        [JsonProperty("BUSINESS_UNIT")]
        public StringText BusinessUnitBusinessUnit { get; set; }

        [JsonProperty("BUSINESS_UNIT_ACTIVE_INACTIVE")]
        public StringText BusinessUnitActiveInactive { get; set; }

        [JsonProperty("BUSINESS_UNIT_DESCR")]
        public StringText BusinessUnitDescr { get; set; }
    }

    public partial class CompRatecdTbl
    {
        [JsonProperty("COMP_RATECD")]
        public StringText CompRatecd { get; set; }

        [JsonProperty("COMP_RATE_TYPE")]
        public StringText CompRateType { get; set; }

        [JsonProperty("COMP_BASE_PAY_SW")]
        public StringText CompBasePaySw { get; set; }

        [JsonProperty("RATE_CODE_CLASS")]
        public StringText RateCodeClass { get; set; }
    }

    public partial class Company
    {
        [JsonProperty("COMPANY")]
        public StringText CompanyCompany { get; set; }

        [JsonProperty("COMPANY_DESCR")]
        public StringText CompanyDescr { get; set; }

        [JsonProperty("COMPANY_COUNTRY")]
        public StringText CompanyCountry { get; set; }

        [JsonProperty("COMPANY_ADDRESS1")]
        public StringText CompanyAddress1 { get; set; }

        [JsonProperty("COMPANY_ADDRESS2")]
        public StringText CompanyAddress2 { get; set; }

        [JsonProperty("COMPANY_ADDRESS3")]
        public StringText CompanyAddress3 { get; set; }

        [JsonProperty("COMPANY_ADDRESS4")]
        public StringText CompanyAddress4 { get; set; }

        [JsonProperty("COMPANY_CITY")]
        public StringText CompanyCity { get; set; }

        [JsonProperty("COMPANY_STATE")]
        public StringText CompanyState { get; set; }

        [JsonProperty("COMPANY_POSTAL")]
        public StringText CompanyPostal { get; set; }

        [JsonProperty("COMPANY_LOCATION")]
        public StringText CompanyLocation { get; set; }
    }

    public partial class Compensation
    {
        [JsonProperty("COMP_EFFSEQ")]
        public ChangeAmt CompEffseq { get; set; }

        [JsonProperty("CHANGE_AMT")]
        public ChangeAmt ChangeAmt { get; set; }
    }

    public partial class ChangeAmt
    {
        [JsonProperty("TEXT")]
        public double Text { get; set; }
    }

    public partial class Department
    {
        [JsonProperty("DEPTID")]
        public StringText Deptid { get; set; }

        [JsonProperty("DEPARTMENT_EFF_STATUS")]
        public StringText DepartmentEffStatus { get; set; }

        [JsonProperty("DEPARTMENT_DESCR")]
        public StringText DepartmentDescr { get; set; }
    }

    public partial class DeptHrRep
    {
        [JsonProperty("IPG_DEPT_REP_1")]
        public StringText IpgDeptRep1 { get; set; }

        [JsonProperty("IPG_DEPT_REP_2")]
        public StringText IpgDeptRep2 { get; set; }

        [JsonProperty("IPG_DEPT_REP_DH")]
        public StringText IpgDeptRepDh { get; set; }
    }

    public partial class EmplClass
    {
        [JsonProperty("EMPL_CLASS")]
        public StringText EmplClassEmplClass { get; set; }

        [JsonProperty("EMPL_CLASS_DESCR")]
        public StringText EmplClassDescr { get; set; }
    }

    public partial class IpgCompRatecd
    {
        [JsonProperty("IPG_RATE_CD_ADP")]
        public StringText IpgRateCdAdp { get; set; }

        [JsonProperty("IPG_ONE_TIME_PMT")]
        public StringText IpgOneTimePmt { get; set; }
    }

    public partial class IpgEmployment
    {
        [JsonProperty("IPG_OFFICER_DT")]
        public StringText IpgOfficerDt { get; set; }

        [JsonProperty("IPG_VAC_ELIG_DT")]
        public StringText IpgVacEligDt { get; set; }

        [JsonProperty("IPG_NXT_PERF_EVAL")]
        public StringText IpgNxtPerfEval { get; set; }
    }

    public partial class IpgaudCompens
    {
        [JsonProperty("AUDIT_STAMP")]
        public StringText AuditStamp { get; set; }

        [JsonProperty("AUDIT_ACTN")]
        public StringText AuditActn { get; set; }

        [JsonProperty("AUDIT_EFFDT")]
        public StringText AuditEffdt { get; set; }

        [JsonProperty("AUDIT_EFFSEQ")]
        public ChangeAmt AuditEffseq { get; set; }
    }

    public partial class Job
    {
        [JsonProperty("")]
        public DataResponseVersion Empty { get; set; }

        [JsonProperty("EMPLID")]
        public ChangeAmt Emplid { get; set; }

        [JsonProperty("EMPL_RCD")]
        public ChangeAmt EmplRcd { get; set; }

        [JsonProperty("EFFDT")]
        public StringText Effdt { get; set; }

        [JsonProperty("EFFSEQ")]
        public ChangeAmt Effseq { get; set; }

        [JsonProperty("PER_ORG")]
        public StringText PerOrg { get; set; }

        [JsonProperty("POSITION_NBR")]
        public StringText PositionNbr { get; set; }

        [JsonProperty("EMPL_STATUS")]
        public StringText EmplStatus { get; set; }

        [JsonProperty("ACTION_DT")]
        public StringText ActionDt { get; set; }

        [JsonProperty("REG_TEMP")]
        public StringText RegTemp { get; set; }

        [JsonProperty("FULL_PART_TIME")]
        public StringText FullPartTime { get; set; }

        [JsonProperty("EMPL_TYPE")]
        public StringText EmplType { get; set; }

        [JsonProperty("HOLIDAY_SCHEDULE")]
        public StringText HolidaySchedule { get; set; }

        [JsonProperty("OFFICER_CD")]
        public StringText OfficerCd { get; set; }

        [JsonProperty("REG_REGION")]
        public StringText RegRegion { get; set; }

        [JsonProperty("FLSA_STATUS")]
        public StringText FlsaStatus { get; set; }

        [JsonProperty("EEO_CLASS")]
        public StringText EeoClass { get; set; }

        [JsonProperty("FTE")]
        public ChangeAmt Fte { get; set; }

        [JsonProperty("REPORTS_TO")]
        public StringText ReportsTo { get; set; }

        [JsonProperty("ESTABID")]
        public StringText Estabid { get; set; }

        [JsonProperty("HIRE_DT")]
        public StringText HireDt { get; set; }

        [JsonProperty("LAST_HIRE_DT")]
        public StringText LastHireDt { get; set; }

        [JsonProperty("TERMINATION_DT")]
        public StringText TerminationDt { get; set; }

        [JsonProperty("EXPECTED_RETURN_DT")]
        public StringText ExpectedReturnDt { get; set; }

        [JsonProperty("ANNUAL_RT")]
        public ChangeAmt AnnualRt { get; set; }

        [JsonProperty("COMP_FREQUENCY")]
        public StringText CompFrequency { get; set; }

        [JsonProperty("COMPRATE")]
        public ChangeAmt Comprate { get; set; }

        [JsonProperty("CURRENCY_CD")]
        public StringText CurrencyCd { get; set; }

        [JsonProperty("HOURLY_RT")]
        public ChangeAmt HourlyRt { get; set; }

        [JsonProperty("STD_HRS_FREQUENCY")]
        public StringText StdHrsFrequency { get; set; }

        [JsonProperty("STD_HOURS")]
        public ChangeAmt StdHours { get; set; }
    }

    public partial class JobFamily
    {
        [JsonProperty("JOB_FAMILY")]
        public StringText JobFamilyJobFamily { get; set; }

        [JsonProperty("JOB_FAMILY_DESCR")]
        public StringText JobFamilyDescr { get; set; }
    }

    public partial class JobFunction
    {
        [JsonProperty("JOB_FUNCTION")]
        public StringText JobFunctionJobFunction { get; set; }

        [JsonProperty("JOB_FUNCTION_DESCR")]
        public StringText JobFunctionDescr { get; set; }
    }

    public partial class JobSubFunc
    {
        [JsonProperty("JOB_SUB_FUNC")]
        public ChangeAmt JobSubFuncJobSubFunc { get; set; }

        [JsonProperty("JOB_SUB_FUNC_DESCR")]
        public StringText JobSubFuncDescr { get; set; }
    }

    public partial class Jobcode
    {
        [JsonProperty("JOBCODE")]
        public ChangeAmt JobcodeJobcode { get; set; }

        [JsonProperty("JOBCODE_DESCR")]
        public StringText JobcodeDescr { get; set; }

        [JsonProperty("JOBCODE_DESCRSHORT")]
        public StringText JobcodeDescrshort { get; set; }

        [JsonProperty("EEO_JOB_GROUP")]
        public StringText EeoJobGroup { get; set; }
    }

    public partial class LocCountry
    {
        [JsonProperty("LOC_COUNTRY")]
        public StringText LocCountryLocCountry { get; set; }

        [JsonProperty("LOC_COUNTRY_DESCR")]
        public StringText LocCountryDescr { get; set; }
    }

    public partial class LocState
    {
        [JsonProperty("LOC_STATE")]
        public StringText LocStateLocState { get; set; }

        [JsonProperty("LOC_STATE_DESCR")]
        public StringText LocStateDescr { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("LOCATION")]
        public StringText LocationLocation { get; set; }

        [JsonProperty("LOCATION_EFF_STATUS")]
        public StringText LocationEffStatus { get; set; }

        [JsonProperty("LOCATION_DESCR")]
        public StringText LocationDescr { get; set; }

        [JsonProperty("LOCATION_ADDRESS1")]
        public StringText LocationAddress1 { get; set; }

        [JsonProperty("LOCATION_ADDRESS2")]
        public StringText LocationAddress2 { get; set; }

        [JsonProperty("LOCATION_ADDRESS3")]
        public StringText LocationAddress3 { get; set; }

        [JsonProperty("LOCATION_ADDRESS4")]
        public StringText LocationAddress4 { get; set; }

        [JsonProperty("LOCATION_CITY")]
        public StringText LocationCity { get; set; }

        [JsonProperty("LOCATION_POSTAL")]
        public StringText LocationPostal { get; set; }
    }

    public partial class ManagerLevel
    {
        [JsonProperty("MANAGER_LEVEL")]
        public ChangeAmt ManagerLevelManagerLevel { get; set; }

        [JsonProperty("MANAGER_LEVEL_DESCR")]
        public StringText ManagerLevelDescr { get; set; }
    }

    public partial class PerOrgAsgn
    {
        [JsonProperty("CMPNY_SENIORITY_DT")]
        public StringText CmpnySeniorityDt { get; set; }

        [JsonProperty("SERVICE_DT")]
        public StringText ServiceDt { get; set; }

        [JsonProperty("PROBATION_DT")]
        public StringText ProbationDt { get; set; }
    }

    public partial class PerOrgInst
    {
        [JsonProperty("ORIG_HIRE_DT")]
        public StringText OrigHireDt { get; set; }
    }

    public partial class SetidBu
    {
        [JsonProperty("DEFAULT_SETID")]
        public StringText DefaultSetid { get; set; }

        [JsonProperty("SETID_BU_DESCR")]
        public StringText SetidBuDescr { get; set; }
    }

    public partial class SetidDept
    {
        [JsonProperty("SETID_DEPT")]
        public StringText SetidDeptSetidDept { get; set; }

        [JsonProperty("SETID_DEPT_DESCR")]
        public StringText SetidDeptDescr { get; set; }
    }

    public partial class SetidJobcode
    {
        [JsonProperty("SETID_JOBCODE")]
        public StringText SetidJobcodeSetidJobcode { get; set; }

        [JsonProperty("SETID_JOBCODE_DESCR")]
        public StringText SetidJobcodeDescr { get; set; }
    }

    public partial class SetidLocation
    {
        [JsonProperty("SETID_LOCATION")]
        public StringText SetidLocationSetidLocation { get; set; }

        [JsonProperty("SETID_LOCATION_DESCR")]
        public StringText SetidLocationDescr { get; set; }
    }

    public partial class SupervisorId
    {
        [JsonProperty("SUPERVISOR_ID")]
        public StringText SupervisorIdSupervisorId { get; set; }

        [JsonProperty("SUPERVISOR_NAME")]
        public StringText SupervisorName { get; set; }
    }
}
