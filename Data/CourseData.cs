using Contoso.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Contoso.Data;
public sealed class CourseData : NamedData{
    public int Number { get; set; }
    public int Credits { get; set; }
    public int DepartmentID { get; set; }
}
