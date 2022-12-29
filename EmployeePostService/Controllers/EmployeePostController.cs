using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EmployeePostLibrary;

namespace EmployeePostService.Controllers
{
    /*[Authorize]*/
    public class EmployeePostController : ApiController
    {
        IEmployeePostRepo empPostRepo = new EmployeePostRepo();

        // GET: EmployeePost
        [System.Web.Http.Route("api/EmployeePost/")]
        public async Task<IHttpActionResult> GetAllEmployeePosts()
        {
            List<EmployeePost> employeePosts = await empPostRepo.GetAllEmployeePostsAsync();
            return Ok(employeePosts);
        }

        [System.Web.Http.Route("api/EmployeePost/{empId}/{postId}")]
        public async Task<IHttpActionResult> GetEmployeePostById(string empId,int postId)
        {
            EmployeePost empPost = await empPostRepo.GetEmployeePostByIdAsync(empId, postId);
            return Ok < EmployeePost >(empPost);
        }

        [System.Web.Http.Route("api/EmployeePost/ByEmpId/{empId}")]
        public async Task<IHttpActionResult> GetEmployeePostsByEmpId(string empId)
        {
            List<EmployeePost> employeePosts= await empPostRepo.GetEmployeePostsByEmpIdAsync(empId);
            return Ok<List<EmployeePost>>(employeePosts);
        }

        [System.Web.Http.Route("api/EmployeePost/ByPost/{postId}")]
        public async Task<IHttpActionResult> GetEmployeePostsByPostId(int postId)
        {
            List<EmployeePost> employeePosts = await empPostRepo.GetEmployeePostsByPostIdAsync(postId);
            return Ok<List<EmployeePost>>(employeePosts);
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> Insert(EmployeePost empPost)
        {
            await empPostRepo.InsertEmployeePostAsync(empPost);
            return Created("/api/EmployeePost", empPost);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/EmployeePost/{empId}/{postId}")]
        public async Task<IHttpActionResult> Update(string empId, int postId, EmployeePost employeePost)
        {
            await empPostRepo.UpdateEmployeePostAsync(empId,postId,employeePost);
            return Ok<EmployeePost>(employeePost);
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/EmployeePost/{empId}/{postId}")]
        public async Task<IHttpActionResult> Delete(string empId, int postId)
        {
            await empPostRepo.DeleteEmployeePostAsync(empId,postId);
            return Ok();
        }
    }
}