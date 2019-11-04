using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsWorkflow.HrLink.Dto
{
    public class SoapenvEnvelopeDefinition
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

    

    public class Addresses
    {
        [JsonProperty("")]
        public DataResponseVersion Version { get; set; }

        [JsonProperty("ADDRESS_TYPE")]
        public StringText AddressType { get; set; }

        [JsonProperty("ADDRESS1")]
        public StringText Address1 { get; set; }

        [JsonProperty("ADDRESS2")]
        public StringText Address2 { get; set; }

        [JsonProperty("ADDRESS3")]
        public StringText Address3 { get; set; }

        [JsonProperty("ADDRESS4")]
        public StringText Address4 { get; set; }

        [JsonProperty("CITY")]
        public StringText City { get; set; }

        [JsonProperty("POSTAL")]
        public StringText Postal { get; set; }
    }

    public class State
    {
        [JsonProperty("ADDRESS_STATE")]
        public StringText AddressState { get; set; }

        [JsonProperty("ADDRESS_STATE_DESCR")]
        public StringText AddressStateDescr { get; set; }
    }

    public class Country
    {
        [JsonProperty("ADDDRESS_COUNTRY")]
        public StringText AdddressCountry { get; set; }

        [JsonProperty("ADDRESS_COUNTRY_DESCR")]
        public StringText AddressCountryDescr { get; set; }
    }

    public class SubNames
    {
        [JsonProperty("")]
        public DataResponseVersion Version { get; set; }

        [JsonProperty("NAME_TYPE")]
        public StringText NameType { get; set; }

        [JsonProperty("NAME")]
        public StringText Name { get; set; }

        [JsonProperty("NAME_PREFIX")]
        public StringText NamePrefix { get; set; }

        [JsonProperty("NAME_SUFFIX")]
        public StringText NameSuffix { get; set; }

        [JsonProperty("NAME_DISPLAY")]
        public StringText NameDisplay { get; set; }

        [JsonProperty("LAST_NAME")]
        public StringText LastName { get; set; }

        [JsonProperty("FIRST_NAME")]
        public StringText FirstName { get; set; }

        [JsonProperty("MIDDLE_NAME")]
        public StringText MiddleName { get; set; }

        [JsonProperty("PREF_FIRST_NAME")]
        public StringText PrefFirstName { get; set; }

        [JsonProperty("LAST_NAME_PREF_NLD")]
        public LongText LastNamePrefNld { get; set; }
    }

    public class Email
    {
        [JsonProperty("")]
        public DataResponseVersion Version { get; set; }

        [JsonProperty("E_ADDR_TYPE")]
        public StringText EAddrType { get; set; }

        [JsonProperty("EMAIL_ADDR")]
        public StringText EmailAddr { get; set; }
    }

    public class PersonalPhone
    {
        [JsonProperty("")]
        public DataResponseVersion Version { get; set; }

        [JsonProperty("PHONE_TYPE")]
        public StringText PhoneType { get; set; }

        [JsonProperty("COUNTRY_CODE")]
        public StringText CountryCode { get; set; }

        [JsonProperty("PHONE")]
        public StringText Phone { get; set; }

        [JsonProperty("EXTENSION")]
        public StringText Extension { get; set; }
    }

    public class EmergencyContact
    {
        [JsonProperty("")]
        public DataResponseVersion Version { get; set; }

        [JsonProperty("EMERGENCY_CNT_NAME")]
        public StringText EmergencyCntName { get; set; }

        [JsonProperty("EMERGENCY_CNT_RELATIONSHIP")]
        public StringText EmergencyCntRelationship { get; set; }

        [JsonProperty("EMERGENCY_CNT_PRIMARY_CONTACT")]
        public StringText EmergencyCntPrimaryContact { get; set; }

        [JsonProperty("EMERGENCY_CNT_COUNTRY_CODE")]
        public StringText EmergencyCntCountryCode { get; set; }

        [JsonProperty("EMERGENCY_CNT_PHONE_TYPE")]
        public StringText EmergencyCntPhoneType { get; set; }

        [JsonProperty("EMERGENCY_CNT_EXTENSION")]
        public StringText EmergencyCntExtension { get; set; }

        [JsonProperty("EMERGENCY_CNT_PHONE")]
        public StringText EmergencyCntPhone { get; set; }

        [JsonProperty("EMERGENCY_CNT_ADDRESS1")]
        public StringText EmergencyCntAddress1 { get; set; }

        [JsonProperty("EMERGENCY_CNT_ADDRESS2")]
        public StringText EmergencyCntAddress2 { get; set; }

        [JsonProperty("EMERGENCY_CNT_ADDRESS3")]
        public StringText EmergencyCntAddress3 { get; set; }

        [JsonProperty("EMERGENCY_CNT_ADDRESS4")]
        public StringText EmergencyCntAddress4 { get; set; }

        [JsonProperty("EMERGENCY_CNT_CITY")]
        public StringText EmergencyCntCity { get; set; }

        [JsonProperty("EMERGENCY_CNT_POSTAL")]
        public StringText EmergencyCntPostal { get; set; }

        [JsonProperty("EMERGENCY_CNT_STATE")]
        public StringText EmergencyCntState { get; set; }

        [JsonProperty("EMERGENCY_CNT_COUNTRY")]
        public StringText EmergencyCntCountry { get; set; }

        [JsonProperty("EMERGENCY_CNT_ADDRESS_TYPE")]
        public StringText EmergencyCntAddressType { get; set; }
    }

    public partial class PersonData
    {
        [JsonProperty("")]
        public DataResponseVersion Empty { get; set; }

        [JsonProperty("BIRTHDATE")]
        public StringText Birthdate { get; set; }

        [JsonProperty("MAR_STATUS")]
        public StringText MarStatus { get; set; }

        [JsonProperty("SEX")]
        public StringText Sex { get; set; }
    }

    public class Person
    {
        [JsonProperty("")]
        public DataResponseVersion Version { get; set; }

        [JsonProperty("EMPLID")]
        public LongText Emplid { get; set; }

        [JsonProperty("NAME_PSFORMAT")]
        public StringText NamePsformat { get; set; }

        [JsonProperty("BIRTHCOUNTRY")]
        public StringText Birthcountry { get; set; }

        [JsonProperty("PASSPORT_NBR")]
        public StringText PassportNbr { get; set; }

        [JsonProperty("DT_OF_DEATH")]
        public StringText DtOfDeath { get; set; }

        [JsonProperty("IPG_ALT_ID")]
        public StringText IpgAltId { get; set; }

        [JsonProperty("LANG_CD")]
        public StringText LangCd { get; set; }

        [JsonProperty("ISO_LOCALE")]
        public StringText IsoLocale { get; set; }

        [JsonProperty("IPG_API_ADDRESSES_C1")]
        public Addresses IpgApiAddressesC1 { get; set; }

        [JsonProperty("IPG_API_PD_STATE_C")]
        public State State { get; set; }

        [JsonProperty("IPG_API_PD_COUNTRY_C")]
        public Country Country { get; set; }

        [JsonProperty("IPG_API_PERS_DATA_SUB_NAMES")]
        public SubNames SubNames { get; set; }

        [JsonProperty("IPG_API_EMAIL_C")]
        public Email Email { get; set; }

        [JsonProperty("IPG_API_PERSONAL_PHONE_C")]
        public PersonalPhone PersonalPhone { get; set; }

        [JsonProperty("IPG_API_EMERGENCY_CNTCT_C")]
        public EmergencyContact EmergencyContact { get; set; }

        [JsonProperty("IPG_API_PERS_DATA")]
        public PersonData PersonData { get; set; }
    }

    public class ApiVersionPersons
    {
        [JsonProperty("")]
        public DataResponseVersion Version { get; set; }

        [JsonProperty("IPG_API_PERS_DATA_RESP_P")]
        public Person[] Persons { get; set; }
    }

    public class SoapenvBody
    {
        [JsonProperty("IPG_API_PERS_DATA_RESP_P_COLL")]
        public ApiVersionPersons ApiVersionPersons { get; set; }
    }

    public class SoapenvEnvelope
    {
        [JsonProperty("")]
        public SoapenvEnvelopeDefinition Definition { get; set; }

        [JsonProperty("soapenvBody")]
        public SoapenvBody Body { get; set; }
    }

    public class PersonalDataResponse
    {
        [JsonProperty("soapenvEnvelope")]
        public SoapenvEnvelope SoapenvEnvelope { get; set; }
    }
}
