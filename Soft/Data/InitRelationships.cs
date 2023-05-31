using Contoso.Data;

namespace Contoso.Soft.Data;
internal static class InitRelationships {
    internal static int cntRelationships = InitStudents.cntStudents;
    internal static List<RelationshipData> relationships {
        get {
            var l = new List<RelationshipData> {
                relationship("Carson Alexander", "Sophia Alexander"),
                relationship("Meredith Alonso", "Ethan Alonso"),
                relationship("Arturo Anand", "Ava Anand"),
                relationship("Gytis Barzdukas", "Noah Barzdukas"),
                relationship("Yan Li", "Isabella Li"),
                relationship("Peggy Justice", "Liam Justice"),
                relationship("Laura Norman","Mia Norman"),
                relationship("Nino Olivetto", "Lucas Olivetto")
            };
            InitSchool.addYear(cntRelationships, relationship);
            return l;
        }
    }
    internal static RelationshipData relationship(int idx, string year)
        => relationship($"SFirstName{idx % InitStudents.cntStudents} SLastName{idx % InitStudents.cntStudents}", 
                        $"PFirstName{idx % InitParents.cntParents} PLastName{idx % InitParents.cntParents}");
    internal static RelationshipData relationship(string student, string parent) {
        var sId = InitStudents.studentId(student);
        var pId = InitParents.parentId(parent);
        return InitSchool.db.Relationships.Any(x => (x.StudentID == sId) && (x.ParentID == pId))
            ? null
            : new() { StudentID = sId, ParentID = pId };
    }
}