using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmployeeSkillLibrary;
using InternalJobPortalApp.Models;

namespace InternalJobPortalApp.Controllers
{
    public class EmployeeSkillController : Controller
    {
        EmployeeSkillApiRepo empSkillRepo = new EmployeeSkillApiRepo();
        public async Task<ActionResult> Index()
        {
            string userName = User.Identity.Name;
            //string roleName = User.Claims.ToArray()[4].Value;
            //await empSkillRepo.GetToken(userName, roleName);
            List<EmployeeSkill> empSkills = await empSkillRepo.GetAllEmployeeSkills();
            return View(empSkills);
        }
        public async Task<ActionResult> Details(string empId,string skillId)
        {
            EmployeeSkill empSkill = await empSkillRepo.GetById(empId,skillId);
            return View(empSkill);
        }
        public async Task<ActionResult> GetByEmployeeId(string empId)
        {
            List<EmployeeSkill> empSkills = await empSkillRepo.GetByEmployeeId(empId);
            return View(empSkills);
        }
        public async Task<ActionResult> GetBySkillId(string skillId)
        {
            List<EmployeeSkill> empSkills = await empSkillRepo.GetBySkillId(skillId);
            return View(empSkills);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeSkill employeeSkill)
        {
            await empSkillRepo.Insert(employeeSkill);
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(string empId,string skillId)
        {
            EmployeeSkill empSkill = await empSkillRepo.GetById(empId, skillId);
            return View(empSkill);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string empId,string skillId, EmployeeSkill employeeSkill)
        {
            await empSkillRepo.Update(empId, skillId, employeeSkill);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Delete(string empId,string skillId)
        {
            EmployeeSkill empSkill = await empSkillRepo.GetById(empId, skillId);
            return View(empSkill);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string empId,string skillId, FormCollection collection)
        {
            await empSkillRepo.Delete(empId, skillId);
            return RedirectToAction(nameof(Index));
        }
    }
}
