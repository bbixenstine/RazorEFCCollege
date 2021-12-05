using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorCollege.Models;

namespace RazorCollege.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has already been seeded
            }
            // CAN GENERATE ARRAYS HERE, OR CAN GENERATE ARRAY OR LIST IN SEPARATE STATIC METHODS
            /*var students = new Student[]
            {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01")}
            };

            context.Students.AddRange(students);*/
            context.AddRange(StudentSeeds());
            context.SaveChanges();

            /*var courses = new Course[]
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3},
                new Course{CourseID=4022,Title="Microeconomics",Credits=3},
                new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
                new Course{CourseID=1045,Title="Calculus",Credits=4},
                new Course{CourseID=3141,Title="Trigonometry",Credits=4},
                new Course{CourseID=2021,Title="Composition",Credits=3},
                new Course{CourseID=2042,Title="Literature",Credits=4}
            };

            context.Courses.AddRange(courses);*/
            context.AddRange(CourseSeeds());
            context.SaveChanges();

            /*var enrollments = new Enrollment[]
            {
                //new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                //new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
                //new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=8,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=8,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=8,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
                new Enrollment{StudentID=6,CourseID=1045},
                new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };

            context.Enrollments.AddRange(enrollments);*/
            context.AddRange(EnrollmentSeeds());
            context.SaveChanges();
        }
        // could have used public static Student[] StudentSeeds() with var students = new Students[]
        public static List<Student> StudentSeeds() 
	    {
            var students = new List<Student>
            {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01")}
            };
            return students;
        }
        public static List<Course> CourseSeeds()
	    {
            var courses = new List<Course>
            {
                new Course{CourseID=1,CourseNo=1050,Title="Introduction to Chemistry",Credits=3,CourseYear=2017,CourseSemester=Semester.Fall},
                new Course{CourseID=2,CourseNo=1050,Title="Introduction to Chemistry",Credits=3,CourseYear=2019,CourseSemester=Semester.Fall},
                new Course{CourseID=3,CourseNo=4022,Title="Microeconomics",Credits=3,CourseYear=2021,CourseSemester=Semester.Spring},
                new Course{CourseID=4,CourseNo=4041,Title="Macroeconomics",Credits=3,CourseYear=2021,CourseSemester=Semester.Fall},
                new Course{CourseID=5,CourseNo=1045,Title="Calculus 1",Credits=4,CourseYear=2017,CourseSemester=Semester.Fall},
                new Course{CourseID=6,CourseNo=1045,Title="Calculus 1",Credits=4,CourseYear=2019,CourseSemester=Semester.Fall},
                new Course{CourseID=7,CourseNo=3141,Title="Trigonometry 1",Credits=3,CourseYear=2019,CourseSemester=Semester.Fall},
                new Course{CourseID=8,CourseNo=2021,Title="Advanced Composition",Credits=3,CourseYear=2019,CourseSemester=Semester.Fall},
                new Course{CourseID=9,CourseNo=2042,Title="American Literature",Credits=4,CourseYear=2019,CourseSemester=Semester.Fall},
                new Course{CourseID=10,CourseNo=1050,Title="Introduction to Chemistry",Credits=3,CourseYear=2021,CourseSemester=Semester.Fall}
                /*new Course{CourseNo=1050,Title="Introduction to Chemistry",Credits=3,CourseYear=2017,CourseSemester=Semester.Fall},
                new Course{CourseNo=1050,Title="Introduction to Chemistry",Credits=3,CourseYear=2019,CourseSemester=Semester.Fall},
                new Course{CourseNo=4022,Title="Microeconomics",Credits=3,CourseYear=2021,CourseSemester=Semester.Spring},
                new Course{CourseNo=4041,Title="Macroeconomics",Credits=3,CourseYear=2021,CourseSemester=Semester.Fall},
                new Course{CourseNo=1045,Title="Calculus 1",Credits=4,CourseYear=2017,CourseSemester=Semester.Fall},
                new Course{CourseNo=1045,Title="Calculus 1",Credits=4,CourseYear=2019,CourseSemester=Semester.Fall},
                new Course{CourseNo=3141,Title="Trigonometry 1",Credits=3,CourseYear=2019,CourseSemester=Semester.Fall},
                new Course{CourseNo=2021,Title="Advanced Composition",Credits=3,CourseYear=2019,CourseSemester=Semester.Fall},
                new Course{CourseNo=2042,Title="American Literature",Credits=4,CourseYear=2019,CourseSemester=Semester.Fall},
                new Course{CourseNo=1050,Title="Introduction to Chemistry",Credits=3,CourseYear=2021,CourseSemester=Semester.Fall}*/
            };
            return courses;
        }
        public static List<Enrollment> EnrollmentSeeds()
	    {
            var enrollments = new List<Enrollment>
            {
                /*new Enrollment{StudentID=1,CourseID=1,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=2,Grade=Grade.C},
                new Enrollment{StudentID=1,CourseID=3,Grade=Grade.B},
                new Enrollment{StudentID=8,CourseID=1,Grade=Grade.A},
                new Enrollment{StudentID=8,CourseID=2,Grade=Grade.C},
                new Enrollment{StudentID=8,CourseID=3},
                new Enrollment{StudentID=2,CourseID=5,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=6,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=7,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=9},
                new Enrollment{StudentID=4,CourseID=9},
                new Enrollment{StudentID=4,CourseID=2,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=3},
                new Enrollment{StudentID=6,CourseID=5,Grade=Grade.A},
                new Enrollment{StudentID=7,CourseID=6,Grade=Grade.A}*/
                new Enrollment{StudentID=1,CourseID=2,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=3,Grade=Grade.C},
                new Enrollment{StudentID=1,CourseID=4},
                new Enrollment{StudentID=8,CourseID=2,Grade=Grade.A},
                new Enrollment{StudentID=8,CourseID=3,Grade=Grade.C},
                new Enrollment{StudentID=8,CourseID=4},
                new Enrollment{StudentID=2,CourseID=6,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=7,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=8,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=10},
                new Enrollment{StudentID=4,CourseID=10},
                new Enrollment{StudentID=4,CourseID=3,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=4},
                new Enrollment{StudentID=6,CourseID=6,Grade=Grade.A},
                new Enrollment{StudentID=7,CourseID=7,Grade=Grade.A}
            };
            return enrollments;
        }
    }
}