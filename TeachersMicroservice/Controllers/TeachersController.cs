using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TeacherMicroservice.Controllers
{
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {      

        private readonly ILogger<TeachersController> _logger;

        public TeachersController(ILogger<TeachersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return Enumerable.Range(1, 10).Select(index => new Teacher
            {
                Name = $"Teacher{index}",
                Subject = new string[] { "Maths", "English", "Science" }[new Random().Next(0, 3)],
                Grades = Enumerable.Range(1, new Random().Next(1, 6)).Select(x => new Random().Next(1, x)).Distinct()
            });
        }
    }
}
