using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostLibrary
{
    public interface IJobPostRepo
    {
        Task<List<JobPost>> GetAllJobsAsync();
        Task<JobPost> GetJobsByPostId(int postId);
        void InsertIntoJobPost(JobPost post);
        void UpdateIntoJobPost(int postId, JobPost post);
        void DeleteFromJobPost(int postId);
    }
}
