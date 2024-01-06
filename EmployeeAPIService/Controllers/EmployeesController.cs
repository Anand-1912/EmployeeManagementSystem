using AutoMapper;
using EmployeeAPIService.Model.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;
        //private IMapper _mapper;

        public EmployeesController(
            IEmployeeService employeeService
            //,IMapper mapper
            )
        {
            _employeeService = employeeService;
            //_mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeService.GetById(id);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            _employeeService.Create(model);
            return Ok(new { message = "Employee created" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return Ok(new { message = "Employee deleted" });
        }

        [HttpPut]
        public IActionResult Update(UpdateRequest model)
        {
            _employeeService.Update(model);
            return Ok(new { message = "Employee data has been updated!" });
        }
    }
}
