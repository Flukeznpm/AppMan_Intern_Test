using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class registerController : ControllerBase
    {
        private readonly TodoContext _context;

        public registerController(TodoContext context)
        {
            _context = context;
        }



        // GET /register -> f^ การศึกษาของนักศึกษา
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentinUniversity>> GetStudentinuniversityById(long id)
        {
            var StudentinUniversities = await _context.StudentinUniversities.FindAsync(id);

            if (StudentinUniversities == null)
            {
                return NotFound();
            }

            return StudentinUniversities;
        }



        // POST /register -> เพิ่ม การศึกษาของนักศึกษา
        [HttpPost]
        public async Task<ActionResult<StudentinUniversity>> PostRegisterStudent(StudentinUniversity studentinUniversity)
        {
            _context.StudentinUniversities.Add(studentinUniversity);
            await _context.SaveChangesAsync();
            Content("Add new student Success !!");
            return CreatedAtAction(nameof(GetStudentinuniversityById), new { id = studentinUniversity.std_id }, studentinUniversity);
        }
    }
}
