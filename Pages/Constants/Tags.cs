namespace Contoso.Pages.Constants;
public static class Tags {
	public static string BoldTitleStart => "<dt class=\"col-sm-2\">";
	public static string TitleStart => "<dd class=\"col-sm-2\">";
	public static string BoldTitleEnd => "</dt>";
	public static string DataStart => "<dd class=\"col-sm-10\">";
	public static string DataEnd => "</dd>";
	public static string TitleEnd => DataEnd;
	public static string TextDanger => "text-danger";
	public static string GroupStart => "<div class=\"form-group\">";
	public static string GroupEnd => DataEnd;
	public static string FormControl => "form-control";
}
