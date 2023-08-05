using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortal.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        public ActionResult GetEmployee()
        {
           Employee obj = new Employee();

            return View(obj);
        }

        public ActionResult GetAllEmployees()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveEmployee(Employee employee)
        {
            int rowsAffected = 0;
            //string storedProcedureName = "SaveEmployee";
            //string connectionName = "MVCConnection";
            //string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MVC;Integrated Security=true;";

            //SqlConnection is used to connect to sql 
            SqlConnection connection = new SqlConnection(connectionString);

            //SqlCommand is used to connect to a specific SP for a connection
            SqlCommand command = new SqlCommand("SaveEmployee", connection);
            command.CommandType = CommandType.StoredProcedure;

            //SqlParameter is hold parameters that can be passed to any SP
            SqlParameter para = new SqlParameter();
            para.ParameterName = "@Name";
            para.Value = employee.EmployeeName;

            SqlParameter para1 = new SqlParameter();
            para1.ParameterName = "@Address";
            para1.Value = employee.EmployeeAddress;

            //This ensures that these parameter needs to be passed for a Specefic command/SP
            command.Parameters.Add(para);

            command.Parameters.Add(para1);

            //Open Connection
            connection.Open();

            //Excecute the command/SP
            rowsAffected = command.ExecuteNonQuery();

            //Close Connnection
            connection.Close();


            if (rowsAffected > 0)
            {
                Employee emp = new Employee();
                return View("~/Views/Employee/GetEmployee.cshtml", emp);
            }
            return View("~/Views/Error.cshtml");
        }

        public string GetName()
        {
            int a = 10;
            return "sadan";
            a = 10;
        }
    }
}