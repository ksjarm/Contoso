using Contoso.Aids;
using Contoso.Data;
using Contoso.Infra;
using Contoso.Pages.Constants;

namespace Contoso.Soft.Data;
public static class InitParents {
    private static SchoolContext db;
    internal static int cntParents = 700;
    private static Dictionary<string, int> parentIDs;
    private static Action<int, Func<int, string, ParentData>> add;
    internal static List<ParentData> parents {
        get {
            var l = new List<ParentData> {
                parent("Sophia", "Alexander", 58947384, IsoGender.Female),
                parent("Ethan", "Alonso", 59384726, IsoGender.Male),
                parent("Ava", "Anand", 55637894, IsoGender.Female),
                parent("Noah", "Barzdukas",52534566, IsoGender.Female),
                parent("Isabella", "Li", 57558690, IsoGender.Female),
                parent("Liam", "Justice", 5463748, IsoGender.Male),
                parent("Mia", "Norman", 50068034, IsoGender.Female),
                parent("Lucas", "Olivetto", 55886739, IsoGender.Male)
            };
            add(cntParents, parent);
            return l;
        }
    }
    internal static void init(SchoolContext c, Action<int, Func<int, string, ParentData>> a) {
        db = c;
        parentIDs = new Dictionary<string, int>();
        add = a;
    }
    internal static ParentData parent(int idx, string phoneNr)
        => parent($"PFirstName{idx}", $"PLastName{idx}", int.Parse(phoneNr), GetRandom.Enum<IsoGender>());
    internal static ParentData parent(string firstName, string name, int phoneNr, IsoGender gender)
        => db.Parents.Any(x => x.Name == name)
        ? null
        : new() { FirstName = firstName, Name = name, PhoneNr = phoneNr, Gender = gender };
    internal static int parentId(string key) {
        if (parentIDs.TryGetValue(key, out int value)) return value;
        var id = db.Parents.Single(i => i.Name == key).ID;
        parentIDs.Add(key, id);
        return id;
    }
}