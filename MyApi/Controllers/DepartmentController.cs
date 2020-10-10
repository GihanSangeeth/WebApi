using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Controllers
{
    [RoutePrefix("departments")]
    public class DepartmentController : ApiController
    {

        List<Departments> dep = new List<Departments>();

        

        public DepartmentController()
        {
           
            dep.Add(new Departments { department_id = "L01" , department_name = "SOB"});
            dep.Add(new Departments { department_id = "L02", department_name = "SOC" });
            dep.Add(new Departments { department_id = "L03", department_name = "SOE" });
            dep.Add(new Departments { department_id = "A01", department_name = "Examination" });
            dep.Add(new Departments { department_id = "A02", department_name = "Financial" });

        }

        // GET : departments
        [Route]
        [HttpGet]
        public List<Departments> Get()
        {
            return dep;
        }

        
    }
}
