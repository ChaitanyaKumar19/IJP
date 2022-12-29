using JobPostLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InternalJobPortalApp.Models
{
    public class JobPostApiRepoAsync
    {
        public HttpClient webApi;
        public JobPostApiRepoAsync()
        {
            webApi = new HttpClient();
            webApi.BaseAddress = new Uri("http://localhost:4000/api/JobPost/");
        }
        public async Task DeleteJobPostAsync(int postId)
        {
            await webApi.DeleteAsync("" + postId);
        }
        public async Task<List<JobPost>> GetAllJobPostsAsync()
        {
            HttpResponseMessage response = await webApi.GetAsync("" + "GetAllPosts");
            string str = await response.Content.ReadAsStringAsync();
            Console.WriteLine(str);
            List<JobPost> jobPosts = JsonConvert.DeserializeObject<List<JobPost>>(str);
            return jobPosts;
        }
        public async Task<JobPost> GetJobPostByIdAsync(int postId)
        {
            try
            {
                HttpResponseMessage response = await webApi.GetAsync("" + postId);
                string str = await response.Content.ReadAsStringAsync();
                JobPost jobPost = JsonConvert.DeserializeObject<JobPost>(str);
                return jobPost;
            }
            catch (Exception)
            {
                throw new Exception("No such Job Post");
            }
        }
        public async Task InsertJobPostAsync(JobPost jobPost)
        {
            var json = JsonConvert.SerializeObject(jobPost);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PostAsync("", data);
        }
        public async Task UpdateJobPostAsync(int postId, JobPost jobPost)
        {
            var json = JsonConvert.SerializeObject(jobPost);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PutAsync("" + postId, data);
        }
    }
}