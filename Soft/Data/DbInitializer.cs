using Contoso.Domain;
using Contoso.Infra;

namespace Contoso.Soft.Data
{
	public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstMidName = "Carson",   Name = "Alexander",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Meredith", Name = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Arturo",   Name = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gytis",    Name = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Yan",      Name = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Peggy",    Name = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Laura",    Name = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Nino",     Name = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Kim",     Name = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Fadi",    Name = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Roger",   Name = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Candace", Name = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Roger",   Name = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.Name == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.Name == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.Name == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.Name == "Kapoor").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {ID = 1050, Name = "Chemistry",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").ID
                },
                new Course {ID = 4022, Name = "Microeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").ID
                },
                new Course {ID = 4041, Name = "Macroeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").ID
                },
                new Course {ID = 1045, Name = "Calculus",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").ID
                },
                new Course {ID = 3141, Name = "Trigonometry",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").ID
                },
                new Course {ID = 2021, Name = "Composition",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").ID
                },
                new Course {ID = 2042, Name = "Literature",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "English").ID
                },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.Name == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.Name == "Harui").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.Name == "Kapoor").ID,
                    Location = "Thompson 304" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Name == "Chemistry" ).ID,
                    InstructorID = instructors.Single(i => i.Name == "Kapoor").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Name == "Chemistry" ).ID,
                    InstructorID = instructors.Single(i => i.Name == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Name == "Microeconomics" ).ID,
                    InstructorID = instructors.Single(i => i.Name == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Name == "Macroeconomics" ).ID,
                    InstructorID = instructors.Single(i => i.Name == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Name == "Calculus" ).ID,
                    InstructorID = instructors.Single(i => i.Name == "Fakhouri").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Name == "Trigonometry" ).ID,
                    InstructorID = instructors.Single(i => i.Name == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Name == "Composition" ).ID,
                    InstructorID = instructors.Single(i => i.Name == "Abercrombie").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Name == "Literature" ).ID,
                    InstructorID = instructors.Single(i => i.Name == "Abercrombie").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.Name == "Alexander").ID,
                    CourseID = courses.Single(c => c.Name == "Chemistry" ).ID,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.Name == "Alexander").ID,
                    CourseID = courses.Single(c => c.Name == "Microeconomics" ).ID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Name == "Alexander").ID,
                    CourseID = courses.Single(c => c.Name == "Macroeconomics" ).ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.Name == "Alonso").ID,
                    CourseID = courses.Single(c => c.Name == "Calculus" ).ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.Name == "Alonso").ID,
                    CourseID = courses.Single(c => c.Name == "Trigonometry" ).ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Name == "Alonso").ID,
                    CourseID = courses.Single(c => c.Name == "Composition" ).ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Name == "Anand").ID,
                    CourseID = courses.Single(c => c.Name == "Chemistry" ).ID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Name == "Anand").ID,
                    CourseID = courses.Single(c => c.Name == "Microeconomics").ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Name == "Barzdukas").ID,
                    CourseID = courses.Single(c => c.Name == "Chemistry").ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Name == "Li").ID,
                    CourseID = courses.Single(c => c.Name == "Composition").ID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.Name == "Justice").ID,
                    CourseID = courses.Single(c => c.Name == "Literature").ID,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.ID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
