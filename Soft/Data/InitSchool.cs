using Contoso.Aids;
using Contoso.Infra;
using System.Collections;

namespace Contoso.Soft.Data;
public static class InitSchool {
    internal static SchoolContext db;
    public static void Initialize(IHost host) {
        using var s = host.Services.CreateScope();
        var p = s.ServiceProvider;
        var c = p.GetRequiredService<SchoolContext>();
        Initialize(c);
    }
    public static void Initialize(SchoolContext c) {
        init(c);
        Safe.Run(() => toDb(InitStudents.students));
        Safe.Run(() => toDb(InitParents.parents));
        Safe.Run(() => toDb(InitInstructors.instructors));
        Safe.Run(() => toDb(InitDepartments.departments));
        Safe.Run(() => toDb(InitCourses.courses));
        Safe.Run(() => toDb(InitOfficeAssignments.officeAssignments));
        Safe.Run(() => toDb(InitCourseAssignments.courseAssignments));
        Safe.Run(() => toDb(InitRelationships.relationships));
        Safe.Run(() => toDb(InitEnrollments.enrollments));
    }
    internal static void init(SchoolContext c) {
        db = c;
        c.Database.EnsureCreated();
        InitStudents.init(c, addYear);
        InitParents.init(c, addPhoneNr);
        InitCourses.init(c, addYear);
        InitInstructors.init(c, addYear);
        InitDepartments.init(c, addYear);
    }
    internal static void toDb(IEnumerable list) {
        var i = 0;
        foreach (var e in list) {
            if (e is null) continue;
            db.Add(e);
            i++;
            if (i % 500 == 0) db.SaveChanges();
        }
        db.SaveChanges();
    }
    internal static void addYear<T>(int count, Func<int, string, T> item) {
        var yearStart = 2005;
        var opYears = DateTime.Now.Year - yearStart;
        var cntYear = count / opYears;
        for (var i = 0; i < count; i++) {
            var j = i / cntYear;
            var year = new DateTime(yearStart, 9, 1).AddYears(j).Year.ToString();
            var x = item(i, year);
            if (x is null) continue;
            db.Add(x);
            if (i % 500 == 0) db.SaveChanges();
        }
        db.SaveChanges();
    }
    internal static void addPhoneNr<T>(int count, Func<int, string, T> item) {
        Random random = new Random();
        var numberStart = 5000000;
        var numberRange = 10000000 - numberStart;
        for (var i = 0; i < count; i++) {
            var randomNumber = "5" + random.Next(1000000, 10000000).ToString();
            var x = item(i, randomNumber);
            if (x is null) continue;
            db.Add(x);
            if (i % 500 == 0) db.SaveChanges();
        }
        db.SaveChanges();
    }
}