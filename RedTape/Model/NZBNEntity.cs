using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedTape.Model
{
    public partial class NzbnEntity
    {
        [JsonProperty("entityStatusCode")]
        public long? EntityStatusCode { get; set; }

        [JsonProperty("entityName")]
        public string EntityName { get; set; }

        [JsonProperty("nzbn")]
        public string Nzbn { get; set; }

        [JsonProperty("entityTypeCode")]
        public string EntityTypeCode { get; set; }

        [JsonProperty("entityTypeDescription")]
        public string EntityTypeDescription { get; set; }

        [JsonProperty("entityStatusDescription")]
        public string EntityStatusDescription { get; set; }

        [JsonProperty("registrationDate")]
        public DateTime? RegistrationDateTime { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDateTime { get; set; }

        [JsonProperty("sourceRegister")]
        public string SourceRegister { get; set; }

        [JsonProperty("sourceRegisterUniqueIdentifier")]
        public long? SourceRegisterUniqueIdentifier { get; set; }

        [JsonProperty("gstStatus")]
        public object GstStatus { get; set; }

        [JsonProperty("gstEffectiveDate")]
        public object GstEffectiveDateTime { get; set; }

        [JsonProperty("lastUpdatedDate")]
        public string LastUpdatedDateTime { get; set; }

        [JsonProperty("locationIdentifier")]
        public object LocationIdentifier { get; set; }

        [JsonProperty("australianBusinessNumber")]
        public object AustralianBusinessNumber { get; set; }

        [JsonProperty("australianCompanyNumber")]
        public object AustralianCompanyNumber { get; set; }

        [JsonProperty("australianServiceAddress")]
        public object AustralianServiceAddress { get; set; }

        [JsonProperty("entityNames")]
        public List<EntityName> EntityNames { get; set; }

        [JsonProperty("entityStatus")]
        public List<EntityStatus> EntityStatus { get; set; }

        [JsonProperty("emailAddress")]
        public List<object> EmailAddress { get; set; }

        [JsonProperty("otherAddress")]
        public List<object> OtherAddress { get; set; }

        [JsonProperty("registeredAddress")]
        public List<Dictionary<string, string>> RegisteredAddress { get; set; }

        [JsonProperty("postalAddress")]
        public List<object> PostalAddress { get; set; }

        [JsonProperty("industryClassification")]
        public List<object> IndustryClassification { get; set; }

        [JsonProperty("principalPlaceOfActivity")]
        public List<Dictionary<string, string>> PrincipalPlaceOfActivity { get; set; }

        [JsonProperty("physicalAddress")]
        public List<Dictionary<string, string>> PhysicalAddress { get; set; }

        [JsonProperty("phoneNumber")]
        public List<object> PhoneNumber { get; set; }

        [JsonProperty("website")]
        public List<object> Website { get; set; }

        [JsonProperty("tradingNames")]
        public List<object> TradingNames { get; set; }

        [JsonProperty("privacySettings")]
        public object PrivacySettings { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("roles")]
        public List<Role> Roles { get; set; }

        [JsonProperty("supportingInformation")]
        public object SupportingInformation { get; set; }
    }

    public partial class Company
    {
        [JsonProperty("annualReturnFilingMonth")]
        public long? AnnualReturnFilingMonth { get; set; }

        [JsonProperty("financialReportFilingMonth")]
        public object FinancialReportFilingMonth { get; set; }

        [JsonProperty("nzsxCode")]
        public object NzsxCode { get; set; }

        [JsonProperty("annualReturnLastFiled")]
        public string AnnualReturnLastFiled { get; set; }

        [JsonProperty("hasConstitutionFiled")]
        public bool? HasConstitutionFiled { get; set; }

        [JsonProperty("countryOfOrigin")]
        public object CountryOfOrigin { get; set; }

        [JsonProperty("overseasCompany")]
        public bool? OverseasCompany { get; set; }

        [JsonProperty("extensiveShareholding")]
        public bool? ExtensiveShareholding { get; set; }

        [JsonProperty("stockExchangeListed")]
        public object StockExchangeListed { get; set; }

        [JsonProperty("shareholding")]
        public Shareholding Shareholding { get; set; }

        [JsonProperty("ultimateHoldingCompany")]
        public object UltimateHoldingCompany { get; set; }

        [JsonProperty("insolvencyDetails")]
        public object InsolvencyDetails { get; set; }

        [JsonProperty("insolvencies")]
        public List<object> Insolvencies { get; set; }

        [JsonProperty("removalCommenced")]
        public bool? RemovalCommenced { get; set; }
    }

    public partial class Shareholding
    {
        [JsonProperty("numberOfShares")]
        public long? NumberOfShares { get; set; }

        [JsonProperty("shareAllocation")]
        public List<ShareAllocation> ShareAllocation { get; set; }

        [JsonProperty("historicShareholder")]
        public List<HistoricShareholder> HistoricShareholder { get; set; }
    }

    public partial class HistoricShareholder
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("appointmentDate")]
        public DateTime? AppointmentDateTime { get; set; }

        [JsonProperty("vacationDate")]
        public string VacationDateTime { get; set; }

        [JsonProperty("historicShareholderAddress")]
        public object HistoricShareholderAddress { get; set; }

        [JsonProperty("historicIndividualShareholder")]
        public object HistoricIndividualShareholder { get; set; }

        [JsonProperty("historicOtherShareholder")]
        public OtherShareholder HistoricOtherShareholder { get; set; }
    }

    public partial class OtherShareholder
    {
        [JsonProperty("currentEntityName")]
        public string CurrentEntityName { get; set; }

        [JsonProperty("nzbn")]
        public string Nzbn { get; set; }

        [JsonProperty("companyNumber")]
        public long? CompanyNumber { get; set; }

        [JsonProperty("entityType")]
        public string EntityType { get; set; }
    }

    public partial class ShareAllocation
    {
        [JsonProperty("allocation")]
        public long? Allocation { get; set; }

        [JsonProperty("shareholder")]
        public List<Shareholder> Shareholder { get; set; }
    }

    public partial class Shareholder
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("appointmentDate")]
        public DateTime? AppointmentDateTime { get; set; }

        [JsonProperty("vacationDate")]
        public object VacationDateTime { get; set; }

        [JsonProperty("individualShareholder")]
        public RolePerson IndividualShareholder { get; set; }

        [JsonProperty("otherShareholder")]
        public OtherShareholder OtherShareholder { get; set; }

        [JsonProperty("shareholderAddress")]
        public Dictionary<string, string> ShareholderAddress { get; set; }
    }

    public partial class RolePerson
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("middleNames")]
        public string MiddleNames { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("fullName")]
        public object FullName { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }
    }

    public partial class EntityName
    {
        [JsonProperty("entityName")]
        public string EntityNameEntityName { get; set; }

        [JsonProperty("startDate")]
        public object StartDateTime { get; set; }

        [JsonProperty("endDate")]
        public object EndDateTime { get; set; }
    }

    public partial class EntityStatus
    {
        [JsonProperty("entityStatus")]
        public long? EntityStatusEntityStatus { get; set; }

        [JsonProperty("startDate")]
        public object StartDateTime { get; set; }

        [JsonProperty("endDate")]
        public object EndDateTime { get; set; }

        [JsonProperty("statusReasonCode")]
        public object StatusReasonCode { get; set; }

        [JsonProperty("comment")]
        public object Comment { get; set; }
    }

    public partial class Role
    {
        [JsonProperty("roleType")]
        public string RoleType { get; set; }

        [JsonProperty("roleStatus")]
        public string RoleStatus { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDateTime { get; set; }

        [JsonProperty("endDate")]
        public object EndDateTime { get; set; }

        [JsonProperty("asicDirectorshipYn")]
        public bool? AsicDirectorshipYn { get; set; }

        [JsonProperty("asicName")]
        public object AsicName { get; set; }

        [JsonProperty("acn")]
        public object Acn { get; set; }

        [JsonProperty("roleEntity")]
        public object RoleEntity { get; set; }

        [JsonProperty("rolePerson")]
        public RolePerson RolePerson { get; set; }

        [JsonProperty("roleAddress")]
        public List<Dictionary<string, string>> RoleAddress { get; set; }

        [JsonProperty("roleAsicAddress")]
        public List<Dictionary<string, string>> RoleAsicAddress { get; set; }

        [JsonProperty("uniqueIdentifier")]
        public string UniqueIdentifier { get; set; }
    }
}
