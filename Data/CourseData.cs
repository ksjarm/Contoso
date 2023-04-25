using Contoso.Data.Base;

namespace Contoso.Data;
public sealed class CourseData : NamedData{
    public int Number { get; set; }
    public int Credits { get; set; }
    public int DepartmentID { get; set; }
}
