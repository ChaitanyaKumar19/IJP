using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EmployeeSkillLibrary;

namespace EmployeeSkillService.Controllers
{
    public class EmployeeSkillController : ApiController
    {
        IEmployeeSkillRepoAsync empSkillRepo = new EmployeeSkillRepoAsync();
        [HttpGet]
        [Route("api/EmployeeSkill/GetAll/")]
        public async Task<IHttpActionResult> GetAll()
        {
            List<EmployeeSkill> empSkills = await empSkillRepo.GetAllEmployeeSkillsAsync();
            return Ok<List<EmployeeSkill>>(empSkills);
        }
        [HttpGet]
        [Route("api/EmployeeSkill/ByEmpId/{empId}")]
        public async Task<IHttpActionResult> GetByEmployeeId(string empId)
        {
            List<EmployeeSkill> empSkills = await empSkillRepo.GetEmployeeSkillsByEmpIdAsync(empId);
            return Ok<List<EmployeeSkill>>(empSkills);
        }
        [HttpGet]
        [Route("api/EmployeeSkill/BySkillId/{skillId}")]
        public async Task<IHttpActionResult> GetBySkillId(string skillId)
        {
            List<EmployeeSkill> empSkills = await empSkillRepo.GetEmployeeSkillsBySkillIdAsync(skillId);
            return Ok<List<EmployeeSkill>>(empSkills);
        }
        [HttpGet]
        [Route("api/EmployeeSkill/{empId}/{skillId}")]
        public async Task<IHttpActionResult> GetOne(string empId, string skillId)
        {
            EmployeeSkill empSkill = await empSkillRepo.GetEmployeeSkillByIdAsync(empId, skillId);
            return Ok<EmployeeSkill>(empSkill);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insert(EmployeeSkill es)
        {
            await empSkillRepo.InsertEmployeeSkillAsync(es);
            return Created("/api/EmployeeSkill", es);
        }
        [HttpPut]
        [Route("api/EmployeeSkill/{empId}/{skillId}")]
        public async Task<IHttpActionResult> Update(string empId, string skillId, EmployeeSkill es)
        {
            await empSkillRepo.UpdateEmployeeSkillAsync(empId, skillId, es);
            return Ok<EmployeeSkill>(es);
        }
        [HttpDelete]
        [Route("api/EmployeeSkill/{empId}/{skillId}")]
        public async Task<IHttpActionResult> Delete(string empId, string skillId)
        {
            await empSkillRepo.DeleteEmployeeSkillAsync(empId, skillId);
            return Ok();
        }
    }
}
