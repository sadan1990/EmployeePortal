using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeeName = "";
        }
        public string EmployeeName { get; set; }

        public string EmployeeAddress { get; set; }
    }
}