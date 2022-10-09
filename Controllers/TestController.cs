﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementSystem.Controllers
{
    public class TestController : Controller
    {
        [HttpGet("api/user")]
        public IActionResult Index()
        {
            return Ok(new { Name = "Sohail", });
        }
    }
}
