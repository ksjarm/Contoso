using Contoso.Data;
using Contoso.Infra;

namespace Contoso.Soft.Data;
public static class InitStudents {
    private static SchoolContext db;
    internal static int cntStudents = 10000;
    private static Dictionary<string, int> studentIDs;
    private static Action<int, Func<int, string, StudentData>> add; 
    internal static List<StudentData> students {
        get {
            var l = new List<StudentData> {
                student("Carson", "Alexander", "2010-09-01"),
                student("Meredith", "Alonso", "2012-09-01"),
                student("Arturo", "Anand", "2013-09-01"),
                student("Gytis", "Barzdukas", "2012-09-01"),
                student("Yan", "Li", "2012-09-01"),
                student("Peggy", "Justice", "2011-09-01"),
                student("Laura", "Norman", "2013-09-01"),
                student("Nino", "Olivetto", "2005-09-01")
            };
            add(cntStudents, student);
            return l;
        }
    }
    internal static void init(SchoolContext c, Action<int, Func<int, string, StudentData>> a) {
        db = c;
        studentIDs = new Dictionary<string, int>();
        add = a;
    }
    internal static StudentData student(int idx, string year) 
        => student($"FirstName{idx}", $"LastName{idx}", $"{year}-09-01");
    internal static StudentData student(string firstName, string name, string enrollment) 
        => db.Students.Any(x => x.Name == name)
        ? null
        : new() { FirstName = firstName, Name = name, EnrollmentDate = DateTime.Parse(enrollment) };
    internal static int studentId(string key) {
        if (studentIDs.TryGetValue(key, out int value)) return value;
        var id = db.Students.Single(i => i.Name == key).ID;
        studentIDs.Add(key, id);
        return id;
    }
}