using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDBLibrary
{
    public interface IPortalRepoAsync
    {
        Task<List<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(string jobId);
        Task<List<Skill>> GetAllSkillsAsync();
        Task<Skill> GetSkillByIdAsync( string skillId);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(string empId);
        Task<List<JobSkill>> GetAllJobSkillAsync();
        Task<JobSkill> GetJobSkillByIdAsync(string jobId,string skillId);
        Task<List<JobSkill>> GetJobSkillsByJobIdAsync(string jobId);
        Task<List<JobSkill>> GetJobSkillsBySkillIdAsync(string skillId);

    }
}
