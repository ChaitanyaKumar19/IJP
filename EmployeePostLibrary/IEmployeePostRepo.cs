using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePostLibrary
{
    public interface IEmployeePostRepo
    {
        Task<List<EmployeePost>> GetAllEmployeePostsAsync();
        Task<List<EmployeePost>> GetEmployeePostsByEmpIdAsync(string empId);
        Task<List<EmployeePost>> GetEmployeePostsByPostIdAsync(int postId);
        Task<EmployeePost> GetEmployeePostByIdAsync(string empId, int postId);
        Task InsertEmployeePostAsync(EmployeePost employeePost);
        Task UpdateEmployeePostAsync(string empId, int postId, EmployeePost employeePost);
        Task DeleteEmployeePostAsync(string empId, int postId);
    }
}
