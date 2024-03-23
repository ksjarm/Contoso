using Contoso.Pages.Constants;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Contoso.Pages.HtmlHelpers;
public static class HtmlViewImage {
	public static IHtmlContent ViewImage<TModel, TValue>(this IHtmlHelper<TModel> h,
		Expression<Func<TModel, TValue>> value, int height) {
		var s = htmlStrings(h, value, height);
		return new HtmlContentBuilder(s);
	}
	public static IHtmlContent ViewImage<TModel, TValue>(this IHtmlHelper<TModel> h,
		Expression<Func<TModel, TValue>> value, int height, string label) {
		var s = htmlStrings(h, value, height, label);
		return new HtmlContentBuilder(s);
	}
	internal static List<object> htmlStrings<TModel, TValue>
        (IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> value, int height)
        => new() {
            new HtmlString(Tags.BoldTitleStart),
            h.DisplayNameFor(value),
            new HtmlString(Tags.BoldTitleEnd),
            new HtmlString(Tags.DataStart),
            getImage(h, value, height),
            new HtmlString(Tags.DataEnd),
        };
    internal static List<object> htmlStrings<TModel, TValue>
        (IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> value,
        int height, string label)
        => new() {
            new HtmlString(Tags.BoldTitleStart),
            h.Raw(label),
            new HtmlString(Tags.BoldTitleEnd),
            new HtmlString(Tags.DataStart),
            getImage(h, value, height),
            new HtmlString(Tags.DataEnd),
        };
    private static HtmlString getImage<TModel, TResult>(IHtmlHelper<TModel> h,
        Expression<Func<TModel, TResult>> e, int height) {
        var value = h.ValueFor(e) ?? "";
        return new HtmlString(img(value, height));
    }
    private static string img(string value, int height)
        => $"<img id=\"imgView\" src=\"{value}\" style=\"height: {height}px; ; object-fit:cover\"/>";
}
