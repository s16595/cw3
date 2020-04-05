using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.DAL;
using WebApplication3.Model;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            } else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta");
        }


        [HttpGet("{Order}")]
        public IActionResult GetStudents(string order)
        {
            return Ok(_dbService.GetStudents());
        }


        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = "s" + new Random().Next(1, 2000);
            return Ok(student);
        }


        [HttpPut("{id}/{student}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            _dbService.updateStudent(id, student);
            return Ok("Student został zaktualizowany ID: " + id);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _dbService.removeId(id);
            return Ok("Student usunięty ID: " + id);
        }
    }
}