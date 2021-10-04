using Evidence_1264855.Models;
using Evidence_1264855.Models.DbMetadata;
using Evidence_1264855.Models.DbViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evidence_1264855.Controllers
{
    public class EmployeesController : Controller
    {
        readonly CompanyDbContext db = new CompanyDbContext();
        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Branches = db.Branches.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeViewModel e)
        {
            if (ModelState.IsValid)
            {
                Employees em = new Employees { EmployeeName = e.EmployeeName, EmployeePhone = e.EmployeePhone, EmployeeDepartment = (int)e.EmployeeDepartment, BranchID = e.BranchID, EmployeeJoinDate = e.EmployeeJoinDate, EmployeePicture = "no-pic.png" };
                if (e.EmployeePicture != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(e.EmployeePicture.FileName);
                    e.EmployeePicture.SaveAs(Server.MapPath("~/Images/") + fileName);
                    em.EmployeePicture = fileName;
                }
                db.Employees.Add(em);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Branches = db.Branches.ToList();
            return View();
        }

        public ActionResult Edit(int ID)
        {
            ViewBag.Branches = db.Branches.ToList();
            var e = db.Employees.First(em => em.EmployeeID == ID);
            ViewBag.EmployeePicture = e.EmployeeDepartment;
            return View(new EmployeeViewModel { EmployeeID = e.EmployeeID, EmployeeName = e.EmployeeName, EmployeePhone = e.EmployeePhone, EmployeeDepartment = (Departments)e.EmployeeDepartment, EmployeeJoinDate = e.EmployeeJoinDate, BranchID = e.BranchID });
        }
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel e)
        {
            var em = db.Employees.First(ei => ei.EmployeeID == e.EmployeeID);
            if (ModelState.IsValid)
            {
                em.EmployeeName = e.EmployeeName;
                em.EmployeePhone = e.EmployeePhone;
                em.EmployeeDepartment = (int)e.EmployeeDepartment;
                em.EmployeeJoinDate = e.EmployeeJoinDate;
                em.BranchID = e.BranchID;
                if (e.EmployeePicture != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(e.EmployeePicture.FileName);
                    e.EmployeePicture.SaveAs(Server.MapPath("~/Images/") + fileName);
                    em.EmployeePicture = fileName;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeePicture = e.EmployeeDepartment;
            ViewBag.Branches = db.Branches.ToList();
            return View(e);
        }
        public ActionResult Delete(int ID)
        {
            return View(db.Employees.First(e => e.EmployeeID == ID));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DoneDelete(int ID)
        {
            Employees em = new Employees { EmployeeID = ID };
            db.Entry(em).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}