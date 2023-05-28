using Contoso.Data.Base;

namespace Contoso.Data;
public sealed class CourseData : NamedData{
    public int Credits { get; set; }
    public int DepartmentID { get; set; }
    public int Number { get; set; }
}