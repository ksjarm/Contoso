using Contoso.Data;

namespace Contoso.Soft.Data;
internal static class InitEnrollments {
    internal static int cntEnrollments = 10 * InitStudents.cntStudents;
    internal static List<EnrollmentData> enrollments {
        get {
            var l = new List<EnrollmentData> {
                enrollment("Alexander", "Chemistry" , Grade.A),
                enrollment("Alexander", "Microeconomics", Grade.C),
                enrollment("Alexander", "Macroeconomics", Grade.B),
                enrollment("Alonso","Calculus", Grade.B),
                enrollment("Alonso", "Trigonometry", Grade.B),
                enrollment("Alonso","Composition",Grade.B),
                enrollment("Anand","Chemistry"),
                enrollment("Anand", "Microeconomics", Grade.B),
                enrollment("Barzdukas","Chemistry", Grade.B),
                enrollment("Li", "Composition", Grade.B),
                enrollment("Justice", "Literature",Grade.B)
            };
            InitSchool.addYear(cntEnrollments, enrollment);
            return l;
        }
    }
    internal static EnrollmentData enrollment(int idx, string year)
        => enrollment($"SLastName{idx % InitStudents.cntStudents}", $"Course{idx % InitCourses.cntCourses}", grade(idx, year));
    internal static EnrollmentData enrollment(string student, string course, Grade? g = null) {
        var sId = InitStudents.studentId(student);
        var cId = InitCourses.courseId(course);
        return InitSchool.db.Enrollments.Any(x => (x.StudentID == sId) && (x.CourseID == cId))
            ? null
            : new() { StudentID = sId, CourseID = cId, Grade = g };
    }
    internal static Grade? grade(int idx, string year) =>
        (int.Parse(year) > 2021) ? null : (idx % 5 == 0) ? Grade.A : (idx % 3 == 0) ? Grade.C : Grade.B;
}