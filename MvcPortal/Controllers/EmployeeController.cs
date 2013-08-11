using System;
using System.Linq;
using System.Web.Mvc;
using CodeFirstEntities;
using CodeFirstServices.Interfaces;

namespace CodeFirstPortal.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._EmployeeService = employeeService;
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var studentDetails = _EmployeeService.GetEmployeeById((int)id);
            if (studentDetails == null) throw new ArgumentNullException("Not Found");
            return View(studentDetails);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var studentDetails = _EmployeeService.GetEmployeeById((int)id);
            if (studentDetails == null) throw new ArgumentNullException("Not Found");
            return View(studentDetails);
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            _EmployeeService.DeleteEmployee(employee.EmployeeId);
            return RedirectToAction("List", "Employee");
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var studentDetails = _EmployeeService.GetEmployeeById((int)id);
            if (studentDetails == null) throw new ArgumentNullException("Not Found");
            return View(studentDetails);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            _EmployeeService.UpdateEmployee(employee);
            return RedirectToAction("List", "Employee");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var employeeModel = new Employee()
                                   {                                       
                                       Name = employee.Name,                                       
                                       Code = employee.Code,
                                       StartDate = employee.StartDate
                                   };
            _EmployeeService.CreateEmployee(employee);
            return RedirectToAction("List", "Employee");
        }

        [HttpGet]
        public ActionResult List()
        {
            if (TempData["EmployeeDetails"] != null)
                return View("List", TempData["EmployeeDetails"]);

            var employees = _EmployeeService.GetEmployees();
            if (employees.Any())
            {
                return View("List", employees);
            }

            return View("List");
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(FormCollection collection)
        {
            
            string TipoPort = collection["hiddenSearch"].ToString();
            if (collection["hiddenSearch"] == "Name")
            {
                var employeeDetails = _EmployeeService.GetEmployeeByName(collection["Name"]);
                if (employeeDetails.Count() == 0) return RedirectToAction("Search");

                TempData["EmployeeDetails"] = employeeDetails;
               
                return RedirectToAction("List");
            }
            if (collection["hiddenSearch"] == "Code")
            {
                var employeeDetails = _EmployeeService.GetEmployeeByCode(Convert.ToInt32(collection["Code"]));
                if (employeeDetails.Count() == 0) return RedirectToAction("Search");

                TempData["EmployeeDetails"] = employeeDetails;

                return RedirectToAction("List");
            }
            if (collection["hiddenSearch"] == "Date")
            {

                DateTime DateSearch = Convert.ToDateTime(collection["Date"]);
                var employeeDetails = _EmployeeService.GetEmployeeByDateMajor(DateSearch);
                if (employeeDetails.Count() == 0) return RedirectToAction("Search");

                TempData["EmployeeDetails"] = employeeDetails;

                return RedirectToAction("List");
            }
            return View();
            
        }

        

    }
}
