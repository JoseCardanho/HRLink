using SkillsWorkflow.HrLink.Dto;
using System.Collections.Generic;
using System.Configuration;

namespace SkillsWorkflow.HrLink.Helpers
{
    public static class TenantSectionHelper
    {
        public static List<TenantsSectionDto> Get()
        {
            TenantsSection tenantsApiSection = ConfigurationManager.GetSection("TenantsApi") as TenantsSection;
            if (tenantsApiSection == null) return null;
            var tenantSections = new List<TenantsSectionDto>();
            for (int i = 0; i < tenantsApiSection.Tenants.Count; i++)
            {
                var tenantSection = new TenantsSectionDto
                {
                    Name = tenantsApiSection.Tenants[i].Name,
                    ApiUrl = tenantsApiSection.Tenants[i].ApiUrl,
                    ApiId = tenantsApiSection.Tenants[i].ApiId,
                    ApiSecret = tenantsApiSection.Tenants[i].ApiSecret
                };
                if (string.IsNullOrEmpty(tenantSection.Name)) continue;
                tenantSections.Add(tenantSection);
            }
            return tenantSections;
        }
    }
}
