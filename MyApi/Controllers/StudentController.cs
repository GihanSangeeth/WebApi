using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Controllers
{
    [RoutePrefix("students")]
    public class StudentController : ApiController
    {

        List<Student> st = new List<Student>();

        public StudentController()
        {
            st.Add(new Student { student_id = 1001, student_name = "Gihan", student_address = "No:124, xxxxx, xxxx", student_moblie = 0716626044, age = 25, department = "SOC", course = "Software Engineering" });
            st.Add(new Student { student_id = 1002, student_name = "Pathum", student_address = "No:14, xxxxx, xxxx", student_moblie = 0716555044, age = 22, department = "SOC", course = "Software Engineering" });
            st.Add(new Student { student_id = 1003, student_name = "Jimith", student_address = "No:04, xxxxx, xxxx", student_moblie = 0775626044, age = 21, department = "SOC", course = "Computer Science" });
            st.Add(new Student { student_id = 1011, student_name = "Thrushi", student_address = "No:24, xxxxx, xxxx", student_moblie = 0716343044, age = 22, department = "SOB", course = "Management" });
            st.Add(new Student { student_id = 1012, student_name = "Hasini", student_address = "No:34, xxxxx, xxxx", student_moblie = 0716622224, age = 25, department = "SOB", course = "Accounting" });
        }

        //GET: students
        [Route]
        [HttpGet]
        public List<Student> Get()
        {
            return st;
        }

        //GET: students/get_names
        [Route("get_names")]
        [HttpGet]
        public List<string> GetNames()
        {
            List<string> output = new List<string>();
            foreach (var p in st)
            {
                output.Add(p.student_name);
            }
            return output;
        }

        //GET: students/{student_id}
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var student = st.FirstOrDefault((s) => s.student_id == id);
            if (student == null)
            {
                return BadRequest("Not a valid student id");
            }
            return Ok(student);
        }

        // POST: students
        [Route]
        [HttpPost]
        public IHttpActionResult Post(Student value)
        {
            if (value == null)
            {
                return BadRequest("invalid data");
            }

            st.Add(value);
            return Ok("done");
        }

        // PUT: students/5
        [Route("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]Student value)
        {

            var existingStudent = st.FirstOrDefault(s => s.student_id == id);
            if (existingStudent == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Not found");
            }
            else if(value == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Invalid data");
            }
            else
            {
                existingStudent.student_name = value.student_name;
                existingStudent.student_address = value.student_address;
                existingStudent.age = value.age;
                existingStudent.department = value.department;
                existingStudent.course = value.course;

                return Request.CreateResponse(HttpStatusCode.OK, "done");

            }


        }

        // DELETE: students/5
        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var student = st.FirstOrDefault(s => s.student_id == id);
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Student with Id = " + id.ToString() + " not found to delete");
            }
            else
            {
                st.Remove(student);
                return Request.CreateResponse(HttpStatusCode.OK,"Deleted");
            }
        }
    }
}
