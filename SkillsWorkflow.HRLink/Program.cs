using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillsWorkflow.Common;

namespace SkillsWorkflow.HrLink
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("<Program> Starting");
            var tenantsSection = Helpers.TenantSectionHelper.Get();
            List<ApiDto> tenants = new List<ApiDto>();
            foreach (var tenantSection in tenantsSection)
                tenants.Add(new ApiDto { Url = tenantSection.ApiUrl, Id = tenantSection.ApiId, Secret = tenantSection.ApiSecret });
            var mailDto = MailHelper.ReadConfigurationSettings();
            if (args.Length == 4 && args[0] == "-update")
            {
                var apiDto = new ApiDto { Url = args[1], Id = args[2], Secret = args[3] };
                var contextDto = await ApiHelper.GetContextDtoAsync(apiDto);
                await Updater.UpdateAsync(apiDto, mailDto, contextDto);
                return;
            }
            if (args.Length == 1 && args[0] == "-status")
            {
                foreach (var tenant in tenants)
                    Console.WriteLine(Tester.Execute(tenant.Url, tenant.Id, tenant.Secret));
                return;
            }
            if (args.Length == 1 && args[0] == "-update")
            {
                foreach (var tenant in tenants)
                {
                    var contextDto = await ApiHelper.GetContextDtoAsync(tenant);
                    await Updater.UpdateAsync(tenant, mailDto, contextDto);
                }
                return;
            }
            if (args.Length == 0)
            {
                var controller = new Controller(tenants, mailDto);
                await controller.ExecuteAsync();
                return;
            }
            if (args.Length == 2 && args[0] == "-status")
            {
                foreach (var tenant in tenants)
                {
                    Guid id;
                    if (!Guid.TryParse(args[1], out id)) return;
                    var result = Tester.Execute(tenant.Url, tenant.Id, tenant.Secret);
                    PortalHelper.Start(id, result).Wait();
                }
            }
            Console.Write("<Program> Ending");
        }
    }
}
