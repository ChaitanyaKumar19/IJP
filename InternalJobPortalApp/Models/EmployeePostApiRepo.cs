using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmployeePostLibrary;
using Newtonsoft.Json;

namespace InternalJobPortalApp.Models
{
    public class EmployeePostApiRepo
    {
        public HttpClient webApi;
        public EmployeePostApiRepo()
        {
            webApi = new HttpClient();
            webApi.BaseAddress = new Uri("http://localhost:2000/api/EmployeePost/");
        }
        public async Task DeleteEmployeePostAsync(string empId, int postId)
        {
            await webApi.DeleteAsync("" + empId + "/" + postId);
        }


        public async Task<List<EmployeePost>> GetAllEmployeePostsAsync()
        {
            HttpResponseMessage response = await webApi.GetAsync(""+ "GetAll");
            string str = await response.Content.ReadAsStringAsync();
            List<EmployeePost> empPosts = JsonConvert.DeserializeObject<List<EmployeePost>>(str);
            return empPosts;
        }

        public async Task<List<EmployeePost>> GetEmployeePostByEmpIdAsync(string empId)
        {
            try
            {
                HttpResponseMessage response = await webApi.GetAsync("" + "ByEmpId/" + empId);
                string str = await response.Content.ReadAsStringAsync();
                List<EmployeePost> empPosts = JsonConvert.DeserializeObject<List<EmployeePost>>(str);
                return empPosts;
            }
            catch (Exception)
            {
                throw new Exception("No such Employee Post");
            }
        }

        public async Task<List<EmployeePost>> GetEmployeePostByPostIdAsync(int postId)
        {
            try
            {
                HttpResponseMessage response = await webApi.GetAsync("" + "ByPost/" + postId);
                string str = await response.Content.ReadAsStringAsync();
                List<EmployeePost> empPosts = JsonConvert.DeserializeObject<List<EmployeePost>>(str);
                return empPosts;
            }
            catch (Exception)
            {
                throw new Exception("No such Employee Post");
            }
        }

        public async Task<EmployeePost> GetEmployeePostByIdAsync(string empId, int postId)
        {
            try
            {
                HttpResponseMessage response = await webApi.GetAsync("" + empId + "/" + postId);
                string str = await response.Content.ReadAsStringAsync();
                EmployeePost empPost = JsonConvert.DeserializeObject<EmployeePost>(str);
                return empPost;
            }
            catch (Exception)
            {
                throw new Exception("No such Employee Post");
            }
        }

        public async Task InsertEmployeePostAsync(EmployeePost empPost)
        {
            var json = JsonConvert.SerializeObject(empPost);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PostAsync("", data);

        }

        public async Task UpdateEmployeePostAsync(string empId, int postId, EmployeePost empPost)
        {
            var json = JsonConvert.SerializeObject(empPost);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PutAsync("" + empId + "/" +postId, data);
        }
    }


}
