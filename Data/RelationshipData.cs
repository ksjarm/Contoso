using Contoso.Data.Base;

namespace Contoso.Data;
public sealed class RelationshipData : DescribedData {
    public int StudentID { get; set; }
    public int ParentID { get; set; }
}