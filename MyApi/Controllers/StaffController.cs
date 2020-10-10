using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Controllers

{

    [RoutePrefix("staff")]

    public class StaffController : ApiController
    {
        

        List<Staff> staff = new List<Staff>();

        public StaffController()
        {
            staff.Add(new Staff { staff_id=001, staff_name="Sumith", staff_address= "No:34, xxxxx, xxxx", staff_moblie=0712365356, department="Examination"});
            staff.Add(new Staff { staff_id = 002, staff_name = "Nimal", staff_address = "No:23, xxxxx, xxxx", staff_moblie = 0712367656, department = "Examination" });
            staff.Add(new Staff { staff_id = 003, staff_name = "Amal", staff_address = "No:101, xxxxx, xxxx", staff_moblie = 0713345356, department = "Finabcial" });
            staff.Add(new Staff { staff_id = 004, staff_name = "Nipuni", staff_address = "No:56, xxxxx, xxxx", staff_moblie = 0712365356, department = "SOB" });
        }
       

        //GET: staff
        [Route]
        [HttpGet]
        public IEnumerable<Staff> Get()
        {
            return staff;
        }

        //GET: staff/get_names
        [Route("get_names")]
        [HttpGet]
        public List<string> GetNames()
        {
            List<string> output = new List<string>();
            foreach (var p in staff)
            {
                output.Add(p.staff_name);
            }
            return output;
        }

       
        //GET: staff/5
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var member = staff.FirstOrDefault((s) => s.staff_id == id);
            if (member == null)
            {
                return BadRequest("Not found");
            }
            return Ok(member);
        }



        // POST: staff
        [Route]
        [HttpPost]
        public IHttpActionResult Post(Staff value)
        {
            if (value == null)
            {
                return BadRequest("invalid data");
            }

            staff.Add(value);
            return Ok("done");
        }


        // DELETE: Staff/5
        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var member = staff.FirstOrDefault(e => e.staff_id == id);
            if (member == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Staff with Id = " + id.ToString() + " not found to delete");
            }
            else
            {
                staff.Remove(member);
                return Request.CreateResponse(HttpStatusCode.OK,"Deleted");
            }
        }
    }
}
