using Contoso.Data;
using Contoso.Infra;

namespace Contoso.Soft.Data;
internal static class InitCourses {
    private static SchoolContext db;
    internal static int cntCourses = 300;
    internal static int cntCredits = 5;
    private static Dictionary<string, int> courseIDs;
    private static Action<int, Func<int, string, CourseData>> add;
    internal static List<CourseData> courses {
        get {
            var l = new List<CourseData> {
                 course(1050, "Chemistry",  3, "Engineering"),
                 course(4022, "Microeconomics", 3,"Economics"),
                 course(4041, "Macroeconomics", 3,"Economics"),
                 course(1045, "Calculus", 4, "Mathematics"),
                 course(3141, "Trigonometry", 4, "Mathematics"),
                 course(2021, "Composition", 3,"English"),
                 course(2042, "Literature", 4,"English")
            };
            add(cntCourses, course);
            return l;
        }
    }
    internal static void init(SchoolContext c, Action<int, Func<int, string, CourseData>> a) {
        db = c;
        courseIDs = new Dictionary<string, int>();
        add = a;
    }
    internal static CourseData course(int idx, string year)
        => course(5000 + idx, $"Course{idx}", (idx % cntCredits) + 1, $"Department{idx % InitDepartments.cntDepartments}");
    internal static CourseData course(int number, string name, int credits, string department) {
        var id = InitDepartments.departmentId(department);
        return db.Courses.Any(x => x.Number == number)
            ? null
            : new() { Number = number, Name = name, Credits = credits, DepartmentID = id };
    }
    internal static int courseId(string key) {
        if (courseIDs.TryGetValue(key, out int value)) return value;
        var id = db.Courses.Single(i => i.Name == key).ID;
        courseIDs.Add(key, id);
        return id;
    }
}