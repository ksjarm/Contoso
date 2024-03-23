using Contoso.Data;

namespace Contoso.Soft.Data;
internal static class InitRelationships {
    internal static int cntRelationships = 1000;
    internal static List<RelationshipData> relationships {
        get {
            var l = new List<RelationshipData> {
                relationship("Alexander", "Alexander"),
                relationship("Alonso", "Alonso"),
                relationship("Anand", "Anand"),
                relationship("Barzdukas", "Barzdukas"),
                relationship("Li", "Li"),
                relationship("Justice", "Justice"),
                relationship("Norman","Norman"),
                relationship("Olivetto", "Olivetto")
            };
            InitSchool.addYear(cntRelationships, relationship);
            return l;
        }
    }
    internal static RelationshipData relationship(int idx, string year)
        => relationship($"SLastName{idx % InitStudents.cntStudents}", 
                        $"PLastName{idx % InitParents.cntParents}");
    internal static RelationshipData relationship(string student, string parent) {
        var sId = InitStudents.studentId(student);
        var pId = InitParents.parentId(parent);
        return InitSchool.db.Relationships.Any(x => (x.StudentID == sId) && (x.ParentID == pId))
            ? null
            : new() { StudentID = sId, ParentID = pId };
    }
}