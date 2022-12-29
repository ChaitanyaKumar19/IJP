using EmployeePostLibrary;
using InternalJobPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InternalJobPortalApp.Controllers
{
    public class EmployeePostController : Controller
    {
        EmployeePostApiRepo empPostClient = new EmployeePostApiRepo();
        // GET: EmployeePost
        public async Task<ActionResult> Index()
        {
            List<EmployeePost> empPosts = await empPostClient.GetAllEmployeePostsAsync();
            return View(empPosts);
        }

         
        public async Task<ActionResult> Details(string empId,int postId)
        {
            EmployeePost empPost = await empPostClient.GetEmployeePostByIdAsync(empId,postId);
            return View(empPost);
        }

        public async Task<ActionResult> DetailsbyEmpId(string empId)
        {
            List<EmployeePost> empPosts = await empPostClient.GetEmployeePostByEmpIdAsync(empId);
            return View(empPosts);
        }

        public async Task<ActionResult> DetailsbyPostId(int postId)
        {
            List<EmployeePost> empPosts = await empPostClient.GetEmployeePostByPostIdAsync(postId);
            return View(empPosts);
        }

        // GET: JobPost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobPost/Create
        [HttpPost]
        public async Task<ActionResult> Create(EmployeePost empPost)
        {
            try
            {
                // TODO: Add insert logic here
                await empPostClient.InsertEmployeePostAsync(empPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobPost/Delete/5
        public async Task<ActionResult> Delete(string empId,int postId)
        {
            EmployeePost empPost = await empPostClient.GetEmployeePostByIdAsync(empId,postId);
            return View(empPost);
        }

        // POST: JobPost/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string empId, int postId, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                await empPostClient.DeleteEmployeePostAsync(empId, postId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(string empId,int postId)
        {
            EmployeePost empPost = await empPostClient.GetEmployeePostByIdAsync(empId,postId);
            return View(empPost);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(string empId, int postId,EmployeePost empPost)
        {
            try
            {
                // TODO: Add update logic here
                await empPostClient.UpdateEmployeePostAsync(empId,postId, empPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}