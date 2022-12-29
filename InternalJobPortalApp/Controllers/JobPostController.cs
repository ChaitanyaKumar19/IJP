using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InternalJobPortalApp.Models;
using JobPostLibrary;


namespace InternalJobPortalApp.Controllers
{
    public class JobPostController : Controller
    {
        // GET: JobPost
        JobPostApiRepoAsync jobPostRepo = new JobPostApiRepoAsync();
        public async Task<ActionResult> Index()
        {
            //string userName = User.Identity.Name;
            //string roleName = User.Claims.ToArray()[4].Value;
            //await jobPostRepo.GetToken(userName, roleName);
            List<JobPost> posts = await jobPostRepo.GetAllJobPostsAsync();
            return View(posts);
        }

        // GET: JobPost/Details/5
        public async Task<ActionResult> Details(int postId)
        {
            JobPost post = await jobPostRepo.GetJobPostByIdAsync(postId);
            return View(post);
        }

        // GET: JobPost/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobPost/Create
        [HttpPost]
        public async Task<ActionResult> Create(JobPost post)
        {
            try
            {
                // TODO: Add insert logic here
                await jobPostRepo.InsertJobPostAsync(post);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobPost/Edit/5
        public async Task<ActionResult> Edit(int postId)
        {
            JobPost post = await jobPostRepo.GetJobPostByIdAsync(postId);
            return View(post);
        }

        // POST: JobPost/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int postId, JobPost post)
        {
            try
            {
                // TODO: Add update logic here
                await jobPostRepo.UpdateJobPostAsync(postId, post);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobPost/Delete/5
        public async  Task<ActionResult> Delete(int postId)
        {
            JobPost post = await jobPostRepo.GetJobPostByIdAsync(postId);
            return View(post);
        }

        // POST: JobPost/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int postId, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                await jobPostRepo.DeleteJobPostAsync(postId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
