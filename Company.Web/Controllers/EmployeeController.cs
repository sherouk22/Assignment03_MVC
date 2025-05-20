using Company.Data.Models;
using Company.Service.Interfaces.Departments;
using Company.Service.Interfaces.Employees;
using Company.Service.Interfaces.Employees.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers 
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public IActionResult Index(string searchInp)
        {
            //ViewBag.Massege = "Hello From Employee Index (ViewBag)";
            //ViewData["TxetMassegge"]= "Hello From Employee Index (ViewData)";
            //TempData["TxetTempMassegge"] = "Hello From Employee Index (TempData)";
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            
            if (string.IsNullOrEmpty(searchInp)) 
                 employees = _employeeService.GetAll();
            else
                 employees = _employeeService.GetEmployeeByName(searchInp);
            
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();

        }


        [HttpPost]
        public IActionResult Create(EmployeeDto employee) 
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction("Index");
                    // or => return RedirectToAction(nameof(Index));
                }

               

                return View(employee);

            }
            catch (Exception ex)
            {


                return View(employee);
            }

        }
    }
}
