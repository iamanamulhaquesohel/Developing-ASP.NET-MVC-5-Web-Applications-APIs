using Evidence_1264855.Models.DbMetadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evidence_1264855.Models.DbViewModel
{
    //Employee View Model
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        [Display(Name = "Photo")]
        public HttpPostedFileBase EmployeePicture { get; set; }
        [Required, StringLength(50), Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Required, StringLength(20), Display(Name = "Phone")]
        public string EmployeePhone { get; set; }
        [Required, EnumDataType(typeof(Departments)), Display(Name = "Department")]
        public Departments EmployeeDepartment { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Join Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime EmployeeJoinDate { get; set; }
        [Required, Display(Name = "Branch")]
        public int BranchID { get; set; }

        public virtual Branches Branches { get; set; }
    }
}