using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public class Lecturer
    {
        public int lecturer_id { get; set; } = 0;
        public string lecturer_name { get; set; } = "";
        public int lecturer_mobile { get; set; } = 0;
        public string lecturer_address { get; set; } = "";
        public string department { get; set; } = "";

        
    }
}