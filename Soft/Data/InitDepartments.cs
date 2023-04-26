using Contoso.Domain;
using Contoso.Infra;

namespace Contoso.Soft.Data;
internal static class InitDepartments {
    private static SchoolContext db;
    internal static int cntDepartments = 50;
    internal static int cntDepartmentMembers = InitInstructors.cntInstructors / cntDepartments;
    private static Dictionary<string, int> departmentIDs;
    private static Action<int, Func<int, string, Department>> add;
    internal static List<Department> departments {
        get {
            var l = new List<Department> {
                department("English", 350000, "2007-09-01", "Abercrombie"),
                department( "Mathematics", 100000, "2007-09-01", "Fakhouri"),
                department( "Engineering", 350000, "2007-09-01", "Harui"),
                department("Economics", 100000,"2007-09-01", "Kapoor")
            };
            add(cntDepartments, department);
            return l;
        }
    }
    internal static void init(SchoolContext c, Action<int, Func<int, string, Department>> a) {
        db = c;
        departmentIDs = new Dictionary<string, int>();
        add = a;
    }
    internal static Department department(int idx, string year) =>
          department($"Department{idx}", (idx + 1) * 2000, $"{year}-09-01",
              $"LastName{idx * cntDepartmentMembers}");
    internal static Department department(string name, decimal budget, string date, string instructor)
        => db.Departments.Any(x => x.Name == name)
        ? null
        : new() { Name = name, Budget = budget, StartDate = DateTime.Parse(date),
            InstructorID = InitInstructors.instructorId(instructor) };
    internal static int departmentId(string key) {
        if (departmentIDs.TryGetValue(key, out int value)) return value;
        var id = db.Departments.Single(i => i.Name == key).ID;
        departmentIDs.Add(key, id);
        return id;
    }
}