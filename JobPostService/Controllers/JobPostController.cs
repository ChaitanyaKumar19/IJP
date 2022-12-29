using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using JobPostLibrary;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace JobPostService.Controllers
{
    /*[Authorize]*/
    public class JobPostController : ApiController
    {
        IJobPostRepoAsync jobPostRepo = new JobPostRepoAysnc();
        [HttpGet]
        [Route("api/JobPost/GetAllPosts")]
        public async Task<IHttpActionResult> GetAll()
        {
            List<JobPost> posts = await jobPostRepo.GetAllJobsAsync();
            return Ok<List<JobPost>>(posts);
        }
        [HttpGet]
        [Route("api/JobPost/{postId}")]
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
        private void PublishToMessageQueue(string integrationEvent, string eventData)
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(eventData);
            channel.BasicPublish(exchange: "jobPost", routingKey: integrationEvent, basicProperties: null, body: body);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insert(JobPost post)
        {
            await jobPostRepo.InsertIntoJobPostAsync(post);
            var integrationEventData = JsonConvert.SerializeObject(new { PostId = post.PostId });
            PublishToMessageQueue("jobPost.add", integrationEventData);
            return Created<JobPost>("/api/JobPost", post);
        }
        [HttpPut]
        [Route("api/JobPost/{postId}")]
        public async Task<IHttpActionResult> Update(int postId, JobPost post)
        {
            await jobPostRepo.UpdateIntoJobPostAync(postId, post);
            return Ok<JobPost>(post);
        }
        [HttpDelete]
        [Route("api/JobPost/{postId}")]
        public async Task<IHttpActionResult> Delete(int postId)
        {
            await jobPostRepo.DeleteFromJobPostAync(postId);
            return Ok();
        }


    }
}
