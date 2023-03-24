using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Contoso.Soft.HtmlHelpers;
	public static class HtmlViewer {
		public static IHtmlContent ViewerFor<TModel, TResult>
			(this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) {
			var s = htmlStrings(h, e);
			return new HtmlContentBuilder(s);
		}

	private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, 
		Expression<Func<TModel, TResult>> e) => new () {
			new HtmlString("<dt class=\"col-sm-2\">"),
			h.DisplayNameFor(e),
			new HtmlString("/dt>"),
			new HtmlString("<dt class=\"col-sm-10\">"),
			h.DisplayFor(e),
			new HtmlString("/dt>")
		};
}
