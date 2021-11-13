using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Evidence_1264855.Models
{
    //Employee Create Model
    public class EmployeeCreateModel
    {
        public int EmployeeId { get; set; }
        [Required, Display(Name = "New Photo")]
        //HttpPostedFileBase For Photo
        public HttpPostedFileBase EmployeePicture { get; set; }
        [Required, StringLength(50), Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Required, StringLength(20), Display(Name = "Phone")]
        public string EmployeePhone { get; set; }
        [Required, Column(TypeName = "money"), Display(Name = "Salary(TK)")]
        public Decimal EmployeeSalary { get; set; }
        [Required, EnumDataType(typeof(Departments)), Display(Name = "Department")]
        public Departments EmployeeDepartment { get; set; }
        [Required, Column(TypeName = "date"), Display(Name = "Join Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime EmployeeJoinDate { get; set; }
        [Required, EnumDataType(typeof(Gender)), Display(Name = "Gender")]
        public Gender EmployeeGender { get; set; }
        [Required, Display(Name = "Check it if Job Running.")]
        public bool Continued { get; set; }
        [Required, ForeignKey("Branches"), Display(Name = "Branch Name")]
        public int BranchId { get; set; }
    }
    //Employee Edit Model
    public class EmployeeEditModel
    {
        public int EmployeeId { get; set; }
        [Display(Name = "Select New Photo")]
        public HttpPostedFileBase EmployeePicture { get; set; }
        [Required, StringLength(50), Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Required, StringLength(20), Display(Name = "Phone")]
        public string EmployeePhone { get; set; }
        [Required, Column(TypeName = "money"), Display(Name = "Salary(TK)")]
        public Decimal EmployeeSalary { get; set; }
        [Required, EnumDataType(typeof(Departments)), Display(Name = "Department")]
        public Departments EmployeeDepartment { get; set; }
        [Required, Column(TypeName = "date"), Display(Name = "Join Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime EmployeeJoinDate { get; set; }
        [Required, EnumDataType(typeof(Gender)), Display(Name = "Gender")]
        public Gender EmployeeGender { get; set; }
        [Required, Display(Name = "Check it if Job Running.")]
        public bool Continued { get; set; }
        [Required, ForeignKey("Branches"), Display(Name = "Branch Name")]
        public int BranchId { get; set; }
    }
}