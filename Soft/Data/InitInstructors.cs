using Contoso.Aids;
using Contoso.Data;
using Contoso.Infra;

namespace Contoso.Soft.Data;
internal static class InitInstructors {
    private static SchoolContext db;
    internal static int cntInstructors = 1000;
    private static Dictionary<string, int> instructorIDs;
    private static Action<int, Func<int, string, InstructorData>> add;
    internal static List<InstructorData> instructors {
        get {
            var l = new List<InstructorData> {
                 instructor("Kim", "Abercrombie","1995-03-11", IsoGender.Female),
                 instructor("Fadi", "Fakhouri","2002-07-06", IsoGender.Male),
                 instructor("Roger", "Harui", "1998-07-01", IsoGender.Male),
                 instructor("Candace", "Kapoor", "2001-01-15", IsoGender.Female),
                 instructor("Roger", "Zheng","2004-02-12", IsoGender.Male)
            };
            add(cntInstructors, instructor);
            return l;
        }
    }
    internal static void init(SchoolContext c, Action<int, Func<int, string, InstructorData>> a) {
        db = c;
        instructorIDs = new Dictionary<string, int>();
        add = a;
    }
    internal static InstructorData instructor(int idx, string year)
        => instructor($"FirstName{idx}", $"LastName{idx}", $"{year}-09-01", EnumHelper.GetRandomValue<IsoGender>());
    internal static InstructorData instructor(string firstName, string name, string date, IsoGender gender)
        => db.Instructors.Any(x => (x.Name == name) && (x.FirstName == firstName))
        ? null
        : new() { FirstName = firstName, Name = name, HireDate = DateTime.Parse(date), Gender = gender };
    internal static int instructorId(string key) {
        if (instructorIDs.TryGetValue(key, out int value)) return value;
        var id = db.Instructors.Single(i => i.Name == key).ID;
        instructorIDs.Add(key, id);
        return id;
    }
}