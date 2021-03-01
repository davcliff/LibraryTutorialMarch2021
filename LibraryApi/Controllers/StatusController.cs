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
    }

    public class StatusResponse
    {
        public string Message { get; set; }
        public DateTime LastChecked { get; set; }
    }
}
