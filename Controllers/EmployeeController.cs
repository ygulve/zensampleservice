using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ZenDerivco.Models;
using ZenDerivco.Models.Repositroy;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenDerivco.Controllers
{
   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]       
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Employee> _dataRepository;

        public EmployeeController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }        
        
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            IEnumerable<Employee> employees = _dataRepository.GetAll();
            return employees;
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long Id)
        {
            Employee employee = _dataRepository.Get(Id);

            if (employee == null)
            {
                return NotFound("The Employee data couldn't be found.");
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null");
            }

            _dataRepository.Add(employee);
            return CreatedAtRoute("Get", new { Id = employee.EmployeeId }, employee);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(long id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null");
            }

            Employee employeeToUpdate = _dataRepository.Get(id);
            if (employeeToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Update(employeeToUpdate, employee);

            return NoContent();

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long id)
        {
            Employee employee = _dataRepository.Get(id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Delete(employee);
            return NoContent();
        }
    }
}
