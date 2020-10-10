using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public class Staff
    {
        public int staff_id { get; set; } = 0;

        public string staff_name { get; set; } = "";
        
        public int staff_moblie { get; set; } = 0;
        
        public string staff_address { get; set; } = "";
        
        public string department { get; set; } = "";
    }
}