using SkillsWorkflow.Common;
using SkillsWorkflow.HrLink.Dto;
using SkillsWorkflow.HrLink.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace SkillsWorkflow.HrLink.Helpers
{
    public class CompanyHelper : ICompanyHelper
    {
        public async Task<List<CompanyDto>> GetAsync(ApiDto apiDto)
        {
            var httpClient = HttpClientHelper.Get(apiDto);
            var policeResponse = await PollyHelper.GetHttpResponseMessage(httpClient, ConfigurationManager.AppSettings["RetryPolicy:Http:RetryTimeoutMinutes"], "/api/skillviews/search?viewName=SkillsWorkflowIntegrationHrLinkCompanies");
            if (!policeResponse.IsSuccessStatusCode)
                throw new Exception("Error searching view named SkillsWorkflowIntegrationHrLinkCompanies. " + Environment.NewLine + policeResponse.Content.ReadAsStringAsync().Result);
            var searchedViews = await policeResponse.Content.ReadAsJsonAsync<List<string>>();
            if (searchedViews.Count == 0) return new List<CompanyDto>();
            policeResponse = await PollyHelper.GetHttpResponseMessage(httpClient, ConfigurationManager.AppSettings["RetryPolicy:Http:RetryTimeoutMinutes"], "/api/skillviews/SkillsWorkflowIntegrationHrLinkCompanies");
            if (!policeResponse.IsSuccessStatusCode)
                throw new Exception("Error executing view named SkillsWorkflowIntegrationHrLinkCompanies. " + Environment.NewLine + policeResponse.Content.ReadAsStringAsync().Result);
            return await policeResponse.Content.ReadAsJsonAsync<List<CompanyDto>>();
        }
    }
}
