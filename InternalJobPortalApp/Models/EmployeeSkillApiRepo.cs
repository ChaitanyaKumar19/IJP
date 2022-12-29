using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EmployeeSkillLibrary;
using Newtonsoft.Json;

namespace InternalJobPortalApp.Models
{
    public class EmployeeSkillApiRepo
    {
        public HttpClient webApi;
        
        public EmployeeSkillApiRepo()
        {
            webApi = new HttpClient();
            webApi.BaseAddress = new Uri("http://localhost:50601/api/EmployeeSkill/");
        }

        public async Task<List<EmployeeSkill>> GetAllEmployeeSkills()
        {
            HttpResponseMessage response = await webApi.GetAsync(""+"GetAll");
            string str = await response.Content.ReadAsStringAsync();
            Console.WriteLine(str);
            List<EmployeeSkill> employeeSkills = JsonConvert.DeserializeObject<List<EmployeeSkill>>(str);
            return employeeSkills;
        }

        public async Task<List<EmployeeSkill>> GetByEmployeeId(string empId)
        {
            HttpResponseMessage response = await webApi.GetAsync("" + "ByEmpId/" + empId);
            string str = await response.Content.ReadAsStringAsync();
            Console.WriteLine(str);
            List<EmployeeSkill> employeeSkills = JsonConvert.DeserializeObject<List<EmployeeSkill>>(str);
            return employeeSkills;
        }

        public async Task<List<EmployeeSkill>> GetBySkillId(string skillId)
        {
            HttpResponseMessage response = await webApi.GetAsync("" + "BySkillId/" + skillId);
            string str = await response.Content.ReadAsStringAsync();
            Console.WriteLine(str);
            List<EmployeeSkill> employeeSkills = JsonConvert.DeserializeObject<List<EmployeeSkill>>(str);
            return employeeSkills;
        }

        public async Task<EmployeeSkill> GetById(string empid,string skillId)
        {
            HttpResponseMessage response = await webApi.GetAsync("" + empid + "/" + skillId);
            string str = await response.Content.ReadAsStringAsync();
            Console.WriteLine(str);
            EmployeeSkill employeeSkill = JsonConvert.DeserializeObject<EmployeeSkill>(str);
            return employeeSkill;
        }

        public async Task Insert(EmployeeSkill employeeSkill)
        {
            var json = JsonConvert.SerializeObject(employeeSkill);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PostAsync("", data);
        }

        public async Task Update(string empId, string skillId, EmployeeSkill employeeSkill)
        {
            var json = JsonConvert.SerializeObject(employeeSkill);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PutAsync("" + empId + skillId, data);
        }

        public async Task Delete(string empId, string skillId)
        {
            await webApi.DeleteAsync("" + empId + skillId);
        }

    }
}