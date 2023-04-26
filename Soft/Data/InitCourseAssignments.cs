using Contoso.Domain;
using Contoso.Infra;

namespace Contoso.Soft.Data;
internal static class InitCourseAssignments {
    private static SchoolContext db;
    internal static int cntCourceAssignments = 3 * InitInstructors.cntInstructors;
    internal static List<CourseAssignment> courseAssignments {
        get {
            var l = new List<CourseAssignment> {
                courseAssignment("Chemistry" ,"Kapoor"),
                courseAssignment("Chemistry", "Harui"),
                courseAssignment("Microeconomics", "Zheng"),
                courseAssignment("Macroeconomics", "Zheng"),
                courseAssignment("Calculus", "Fakhouri"),
                courseAssignment("Trigonometry", "Harui"),
                courseAssignment("Composition","Abercrombie"),
                courseAssignment("Literature", "Abercrombie")
            };
            InitSchool.add(cntCourceAssignments, courseAssignment);
            return l;
        }
    }
    internal static CourseAssignment courseAssignment(int idx, string year)
        => courseAssignment($"Course{idx % InitCourses.cntCourses}", $"LastName{idx % InitInstructors.cntInstructors}");
    internal static CourseAssignment courseAssignment(string course, string instructor) {
        var iId = InitInstructors.instructorId(instructor);
        var cId = InitCourses.courseId(course);
        return InitSchool.db.CourseAssignments.Any(x => (x.InstructorID == iId) && (x.CourseID == cId))
            ? null
            : new() { CourseID = cId, InstructorID = iId };
    }
}