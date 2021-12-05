using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCollege.Models
{
    public enum Grade
    {
        Ap=13, Bp=10, Cp=7, Dp=4, Fp=1,
        A=12, B=9, C=6, D=3, F=0,
        Am=11, Bm=8, Cm=5, Dm=2
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}