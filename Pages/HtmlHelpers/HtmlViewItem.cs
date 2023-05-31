using Contoso.Pages.Constants;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Contoso.Pages.HtmlHelpers;
public static class HtmlViewItem {
    public static IHtmlContent ViewItem<TModel, TValue>
        (this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> value) {
        
        var s = htmlStrings(h, value, value);
        return new HtmlContentBuilder(s);
    }
    public static IHtmlContent ViewItem<TModel, TValue, TLabel>
        (this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> value, Expression<Func<TModel, TLabel>> label) {
        
        var s = htmlStrings(h, value, label);
        return new HtmlContentBuilder(s);
    }

    internal static List<object> htmlStrings<TModel, TValue, TLabel>
        (IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> value, Expression<Func<TModel, TLabel>> label) => new() {
            new HtmlString(Tags.TitleStart),
            h.DisplayNameFor(label),
            new HtmlString(Tags.TitleEnd),
            new HtmlString(Tags.DataStart),
            h.DisplayFor(value),
            new HtmlString(Tags.DataEnd),
        };
}
