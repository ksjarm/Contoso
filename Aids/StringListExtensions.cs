namespace Contoso.Aids;
public static class StringListExtensions {
    public static void RemoveAll(this List<string> l, params string[] tags) {
        foreach (string tag in tags) l.RemoveAll(x => x.StartsWith(tag));
    }
}