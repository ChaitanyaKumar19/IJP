using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PortalDBLibrary;

namespace PortalDBService.Controllers
{
    public class PortalDBController : ApiController
    {
        IPortalRepoAsync portalRepo = new PortalRepoAsync();

        [HttpGet]
        [Route("api/PortalDB/GetAllEmployee/")]
        public async Task<IHttpActionResult> GetAllEmployee()
        {
            List<Employee> employees = await portalRepo.GetAllEmployeesAsync();
            return Ok<List<Employee>>(employees);
        }

        [HttpGet]
        [Route("api/PortalDB/GetAllJobs/")]
        public async Task<IHttpActionResult> GetAllJobs()
        {
            List<Job> jobs = await portalRepo.GetAllJobsAsync();
            return Ok<List<Job>>(jobs);
        }

        [HttpGet]
        [Route("api/PortalDB/GetAllJobSkills/")]
        public async Task<IHttpActionResult> GetAllJobSkills()
        {
            List<JobSkill> jobSkills = await portalRepo.GetAllJobSkillAsync();
            return Ok<List<JobSkill>>(jobSkills);
        }

        [HttpGet]
        [Route("api/PortalDB/GetAllSkills/")]
        public async Task<IHttpActionResult> GetAllSkills()
        {
            List<Skill> skills = await portalRepo.GetAllSkillsAsync();
            return Ok<List<Skill>>(skills);
        }

        [HttpGet]
        [Route("api/PortalDB/Employee/ById/{EmpId}/")]
        public async Task<IHttpActionResult> GetEmployee(string EmpId)
        {
            try
            {
                Employee employee = await portalRepo.GetEmployeeByIdAsync(EmpId);
                return Ok<Employee>(employee);
            }
            catch
            {
                return BadRequest("No Such Employee!");
            }
            
        }

        [HttpGet]
        [Route("api/PortalDB/Job/ById/{JobId}/")]
        public async Task<IHttpActionResult> GetJob(string JobId)
        {
            try
            {
                Job job = await portalRepo.GetJobByIdAsync(JobId);
                return Ok<Job>(job);
            }
            catch
            {
                return BadRequest("No Such Job!");
            }
            
        }

        [HttpGet]
        [Route("api/PortalDB/JobSkill/ById/{JobId}/{SkillId}/")]
        public async Task<IHttpActionResult> GetJobSkill(string JobId,string SkillId)
        {
            try
            {
                JobSkill jobSkill = await portalRepo.GetJobSkillByIdAsync(JobId, SkillId);
                return Ok<JobSkill>(jobSkill);
            }
            catch
            {
                return BadRequest("No Such Job Skill!");
            }
            
        }

        [HttpGet]
        [Route("api/PortalDB/JobSkill/ById/{JobId}/")]
        public async Task<IHttpActionResult> GetJobSkillByJobId(string JobId)
        {
            List<JobSkill> jobSkills = await portalRepo.GetJobSkillsByJobIdAsync(JobId);
            return Ok<List<JobSkill>>(jobSkills);
        }

        [HttpGet]
        [Route("api/PortalDB/JobSkill/ById/{SkillId}/")]
        public async Task<IHttpActionResult> GetJobSkillBySkillId(string SkillId)
        {
            List<JobSkill> jobSkills = await portalRepo.GetJobSkillsBySkillIdAsync(SkillId);
            return Ok<List<JobSkill>>(jobSkills);
        }

        [HttpGet]
        [Route("api/PortalDB/Skill/ById/{SkillId}/")]
        public async Task<IHttpActionResult> GetSkill(string SkillId)
        {
            try
            {
                Skill skill = await portalRepo.GetSkillByIdAsync(SkillId);
                return Ok<Skill>(skill);
            }
            catch
            {
                return BadRequest("No Such Job Skill!");
            }   
        }
    }
}
