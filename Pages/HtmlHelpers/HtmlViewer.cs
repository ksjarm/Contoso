using Contoso.Pages.Constants;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Contoso.Pages.HtmlHelpers;
public static class HtmlViewer {
	public static IHtmlContent ViewerFor<TModel, TResult>
		(this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) {
		var s = htmlStrings(h, e);
		return new HtmlContentBuilder(s);
	}
	internal static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h,
		Expression<Func<TModel, TResult>> e) => new() {
			new HtmlString(HtmlConstants.BoldTitleStart),
			h.DisplayNameFor(e),
			new HtmlString(HtmlConstants.BoldTitleEnd),
			new HtmlString(HtmlConstants.DataStart),
			h.DisplayFor(e),
			new HtmlString(HtmlConstants.DataEnd),
		};
}
