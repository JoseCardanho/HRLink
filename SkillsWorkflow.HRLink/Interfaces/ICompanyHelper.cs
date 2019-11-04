using SkillsWorkflow.Common;
using SkillsWorkflow.HrLink.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillsWorkflow.HrLink.Interfaces
{
    public interface ICompanyHelper
    {
        Task<List<CompanyDto>> GetAsync(ApiDto apiDto);
    }
}
