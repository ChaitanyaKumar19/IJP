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
        public async void DeleteFromJobPostAync(int postId)
        {
            JobPost post2del = await(from jp in jpEntity.JobPosts where jp.PostId == postId select jp).FirstAsync();
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
            JobPost post = await (from jp in jpEntity.JobPosts where jp.PostId == postId select jp).FirstAsync();
            return post;
        }

        public async void InsertIntoJobPostAsync(JobPost post)
        {
            jpEntity.JobPosts.Add(post);
            await jpEntity.SaveChangesAsync();
        }

        public async void UpdateIntoJobPostAync(int postId, JobPost post)
        {
            JobPost post2edit = await(from jp in jpEntity.JobPosts where jp.PostId == postId select jp).FirstAsync();
            post2edit.JobId = post.JobId;
            post2edit.LastDatetoApply = post.LastDatetoApply;
            post2edit.NoOfVacancies = post.NoOfVacancies;
            post2edit.DoP = post.DoP;
        }
    }
}
