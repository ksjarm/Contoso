using Contoso.Data;
using Contoso.Domain;
using Contoso.Infra;
using NuGet.Packaging;
using System.Collections;

namespace Contoso.Soft.Data;
public static class DbInitializer {
    private static SchoolContext context;
    internal static void ToDb(IEnumerable list) {
        var i = 0;
        foreach (var e in list) {
            context.Add(e);
            i++;
            if (i % 500 == 0) context.SaveChanges();
        }
        context.SaveChanges();
    }    
    public static void Initialize(SchoolContext c) {
        context = c;
        c.Database.EnsureCreated();
        if (c.Students.Any()) return;
        ToDb(students);
        ToDb(instructors);
        ToDb(departments);
        ToDb(courses);
        ToDb(officeAssignments);
        ToDb(courseInstructors);
        ToDb(enrollments);
    }
    internal static List<Student> students {
        get {
            var l = new List<Student> {
                createStudent("Carson", "Alexander", "2010-09-01"),
                createStudent("Meredith", "Alonso", "2012-09-01"),
                createStudent("Arturo", "Anand", "2013-09-01"),
                createStudent("Gytis", "Barzdukas", "2012-09-01"),
                createStudent("Yan", "Li", "2012-09-01"),
                createStudent("Peggy", "Justice", "2011-09-01"),
                createStudent("Laura", "Norman", "2013-09-01"),
                createStudent("Nino", "Olivetto", "2005-09-01")
            };
            for (var i = 0; i < 100000; i++) {
                var j = i / 500;
                var year = new DateTime(1822, 9, 1).AddYears(j).Year.ToString();
                l.Add(createStudent($"FirstName{i}", $"LastName{i}", $"{year}-09-01"));
            }
            return l;
        }
    }
    internal static List<Instructor> instructors {
        get {
            var l = new List<Instructor> {
                createInstructor("Kim", "Abercrombie", "1995-03-11"),
                createInstructor("Fadi", "Fakhouri", "2002-07-06"),
                createInstructor("Roger", "Harui", "1998-07-01"),
                createInstructor("Candace", "Kapoor", "2001-01-15"),
                createInstructor("Roger", "Zheng", "2004-02-12")
            };
            for (var i = 0; i < 10000; i++) {
                var j = i / 50;
                var year = new DateTime(1822, 9, 1).AddYears(j).Year.ToString();
                l.Add(createInstructor($"FirstName{i}", $"LastName{i}", $"{year}-09-01"));
            }
            return l;
        }
    }
    internal static Department[] departments => new Department[] {
            createDepartment("English", 350000, "2007-09-01", "Abercrombie"),
            createDepartment("Mathematics", 100000, "2007-09-01", "Fakhouri"),
            createDepartment("Engineering", 350000, "2007-09-01", "Harui"),
            createDepartment("Economics", 100000, "2007-09-01", "Kapoor")
    };
    internal static CourseData[] courses => new CourseData[] {
            createCourse(1050, "Chemistry", 3, "Engineering"),
            createCourse(4022, "Microeconomics", 3, "Economics"),
            createCourse(4041, "Macroeconomics", 3, "Economics"),
            createCourse(1045, "Calculus", 4, "Mathematics"),
            createCourse(3141, "Trigonometry", 4, "Mathematics"),
            createCourse(2021, "Composition", 3, "English"),
            createCourse(2042, "Literature", 4, "English")
    };
    internal static OfficeAssignment[] officeAssignments => new OfficeAssignment[] {
            createOfficeAssignment("Fakhouri", "Smith 17"),
            createOfficeAssignment("Harui", "Gowan 27"),
            createOfficeAssignment("Kapoor", "Thompson 304")
    };
    internal static CourseAssignment[] courseInstructors => new CourseAssignment[] {
            createCourseAssignment("Chemistry", "Kapoor"),
            createCourseAssignment("Chemistry", "Harui"),
            createCourseAssignment("Microeconomics", "Zheng"),
            createCourseAssignment("Macroeconomics", "Zheng"),
            createCourseAssignment("Calculus", "Fakhouri"),
            createCourseAssignment("Trigonometry", "Harui"),
            createCourseAssignment("Composition", "Abercrombie"),
            createCourseAssignment("Literature", "Abercrombie")
    };
    internal static Enrollment[] enrollments => new Enrollment[] {
            createEnrollment("Alexander", "Chemistry", Grade.A),
            createEnrollment("Alexander", "Microeconomics", Grade.C),
            createEnrollment("Alexander", "Macroeconomics", Grade.B),
            createEnrollment("Alonso", "Calculus", Grade.B),
            createEnrollment("Alonso", "Trigonometry", Grade.B),
            createEnrollment("Alonso", "Composition", Grade.B),
            createEnrollment("Anand", "Chemistry"),
            createEnrollment("Anand", "Microeconomics", Grade.B),
            createEnrollment("Barzdukas", "Chemistry", Grade.B),
            createEnrollment("Li", "Composition", Grade.B),
            createEnrollment("Justice", "Literature", Grade.B)
     };
    internal static Student createStudent(string firstName, string name, string enrollment)
        => new() { FirstName = firstName, Name = name, EnrollmentDate = DateTime.Parse(enrollment) };
    internal static Instructor createInstructor(string firstName, string name, string hireDate)
        => new() { FirstName = firstName, Name = name, HireDate = DateTime.Parse(hireDate) };
    internal static Department createDepartment(string name, decimal budget, string startDate, string instructor)
        => new() { Name = name, Budget = budget, StartDate = DateTime.Parse(startDate), 
                   InstructorID = context.Instructors.Single(i => i.Name == instructor).ID };
    internal static CourseData createCourse(int number, string name, int credits, string department)
        => new() { Number = number, Name = name, Credits = credits, 
                   DepartmentID = context.Departments.Single(s => s.Name == department).ID };
    internal static OfficeAssignment createOfficeAssignment(string instructor, string location)
        => new() { InstructorID = context.Instructors.Single(i => i.Name == instructor).ID, Location = location};
    internal static CourseAssignment createCourseAssignment(string course, string instructor)
        => new() { CourseID = context.Courses.Single(c => c.Name == course).ID,
                   InstructorID = context.Instructors.Single(i => i.Name == instructor).ID };
    internal static Enrollment createEnrollment(string student, string course, Grade? g = null)
        => new() { StudentID = context.Students.Single(s => s.Name == student).ID,
                   CourseID = context.Courses.Single(c => c.Name == course).ID, Grade = g};
}
