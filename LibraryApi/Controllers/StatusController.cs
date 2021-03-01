using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class StatusController : ControllerBase
    {
        [HttpGet("status")]
        public StatusResponse GetTheStatus()
        {
            return new StatusResponse
            {
                Message = "Great Job!",
                LastChecked = DateTime.Now
            };
        }

        [HttpGet("customers/{customerId:int}")]
        public ActionResult GetInfoAboutCustomer(int customerId)
        {
            return Ok($"Getting info about customer {customerId}");
        }

        [HttpGet("blogs/{year:int}/{month:int}/{day:int}")]
        public ActionResult GetBlogPosts(int year, int month, int day)
        {
            if(day < 1 || day > 31)
            {
                return NotFound();
            }
            return Ok($"Getting blogs for {month}-{day}-{year}");
        }

        [HttpGet("employees")]
        public ActionResult GetEmployees([FromQuery] string department="All")
        {
            var response = new GetEmployeesResponse
            {
                Data = new List<string> { "Joe", "Sue", "Mary" },
                Department = department
            };
            return Ok(response);
        }

        [HttpPost("employees")]
        public ActionResult Hire([FromBody] PostEmployeeResuest request)
        {
            return Ok($"Hiring {request.Name} in {request.Department} at a starting salary of {request.StartingSalary}");
        }
    }

    public class PostEmployeeResuest
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal StartingSalary { get; set; }
    }

    public class GetEmployeesResponse
    {
        public List<string> Data { get; set; }
        public string Department { get; set; }
    }

    public class StatusResponse
    {
        public string Message { get; set; }
        public DateTime LastChecked { get; set; }
    }
}
