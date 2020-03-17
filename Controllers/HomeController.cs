using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDataRecordDisplay.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = @"Data Source = LAPTOP-3KFTRPBK; Initial Catalog = HumanResourceDB; Integrated Security = True";
        public ActionResult Index()
        {
            DataTable dataTableBook = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select EmployeeName, Department, ManagerName from Employee Join Manager On Employee.ManagerID = Manager.ID", connection);
                dataAdapter.Fill(dataTableBook);
            }
            return View(dataTableBook);
        }

    }
}