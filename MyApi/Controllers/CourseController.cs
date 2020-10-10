using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Controllers
{
    [RoutePrefix("courses")]
    public class CourseController : ApiController
    {
        List<Course> course = new List<Course>();


        public CourseController()
        {

            course.Add(new Course { course_name="Software Engineering" });
            course.Add(new Course { course_name = "Computer Science" });
            course.Add(new Course { course_name = "MIS" });
            course.Add(new Course { course_name = "Management" });



        }

        //GET: courses
        [Route]
        [HttpGet]
        public List<Course> Get()
        {
            return course;
        }



        
    }
}
