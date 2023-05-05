using Contoso.Data.Base;

namespace Contoso.Data;
public class DepartmentData : NamedData {
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }

    //[Timestamp] public byte[]? RowVersion { get; set; }
    public int? InstructorID { get; set; }
}