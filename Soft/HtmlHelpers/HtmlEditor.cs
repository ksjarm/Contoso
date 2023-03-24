using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Contoso.Soft.HtmlHelpers
{
	public static class HtmlEditor
	{
		public static IHtmlContent MyEditorFor<TModel, TResult>
				(this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
		{
			var s = htmlStrings(h, e);
			return new HtmlContentBuilder(s);
		}

		internal static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h,
			Expression<Func<TModel, TResult>> e) => new() {
			new HtmlString("<dt class=\"col-sm-2\">"),
			h.LabelFor(e),
			new HtmlString("/dt>"),
			new HtmlString("<dt class=\"col-sm-10\">"),
			h.EditorFor(e),
			h.ValidationMessageFor(e, "", new { @class = "text-danger"}),
			new HtmlString("/dt>")
			};
	}
}