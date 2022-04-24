using PersonalMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace PersonalMvc.Controllers
{
    public class PersonalController : Controller
    {
        PersonalContext db = new PersonalContext();
        public ActionResult Index(string searchstring, string department)
        {
            var personalList = new List<string>();
            var personalDep = from d in db.Personals orderby d.Department.Name select d.Department.Name;
            personalList.AddRange(personalDep.Distinct());
            var personals = from p in db.Personals.Include(p => p.Department).Include(p => p.Profession) select p;
            ViewBag.department = new SelectList(personalList);
            if (!string.IsNullOrEmpty(searchstring))
            {
                personals = personals.Where(p => p.Name.Contains(searchstring));
            }
            if (!string.IsNullOrEmpty(department))
            {
                personals = personals.Where(p => p.Department.Name == department);
            }
            return View(personals);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Personal personal = db.Personals.Include(p => p.Department).Include(p => p.Profession).FirstOrDefault(p=>p.Id==id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }
        [HttpGet]
        public ActionResult ChooseDepartment()
        {
            var departments = db.Departments.ToList();
            ViewBag.Departments = departments;
            return View();
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            SelectList professions = new SelectList(db.Professions, "Id", "Name");
            ViewBag.Professions = professions;
            SelectList departments = new SelectList(db.Departments, "Id", "Name");
            ViewBag.Departments = departments;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Personal personal)
        {
            db.Personals.Add(personal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            SelectList professions = new SelectList(db.Professions, "Id", "Name");
            ViewBag.Professions = professions;
            SelectList departments = new SelectList(db.Departments, "Id", "Name");
            ViewBag.Departments = departments;
            Personal personal = db.Personals.Include(p => p.Profession).Include(p => p.Department).FirstOrDefault(p => p.Id == id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }
        [HttpPost]
        public ActionResult Edit(Personal personal)
        {
            db.Entry(personal).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Personal personal = db.Personals.Include(p=>p.Profession).Include(p=>p.Department).FirstOrDefault(p=>p.Id==id);
            if(personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Personal personal = db.Personals.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            db.Personals.Remove(personal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}