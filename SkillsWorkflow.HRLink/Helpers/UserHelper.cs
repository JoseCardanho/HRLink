using Newtonsoft.Json;
using SkillsWorkflow.Common;
using SkillsWorkflow.HrLink.Dto;
using SkillsWorkflow.HrLink.Interfaces;
using SkillsWorkflow.Integration.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SkillsWorkflow.HrLink.Helpers
{
    public class UserHelper : IUserHelper
    {
        private static async Task<DepartmentDto> GetDepartmentAsync(HttpClient httpClient, Guid companyId, string externalId)
        {
            var response = await httpClient.GetAsync($"/api/companies/{companyId}/departments/external?externalId={HttpUtility.UrlEncode(externalId)}");
            if (response.StatusCode == HttpStatusCode.NotFound) return null;
            if (response.StatusCode == HttpStatusCode.BadRequest) return null;
            return await response.Content.ReadAsJsonAsync<DepartmentDto>();
        }

        private static async Task<EmployeeDto> SaveEmployeeAsync(HttpClient httpClient, Dto.CompanyDto company, long externalId, string userName, bool active, string progressMessage, List<MailBodyDto> mailBodyList)
        {
            EmployeeModel model = new EmployeeModel
            {
                CompanyId = company.CompanyId,
                CompanyCode = company.Code,
                ExternalId = externalId.ToString(),
                Name = userName,
                IsActive = active
            };
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/employees", contentPost);
            if (response.IsSuccessStatusCode)
            {
                var employeeDto = await response.Content.ReadAsJsonAsync<EmployeeDto>();
                await ApiHelper.SaveLogAsync(httpClient, company.Code, company.CompanyId, Updater.MyStatusId, "Employee", userName, employeeDto.Action, progressMessage, JsonConvert.SerializeObject(model));
                return employeeDto;
            }
            var errorMessage = response.Content.ReadAsStringAsync().Result;
            await ApiHelper.SaveLogAsync(httpClient, company.Code, company.CompanyId, Updater.MyStatusId, "Employee", userName, errorMessage, progressMessage, JsonConvert.SerializeObject(model));
            return null;
        }

        private static async Task<Integration.Api.Models.UserTypologyDto> GetUserTypologyAsync(HttpClient httpClient, Guid departmentId, string externalId)
        {
            var response = await httpClient.GetAsync($"/api/departments/{departmentId}/usertypologies/external?externalId={HttpUtility.UrlEncode(externalId)}");
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadAsJsonAsync<UserTypologyDto>();
        }

        private static async Task<bool> SaveUserTypologyGroupAsync(HttpClient httpClient, UserTypologyGroupModel model, string progressMessage)
        {            
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/usertypologygroups", contentPost);
            if (response.IsSuccessStatusCode)
            {
                var userTypologyGroupDto = await response.Content.ReadAsJsonAsync<UserTypologyGroupDto>();
                await ApiHelper.SaveLogAsync(httpClient, model.CompanyCode, model.CompanyId, Updater.MyStatusId, "UserTypologyGroup", model.Name, userTypologyGroupDto.Action, progressMessage, JsonConvert.SerializeObject(model));
                return true;
            }
            var errorMessage = response.Content.ReadAsStringAsync().Result;
            await ApiHelper.SaveLogAsync(httpClient, model.CompanyCode, model.CompanyId, Updater.MyStatusId, "UserTypologyGroup", model.Name, errorMessage, progressMessage, JsonConvert.SerializeObject(model));
            return response.IsSuccessStatusCode;
        }

        private static async Task<bool> SaveUserTypologyAsync(HttpClient httpClient, UserTypologyModel model, string progressMessage)
        {
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/usertypologies", contentPost);
            if (response.IsSuccessStatusCode)
            {
                var userTypologyDto = await response.Content.ReadAsJsonAsync<UserTypologyDto>();
                await ApiHelper.SaveLogAsync(httpClient, model.CompanyCode, model.CompanyId, Updater.MyStatusId, "UserTypology", model.Name, userTypologyDto.Action, progressMessage, JsonConvert.SerializeObject(model));
                return true;
            }
            var errorMessage = response.Content.ReadAsStringAsync().Result;
            await ApiHelper.SaveLogAsync(httpClient, model.CompanyCode, model.CompanyId, Updater.MyStatusId, "UserTypology", model.Name, errorMessage, progressMessage, JsonConvert.SerializeObject(model));
            return response.IsSuccessStatusCode;
        }

        private static async Task<bool> SaveUserTypologyAsync(HttpClient httpClient, Dto.CompanyDto company, Guid departmentId, JobDataWithComp job, string progressMessage)
        {
            var userTypologyName = job.JobFunction.JobFunctionJobFunction.Text;
            var userTypology = await GetUserTypologyAsync(httpClient, departmentId, job.JobFunction.JobFunctionJobFunction.Text);
            if (userTypology != null)
                return true;
            var userTypologyGroupModel = new UserTypologyGroupModel
            {
                CompanyId = company.CompanyId,
                Name = userTypologyName,
                Active = true
            };
            var saveUserTypologyGroup = await SaveUserTypologyGroupAsync(httpClient, userTypologyGroupModel, progressMessage);            
            if (!saveUserTypologyGroup)
                return false;
            UserTypologyModel model = new UserTypologyModel
            {
                CompanyId = company.CompanyId,
                Name = userTypologyName,
                ExternalId = userTypologyName,
                DepartmentId = departmentId,
                UserTypologyGroupName = userTypologyName,
                Active = true,
            };
            var saveUserTypology = await SaveUserTypologyAsync(httpClient, model, progressMessage);            
            return saveUserTypology;
        }



        private static async Task<UserDto> SaveUserAsync(HttpClient httpClient, Dto.CompanyDto company, long externalId, string userName, bool isActive, Person person, JobDataWithComp job, Guid employeeId, string progressMessage, List<MailBodyDto> mailBodyList)
        {
            UserModel model = new UserModel
            {
                Name = userName,
                UserName = userName,
                ExternalId = externalId.ToString(),
                CompanyId = company.CompanyId,
                CompanyCode = company.Code,
                EmployeeId = employeeId,
                DepartmentExternalId = job.Department.Deptid.Text,
                TypologyExternalId = job.JobFunction.JobFunctionJobFunction.Text,
                Mail = person.Email.EmailAddr.Text,
                Phone = person.PersonalPhone.Phone.Text,
                IsActive = isActive
            };            
            if (!string.IsNullOrEmpty(job.Job.HireDt.Text))
                model.HireDate = Convert.ToDateTime(job.Job.HireDt.Text);
        //public string SsoUserName { get; set; }
        //public bool SsoUserNameUpdatable { get; set; }
        //public DateTime? ExpirationDate { get; set; }
        //public double RequiredWeeklyHours { get; set; }
        //public double RequiredHours { get; set; }
        //public Guid ResponsibleId { get; set; }
        //public Guid UserTypeId { get; set; }
        //public double WeeklyOvertimeThresholdHours { get; set; }
        //public bool ExternalNumberUpdatable { get; set; }
        //public string ExternalNumber { get; set; }
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/users", contentPost);
            if (response.IsSuccessStatusCode)
            {
                var savedUserDto = await response.Content.ReadAsJsonAsync<UserDto>();
                await ApiHelper.SaveLogAsync(httpClient, company.Code, company.CompanyId, Updater.MyStatusId, "User", model.UserName, savedUserDto.Action, progressMessage, JsonConvert.SerializeObject(model));
                return savedUserDto;
            }
            var errorMessage = response.Content.ReadAsStringAsync().Result;
            await ApiHelper.SaveLogAsync(httpClient, company.Code, company.CompanyId, Updater.MyStatusId, "User", model.UserName, errorMessage, progressMessage, JsonConvert.SerializeObject(model));
            return null;
        }


        public async Task<JobDataResponse> GetJobDataAsync(ApiDto apiDto, Dto.CompanyDto company, List<MailBodyDto> mailBodyList)
        {
            var httpClient = HttpClientHelper.Get(apiDto);
            string body = "";
            string uriString = company.JobWithCompensationUrl + $"?REQUESTOR={HttpUtility.UrlEncode(company.Requestor)}&PASSWORD={HttpUtility.UrlEncode(company.Password)}";
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(uriString),
                Content = new StringContent(body)
            };
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {company.AccessToken}");
            httpClient.DefaultRequestHeaders.Add("apikey", company.ApiKey);
            httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsJsonAsync<JobDataResponse>();
            var message = await response.Content.ReadAsStringAsync();
            mailBodyList.Add(new MailBodyDto { CompanyCode = company.Code, Message = message });            
            return null;
        }

        public async Task<PersonalDataResponse> GetPersonalDataAsync(ApiDto apiDto, Dto.CompanyDto company, List<MailBodyDto> mailBodyList)
        {
            var httpClient = HttpClientHelper.Get(apiDto);
            string body = "";
            string uriString = company.PersonalDataUrl + $"?REQUESTOR={HttpUtility.UrlEncode(company.Requestor)}&PASSWORD={HttpUtility.UrlEncode(company.Password)}";
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(uriString),
                Content = new StringContent(body)
            };
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {company.AccessToken}");
            httpClient.DefaultRequestHeaders.Add("apikey", company.ApiKey);
            httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsJsonAsync<PersonalDataResponse>();
            var message = await response.Content.ReadAsStringAsync();
            mailBodyList.Add(new MailBodyDto { CompanyCode = company.Code, Message = message });
            return null;
        }

        public async Task<bool> ImportAsync(ApiDto apiDto, Dto.CompanyDto company, PersonalDataResponse personalData, JobDataResponse jobData, List<MailBodyDto> mailBodyList)
        {
            var persons = personalData == null ? new List<Person>() : personalData.SoapenvEnvelope.Body.ApiVersionPersons.Persons.ToList();            
            var jobs = jobData == null ? new List<JobDataWithComp>() : jobData.SoapenvEnvelope.Body.ApiVersionJobs.JobDataWithCompList.ToList();
            int count = 1;
            var httpClient = HttpClientHelper.Get(apiDto);
            var imported = true;
            foreach (var person in persons)
            {
                var progressMessage = $"Importing {count++} of {persons.Count}.";
                var externalId = person.Emplid.Text;
                var userName = person.SubNames.NameDisplay.Text;
                var job = jobs.FirstOrDefault(j => j.Job.Emplid.Text == externalId);
                if(job == null)
                {
                    await LogHelper.SaveLogAsync(apiDto, company.Code, company.CompanyId, Updater.MyStatusId, "User", userName, $"-- Not Imported - Job data must exists for employeeid {externalId} --", progressMessage, JsonConvert.SerializeObject(person));
                    imported = false;
                    continue;
                }
                var department = await GetDepartmentAsync(httpClient, company.CompanyId, job.Department.Deptid.Text);
                if (department == null)
                {
                    await ApiHelper.SaveLogAsync(apiDto, company.Code, company.CompanyId, Updater.MyStatusId, "User", userName, $"Department does not exists for external id {job.Department.Deptid.Text}.", progressMessage, JsonConvert.SerializeObject(person));
                    continue;
                }
                var isActive = job.Job.EmplStatus.Text == "A";
                var employeeDto = await SaveEmployeeAsync(httpClient, company, externalId, userName, isActive, progressMessage, mailBodyList);
                if (employeeDto == null)
                {
                    imported = false;
                    continue;
                }
                var savedUserTypology = await SaveUserTypologyAsync(httpClient, company, department.Id, job, progressMessage);
                if (!savedUserTypology)
                {
                    imported = false;
                    continue;
                }
                var savedUserDto = await SaveUserAsync(httpClient, company, externalId, userName, isActive, person, job, employeeDto.Id, progressMessage, mailBodyList);
                if (savedUserDto == null)
                {
                    imported = false;
                    continue;
                }
            }
            return imported;
        }
    }
}
