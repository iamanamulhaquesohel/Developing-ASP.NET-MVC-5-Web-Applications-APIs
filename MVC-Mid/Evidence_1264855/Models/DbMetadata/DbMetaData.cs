using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evidence_1264855.Models.DbMetadata
{
    public enum Departments { IT = 1, Software, Accounts, HR }

    public partial class BranchesType
    {
        [Display(Name = "Branch Code")]
        public int BranchID { get; set; }
        [Required, StringLength(50), Display(Name = "Branches Name")]
        public string BranchName { get; set; }
        [Required, StringLength(100), Display(Name = "Branches Address")]
        public string BranchAddress { get; set; }
    }

    public partial class EmployeesType
    {
        public int EmployeeID { get; set; }
        [Required, Display(Name = "Photo")]
        public string EmployeePicture { get; set; }
        [Required, StringLength(50), Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Required, StringLength(20), Display(Name = "Phone")]
        public string EmployeePhone { get; set; }
        [Required, EnumDataType(typeof(Departments)), Display(Name = "Department")]
        public int EmployeeDepartment { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Join Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime EmployeeJoinDate { get; set; }
    }
}