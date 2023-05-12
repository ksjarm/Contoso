using Contoso.Data;
using Contoso.Infra;

namespace Contoso.Soft.Data;
internal static class InitOfficeAssignments {
    private static SchoolContext db;
    internal static int cntOfficeAssignments = InitInstructors.cntInstructors;
    internal static int cntOffices = 200;
    internal static List<OfficeAssignmentData> officeAssignments {
        get {
            var l = new List<OfficeAssignmentData> {
                officeAssignment ("Fakhouri", "Smith 17"),
                officeAssignment( "Harui", "Gowan 27"),
                officeAssignment("Kapoor", "Thompson 304")
            };
            InitSchool.add(cntOfficeAssignments, officeAssignment);
            return l;
        }
    }
    internal static OfficeAssignmentData officeAssignment(int idx, string year)
        => officeAssignment($"LastName{idx}", $"Office {idx % cntOffices}");
    internal static OfficeAssignmentData officeAssignment(string instructor, string location) {
        var id = InitInstructors.instructorId(instructor);
        return InitSchool.db.OfficeAssignments.Any(x => x.InstructorID == id)
            ? null
            : new() { InstructorID = id, Location = location };
    }
}