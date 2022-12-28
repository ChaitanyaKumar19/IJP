using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace JobPostLibrary
{
    public class JobPostRepoAysnc : IJobPostRepoAsync
    {
        JobPostDBEntities jpEntity = new JobPostDBEntities();
        public async Task DeleteFromJobPostAync(int postId)
        {
            JobPost post2del = await GetJobsByPostIdAsync(postId);
            jpEntity.JobPosts.Remove(post2del);
            await jpEntity.SaveChangesAsync();
        }

        public async Task<List<JobPost>> GetAllJobsAsync()
        {
            List<JobPost> posts = await jpEntity.JobPosts.ToListAsync();
            return posts;
        }

        public async Task<JobPost> GetJobsByPostIdAsync(int postId)
        {
            try
            {
                JobPost post = await (from jp in jpEntity.JobPosts where jp.PostId == postId select jp).FirstAsync();
                return post;
            }
            catch
            {
                throw new Exception("No Such Job Post!");
            }
            
        }

        public async Task InsertIntoJobPostAsync(JobPost post)
        {
            jpEntity.JobPosts.Add(post);
            await jpEntity.SaveChangesAsync();
        }

        public async Task UpdateIntoJobPostAync(int postId, JobPost post)
        {
            JobPost post2edit = await GetJobsByPostIdAsync(postId);
            post2edit.JobId = post.JobId;
            post2edit.LastDatetoApply = post.LastDatetoApply;
            post2edit.NoOfVacancies = post.NoOfVacancies;
            post2edit.DoP = post.DoP;
            await jpEntity.SaveChangesAsync();
        }
    }
}
