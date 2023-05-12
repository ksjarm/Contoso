using Contoso.Aids;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Contoso.Pages.HtmlHelpers;
public static class HtmlTableHeader {
    public static IHtmlContent TableHeader<TModel>(this IHtmlHelper<IEnumerable<TModel>> _,
        string name, string sortOrder, string page) {
        var s = htmlStrings(name, sortOrder, page);
        return new HtmlContentBuilder(s);
    }
    public static IHtmlContent TableHeader<TModel>(this IHtmlHelper<IEnumerable<TModel>> _,
        Expression<Func<TModel, dynamic>> value, string sortOrder, string page) {
        var s = htmlStrings(value, sortOrder, page);
        return new HtmlContentBuilder(s);
    }
    private static List<object> htmlStrings<TModel>(
        Expression<Func<TModel, dynamic>> value, string sortOrder, string page) {
        var name = GetMember.Name(value) ?? "Unspecified";
        var label = GetMember.Label(value) ?? name;
        var l = new List<object> {
            new HtmlString($"<a href=\"/{page}/Index?"),
            new HtmlString($"sortOrder={getSortOrder(name, sortOrder)}\">"),
            new HtmlString($"{label}</a>")
        };
        return l;
    }
    private static List<object> htmlStrings(string name, string sortOrder, string page) {
        name ??= "Unspecified";
        var l = new List<object> {
            new HtmlString($"<a href=\"/{page}/Index?"),
            new HtmlString($"sortOrder={getSortOrder(name, sortOrder)}\">"),
            new HtmlString($"{name}</a>")
        };
        return l;
    }
    private static string getSortOrder(string name, string sortOrder) {
        if (name is null) return string.Empty;
        if (sortOrder is null) return name;
        if (!sortOrder.StartsWith(name)) return name;
        if (sortOrder.EndsWith("_desc")) return name;
        return name + "_desc";
    }
}