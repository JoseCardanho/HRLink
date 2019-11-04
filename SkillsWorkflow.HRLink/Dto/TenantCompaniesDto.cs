using SkillsWorkflow.Common;
using System.Collections.Generic;

namespace SkillsWorkflow.HrLink.Dto
{
    public class TenantCompaniesDto
    {
        public ApiDto Api { get; set; }
        public List<CompanyDto> Companies { get; set; }
    }
}
