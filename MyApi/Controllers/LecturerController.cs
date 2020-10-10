using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyApi.Controllers
{
    [RoutePrefix("lecturers")]
    public class LecturerController : ApiController

    {
        

        List<Lecturer> lec = new List<Lecturer>();

        public LecturerController()
        {
            lec.Add(new Lecturer { lecturer_id=101, lecturer_name="Dr.Rasika", lecturer_address= "No01, xxxxx, xxxx", lecturer_mobile=0775653555, department="SOC" });
            lec.Add(new Lecturer { lecturer_id = 102, lecturer_name = "Mrs.Pabitha", lecturer_address = "No56, xxxxx, xxxx", lecturer_mobile = 0771233555, department = "SOC" });
            lec.Add(new Lecturer { lecturer_id = 113, lecturer_name = "Dr.Prabath", lecturer_address = "No58, xxxxx, xxxx", lecturer_mobile = 0715655555, department = "SOE" });
            lec.Add(new Lecturer { lecturer_id = 114, lecturer_name = "Mr.Jagath", lecturer_address = "No71, xxxxx, xxxx", lecturer_mobile = 0775893555, department = "SOC" });
            lec.Add(new Lecturer { lecturer_id = 211, lecturer_name = "Mrs.Nimeshi", lecturer_address = "No25, xxxxx, xxxx", lecturer_mobile = 0775645555, department = "SOB" });
        }

        //GET: lecturers
        [Route]
        [HttpGet]
        public List<Lecturer> Get()
        {
            return lec;
        }

        //GET: lecturers/get_names
        [Route("get_names")]
        [HttpGet]
        public List<string> GetNames() 
        {
            List<string> output = new List<string>();
            foreach(var p in lec)
            {
                output.Add(p.lecturer_name);
            }
            return output;
        }

        //GET: lecturers/5
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var lecturer = lec.FirstOrDefault((l) => l.lecturer_id == id);
            if (lecturer == null)
            {
                return BadRequest("Not found");
            }
            return Ok(lecturer);
        }


        // POST: lecturers
        [Route]
        [HttpPost]
        public IHttpActionResult Post(Lecturer value)
        {
            if (value == null)
            {
                return BadRequest("invalid data");
            }

            lec.Add(value);
            
            return Ok("done"); 
        }

      
        // DELETE: lecturers/5
        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var member = lec.FirstOrDefault(l => l.lecturer_id == id);
            if (member == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Staff with Id = " + id.ToString() + " not found to delete");
            }
            else
            {
                lec.Remove(member);
                return Request.CreateResponse(HttpStatusCode.OK, "Deteted");
            }
        }
    }
}
