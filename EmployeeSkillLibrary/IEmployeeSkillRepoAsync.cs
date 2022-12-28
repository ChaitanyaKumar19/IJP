using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSkillLibrary
{
    public interface IEmployeeSkillRepoAsync
    {
        Task<List<EmployeeSkill>> GetAllEmployeeSkillsAsync();
        Task<List<EmployeeSkill>> GetEmployeeSkillsByEmpIdAsync(string empId);
        Task<List<EmployeeSkill>> GetEmployeeSkillsBySkillIdAsync(string skillId);
        Task<EmployeeSkill> GetEmployeeSkillByIdAsync(string empId, string skillId);
        Task InsertEmployeeSkillAsync(EmployeeSkill employeeSkill);
        Task UpdateEmployeeSkillAsync(string empId, string skillId, EmployeeSkill employeeSkill);
        Task DeleteEmployeeSkillAsync(string empId, string skillId);
    }
}
