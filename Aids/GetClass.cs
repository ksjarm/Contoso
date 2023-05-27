using System.Reflection;

namespace Contoso.Aids;
public static class GetClass {
    public static List<string> DeclaredMemberNames(Type t) 
        => t.GetMembers(BindingFlags.DeclaredOnly
                | BindingFlags.Public
                | BindingFlags.Instance
                | BindingFlags.Static)
            .Select(x => x.Name)
            .ToList();
}