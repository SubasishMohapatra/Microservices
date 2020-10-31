using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;

namespace StudentMicroservice.Controllers
{
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    //[Route("[controller]")]
    public class StudentsController : ControllerBase
    {

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public IEnumerable<Student> GetAllStudents()
        {
            return Enumerable.Range(1, 20).Select(index => new Student
            {
                Name = $"Student{index}",
                DoB = DateTime.Now.AddDays(-(365 * new Random().Next(1, 6)) + (new Random().Next(1, 13) * 30)).ToShortDateString(),
                Grade = new Random().Next(1, 6),
                Section = "ABC"[new Random().Next(0, 3)]
            });
        }

        [HttpGet]
        [Route("GetStudent/{id}")]
        public Student GetStudent(int Id)
        {
            var allStudents = Enumerable.Range(1, 30).Select(index => new Student
            {
                Name = $"Student{index}",
                DoB = DateTime.Now.AddDays(-(365 * new Random().Next(1, 6)) + (new Random().Next(1, 13) * 30)).ToShortDateString(),
                Grade = new Random().Next(1, 6),
                Section = "ABC"[new Random().Next(0, 3)]
            });
            return allStudents.FirstOrDefault(x => string.Compare($"Student{Id}", x.Name, true) == 0);
        }

        [HttpGet]
        [Route("GetStudentOfGrade/{grade}")]
        public IEnumerable<Student> GetStudentOfGrade(int grade)
        {
            var allStudents = Enumerable.Range(1, 30).Select(index => new Student
            {
                Name = $"Student{index}",
                DoB = DateTime.Now.AddDays(-(365 * new Random().Next(1, 6)) + (new Random().Next(1, 13) * 30)).ToShortDateString(),
                Grade = new Random().Next(1, 6),
                Section = "ABC"[new Random().Next(0, 3)]
            });
            return allStudents.Where(x => x.Grade==grade);
        }
    }
}
