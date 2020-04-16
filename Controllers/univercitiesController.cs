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
    public class univercitiesController : ControllerBase
    {
        private readonly TodoContext _context;

        public univercitiesController(TodoContext context)
        {
            _context = context;
        }

        // GET /univercities -> return รายชื่อของ มหาวิทยาลัย ทั้งหมด
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetUniversitys()
        {
            return await _context.Universitys.ToListAsync();
        }

        // GET /univercities/:id -> return ข้อมูลของ มหาวิทยาลัย ที่ id ตรงกับใน database พร้อมทั้งรายชื่อของ นักศึกษา ที่ศึกษาอยู่ทั้งหมด
        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetUniversityById(long id)
        {
            var university = await _context.Universitys.FindAsync(id);
            if (university == null)
            {
                return Content("No university for this ID");
            }
            else
            {
                var result = (from s in _context.Students
                              join su1 in _context.StudentinUniversities on s.std_Id equals su1.std_id
                              join u in _context.Universitys on su1.uni_id equals u.uni_Id
                              where u.uni_Id == id
                              select new
                              {
                                  University = u.uni_name,
                                  Student_ID = s.std_Id,
                                  Firstname = s.std_fname,
                                  Lastname = s.std_lname
                              }
                              ).ToList();
                return Ok(result);
            }
        }

        // PUT /univercities/:id -> แก้ไขข้อมูล มหาวิทยาลัย ที่ id ตรงกับใน database
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversity(long id, University university)
        {
            if (id != university.uni_Id)
            {
                return Content("No university for this ID");
            }

            _context.Entry(university).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
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

        // POST /univercities -> เพิ่ม มหาวิทยาลัย
        [HttpPost]
        public async Task<ActionResult<University>> PostUniversity(University university)
        {
            _context.Universitys.Add(university);
            await _context.SaveChangesAsync();
            Content("Add new university Success !!");
            return CreatedAtAction(nameof(GetUniversityById), new { id = university.uni_Id }, university);
        }

        // DELETE /univercities/:id -> ลบ มหาวิทยาลัย ที่ id ตรงกับใน database
        [HttpDelete("{id}")]
        public async Task<ActionResult<University>> DeleteTodoItem(long id)
        {
            var university = await _context.Universitys.FindAsync(id);
            if (university == null)
            {
                return Content("No university for this code !!");
            }

            _context.Universitys.Remove(university);
            await _context.SaveChangesAsync();

            return Content("Delete Success !!");
        }

        private bool TodoItemExists(long id)
        {
            return _context.Universitys.Any(e => e.uni_Id == id);
        }
    }
}
