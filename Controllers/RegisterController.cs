using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ZenDerivco.Models;
using ZenDerivco.Models.Repository;
using ZenDerivco.Models.Repositroy;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenDericvo.Controllers
{
    [Route("api/auth")]   
    [EnableCors("AllowSpecificOrigin")]
    public class RegisterController : Controller
    {

        private readonly IDataRepository<Employee> _dataRepository;

        public RegisterController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        
        [HttpPost]
        public HttpResponseMessage Register([FromBody] Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                _dataRepository.Add(employee);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}
