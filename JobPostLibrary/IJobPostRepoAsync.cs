using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostLibrary
{
    public interface IJobPostRepoAsync
    {
        Task<List<JobPost>> GetAllJobsAsync();
        Task<JobPost> GetJobsByPostIdAsync(int postId);
        Task InsertIntoJobPostAsync(JobPost post);
        Task UpdateIntoJobPostAync(int postId, JobPost post);
        Task DeleteFromJobPostAync(int postId);
    }
}
