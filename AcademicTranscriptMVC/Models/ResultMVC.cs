using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcademicTranscriptMVC.Models
{
    public class ResultMVC
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Nullable<int> CourseLevel { get; set; }
        [Required]
        public string Credit { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        public Nullable<int> Year { get; set; }
    }
}