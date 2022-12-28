using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePostLibrary
{
    public class EmployeePostRepo : IEmployeePostRepo
    {
        EmployeePostDBEntities ent = new EmployeePostDBEntities();
        public async Task DeleteEmployeePostAsync(string empId, int postId)
        {
            EmployeePost post2del = await GetEmployeePostByIdAsync(empId,postId);
            ent.EmployeePosts.Remove(post2del);
            await ent.SaveChangesAsync();
        }

        public async Task<List<EmployeePost>> GetAllEmployeePostsAsync()
        {
            List<EmployeePost> employeePosts = await ent.EmployeePosts.ToListAsync();
            return (employeePosts);
        }

        public async Task<List<EmployeePost>> GetEmployeePostsByEmpIdAsync(string empId)
        {
            try
            {
                List<EmployeePost> employeePosts = await(from es in ent.EmployeePosts where es.EmpId == empId select es).ToListAsync();
                return employeePosts;
            }
            catch
            {
                throw new Exception("No such Employee id.");
            }
        }

        public async Task<List<EmployeePost>> GetEmployeePostsByPostIdAsync(int postId)
        {
            try
            {
                List<EmployeePost> employeePosts = await(from es in ent.EmployeePosts where es.PostId == postId select es).ToListAsync();
                return employeePosts;
            }
            catch (Exception)
            {
                throw new Exception("No such post id.");
            }
        }

        public async Task<EmployeePost> GetEmployeePostByIdAsync(string empId, int postId)
        {
            try
            {
                EmployeePost empPost = await (from ep in ent.EmployeePosts where ep.EmpId == empId && ep.PostId == postId select ep).FirstAsync();
                return empPost;
            }
            catch (Exception)
            {
                throw new Exception("No record exist.");
            }
        }

        public async Task InsertEmployeePostAsync(EmployeePost employeePost)
        {
            ent.EmployeePosts.Add(employeePost);
            await ent.SaveChangesAsync();
        }

        public async Task UpdateEmployeePostAsync(string empId, int postId, EmployeePost employeePost)
        {
            EmployeePost post2del = await GetEmployeePostByIdAsync(empId,postId);
            post2del.AppliedDate = employeePost.AppliedDate;
            post2del.ApplicationStatus = employeePost.ApplicationStatus;
            await ent.SaveChangesAsync();
        }
    }
}
