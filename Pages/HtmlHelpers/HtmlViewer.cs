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

	private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, 
		Expression<Func<TModel, TResult>> e) => new () {
			new HtmlString((HtmlConstants.TitleEnd),
			h.DisplayNameFor(e),
			new HtmlString((HtmlConstants.TitleEnd),
			new HtmlString("<dt class=\"col-sm-10\">"),
			h.DisplayFor(e),
			new HtmlString("/dt>")
		};
}
