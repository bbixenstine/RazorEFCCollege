using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCollege.Models
{
    public class StudentVM
    {
        public int ID { get; set; }
        // Requires that the first character be an uppercase letter.
        //Allows special characters and numbers in subsequent spaces
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(60)]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        // this is required without having to say so
        public DateTime EnrollmentDate { get; set; }
    }
}