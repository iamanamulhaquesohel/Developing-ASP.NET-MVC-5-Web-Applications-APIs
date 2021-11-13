using Evidence_1264855.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;

namespace Evidence_1264855.Controllers
{
    public class EmployeesController : Controller
    {
        //Context Instance
        readonly CompanyDbContext db = new CompanyDbContext();
        // GET: Employees
        public ActionResult Index(int page = 1)
        {
            var data = db.Employees.OrderBy(b => b.EmployeeId).ToPagedList(page, 4);
            return View(data);
        }
        //Create
        public ActionResult Create()
        {
            ViewBag.Branches = db.Branches.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeCreateModel emp)
        {
            if (ModelState.IsValid)
            {
                Employee Empnew = new Employee
                {
                    EmployeeName = emp.EmployeeName,
                    EmployeePhone= emp.EmployeePhone,
                    EmployeeSalary = emp.EmployeeSalary,
                    EmployeeDepartment = (int)emp.EmployeeDepartment,
                    EmployeeJoinDate = emp.EmployeeJoinDate,
                    EmployeeGender = (int)emp.EmployeeGender,
                    Continued = emp.Continued,
                    BranchId = emp.BranchId,
                    EmployeePicture = "no-pic.png" 
                };
                if (emp.EmployeePicture != null && emp.EmployeePicture.ContentLength > 0)
                {
                    string filePath = Server.MapPath("~/Uploads/");
                    string fileName = Guid.NewGuid() + Path.GetExtension(emp.EmployeePicture.FileName);
                    emp.EmployeePicture.SaveAs(Path.Combine(filePath, fileName));
                    Empnew.EmployeePicture = fileName;
                }
                db.Employees.Add(Empnew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Branches = db.Branches.ToList();
            return View(emp);
        }
        //Edit
        public ActionResult Edit(int Id)
        {
            ViewBag.Branches = db.Branches.ToList();
            var emp = db.Employees.First(x => x.EmployeeId == Id);
            ViewBag.CurrentPicture = emp.EmployeePicture;
            return View(new EmployeeEditModel
            { 
                EmployeeId = emp.EmployeeId,
                EmployeeName = emp.EmployeeName,
                EmployeePhone = emp.EmployeePhone,
                EmployeeSalary = emp.EmployeeSalary,
                EmployeeDepartment= (Departments)emp.EmployeeDepartment,
                EmployeeJoinDate = emp.EmployeeJoinDate,
                EmployeeGender = (Gender)emp.EmployeeGender,
                Continued = emp.Continued,
                BranchId = emp.BranchId
            });
        }
        [HttpPost]
        public ActionResult Edit(EmployeeEditModel emp )
        {
            if (ModelState.IsValid)
            {
                Employee empexist = db.Employees.First(e => e.EmployeeId == emp.EmployeeId);
                empexist.EmployeeName = emp.EmployeeName;
                empexist.EmployeePhone = emp.EmployeePhone;
                empexist.EmployeeSalary = emp.EmployeeSalary;
                empexist.EmployeeDepartment = (int)emp.EmployeeDepartment;
                empexist.EmployeeJoinDate = emp.EmployeeJoinDate;
                empexist.EmployeeGender = (int)emp.EmployeeGender;
                empexist.Continued = emp.Continued;
                empexist.BranchId = emp.BranchId;
                if (emp.EmployeePicture != null && emp.EmployeePicture.ContentLength > 0)
                {
                    string filePath = Server.MapPath("~/Uploads/");
                    string fileName = Guid.NewGuid() + Path.GetExtension(emp.EmployeePicture.FileName);
                    emp.EmployeePicture.SaveAs(Path.Combine(filePath, fileName));
                    empexist.EmployeePicture = fileName;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Branches = db.Branches.ToList();
            var d = db.Employees.First(e => e.EmployeeId == emp.EmployeeId);
            ViewBag.CurrentPic = d.EmployeePicture;
            return View(emp);
        }
        //Delete
        public ActionResult Delete(int Id)
        {
            return View(db.Employees.First(e => e.EmployeeId == Id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DoneDelete(int Id)
        {
            Employee em = new Employee { EmployeeId = Id };
            db.Entry(em).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Info
        public ActionResult Info(int Id)
        {
            return View(db.Employees.First(e => e.EmployeeId == Id));
        }
        [HttpPost, ActionName("Info")]
        public ActionResult DoInfo(int Id )
        {
            return RedirectToAction("Info");
        }

    }
}