using Evidence_1264855.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evidence_1264855.Controllers
{
    public class BranchesController : Controller
    {
        //Context set or Instance Create
        readonly CompanyDbContext db = new CompanyDbContext();
        // GET: Branches
        public ActionResult Index()
        {
            return View(db.Branches.ToList());
        }
        //Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Branches b)
        {
            if (ModelState.IsValid)
            {
                db.Branches.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //Edit
        public ActionResult Edit(int ID)
        {
            return View(db.Branches.First(b => b.BranchID == ID));
        }
        [HttpPost]
        public ActionResult Edit(Branches b)
        {
            if (ModelState.IsValid)
            {
                db.Entry(b).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //Delete
        public ActionResult Delete(int ID)
        {
            return View(db.Branches.First(b => b.BranchID == ID));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DoDelete(int ID)
        {
            Branches b = new Branches { BranchID = ID };
            db.Entry(b).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}