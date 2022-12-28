using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSkillLibrary
{
    class EmployeeSkillRepoAsync : IEmployeeSkillRepoAsync
    {
        EmployeeSkillDBEntities esEnt = new EmployeeSkillDBEntities();
        public async Task DeleteEmployeeSkillAsync(string empId, string skillId)
        {
            EmployeeSkill es2del = await GetEmployeeSkillByIdAsync(empId, skillId);
            esEnt.EmployeeSkills.Remove(es2del);
            await esEnt.SaveChangesAsync();
        }
        public async Task<List<EmployeeSkill>> GetAllEmployeeSkillsAsync()
        {
            List<EmployeeSkill> empSkills = await esEnt.EmployeeSkills.ToListAsync();
            return empSkills;
        }
        public async Task<EmployeeSkill> GetEmployeeSkillByIdAsync(string empId, string skillId)
        {
            try
            {
                EmployeeSkill empSkill = await(from es in esEnt.EmployeeSkills where 
                                               es.EmpId == empId && es.SkillId == skillId 
                                               select es).FirstAsync();
                return empSkill;
            }
            catch
            {
                throw new Exception("No Such Employee Skill!");
            }
        }
        public async Task<List<EmployeeSkill>> GetEmployeeSkillsByEmpIdAsync(string empId)
        {
            try
            {
                List<EmployeeSkill> empSkills = await(from es in esEnt.EmployeeSkills where 
                                                      es.EmpId == empId select es).ToListAsync();
                return empSkills;
            }
            catch(Exception)
            {
                throw new Exception("No such employee id.");
            }
        }
        public async Task<List<EmployeeSkill>> GetEmployeeSkillsBySkillIdAsync(string skillId)
        {
            try
            {
                List<EmployeeSkill> empSkills = await (from es in esEnt.EmployeeSkills where 
                                                       es.SkillId == skillId select es).ToListAsync();
                return empSkills;
            }
            catch(Exception)
            {
                throw new Exception("No such skill id.");
            }
        }
        public async Task InsertEmployeeSkillAsync(EmployeeSkill employeeSkill)
        {
            esEnt.EmployeeSkills.Add(employeeSkill);
            await esEnt.SaveChangesAsync();
        }
        public async Task UpdateEmployeeSkillAsync(string empId, string skillId, EmployeeSkill employeeSkill)
        {
            EmployeeSkill es2upd = await GetEmployeeSkillByIdAsync(empId, skillId);
            es2upd.SkillExp = employeeSkill.SkillExp;
            await esEnt.SaveChangesAsync();
        }
    }
}
