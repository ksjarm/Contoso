using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Contoso.Pages.HtmlHelpers;
public static class HtmlTableHeader {
    public static IHtmlContent TableHeader<TModel>(
        this IHtmlHelper<TModel> h, string? name, string? sortOrder, string? page) {
        var s = htmlStrings(name, sortOrder, page);
        return new HtmlContentBuilder(s);
    }
    private static List<object> htmlStrings(string? name, string? sortOrder, string? page) {
        name ??= "Unspecified";
        var l = new List<object> {
            new HtmlString($"<a href=\"/{page}/Index?"),
            new HtmlString($"sortOrder={getSortOrder(name, sortOrder)}\">"),
            new HtmlString($"{name}</a>")
        };
        return l;
    }
    private static string getSortOrder(string? name, string? sortOrder) {
        if (name is null) return string.Empty;
        if (sortOrder is null) return name;
        if (!sortOrder.StartsWith(name)) return name;
        if (sortOrder.EndsWith("_desc")) return name;
        return name + "_desc";
    }
}