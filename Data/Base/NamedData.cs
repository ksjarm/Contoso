namespace Contoso.Data.Base;
public abstract class NamedData : DescribedData {
    public string Code { get; set; }
    public string Name { get; set; }
}