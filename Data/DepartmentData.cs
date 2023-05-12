using Contoso.Data.Base;

namespace Contoso.Data;
public sealed class DepartmentData : NamedData {
    public decimal Budget { get; set; }
    public int? InstructorID { get; set; }
    public DateTime StartDate { get; set; }
}