using Contoso.Facade.Base;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Facade;
public class CourseView : NamedView {
    [Display(Name = "Number")] public int Number { get; set; }
    [Display(Name = "Title")] public override string Name { get; set; }
    [Range(0, 5)] public int Credits { get; set; }
    [Display(Name = "Department")] public int DepartmentID { get; set; }
    [Display(Name = "Department")] public string DepartmentName { get; set; }
}
