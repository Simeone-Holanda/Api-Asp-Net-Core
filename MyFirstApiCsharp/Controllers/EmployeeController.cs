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
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

            // Salvando um arquivo local na pasta storage
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);

            _employeeRepository.Add(employee);

            // isso aparece por causa do ControllerBase aq eu posso Retornar o Ok de 200
            return Ok();
        }

        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);
            // if (employee != null) {
            var dataBytes = System.IO.File.ReadAllBytes(employee?.photo);
            return File(dataBytes, "image/png");
            //}
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employess = _employeeRepository.GetAll();
            return Ok(employess);
        }
    }
}
