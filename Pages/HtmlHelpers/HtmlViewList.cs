using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using Contoso.Pages.Constants;

namespace Contoso.Pages.HtmlHelpers;
public static class HtmlViewList
{
    public static IHtmlContent ViewList<TModel> (
        this IHtmlHelper<IEnumerable<TModel>> h, IEnumerable<TModel> items, 
              Dictionary<string, Expression<Func<TModel, dynamic>>> columns, 
              Func<TModel,dynamic> getId) {
        var s = htmlStrings(h, items, columns, getId);
        return new HtmlContentBuilder(s);
    }
    internal static List<object> htmlStrings<TModel>(
        IHtmlHelper<IEnumerable<TModel>> h, IEnumerable<TModel> items, 
        Dictionary<string, Expression<Func<TModel, dynamic>>> columns,
        Func<TModel, dynamic> getId) {
        List<object> list = new (){ new HtmlString("<table class=\"table\"> <thead> <tr>") };
        foreach (var c in columns) {
            list.Add(new HtmlString("<td>"));
            list.Add(h.TableHeader(c.Key, getSortOrder(h), getPage(h)));
            list.Add(new HtmlString("</td>"));
        }
        list.Add(new HtmlString("<td></td> </tr> </thead>"));
        list.Add(new HtmlString("<tbody>"));
        foreach (var i in items) {
            list.Add(new HtmlString("<tr>"));
            foreach (var c in columns)
            {
                list.Add(new HtmlString("<td>"));
                list.Add(h.Raw(c.Value.Compile().Invoke(i)));
                list.Add(new HtmlString("</td>"));
            }
            list.Add(new HtmlString("<td>"));

            var id = getId(i);
            list.Add(h.ActionLink(Actions.Edit, Texts.Edit, new { Id = id }));
            list.Add(new HtmlString($" | "));
            list.Add(h.ActionLink(Actions.Details, Texts.Details, new { Id = id }));
            list.Add(new HtmlString($" | "));
            list.Add(h.ActionLink(Actions.Delete, Texts.Delete, new { Id = id }));

            list.Add(new HtmlString("</td>"));

            list.Add(new HtmlString("</tr>"));
        }

        list.Add(new HtmlString("</tbody> </table>"));
        return list;
    }

    private static string? getSortOrder<TModel>(IHtmlHelper<IEnumerable<TModel>> h)
        => h.ViewData[Constants.Data.SortOrder]?.ToString();
    private static string? getPage<TModel>(IHtmlHelper<IEnumerable<TModel>> h)
        => h.ViewData[Constants.Data.Page]?.ToString();
}
