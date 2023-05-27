namespace Contoso.Facade.Common;
public class ErrorView {
    public string RequestID { get; set; }
    public bool ShowRequestID => !string.IsNullOrEmpty(RequestID);
}