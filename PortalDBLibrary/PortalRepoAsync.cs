using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDBLibrary
{
    public class PortalRepoAsync : IPortalRepoAsync
    {
        PortalDBEntities1 pEnt = new PortalDBEntities1();
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            List<Employee> employees = await pEnt.Employees.ToListAsync();
            return employees;
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            List<Job> jobs = await pEnt.Jobs.ToListAsync();
            return jobs;
        }

        public async Task<List<JobSkill>> GetAllJobSkillAsync()
        {
            List<JobSkill> jobSkills = await pEnt.JobSkills.ToListAsync();
            return jobSkills;
        }

        public async Task<List<Skill>> GetAllSkillsAsync()
        {
            List<Skill> skills = await pEnt.Skills.ToListAsync();
            return skills;
        }

        public async Task<Employee> GetEmployeeByIdAsync(string empId)
        {
            try
            {
                Employee employee = await (from emp in pEnt.Employees where emp.EmpId == empId select emp).FirstAsync();
                return employee;
            }
            catch
            {
                throw new Exception("No such Employee!");
            }
        }

        public async Task<Job> GetJobByIdAsync(string jobId)
        {
            try
            {
                Job job = await(from j in pEnt.Jobs where j.JobId == jobId select j).FirstAsync();
                return job;
            }
            catch
            {
                throw new Exception("No such Job!");
            }
        }

        public async Task<JobSkill> GetJobSkillByIdAsync(string jobId, string skillId)
        {
            try
            {
                JobSkill jobSkill = await(from js in pEnt.JobSkills where js.JobId == jobId && js.SkillId == skillId select js).FirstAsync();
                return jobSkill;
            }
            catch
            {
                throw new Exception("No such JobSkill!");
            }
        }

        public async Task<List<JobSkill>> GetJobSkillsByJobIdAsync(string jobId)
        {
            List<JobSkill> jobSkills = await (from js in pEnt.JobSkills where js.JobId == jobId select js).ToListAsync();
            return jobSkills;
        }

        public async Task<List<JobSkill>> GetJobSkillsBySkillIdAsync(string skillId)
        {
            List<JobSkill> jobSkills = await (from js in pEnt.JobSkills where js.SkillId == skillId select js).ToListAsync();
            return jobSkills;
        }

        public async Task<Skill> GetSkillByIdAsync(string skillId)
        {
            try
            {
                Skill skill = await(from s in pEnt.Skills where s.SkillId == skillId select s).FirstAsync();
                return skill;
            }
            catch
            {
                throw new Exception("No such Post Id !");
            }
        }
    }
}
