using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademicTranscriptMVC.Models
{
    public class ResultMVC
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public Nullable<int> CourseLevel { get; set; }
        public string Credit { get; set; }
        public string Grade { get; set; }
        public Nullable<int> Year { get; set; }
    }
}