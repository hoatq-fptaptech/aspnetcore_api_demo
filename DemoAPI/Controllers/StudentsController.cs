using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoAPI.Entities;
using System.Web.Http.Cors;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    [EnableCors(origins:"*",methods:"*",headers:"*")]
    public class StudentsController : ControllerBase
    {
        private readonly Entities.Context _context;
        public StudentsController(Entities.Context context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            var list = _context.Students.ToList<Entities.Student>();
            return Ok(list);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            var student = _context.Students.Find(id);
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Created($"/get-by-id?id={student.Id}",student);
        }

        [HttpPut]
        public IActionResult Put(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return NoContent();
        }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var studentToDelete =  _context.Students.Find(id);
        if (studentToDelete == null)
        {
            return NotFound();
        }
            _context.Students.Remove(studentToDelete);
         _context.SaveChanges();
        return NoContent();
    }
    }
}

