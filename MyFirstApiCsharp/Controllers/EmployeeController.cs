using Microsoft.AspNetCore.Mvc;
using MyFirstApiCsharp.Model;
using MyFirstApiCsharp.ViewModel;

namespace MyFirstApiCsharp.Controllers
{
    // Controller Base é mais adequado para apis

    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        // com isso e o construtor o c# ja vai entender que essa interface implementa aquela classe que criamos de repository
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.Name, employeeView.Age, null);

            _employeeRepository.Add(employee);

            // isso aparece por causa do ControllerBase aq eu posso Retornar o Ok de 200
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employess = _employeeRepository.GetAll();
            return Ok(employess);
        }
    }
}
