using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public class Student
    {
        public int student_id { get; set; } = 0;

        public string student_name { get; set; } = "";
        
        public int student_moblie { get; set; } = 0;

        public int age { get; set; } = 0;
        
        public string student_address { get; set; } = "";

        public string department { get; set; } = "";

        public string course { get; set; } = "";


    }
}