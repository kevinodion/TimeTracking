using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TimeTracking.Core.Abstraction;
using TimeTracking.Model;
using TimeTracking.WebAPI.Helpers;

namespace TimeTracking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTimeLogController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeTimeLogController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var results = await this._employeeRepository.GetTimeLogAsync();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var results = await this._employeeRepository.GetTimeLogByIdAsync(id);

            return Ok(results);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] EmployeeTimeLogModel model)
        {
            var results = await this._employeeRepository.UpdateTimeLogAsync(model);

            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var results = await this._employeeRepository.DeleteTimeLogAsync(id);

            return Ok(results);
        }
    }
}
