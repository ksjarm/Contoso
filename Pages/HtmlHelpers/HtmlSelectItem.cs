using Contoso.Aids;
using Contoso.Pages.Constants;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Contoso.Pages.HtmlHelpers;
public static class HtmlSelectItem {
    public static IHtmlContent SelectItem<TModel, TValue>(this IHtmlHelper<TModel> h,
        Expression<Func<TModel, TValue>> value, IEnumerable<SelectListItem> items) {
        
        var s = htmlStrings(h, value, items, value);
        return new HtmlContentBuilder(s);
    }
    public static IHtmlContent SelectItem<TModel, TValue>(this IHtmlHelper<TModel> h,
        Expression<Func<TModel, TValue>> value, string controller) {

        var s = htmlStrings(h, value, controller, value);
        return new HtmlContentBuilder(s);
    }
    public static IHtmlContent SelectItem<TModel, TValue, TLabel>(this IHtmlHelper<TModel> h,
        Expression<Func<TModel, TValue>> value, IEnumerable<SelectListItem> items, Expression<Func<TModel, TLabel>> label) {

        var s = htmlStrings(h, value, items, label);
        return new HtmlContentBuilder(s);
    }
    internal static List<object> htmlStrings<TModel, TValue, TLabel>(IHtmlHelper<TModel> h,
        Expression<Func<TModel, TValue>> value, IEnumerable<SelectListItem> items, Expression<Func<TModel, TLabel>> label)
            => new() {
                new HtmlString(Tags.BoldTitleStart),
                h.DisplayNameFor(label),
                new HtmlString(Tags.BoldTitleEnd),
                new HtmlString(Tags.DataStart),
                h.DropDownListFor(value, items, new { @class = Tags.FormControl } ),
                h.ValidationMessageFor(value, string.Empty, new { @class = Tags.TextDanger }),
                new HtmlString(Tags.DataEnd),
            };
    internal static List<object> htmlStrings<TModel, TValue, TLabel>(IHtmlHelper<TModel> h,
        Expression<Func<TModel, TValue>> value, string controller, Expression<Func<TModel, TLabel>> label)
            => new() {
                new HtmlString(Tags.BoldTitleStart),
                h.DisplayNameFor(label),
                new HtmlString(Tags.BoldTitleEnd),
                new HtmlString(Tags.DataStart),
                new HtmlString($"<select name=\"{getName(value)}\" " +
                                        $"class=\"selectItems2 {Tags.FormControl}\" " +
                                        $"data-controller=\"{controller}\" " +
                                        $"data-id=\"{getValue(h, value)}\">" +
                               $"</select>"),
                h.ValidationMessageFor(value, string.Empty, new { @class = Tags.TextDanger }),
                new HtmlString(Tags.DataEnd),
            };
    private static TValue getValue<TModel, TValue>(IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e) {
        var o = h.ViewData.Model;
        if (o is null) return default;
        var c = e.Compile();
        return c(o);
    }
    private static string getName<TModel, TValue>(Expression<Func<TModel, TValue>> e) => GetMember.Name(e);
}