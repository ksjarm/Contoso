using Contoso.Facade.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Facade;
public sealed class CourseView : NamedView {
    [DisplayName("Title")] public override string Name { get; set; }
    [DisplayName("Number")] public int Number { get; set; }
    [Range(0, 5)][DisplayName("Credits")] public int Credits { get; set; }
    [DisplayName("Department")] public int DepartmentID { get; set; }
    [DisplayName("Department")] public string DepartmentName { get; set; }
}
