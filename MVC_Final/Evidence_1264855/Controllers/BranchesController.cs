using Evidence_1264855.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace Evidence_1264855.Controllers
{
    public class BranchesController : Controller
    {
        readonly CompanyDbContext db = new CompanyDbContext();
        // GET: Branches
        public ActionResult Index(int page = 1)
        {
            var data = db.Branches.OrderBy(b => b.BranchId).ToPagedList(page, 4);
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Branch Branch)
        {
            if (ModelState.IsValid)
            {
                db.Branches.Add(Branch);
                db.SaveChanges();
                return PartialView("_MessegeCreatePartial", true);
            }
            return PartialView("_MessegeCreatePartial", false);
        }
        public ActionResult Edit(int Id)
        {
            return View(db.Branches.First(b => b.BranchId == Id));
        }
        [HttpPost]
        public ActionResult Edit(Branch Branches)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Branches).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return PartialView("_MessegeUpdatePartial", true);
            }
            return PartialView("_MessegeUpdatePartial", false);
        }
        public ActionResult Delete(int Id)
        {
            return View(db.Branches.First(b => b.BranchId == Id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DoDelete(int Id)
        {
            Branch Branches = new Branch { BranchId = Id };
            if (!db.Employees.Any(e=> e.BranchId == Id))
            {
                db.Entry(Branches).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return PartialView("_MessegeDeletePartial", true);
            }
            return PartialView("_MessegeDeletePartial", false);
        }
        
    }
}