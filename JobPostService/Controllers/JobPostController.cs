using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using JobPostLibrary;

namespace JobPostService.Controllers
{
    public class JobPostController : ApiController
    {
        IJobPostRepoAsync jobPostRepo = new JobPostRepoAysnc();
        [HttpGet]
        [Route("api/JobPosts/GetAllPosts")]
        public async Task<IHttpActionResult> GetAll()
        {
            List<JobPost> posts = await jobPostRepo.GetAllJobsAsync();
            return Ok<List<JobPost>>(posts);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetOne(int postId)
        {
            try
            {
                JobPost post = await jobPostRepo.GetJobsByPostIdAsync(postId);
                return Ok<JobPost>(post);
            }
            catch
            {
                return BadRequest("No such Post Id !");
            }
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insert(JobPost post)
        {
            await jobPostRepo.InsertIntoJobPostAsync(post);
            return Created<JobPost>("/api/JobPost", post);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Update(int postId, JobPost post)
        {
            await jobPostRepo.UpdateIntoJobPostAync(postId, post);
            return Ok<JobPost>(post);
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int postId)
        {
            await jobPostRepo.DeleteFromJobPostAync(postId);
            return Ok();
        }


    }
}
