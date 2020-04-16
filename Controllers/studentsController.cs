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
    public class studentsController : ControllerBase
    {
        private readonly TodoContext _context;

        public studentsController(TodoContext context)
        {
            _context = context;
        }

        // GET /students -> return รายชื่อของ นักศึกษา ทั้งหมด
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET /students/:id -> return ข้อมูลของ นักศึกษา ที่ id ตรงกับใน database พร้อมทั้งรายชื่อของ มหาวิทยาลัย ที่นักศึกษาศึกษาอยู่ทั้งหมด
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(long id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return Content("No student for this ID");
            }
            else
            {
                var result = (from s in _context.Students
                              join su1 in _context.StudentinUniversities on s.std_Id equals su1.std_id
                              join u in _context.Universitys on su1.uni_id equals u.uni_Id
                              where s.std_Id == id
                              select new
                              {
                                  Student_ID = s.std_Id,
                                  Firstname = s.std_fname,
                                  Lastname = s.std_lname,
                                  University = u.uni_name
                              }).ToList();
                return Ok(result);
            }
        }


        // PUT /students/:id -> แก้ไขข้อมูล นักศึกษา ที่ id ตรงกับใน database
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(long id, Student student)
        {
            if (id != student.std_Id)
            {
                return Content("No student for this ID");
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoIStdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Content("Edit Success !!"); ;
        }

        // POST /students -> เพิ่ม นักศึกษา
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            Content("Add new student Success !!");
            return CreatedAtAction(nameof(GetStudentById), new { id = student.std_Id }, student);
        }

        // DELETE /students/:id -> ลบ นักศึกษา ที่ id ตรงกับใน database
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteTodoItem(long id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return Content("No student for this code !!");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Content("Delete Success !!");
        }

        private bool TodoIStdExists(long id)
        {
            return _context.Students.Any(e => e.std_Id == id);
        }
    }
}
