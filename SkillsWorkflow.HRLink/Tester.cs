using Newtonsoft.Json;
using SkillsWorkflow.Common;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SkillsWorkflow.HrLink
{
    public static class Tester
    {
        public static string Execute(string apiUrl, string apiId, string apiSecret)
        {
            var statusList = new List<StatusDto>();
            statusList.Add(new StatusDto() { Code = 0, Name = "DbVersion", Message = Updater.MyVersion });
            var version = ((AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyFileVersionAttribute), false)).Version;
            statusList.Add(new StatusDto() { Code = 0, Name = "Version", Message = version });
            statusList.Add(string.IsNullOrEmpty(apiUrl)
                ? new StatusDto { Code = 1, Name = "ApiUrl", Message = "Must be defined." }
                : new StatusDto { Code = 0, Name = "ApiUrl", Message = "Ok" });
            statusList.Add(string.IsNullOrEmpty(apiId)
                ? new StatusDto { Code = 1, Name = "ApiId", Message = "Must be defined." }
                : new StatusDto { Code = 0, Name = "ApiId", Message = "Ok" });
            statusList.Add(string.IsNullOrEmpty(apiSecret)
                ? new StatusDto { Code = 1, Name = "ApiSecret", Message = "Must be defined." }
                : new StatusDto { Code = 0, Name = "ApiSecret", Message = "Ok" });
            return JsonConvert.SerializeObject(statusList);
        }
    }
}
