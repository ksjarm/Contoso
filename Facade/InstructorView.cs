using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Contoso.Data;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class InstructorView : PersonView {
    [DataType(DataType.Date)] [DisplayName("Hire Date")] public DateTime HireDate { get; set; }
    [DisplayName("Office")] public string Office { get; set; }
    [DisplayName("Courses")] public IEnumerable<CourseView> Courses { get; set; }
}