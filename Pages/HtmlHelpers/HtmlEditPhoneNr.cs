using Contoso.Pages.Constants;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Contoso.Pages.HtmlHelpers;
public static class HtmlEditPhoneNr {
    public static IHtmlContent EditPhoneNr<TModel, TValue>
            (this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> value) {

        var s = htmlStrings(h, value, value);
        return new HtmlContentBuilder(s);
    }
    internal static List<object> htmlStrings<TModel, TValue, TLabel>(IHtmlHelper<TModel> h,
        Expression<Func<TModel, TValue>> value, Expression<Func<TModel, TLabel>> label) => new() {
                new HtmlString(Tags.BoldTitleStart),
                h.DisplayNameFor(label),
                new HtmlString(Tags.BoldTitleEnd),
                new HtmlString(Tags.DataStart),
                HtmlHelperEditorExtensions.EditorFor(h, value,
                    new { htmlAttributes = new { @class = Tags.FormControl } }),
                h.ValidationMessageFor(value, string.Empty, new { @class = Tags.TextDanger }),
                new HtmlString(Tags.DataEnd),
        };
}