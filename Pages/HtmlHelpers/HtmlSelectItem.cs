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
    public static IHtmlContent SelectItem<TModel, TValue, TLabel>(this IHtmlHelper<TModel> h,
        Expression<Func<TModel, TValue>> value, IEnumerable<SelectListItem> items,
        Expression<Func<TModel, TLabel>> label) {
        var s = htmlStrings(h, value, items, label);
        return new HtmlContentBuilder(s);
    }
    internal static List<object> htmlStrings<TModel, TValue, TLabel>(IHtmlHelper<TModel> h,
         Expression<Func<TModel, TValue>> value, IEnumerable<SelectListItem> items,
         Expression<Func<TModel, TLabel>> label)
    {
        var l = new List<object>();
        l.Add(new HtmlString(Tags.TitleStart));
        l.Add(h.DisplayNameFor(label));
        l.Add(new HtmlString(Tags.TitleEnd));
        l.Add(new HtmlString(Tags.DataStart));
        l.Add(h.DropDownListFor(value, items, new { @class = Tags.FormControl }));
        l.Add(h.ValidationMessageFor(value, string.Empty, new { @class = Tags.TextDanger }));
        l.Add(new HtmlString(Tags.DataEnd));
        return l;
    }
}
