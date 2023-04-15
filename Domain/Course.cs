using Contoso.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain;
public class Course : NamedEntity {
    [Display(Name = "Number")] public int Number { get; set; }
    [Display(Name = "Title")] public override string Name { get; set; }
    [Range(0, 5)] public int Credits { get; set; }
    public int DepartmentID { get; set; }
    public Department? Department { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; }
    public ICollection<CourseAssignment>? CourseAssignments { get; set; }
}
