using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // required for DatabaseGenerated
using System.Linq;
using System.Threading.Tasks;

namespace RazorCollege.Models
{
    public enum Semester
    {
        Spring, Fall
    }
    public class Course
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        // if you want a course to have a distinctive year and semester, so that the same course
        // is taught in many semesters, then cannot use the CourseNo as the primary key
        public int CourseID { get; set; }
        [Display(Name = "Course Number")]
        [Range(1, 9999)]
        public int CourseNo { get; set; }
        // this is the only field that is not inherently required
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
        [Range(1, 5)]
        public int Credits { get; set; }
        [Display(Name = "Year")]
        [Range(2000, 9999)]
        public int CourseYear { get; set; } 
        [Display(Name = "Semester")]
        public Semester CourseSemester { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}